# UserManagementAPI Project

A hands-on **ASP.NET Core lab project** demonstrating:

- Manual Swagger/OpenAPI setup  
- Controller-based REST APIs  
- JWT authentication and authorization  
- Serilog logging  
- Client generation using **NSwag**  

This project focuses on understanding **manual Swagger configuration**, **controller metadata**, and **how a generated client consumes the API**.

---

## 🚀 Features

- Controller-based API using ASP.NET Core MVC  
- Manual Swagger/OpenAPI setup with JWT support  
- Endpoints for managing `User` resources  
- Serilog logging of requests, responses, and exceptions  
- OpenAPI client generation via **NSwag**  
- Generated strongly-typed API client in a separate folder  

---

## 🧱 Tech Stack

- .NET 8  
- ASP.NET Core 8 (Controllers)  
- Swagger / OpenAPI  
- NSwag & NJsonSchema  
- Serilog for logging  

---

## ✅ Key Details

- **Manual Swagger Configuration**
  - Services and middleware added explicitly
  - XML comments included for endpoint documentation
  - JWT authentication configured in Swagger UI  
  - Example Swagger URL: `http://localhost:5130/swagger/index.html`

- **Controller-Based API**
  - `UserController` exposes REST endpoints
  - `[ApiController]` and routing attributes used
  - JSON response formatting specified explicitly

- **JWT Authentication**
  - Protected endpoints require a valid token  
  - Token for evaluation: `mysecrettoken`  
  - Swagger Authorize flow:
    1. Click **Authorize** in Swagger UI  
    2. Enter token: `mysecrettoken`  
    3. Access JWT-protected endpoints  
  - For Postman testing:
    ```
    Key: Authorization
    Value: Bearer mysecrettoken
    ```

- **Logging & Exception Handling**
  - Serilog logs to **console** and **daily rolling files**  
  - Custom middleware handles request/response logging and global exceptions  

- **OpenAPI Client Generation (Optional)**
  - `ClientGenerator` console app fetches Swagger JSON at runtime
  - Generates strongly-typed client (`UserManagementAPIClient.cs`) in a dedicated folder  
  - Client code is **auto-generated**, not manually edited
  - URL used for client generation: `http://localhost:5130/swagger/v1/swagger.json`  
  - Execution in `Program.cs` is commented out by default:
    ```csharp
    // await new SwaggerClientGenerator().GenerateClient();
    ```
  - look in bin/debug folder to find generated file (will be done more organised in a live site of the same)

---

## 🧠 Key Learning Points

- How to **manually configure Swagger** in ASP.NET Core  
- Differences between Minimal APIs and Controller-based APIs  
- How OpenAPI metadata is produced from controllers  
- How **NSwag** generates C# client code from Swagger JSON  
- Benefits of a generated client:
  - Type safety  
  - Maintainability  
  - Developer productivity  

---

## 📌 Notes for Reviewers

- Core API functionality is fully testable via Swagger UI (for non-JWT endpoints) or Postman (recommended for JWT-protected endpoints)  
- Optional client generation code is included but **commented out** in `Program.cs`  
- Project structure separates concerns:
  - `API` → Controllers, Models, Middleware  
  - `ClientGenerator` → Console app generating client  
- Swagger is enabled unconditionally for evaluation; in production, it should be restricted  
- JWT-protected endpoints can be tested manually with `mysecrettoken`  

---

## 🛠 Postman Testing (JWT-Protected Endpoints)

1. Request JWT token via login endpoint (POST `/login`)  
2. Copy token (use `mysecrettoken` for evaluation)  
3. Add header to requests:  
    ```
    Key: Authorization  
    Value: Bearer mysecrettoken
    ```  
4. Send requests to protected endpoints  

---

## 💡 Future Improvements

- Split API host and client generator into **distinct projects**  
- Automate client generation in CI/CD or build pipeline  
- Add more endpoints and models  
- Improve error handling in client and API  
- Add versioning and security for Swagger  
