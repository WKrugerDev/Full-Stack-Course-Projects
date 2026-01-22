using System.Text.Json.Nodes;
using Newtonsoft.Json;

public class Person 
{
    public string FirstName { get; set; }
    public string LastName { get; set; } 

    [JsonConstructor] // Tells Newtonsoft to use this constructor
    public Person(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public override string ToString()
    {
        return $"{FirstName} {LastName}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        
        string JsonString = @"{
            ""FirstName"": ""John"",
            ""LastName"": ""Doe""
        }";
        Person person = JsonConvert.DeserializeObject<Person>(JsonString);  
        Console.WriteLine($"First Name: {person.FirstName}, Last Name: {person.LastName}");

    Person newPerson = new Person
    (
        "Jane",
        "Smith"
    );
    string newJson = JsonConvert.SerializeObject(newPerson);
    Console.WriteLine($"Serialized JSON:\n{newJson}");
    }  
}

