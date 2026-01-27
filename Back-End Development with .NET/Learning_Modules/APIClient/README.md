# APIClient

A minimal **.NET 8 console project** demonstrating **consuming a RESTful API** using a **generated Swagger/OpenAPI client**.

This project focuses on understanding **HTTP requests from a client perspective**, **interacting with endpoints**, and **automating client code generation** with NSwag.

---

## 🚀 Features

- Consumes a REST API hosted locally (`http://localhost:5161`)
- Supports **CRUD operations** on `Blog` resources:
  - Retrieve all blogs
  - Create a new blog
  - Delete a blog by ID
- Demonstrates **Swagger client generation** using NSwag
- Minimal console interface for quick testing
- Optional integration with the **IntegratingSwagger** project

---

## 🧱 Tech Stack

- .NET 8  
- C# Console Application  
- Swagger/OpenAPI  
- NSwag for client code generation  

---

## ✅ Key Details

- **API Consumption**
  - Uses `HttpClient` to send HTTP requests
  - Supports `GET`, `POST`, and `DELETE` requests to the `/blogs` endpoint
  - Deserializes JSON responses into `Blog` objects
- **Swagger Client Generation**
  - `SwaggerClientGenerator` fetches the Swagger JSON from the API
  - Generates a strongly-typed client class (`BlogApiClient.cs`)
  - Enables type-safe API calls without manually writing HTTP requests
- **Console Output**
  - Displays blog `Title` and `Content`
  - Provides feedback if no blogs are found

---

## 🧠 Key Learning Points

- How to **consume a REST API** using a typed client
- How `HttpClient` interacts with endpoints
- Using **NSwag** to generate client code automatically
- How to **serialize and deserialize JSON** for request and response handling
- Understanding **asynchronous operations** with `async/await`
- How generated client code can simplify **CRUD operations** in C#

---

## 📌 Notes

- `BlogApiClient.cs` is **generated via `SwaggerClientGenerator`**
- The project demonstrates **local API consumption**; production usage should handle:
  - Base URL configuration
  - Error handling and retries
  - Authentication/Authorization
  - Logging and monitoring
- `IntegratingSwagger` project can be combined to run both the API server and client locally
- The console app is minimal for learning purposes and **does not include UI**

---

## 💡 Future Improvements

- Add support for **updating existing blogs** (`PUT`)
- Integrate authentication and API keys
- Handle API errors gracefully with retries or fallback logic
- Implement unit tests for generated client methods
- Extend console interface for interactive CRUD operations
- Explore structured logging and monitoring of API calls
