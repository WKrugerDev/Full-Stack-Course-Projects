# MinimalApiDemo.Postgres – Minimal API with PostgreSQL

This repository contains a minimal RESTful API built using ASP.NET Core and PostgreSQL.  

The project demonstrates basic CRUD operations on a `TaskItem` entity with EF Core migrations and Swagger UI for testing endpoints.

---

## 🧱 Tech Stack

- .NET 8  
- ASP.NET Core Minimal API (Backend)  
- PostgreSQL  
- C#  
- Entity Framework Core (Code First Migrations)  

---

## 📁 Project Structure

### Backend (`MinimalApiDemo.Postgres/`)  

- ASP.NET Core Minimal API project exposing endpoints  
- CRUD operations for `TaskItem` entity  
- EF Core + PostgreSQL integration  
- Swagger/OpenAPI support for testing endpoints  

**Notes:**  

- `TaskItem` table is created via EF Core migrations  
- ID is auto-generated; do not pass it in POST requests  
- Local development uses `appsettings.Development.json` for connection strings  

---

## ⚙️ Configuration

Database connection is configured in `appsettings.Development.json`:

Host=localhost;Port=5127;Database=minimal_api_db;Username=postgres;Password=YOUR_PASSWORD



**Security Tip:**  

- Avoid committing passwords or sensitive data to Git  
- `.gitignore` already ignores `appsettings.Development.json`  

**Environment Variables Note:**  

- Previously, a `setx` command was used to create a global environment variable for connection strings  
- This could override the project’s local configuration and cause EF Core to target the wrong database  

**Resolution / Best Practice:**  

1. Remove leftover global variables:  
   `Remove-Item Env:ConnectionStrings__DefaultConnection`  
2. Use only local project configuration for development connection strings  

---

## 🗂 Migrations

- Add a new migration:  
  `dotnet ef migrations add InitialCreate`  
- Update database to apply migration:  
  `dotnet ef database update`  
- Verify tables exist in PostgreSQL using pgAdmin or `psql`  

---

## 🚀 Running the Application

- Run the backend:  
  `dotnet run`  
- Swagger UI is available at `http://localhost:{port}/swagger`  
- Example POST request to create a TaskItem: Provide `Name` and `IsCompleted` fields only  

---

## 🧠 Key Learning Outcomes

- Connecting ASP.NET Core Minimal API to PostgreSQL using EF Core  
- Managing migrations and database updates  
- Structuring a small RESTful API with proper endpoints  
- Using Swagger/OpenAPI for testing and debugging  

---

## 💡 Possible Future Enhancements

- Add JWT authentication and authorization  
- Implement unit and integration tests for endpoints  
- Introduce a frontend (Blazor, React, etc.) to consume API  
- Extend CRUD operations and error handling  
- Prepare for CI/CD and deployment pipelines
