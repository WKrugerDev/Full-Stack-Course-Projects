var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpLogging((logging) => {});

var app = builder.Build();

app.Use(async(context, next) =>
{
    Console.WriteLine("Logic Before - Custom Middleware Executing");
    await next.Invoke();
    Console.WriteLine("Logic After - Custom Middleware Executed");
});
app.UseHttpLogging();

app.MapGet("/", () => "Hello World!");
app.MapGet("/test", () => "This is a test endpoint.");

app.Run();

