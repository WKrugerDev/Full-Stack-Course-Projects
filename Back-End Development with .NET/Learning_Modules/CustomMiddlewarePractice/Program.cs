using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container - swagger for API documentation - comment in to use next 2 lines
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

// Sample blog list
var blogs = new List<Blog>
{
    new Blog { Title = "First Blog", Content = "This is the content of the first blog." },
    new Blog { Title = "Second Blog", Content = "This is the content of the second blog." }
};

// Configure the HTTP request pipeline - swagger for API documentation - comment in to use next 5 lines
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

// Middleware to measure request processing time
app.Use (async (context, next) =>
{
    var sw = Stopwatch.StartNew();
    await next();
    sw.Stop();

    Console.WriteLine($"Request processed in {sw.ElapsedMilliseconds} ms");
});

// Middleware to log request and response details
app.Use(async (context, next) =>
{
    // Code before next middleware / endpoint
    Console.WriteLine($"Request Path: {context.Request.Path}");
    await next(); // Call next middleware / endpoint
    // Code after
    Console.WriteLine($"Response Status: {context.Response.StatusCode}");
});

// Middleware to enforce API key authentication for non-GET requests
app.UseWhen(
    context => context.Request.Method != "GET", 
    appbuilder => appbuilder.Use(async (context, next) => {
        var extractedPassword = context.Request.Headers["X-API-KEY"].FirstOrDefault();
        if (extractedPassword == "ThisisaBadPassword")
        {
            await next(); // Call next middleware / endpoint
        }
        else
        {
            context.Response.StatusCode = 401; // Unauthorized
            await context.Response.WriteAsync("Unauthorized: Invalid or missing API key.");
        }

    })
);
// Root endpoint
app.MapGet("/", () => "Hello World!");

// GET all blogs
app.MapGet("/blogs", () => blogs);

// GET a single blog by index
app.MapGet("/blogs/{index:int}", (int index) =>
{
    if (index < 0 || index >= blogs.Count)
        return Results.NotFound("Blog not found");
    return Results.Ok(blogs[index]);
});

// POST a new blog
app.MapPost("/blogs", (Blog newBlog) =>
{
    blogs.Add(newBlog);
    return Results.Created($"/blogs/{blogs.Count - 1}", newBlog);
});

app.Run();

// Blog model
public class Blog
{
    public required string Title { get; set; }
    public required string Content { get; set; }
}
