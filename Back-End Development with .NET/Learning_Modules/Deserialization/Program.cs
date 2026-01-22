using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/", () => "I am root!");

app.MapPost("/auto", (Person personFromClient) => {
    return TypedResults.Ok(personFromClient);
});

app.MapPost("/json", async (HttpContext context) => {
    var personFromClient = await context.Request.ReadFromJsonAsync<Person>();
    return TypedResults.Json(personFromClient);
});

app.MapPost("/custom-options", async (HttpContext context) => {
    var options = new JsonSerializerOptions
    {
        UnmappedMemberHandling = JsonUnmappedMemberHandling.Disallow
    };

    var personFromClient = await context.Request.ReadFromJsonAsync<Person>(options);
    return TypedResults.Json(personFromClient);
});

app.MapPost("/xml", async (HttpContext context) => {
    var reader = new StreamReader(context.Request.Body);
    var body = await reader.ReadToEndAsync();

    var xmlSerializer = new XmlSerializer(typeof(Person));
    using var stringReader = new StringReader(body);
    
    var personFromClient = (Person)xmlSerializer.Deserialize(stringReader)!;
    return TypedResults.Ok(personFromClient);
});

app.Run();

public class Person
{
    required public string UserName { get; set; }
    public int? UserAge { get; set; }
}