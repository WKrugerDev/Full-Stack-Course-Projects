# SerializationDemo

A minimal C# console project demonstrating **serialization of a simple `Person` object** into **binary, XML, and JSON formats**.

This project focuses on **understanding how to save objects in different file formats** and **basic file I/O**, rather than complex business logic.

---

## 🚀 Features

- Create a `Person` object with `UserName` and `UserAge`  
- **Binary serialization** using `FileStream` and `BinaryWriter`  
- **XML serialization** using `XmlSerializer`  
- **JSON serialization** using `System.Text.Json`  
- Confirmation messages printed after each serialization

---

## 🧱 Tech Stack

- .NET 8  
- C# console application  
- System.IO (`FileStream`, `BinaryWriter`)  
- System.Xml.Serialization (`XmlSerializer`)  
- System.Text.Json (`JsonSerializer`)  

---

## ▶️ Running the Application

- Run the project using `dotnet run`  
- Check the project folder for generated files:
  - `person.dat` → binary  
  - `person.xml` → XML  
  - `person.json` → JSON  
- Open XML or JSON files in a text editor to inspect the output

---

## 🧠 Key Learning Points

- How to **create and instantiate objects** in C#  
- How to **serialize objects to different file formats**  
- How **FileStream** and **BinaryWriter** work for binary storage  
- How **XmlSerializer** works for XML serialization  
- How **JsonSerializer** works for JSON serialization  
- Understanding the importance of **closing/disposing streams**

---

## 📌 Notes

- Focus is on **conceptual understanding**, so no advanced error handling is included  
- The project shows **manual file writing**, not reading or deserialization  
- Using statements (`using`) for streams is a **better practice**, though manual `Close()` works here