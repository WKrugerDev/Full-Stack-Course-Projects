# SwaggerApiClientLab

A hands-on **ASP.NET Core lab project** demonstrating **manual Swagger setup**, **controller-based APIs**, and **client generation using OpenAPI** — without relying on the default Web API template.

This project focuses on understanding **how Swagger is wired manually**, **how controllers expose OpenAPI metadata**, and **how a generated client consumes the API**.

---

## 🚀 Features

- Controller-based API using ASP.NET Core MVC
- Manual Swagger / OpenAPI configuration
- Endpoint for retrieving a `User` resource
- OpenAPI client generation using **NSwag**
- Generated strongly-typed API client
- Demonstrates **self-hosted API + client consumption**

---

## 🧱 Tech Stack

- .NET 8  
- ASP.NET Core (Controllers)  
- Swagger / OpenAPI  
- NSwag & NJsonSchema  

---

## ✅ Key Details

- **Manual Swagger Configuration**
  - Swagger services and middleware added explicitly
  - Swagger UI configured with a custom endpoint
  - No Web API template used — setup is intentional and educational
- **Controller-Based API**
  - `UserController` exposes REST endpoints using MVC
  - `[ApiController]` and routing attributes used
  - JSON response formatting specified explicitly
- **OpenAPI Client Generation**
  - `ClientGenerator` fetches Swagger JSON at runtime
  - Generates a strongly-typed client (`GeneratedApiClient.cs`)
  - Client code placed in a separate generated folder
- **Client Consumption**
  - Generated client (`CustomApiClient`) is used to call the API
  - Demonstrates typed access to API responses
  - No manual JSON parsing required

---

## 🧠 Key Learning Points

- How to **manually configure Swagger** in ASP.NET Core
- Differences between:
  - Minimal APIs
  - Controller-based APIs
- How OpenAPI metadata is produced from controllers
- How **NSwag** generates C# client code from Swagger
- How to:
  - Host an API
  - Consume it using a generated client
- Why generated clients improve:
  - Type safety
  - Maintainability
  - Developer productivity

---

## 📌 Notes

- Swagger is enabled unconditionally for learning purposes
- API is hosted locally on `http://localhost:5000`
- `GeneratedApiClient.cs` is **auto-generated** and not intended for manual editing
- Project was created from a **console-style setup**, not the Web API template
- Hosting, routing, and Swagger setup are intentionally explicit

In real-world applications:

- Swagger should be restricted or secured in production
- API and client responsibilities should be split into separate projects
- Client generation should be automated via:
  - Build steps
  - CI pipelines
- Error handling, retries, and logging should be added

---

## 💡 Future Improvements

- Separate API host and client into distinct projects
- Automate client generation during build
- Add more endpoints and models
- Introduce authentication and authorization
- Improve error handling in the generated client
- Add versioning to the API and Swagger documents
