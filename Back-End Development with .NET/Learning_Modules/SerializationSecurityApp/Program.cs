using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

public class User
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    // Generates a SHA256 hash of the serialized (encrypted) object for integrity
    public string GenerateHash()
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            // Hash the JSON representation of the object
            byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(this.ToString()));
            return Convert.ToBase64String(hashBytes);
        }
    }

    // Encrypts sensitive fields (demo: Base64 encoding)
    public void EncryptData()
    {
        Password = Convert.ToBase64String(Encoding.UTF8.GetBytes(Password));
    }

    // Serialize user with validation and encryption
    public static string SerializeUserData(User user)
    {
        if (!user.IsValid())
        {
            Console.WriteLine("Invalid data. Serialization aborted.");
            return string.Empty;
        }

        user.EncryptData();

        string serializedData = JsonSerializer.Serialize(user);
        string hash = user.GenerateHash(); // Can be stored or transmitted alongside JSON

        // For demo, print hash
        Console.WriteLine($"Generated hash: {hash}");

        return serializedData;
    }

    // Validate all required fields
    public bool IsValid()
    {
        return !string.IsNullOrWhiteSpace(Name) &&
               !string.IsNullOrWhiteSpace(Email) &&
               !string.IsNullOrWhiteSpace(Password);
    }

    // Deserialize user only if source is trusted
    public static User? DeserializeUserData(string jsonData, bool isTrustedSource)
    {
        if (!isTrustedSource)
        {
            Console.WriteLine("Untrusted source. Deserialization aborted.");
            return null;
        }

        return JsonSerializer.Deserialize<User>(jsonData);
    }

    // Override ToString to return JSON for proper hashing
    public override string ToString() => JsonSerializer.Serialize(this);
}

public class Program
{
    public static void Main()
    {
        User user = new User
        {
            Name = "John Doe",
            Email = "john.doe@example.com",
            Password = "SecurePassword123"
        };

        // Demo: show data before encryption
        Console.WriteLine($"Before encryption: Name - {user.Name}, Email - {user.Email}, Password - {user.Password}");

        // Serialize user with encryption and hash
        string serializedUser = User.SerializeUserData(user);

        Console.WriteLine("Serialized user with encrypted password:");
        Console.WriteLine(serializedUser);

        // Deserialize from trusted source
        User? deserializedUser = User.DeserializeUserData(serializedUser, true);
        if (deserializedUser != null)
        {
            Console.WriteLine("Deserialized user:");
            Console.WriteLine($"Name: {deserializedUser.Name}, Email: {deserializedUser.Email}, Password: {deserializedUser.Password}");
        }
    }
}
