var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/users/{userID}/posts/{slug}", (int userID, string slug) => {
    return $"User ID: {userID}, Post Slug: {slug}";
});

app.MapGet("products/{id:int:min(0)}", (int id) => {
    return $"Product ID: {id}";
});

app.MapGet("/report/{year?}", (int? year = 2016) => {
    return $"Report for year: {year}";
});

app.MapGet("/files/{*filePath}", (string filePath) => {
    return filePath;
});

app.MapGet("/search", (string? q, int page = 1) => {
    return $"Search {q} on Page {page}";
});

app.Run();
