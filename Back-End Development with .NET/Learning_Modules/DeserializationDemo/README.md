# DeserializationDemo

A minimal .NET console project demonstrating **serialization and deserialization** of a simple `Person` class in **Binary**, **XML**, and **JSON** formats.  

This project focuses on understanding **how data can be persisted and restored**, and includes **data integrity checks** and **error handling** for robust deserialization.

---

## 🚀 Features

- Serialization of `Person` object into:
  - Binary (`person.dat`)
  - XML (`person.xml`)
  - JSON (`person.json`)
- Deserialization from all three formats
- **Data integrity validation**:
  - Ensures required properties (`UserName`, `UserAge`) are present and valid
- **Error handling**:
  - Wraps deserialization in `try/catch` blocks to handle missing or malformed data
- Demonstrates **best practices** for clean code and maintainable deserialization workflows

---

## 🧱 Tech Stack

- .NET 8  
- System.Text.Json  
- System.Xml.Serialization  
- BinaryReader/BinaryWriter  

---

## ✅ Deserialization Details

- **Binary Deserialization**
  - Uses `FileStream` and `BinaryReader` to read object data
  - Checks that `UserName` is not empty and `UserAge` is positive
  - Wrapped in `try/catch` for runtime errors

- **XML Deserialization**
  - Uses `XmlSerializer` and `FileStream` or `StringReader` for XML input
  - Validates required fields and prints appropriate success/error messages
  - Errors such as malformed XML or missing data are caught

- **JSON Deserialization**
  - Uses `JsonSerializer.Deserialize<T>()`
  - Supports options like `WriteIndented` for readability
  - Validates required fields and catches `JsonException` or general errors

---

## 🧠 Key Learning Points

- How **serialization** stores object data in different formats
- How **deserialization** reconstructs objects from persisted data
- Importance of **data integrity verification** after deserialization
- Proper use of **error handling (`try/catch`)** to prevent application crashes
- Using **helper methods** to validate objects consistently across formats
- How Binary, XML, and JSON differ in handling object data

---

## 📌 Notes

- Instructor examples for each format were provided in isolation, sometimes without error handling or validation.  
- This project **extends the examples** by:
  - Adding **try/catch blocks** around deserialization
  - Validating **all required properties** consistently across Binary, XML, and JSON
  - Using a **helper method** for cleaner and maintainable code
- Serialization is deterministic, so validation is focused on **deserialization**, where unexpected input may occur

---

## ▶️ Running the Application

1. Open the project in Visual Studio or VS Code  
2. Run the console application  
3. Observe the console output for:
   - Successful serialization messages  
   - Deserialization success messages or errors  
4. Verify that the output shows the reconstructed `Person` object for each format
