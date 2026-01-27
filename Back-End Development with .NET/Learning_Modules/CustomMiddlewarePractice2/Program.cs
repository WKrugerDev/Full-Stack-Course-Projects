using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer(); // Swagger service
builder.Services.AddSwaggerGen(); // Swagger service
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.All;
    logging.RequestBodyLogLimit = 4096;
    logging.ResponseBodyLogLimit = 4096;
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();      // Swagger middleware
    app.UseSwaggerUI();    // Swagger UI middleware
}
app.UseHttpLogging();
app.UseAuthentication();
app.UseAuthorization();

// Custom Middleware to log request processing time and details
app.Use(async (context, next) =>
{
    var stopwatch = Stopwatch.StartNew();
    await next();
    stopwatch.Stop();
    Console.WriteLine($"Request processing time: {stopwatch.Elapsed} ms");
});

// Custom Middleware to log request and response details
app.Use(async (context, next) =>
{
    var requestPath = context.Request.Path;
    Console.WriteLine($"Incoming request: {requestPath}");
    await next();
    var responseStatusCode = context.Response.StatusCode;
    Console.WriteLine($"Response status code: {responseStatusCode}");
});




app.MapGet("/", () => "Hello World!");


app.Run();


