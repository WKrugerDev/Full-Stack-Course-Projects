var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var blogs = new List<Blog>
{
    new Blog { Title = "First Post", Body = "This is the body of the first post." },
    new Blog { Title = "Second Post", Body = "This is the body of the second post." }
};

app.MapGet("/", () => "Welcome to the Blog API Root!");

app.MapGet("/blogs", () => blogs);

app.MapGet("/blogs/{index}", (int index) =>
{
   if (index < 0 || index >= blogs.Count)
   {
       return Results.NotFound(new { Message = "Blog not found." });
   }
   else
   {
   return Results.Ok(blogs[index]);
   }
});

app.MapPost("/blogs", (Blog newBlog) =>
{
    blogs.Add(newBlog);
    return Results.Created($"/blogs/{blogs.Count - 1}", newBlog);
});

app.MapDelete("/blogs/{index}", (int index) =>
{
   if (index < 0 || index >= blogs.Count)
   {
       return Results.NotFound(new { Message = "Blog not found." });
   }
   else
   {
    //var blog = blogs[index];
    blogs.RemoveAt(index);
    return Results.NoContent();
   }
});

app.MapPut("/blogs/{index}", (int index, Blog updatedBlog) =>
{
   if (index < 0 || index >= blogs.Count)
   {
       return Results.NotFound(new { Message = "Blog not found." });
   }
   else
   {
    blogs[index] = updatedBlog;
    return Results.Ok(updatedBlog);
   }
});

app.Run();

public class Blog
{
    public required string Title { get; set; }
    public required string Body { get; set; }
}