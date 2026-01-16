using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using SafeVault.Data;
using SafeVault.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Entity Framework
builder.Services.AddDbContext<SafeVaultContext>(options =>
    options.UseInMemoryDatabase("SafeVaultDb"));

// Add custom services
builder.Services.AddScoped<AuthenticationService>();
builder.Services.AddScoped<UserService>();

// Add JWT Authentication
var jwtKey = builder.Configuration["Jwt:Key"] ?? "DefaultSecretKey123456789012345678901234567890";
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtKey)),
            ValidateIssuer = false,
            ValidateAudience = false,
            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services.AddAuthorization();

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();

// Serve static files
app.UseStaticFiles();

// Map controllers
app.MapControllers();

// Serve the HTML form
app.MapGet("/", () => Results.Redirect("/webform.html"));

// Initialize database
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<SafeVaultContext>();
    context.Database.EnsureCreated();
    
    // Seed admin user if not exists
    if (!context.Users.Any(u => u.Username == "admin"))
    {
        var adminUser = new SafeVault.Models.User
        {
            Username = "admin",
            Email = "admin@safevault.com",
            PasswordHash = BCrypt.Net.BCrypt.HashPassword("admin123"),
            Role = "Admin"
        };
        context.Users.Add(adminUser);
        context.SaveChanges();
    }
}

app.Run();