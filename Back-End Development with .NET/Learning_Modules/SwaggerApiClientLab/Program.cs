using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using CustomNamespace;
using Microsoft.AspNetCore.Http.HttpResults;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        var app = builder.Build();
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        });
        app.MapControllers();
        await app.RunAsync();

        var httpClient = new HttpClient();
        var client = new CustomApiClient("http://localhost:5000", httpClient);

        var user = await client.UserAsync(1);
        Console.WriteLine($"User ID: {user.Id}, User Name: {user.Name}");

        // await Task.Delay(TimeSpan.FromSeconds(3)); // Wait for the server to start

        // await new ClientGenerator().GenerateClient();
    }   
}
