# WebApiDeserialization

A minimal ASP.NET Core Web API project demonstrating **deserialization of client-sent data** using **JSON and XML** in a Web API context.

This project focuses on **how incoming HTTP request bodies are converted into C# objects**, and how different content types, missing fields, invalid data, and custom deserialization options affect that process.

---

## 🚀 Features

- Deserialize a `Person` object sent from a client over HTTP  
- Demonstrate **automatic model binding** using minimal APIs  
- Demonstrate **manual JSON deserialization** using `ReadFromJsonAsync`  
- Demonstrate **custom JSON deserialization options**  
- Demonstrate **manual XML deserialization** using `XmlSerializer`  
- Show how invalid or mismatched request payloads fail during deserialization  

---

## 🧱 Tech Stack

- .NET 8  
- ASP.NET Core Web API (Minimal APIs)  
- System.Text.Json  
- System.Xml.Serialization  
- VS Code REST Client (`requests.http`)  

---

## ▶️ Running the Application

1. Run the application using `dotnet run`.  
2. Use the provided `requests.http` file (or Postman) to send POST requests to the API.  
3. Inspect responses to see how different payloads succeed or fail during deserialization.

Available endpoints:

- `/auto` – automatic JSON deserialization via model binding  
- `/json` – manual JSON deserialization  
- `/custom-options` – JSON deserialization with stricter rules  
- `/xml` – manual XML deserialization  

---

## 🧠 Key Learning Points

- Difference between **automatic** and **manual** deserialization  
- How ASP.NET Core binds JSON directly to parameters  
- How `ReadFromJsonAsync` behaves with:
  - Missing properties  
  - Extra/unmapped properties  
  - Invalid data types  
- Why XML cannot be deserialized using JSON deserializers  
- How content type (`Content-Type` header) affects deserialization  
- How `required` properties enforce input validity  
- How custom JSON options (e.g. disallowing unmapped members) change behavior  

---

## 🧪 Request Scenarios Demonstrated

The `requests.http` file includes examples that demonstrate:

- Successful JSON deserialization  
- Failure when sending XML to a JSON endpoint  
- Failure when content type does not match body format  
- Missing required properties  
- Optional nullable properties  
- Extra JSON fields being ignored or rejected  
- Invalid data types causing deserialization errors  

These cases are intentional and designed to show **how and why deserialization fails**.

---

## 📌 Notes

- This project focuses on **deserialization behavior**, not persistence or databases  
- Error handling is minimal to make deserialization behavior easier to observe  
- XML deserialization is handled manually to highlight format differences  
- This project pairs conceptually with serialization examples to show both directions of data flow
