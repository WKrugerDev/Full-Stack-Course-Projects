var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/downloads", () => "Downloads Page");
app.MapPut("/", () => "PUT Request Received");

app.Run();
