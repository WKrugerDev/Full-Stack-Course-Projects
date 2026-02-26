using Microsoft.AspNetCore.SignalR;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(policy =>   
    policy.AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader());

app.MapGet("/products", () =>
    {
        var Products = new List<Product>
        {
           new Product {Id = 1, Name = "Laptop", Price = 499.99m},
           new Product {Id = 2, Name = "Phone", Price = 199.99m},
           new Product {Id = 3, Name = "Bicycle", Price = 249.99m}
        };
        return Products;
    });

app.Run();

public class Product
{
    public int Id {get; set; }
    public string Name {get; set; } = string.Empty;
    public decimal Price {get; set;}
}
