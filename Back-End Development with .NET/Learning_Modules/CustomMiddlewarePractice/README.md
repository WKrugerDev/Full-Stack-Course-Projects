# CustomMiddlewarePractice

A minimal **ASP.NET Core Web API** project demonstrating **custom middleware** and how requests flow through the **HTTP request pipeline**.

This project focuses on understanding **middleware execution order**, **request interception**, **conditional middleware**, and **why some approaches are intentionally simplified for learning purposes**.

---

## 🚀 Features

- Custom middleware to:
  - Log request paths and response status codes
  - Measure request processing time
- Conditional middleware using `UseWhen`
- Simple API key validation for non-GET requests
- Minimal API endpoints for testing middleware behavior
- Optional **Swagger/OpenAPI** support for API exploration and testing
- Clear separation between **learning concepts** and **production best practices**

---

## 🧱 Tech Stack

- .NET 8  
- ASP.NET Core Minimal APIs  
- Swagger / OpenAPI (optional)

---

## ✅ Key Details

- **Request Timing**
  - Measures how long each request takes to execute
  - Demonstrates middleware code running **before and after** the endpoint
- **Request & Response Logging**
  - Logs incoming request paths
  - Logs outgoing response status codes
- **Conditional Middleware**
  - Uses `UseWhen` to apply API key validation only to non-GET requests
- **Swagger Integration**
  - Swagger is included but **commented out by default**
  - Can be enabled to visually test and document API endpoints
- **Pipeline Flow**
  - Shows how middleware executes in order
  - Demonstrates short-circuiting requests before they reach endpoints

---

## 🧠 Key Learning Points

- How **custom middleware** is registered and executed
- How middleware can:
  - Inspect HTTP requests
  - Read headers
  - Modify or stop requests before reaching endpoints
- How `await next()` controls pipeline flow
- Why middleware **order matters**
- How conditional middleware works using `UseWhen`
- What Swagger is and **why it is useful during development**
- Why authentication logic is **not usually implemented this way in real applications**

---

## 📌 Notes

- The API key check is implemented **directly inside middleware for demonstration purposes**
- This approach is **intentionally simplified** to focus on understanding:
  - Middleware flow
  - Request interception
  - Conditional execution
- Hard-coded secrets are used **only for learning**
- Swagger is disabled by default to keep focus on middleware behavior
- This implementation is **not production-safe** and should not be used as-is

In real-world applications:

- Authentication should use **ASP.NET Core Authentication & Authorization**
- Secrets should be stored securely using:
  - Environment variables
  - Secret managers
- Authorization should be based on:
  - Claims
  - Roles
  - Policies
- Swagger is usually:
  - Enabled only in development
  - Protected or disabled in production

---

## ▶️ Running the Application

1. Open the project in Visual Studio or VS Code  
2. Run the application  
3. (Optional) Enable Swagger by uncommenting:
   - `AddEndpointsApiExplorer()`
   - `AddSwaggerGen()`
   - `UseSwagger()`
   - `UseSwaggerUI()`
4. Send requests to:
   - `GET /`  
   - `GET /blogs`  
   - `POST /blogs` (requires `X-API-KEY` header)
5. Observe console output for:
   - Request paths
   - Response status codes
   - Request processing time

---

## 💡 Future Improvements

- Replace inline API key validation with:
  - `AddAuthentication()` and a custom authentication handler
- Introduce **authorization policies**
- Move logging and timing into:
  - Dedicated middleware classes
- Add centralized exception-handling middleware
- Integrate structured logging (Serilog, OpenTelemetry, etc.)
- Expand Swagger documentation with:
  - Endpoint descriptions
  - Request/response examples
  - Authentication requirements
