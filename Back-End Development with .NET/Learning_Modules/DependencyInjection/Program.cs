var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IMyservice, MyService>();

var app = builder.Build();

app.Use(async (context, next) =>
{
    var myService = context.RequestServices.GetRequiredService<IMyservice>();
    myService.Logcreation("First middleware invoked");
    await next.Invoke();
});

app.Use(async (context, next) =>
{
    var myService = context.RequestServices.GetRequiredService<IMyservice>();
    myService.Logcreation("Second middleware invoked");
    await next.Invoke();
});

app.MapGet("/", (IMyservice myService) =>
{
    myService.Logcreation("MyService instance created");
    return Results.Ok("Check the console for the service ID log.");
});

app.Run();

public interface IMyservice 
{
    void Logcreation(string message);
}

public class MyService : IMyservice
{
    private readonly int _serviceId;

    public MyService()
    {
        _serviceId = new Random().Next(1, 1000);
    }

    public void Logcreation(string message) {
        Console.WriteLine($"{message} - Service ID: {_serviceId}");
    }
}