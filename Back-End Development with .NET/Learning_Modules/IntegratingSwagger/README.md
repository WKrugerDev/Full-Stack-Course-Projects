# Integrating Swagger

A minimal **ASP.NET Core Web API** project demonstrating **Swagger / OpenAPI integration** using **Minimal APIs** and **in-memory data storage**.

This project focuses on understanding **how Swagger documents endpoints**, **how metadata is added**, and how an API can be **explored and tested visually** during development.

---

## 🚀 Features

- Minimal API endpoints for a simple **Blog API**
- Full **CRUD operations**:
  - Get all blogs
  - Get a blog by index
  - Create a new blog
  - Update an existing blog
  - Delete a blog
- Swagger / OpenAPI integration for:
  - Endpoint discovery
  - Request & response visualization
  - Interactive testing
- In-memory data storage (no database required)
- Clean separation between API logic and documentation metadata

---

## 🧱 Tech Stack

- .NET 8  
- ASP.NET Core Minimal APIs  
- Swagger / OpenAPI  

---

## ✅ Key Details

- **Swagger Integration**
  - Uses `AddEndpointsApiExplorer()` and `AddSwaggerGen()`
  - Swagger UI enabled only in **development**
  - Automatically generates API documentation from Minimal API endpoints
- **OpenAPI Metadata**
  - Each endpoint uses `WithOpenApi()` to define:
    - Summary
    - Description
    - Parameter descriptions
    - Request body descriptions
- **Endpoints**
  - `/blogs` — GET all blog posts
  - `/blogs/{index}` — GET, PUT, DELETE by index
  - `/blogs` — POST new blog
- **Root Endpoint**
  - `/` returns a welcome message
  - Explicitly excluded from Swagger documentation
- **Storage**
  - Blogs stored in an in-memory `List<Blog>`
  - Data resets when the application restarts

---

## 🧠 Key Learning Points

- How **Swagger/OpenAPI** integrates with Minimal APIs
- How endpoint metadata improves API documentation
- How to:
  - Describe endpoints clearly
  - Define request and response expectations
- How Swagger UI enables **interactive API testing**
- Understanding RESTful conventions using:
  - GET
  - POST
  - PUT
  - DELETE
- Why in-memory storage is useful for **learning and prototyping**

---

## 📌 Notes

- This project is intentionally **simple and self-contained**
- No database or persistence layer is used
- Authentication and authorization are **not implemented**
- Index-based access is used for learning purposes, not production
- Swagger UI should be restricted or secured in production environments

In real-world applications:

- Data should be stored in a database
- Resources should use stable identifiers (IDs)
- Validation should be added for request payloads
- Authentication & authorization should protect endpoints
- Swagger should be:
  - Disabled in production
  - Or secured behind authentication

---

## 💡 Future Improvements

- Replace index-based access with unique IDs
- Add validation for blog input models
- Introduce persistence using a database
- Add authentication and authorization
- Secure or restrict Swagger access
- Expand OpenAPI documentation with:
  - Response examples
  - Error responses
  - Authentication requirements
