using System;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

public class Person
{
    required public string UserName { get; set; }
    required public int UserAge { get; set; }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Create a new Person object
        Person person = new Person { UserName = "Alice", UserAge = 30 };

        // -------------------------------
        // Serialize to Binary
        // -------------------------------
        using (FileStream fs = new FileStream("person.dat", FileMode.Create))
        using (BinaryWriter writer = new BinaryWriter(fs))
        {
            writer.Write(person.UserName);
            writer.Write(person.UserAge);
        }

        // -------------------------------
        // Deserialize from Binary
        // -------------------------------
        try
        {
            Person binaryDeserializedPerson;
            using (FileStream fs = new FileStream("person.dat", FileMode.Open))
            using (BinaryReader reader = new BinaryReader(fs))
            {
                binaryDeserializedPerson = new Person
                {
                    UserName = reader.ReadString(),
                    UserAge = reader.ReadInt32()
                };
            }

            ValidateDeserializedPerson(binaryDeserializedPerson, "Binary");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Binary deserialization failed: {ex.Message}");
        }

        // -------------------------------
        // Serialize to XML
        // -------------------------------
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));
        using (FileStream fs = new FileStream("person.xml", FileMode.Create))
        {
            xmlSerializer.Serialize(fs, person);
        }

        // -------------------------------
        // Deserialize from XML
        // -------------------------------
        try
        {
            Person xmlDeserializedPerson;
            using (FileStream fs = new FileStream("person.xml", FileMode.Open))
            {
                xmlDeserializedPerson = (Person)xmlSerializer.Deserialize(fs)!;
            }

            ValidateDeserializedPerson(xmlDeserializedPerson, "XML");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"XML deserialization failed: {ex.Message}");
        }

        // -------------------------------
        // Serialize to JSON
        // -------------------------------
        var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(person, jsonOptions);
        File.WriteAllText("person.json", json);

        // -------------------------------
        // Deserialize from JSON
        // -------------------------------
        try
        {
            Person jsonDeserializedPerson = JsonSerializer.Deserialize<Person>(json)!;
            ValidateDeserializedPerson(jsonDeserializedPerson, "JSON");
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"JSON deserialization failed: {ex.Message}");
        }
    }

    // -------------------------------
    // Helper Method for Validation
    // -------------------------------
    static void ValidateDeserializedPerson(Person person, string format)
    {
        if (string.IsNullOrWhiteSpace(person.UserName) || person.UserAge <= 0)
        {
            Console.WriteLine($"{format} deserialized data is invalid.");
        }
        else
        {
            Console.WriteLine($"{format} deserialization successful: Name={person.UserName}, Age={person.UserAge}");
        }
    }
}

