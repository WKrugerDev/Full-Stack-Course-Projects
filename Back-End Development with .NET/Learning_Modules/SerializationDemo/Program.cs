using System.IO;
using System.Xml.Serialization;
using System.Text.Json;
using System;
public class Person
{
    public string UserName { get; set; }
    public int UserAge { get; set; }


}

public class Program
{
    public static void Main(string[] args)
    {
        Person person = new Person { UserName = "Alice", UserAge = 30 };

    // Binary serialization
    using (FileStream fs = new FileStream("person.dat", FileMode.Create))
    using (BinaryWriter writer = new BinaryWriter(fs))
    {
        writer.Write(person.UserName);
        writer.Write(person.UserAge);
    }
    Console.WriteLine("Binary serialization completed successfully.");

    // XML serialization
    XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));
    using (FileStream xmlFs = new FileStream("person.xml", FileMode.Create))
    {
        xmlSerializer.Serialize(xmlFs, person);
    }
    Console.WriteLine("XML serialization completed successfully.");

    // JSON serialization
    string jsonString = JsonSerializer.Serialize(person);
    File.WriteAllText("person.json", jsonString);
    Console.WriteLine("JSON serialization completed successfully.");
    }
}