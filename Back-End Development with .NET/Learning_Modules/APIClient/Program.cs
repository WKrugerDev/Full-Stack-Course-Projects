using System.Collections.Concurrent; 
using BlogApi;

var httpClient = new HttpClient();
var apiBaseUrl = "http://localhost:5161";

var client = new BlogApiClient(apiBaseUrl, httpClient);

var blogs = await client.BlogsAllAsync();

if (blogs != null)
{
    foreach (var blog in blogs)
    {
        Console.WriteLine($"Title: {blog.Title}");
        Console.WriteLine($"Content: {blog.Content}");
        Console.WriteLine();
    }
} 
else
{
    Console.WriteLine("No blogs found.");
}

await client.BlogsDELETEAsync(0);

var newblog = new Blog
{
    Title = "New Blog Post",
    Content = "This is the content of the new blog post."
};

await client.BlogsPOSTAsync(newblog);

//await new SwaggerClientGenerator().GenerateClient();

//Run the application IntegratingSwagger to combine with this one - it is running on http://localhost:5161

// var httpClient = new HttpClient();
// var apiBaseUrl = "http://localhost:5161";

// var httpResults = await httpClient.GetAsync($"{apiBaseUrl}/blogs");

// if (httpResults.StatusCode != System.Net.HttpStatusCode.OK)
// {
//     Console.WriteLine("Error retrieving blogs");
//     return;
// }

// var blogStream = await httpResults.Content.ReadAsStreamAsync();

// var options = new System.Text.Json.JsonSerializerOptions
// {
//     PropertyNameCaseInsensitive = true
// };

// var blogs = await System.Text.Json.JsonSerializer.DeserializeAsync<List<Blog>>(blogStream, options);

// if (blogs != null)
// {
//     foreach (var blog in blogs)
//     {
//         Console.WriteLine($"Title: {blog.Title}");
//         Console.WriteLine($"Content: {blog.Content}");
//         Console.WriteLine();
//     }
// } 
// else
// {
//     Console.WriteLine("No blogs found.");
// }
   

// class Blog
// {
//     public string Title { get; set; }
//     public string Content { get; set; }
// }