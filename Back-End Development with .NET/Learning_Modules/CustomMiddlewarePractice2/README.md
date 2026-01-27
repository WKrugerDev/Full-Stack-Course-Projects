# CustomMiddlewarePractice2

A minimal **ASP.NET Core Web API** project demonstrating **custom middleware** and how requests flow through the **HTTP request pipeline**.

This project focuses on understanding **middleware execution order**, **request interception**, and **why some approaches are intentionally simplified for learning purposes**.

---

## 🚀 Features

- Custom middleware to:
  - Log incoming request paths
  - Log outgoing response status codes
  - Measure request processing time with high precision using `Stopwatch`
- Built-in middleware:
  - HTTP logging
  - Exception handling (developer page in development, error handler in production)
  - Authentication & Authorization middleware (stub for demonstration)
- Minimal API endpoint (`/`) for quick testing
- Optional **Swagger/OpenAPI** support for API exploration
- Demonstrates **middleware order and execution flow**

---

## 🧱 Tech Stack

- .NET 8  
- ASP.NET Core Minimal APIs  
- Swagger / OpenAPI (optional)

---

## ✅ Key Details

- **Request Timing**
  - Uses `Stopwatch.ElapsedMilliseconds` for precise measurement
  - Demonstrates how middleware executes **before and after** the endpoint
- **Request & Response Logging**
  - Logs incoming request paths
  - Logs outgoing response status codes
- **Built-in Middleware**
  - Exception handling: Developer page in dev, error handler in production
  - HTTP logging captures request/response details, headers, and body (limited to 4KB)
  - Authentication & Authorization included for demonstration, not fully implemented
- **Swagger Integration**
  - Swagger is optional and can be enabled in development for endpoint testing
- **Pipeline Flow**
  - Shows how middleware executes in order
  - Demonstrates how multiple custom middleware components interact

---

## 🧠 Key Learning Points

- How **custom middleware** is registered and executed
- How middleware can:
  - Inspect HTTP requests
  - Modify or short-circuit requests before reaching endpoints
  - Track request duration
- How `await next()` controls pipeline flow
- Why middleware **order matters**
- Integration of built-in middleware for **logging, authentication, and exception handling**
- Optional Swagger usage during development for testing endpoints

---

## 📌 Notes

- Inline middleware is used for demonstration purposes
- This approach is **intentionally simplified** to focus on:
  - Middleware flow
  - Request interception
  - Conditional execution
- Authentication is a stub, not production-ready
- Stopwatch-based timing is precise and easy to extend
- Swagger is enabled only in **development** to avoid exposing endpoints in production

In real-world applications:

- Authentication should use **ASP.NET Core Authentication & Authorization**
- Secrets should be stored securely using environment variables or secret managers
- Authorization should be based on claims, roles, and policies
- Structured logging frameworks (Serilog, OpenTelemetry) are recommended
- Swagger should be restricted to development or secured with authentication

---

## 💡 Future Improvements

- Replace stubbed authentication/authorization with **real handlers and policies**
- Move custom middleware into **dedicated classes**
- Add structured logging (Serilog, OpenTelemetry) for centralized logs
- Filter out static file requests (e.g., `/favicon.ico`) from middleware logging
- Expand Swagger documentation with:
  - Endpoint descriptions
  - Request/response examples
  - Authentication requirements
- Add unit/integration tests for middleware behavior