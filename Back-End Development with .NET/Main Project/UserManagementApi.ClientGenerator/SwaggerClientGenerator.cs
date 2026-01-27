using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using NSwag;
using NSwag.CodeGeneration.CSharp;

public class SwaggerClientGenerator
{
    public async Task GenerateClient()
    {
        var httpClient = new HttpClient();

        // URL of your running API's Swagger JSON
        var swaggerJson = await httpClient.GetStringAsync("http://localhost:5130/swagger/v1/swagger.json");

        // Load the document
        var document = await OpenApiDocument.FromJsonAsync(swaggerJson);

        // Settings for C# client
        var settings = new CSharpClientGeneratorSettings
        {
            ClassName = "UserManagementAPIClient",
            CSharpGeneratorSettings =
            {
                Namespace = "UserManagementAPI.Client" // separate namespace for client
            }
        };

        var generator = new CSharpClientGenerator(document, settings);

        // Generate the client code
        var code = generator.GenerateFile();

        // Write to a dedicated folder
        var outputFolder = Path.Combine(AppContext.BaseDirectory, "GeneratedClient");
        if (!Directory.Exists(outputFolder))
            Directory.CreateDirectory(outputFolder);

        var outputPath = Path.Combine(outputFolder, "UserManagementAPIClient.cs");
        await File.WriteAllTextAsync(outputPath, code);

        Console.WriteLine($"Client generated at {outputPath}");
    }
}
