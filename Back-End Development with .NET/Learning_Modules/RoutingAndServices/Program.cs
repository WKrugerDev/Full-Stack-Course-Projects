using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Register MyService with Singleton, Scoped, or Transient lifetime to see different behaviors.
// Uncomment one of the following lines to test different lifetimes:

//builder.Services.AddSingleton<IMyService, MyService>();
//builder.Services.AddScoped<IMyService, MyService>();
builder.Services.AddTransient<IMyService, MyService>();

var app = builder.Build();

// Middleware to demonstrate service instance behavior
app.Use(async (context, next) =>
{
    var myService = context.RequestServices.GetRequiredService<IMyService>();
    myService.LogCreation("First Middleware Invoked Before");
    await next();
    myService.LogCreation("First Middleware Invoked After");
});

// Another middleware to further illustrate the behavior
app.Use(async (context, next) =>
{
    var myService = context.RequestServices.GetRequiredService<IMyService>();
    myService.LogCreation("Second Middleware Invoked Before");
    await next();
    myService.LogCreation("Second Middleware Invoked After");
});

// Endpoint to demonstrate service instance behavior
app.MapGet("/", (IMyService myService) =>
{
    myService.LogCreation("Endpoint Invoked");
    return Results.Ok("Check the console for service instance logs.");
});

app.Run();

public interface IMyService
{
    public void LogCreation(string message);
}

public class MyService : IMyService
{
    private readonly int _serviceId;
    public MyService()
    {
           _serviceId = new Random().Next(100000, 999999); //Generate a random service ID
    }

    public void LogCreation(string message)
    {
        Console.WriteLine($" {message} - Service ID: {_serviceId}");
    }
}