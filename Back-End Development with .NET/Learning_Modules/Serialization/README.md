# Serialization

A minimal ASP.NET Core Web API project demonstrating **different ways to serialize a C# object (`Person`)** and return it over HTTP using **JSON and XML**.  

The project focuses on **understanding serialization in the context of web APIs**, rather than complex business logic.

---

## 🚀 Features

- Create a `Person` object with `UserName` and `UserAge`  
- Expose multiple endpoints for serialization:
  - Manual JSON serialization (`/manual-json`)  
  - Custom JSON serialization with property naming (`/custom-serializer`)  
  - Automatic JSON serialization (`/json`)  
  - Return object directly (`/auto`)  
  - Manual XML serialization (`/xml`)  
- Use `TypedResults` to return serialized data over HTTP  
- Simple root endpoint (`/`) to verify API is running

---

## 🧱 Tech Stack

- .NET 8  
- ASP.NET Core Web API  
- System.Text.Json (`JsonSerializer`)  
- System.Xml.Serialization (`XmlSerializer`)  
- Minimal APIs (`app.MapGet`)  

---

## ▶️ Running the Application

1. Start the application with `dotnet run`.  
2. Use an HTTP client (Postman, VS Code REST Client, or browser) to test endpoints:

| Endpoint | Method | Description |
|----------|--------|-------------|
| `/` | GET | Root endpoint, returns a test message |
| `/manual-json` | GET | Returns `Person` serialized manually to JSON |
| `/custom-serializer` | GET | Returns `Person` serialized to JSON with custom property naming (snake_case) |
| `/json` | GET | Returns `Person` using automatic JSON serialization (`TypedResults.Json`) |
| `/auto` | GET | Returns the `Person` object directly (automatic serialization) |
| `/xml` | GET | Returns `Person` serialized to XML manually |

3. Inspect the responses to see differences in serialization output.

---

## 🧠 Key Learning Points

- How **minimal APIs** map HTTP requests to serialization logic  
- Difference between:
  - Manual JSON serialization (`JsonSerializer.Serialize`)  
  - Automatic JSON serialization using `TypedResults.Json`  
  - Direct object return with minimal API  
- How **custom JSON options** (property naming policy) affect output  
- How to return **XML responses** manually using `XmlSerializer` and `StringWriter`  
- Using `TypedResults.Text` for custom content types

---

## 📌 Notes

- Focus is on **conceptual understanding of serialization over HTTP**, not on database or persistence  
- JSON and XML outputs can be inspected in Postman, browser, or REST client  
- The project demonstrates **basic API response handling** without full controller setup  
- Property naming policies (e.g., `snake_case`, `kebab-case`) illustrate customization options for JSON serialization