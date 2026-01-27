using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// In-memory storage
var blogs = new List<Blog>
{
    new Blog { Title = "First Post", Content = "Hello World!" },
    new Blog { Title = "Second Post", Content = "Another blog post." }
};

var app = builder.Build();

// Swagger middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Root endpoint (hidden from Swagger)
app.MapGet("/", () => "Welcome to the Blog API!")
   .ExcludeFromDescription();


// GET: all blogs
app.MapGet("/blogs", () => blogs)
   .WithOpenApi(operation =>
   {
       operation.Summary = "Get all blog posts";
       operation.Description = "Returns all blog posts stored in the in-memory list.";
       return operation;
   });


// GET: blog by index
app.MapGet("/blogs/{index}", Results<Ok<Blog>, NotFound> (int index) =>
{
    if (index < 0 || index >= blogs.Count)
        return TypedResults.NotFound();

    return TypedResults.Ok(blogs[index]);
})
.WithOpenApi(operation =>
{
    operation.Summary = "Get a single blog post";
    operation.Description = "Returns the blog post located at the specified index.";
    operation.Parameters[0].Description = "Zero-based index of the blog post.";
    return operation;
});


// POST: create blog
app.MapPost("/blogs", (Blog newPost) =>
{
    blogs.Add(newPost);
    return TypedResults.Created($"/blogs/{blogs.Count - 1}", newPost);
})
.WithOpenApi(operation =>
{
    operation.Summary = "Create a new blog post";
    operation.Description = "Adds a new blog post to the in-memory list.";
    operation.RequestBody.Description = "The blog post to create.";
    return operation;
});


// PUT: update blog
app.MapPut("/blogs/{index}", (int index, Blog updatedPost) =>
{
    if (index < 0 || index >= blogs.Count)
        return Results.NotFound();

    blogs[index].Title = updatedPost.Title;
    blogs[index].Content = updatedPost.Content;
    return Results.NoContent();
})
.WithOpenApi(operation =>
{
    operation.Summary = "Update an existing blog post";
    operation.Description = "Updates the title and content of an existing blog post.";
    operation.Parameters[0].Description = "Zero-based index of the blog post.";
    operation.RequestBody.Description = "Updated blog post data.";
    return operation;
});


// DELETE: remove blog
app.MapDelete("/blogs/{index}", (int index) =>
{
    if (index < 0 || index >= blogs.Count)
        return Results.NotFound();

    blogs.RemoveAt(index);
    return Results.NoContent();
})
.WithOpenApi(operation =>
{
    operation.Summary = "Delete a blog post";
    operation.Description = "Removes the blog post at the specified index.";
    operation.Parameters[0].Description = "Zero-based index of the blog post.";
    return operation;
});

app.Run();


// Blog class
public class Blog
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
}
