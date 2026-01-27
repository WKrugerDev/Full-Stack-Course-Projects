using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        await new SwaggerClientGenerator().GenerateClient();
        Console.WriteLine("Client generated successfully!");
    }
}
