# FullStackApp – Blazor & Minimal API Project

This repository contains a small full-stack .NET application demonstrating frontend-backend integration using Blazor WebAssembly and ASP.NET Core Minimal API.  

The project was developed to practice HTTP communication, asynchronous lifecycle handling, and solution/project structure.

---

## 🧱 Tech Stack

- .NET 8  
- Blazor WebAssembly (Frontend)  
- ASP.NET Core Minimal API (Backend)  
- C#

---

## 📁 Project Structure

### Frontend (`frontend/`)  
Blazor WebAssembly project serving the UI.  

Demonstrates:  

- Fetching data from the backend API via HttpClient  
- Displaying dynamic data in Blazor components (`Products.razor`)  
- Lifecycle handling with OnInitializedAsync  
- Dependency injection for HttpClient  

Notes:  

- HTTP calls point to backend via BaseAddress property  
- Razor components use DTOs for type safety  

---

### Backend (`backend/`)  
ASP.NET Core Minimal API project exposing endpoints.  

Demonstrates:  

- Defining simple API endpoints (`/products`)  
- Returning JSON data for frontend consumption  
- Swagger/OpenAPI support for testing endpoints  
- Structuring code for future database integration  

Notes:  

- Currently returns hard-coded sample data (`Product` list)  
- Ready to be extended with EF Core and PostgreSQL  

---

### Solution File (`FullStackApp.sln`)  
Coordinates multiple projects in the same workspace.  

Demonstrates:  

- Organizing frontend and backend under a single solution  
- Supporting multi-project builds and references  
- Simplifying debugging and testing across projects  

Notes:  

- Future Shared project for DTOs can be added and referenced by both frontend and backend  
- Facilitates proper build order and multi-project deployment

---

## 🧠 Key Learning Outcomes

- Connecting Blazor frontend to Minimal API backend using HttpClient  
- Handling async lifecycle methods in Blazor (OnInitializedAsync)  
- Structuring multi-project solutions with `.sln`  
- Preparing projects for database integration and shared models

---

## 📌 Running the Application

Start the backend by navigating to the backend folder and running `dotnet watch`.  
Start the frontend by navigating to the frontend folder and running `dotnet watch`.  
Then open the frontend in your browser at `/products` to view the product list.  

Make sure the frontend HttpClient points to the correct backend URL and port.

---

## 💡 Possible Future Enhancements

- Add EF Core and PostgreSQL integration for dynamic product storage  
- Move shared models (`Product`) into a Shared class library  
- Implement full CRUD operations via API  
- Extend Swagger/OpenAPI for all endpoints  
- Introduce unit tests for backend endpoints and frontend components  
- Prepare for CI/CD pipeline integration