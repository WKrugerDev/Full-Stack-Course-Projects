# Minimal Task API – Course Version

This repository contains a simple ASP.NET Core Minimal API demonstrating CRUD operations on an **in-memory task list**.  

The project was developed as part of the course to practice:

- Minimal API endpoint creation  
- HTTP communication and status codes  
- In-memory data handling  
- Routing and parameter handling  

---

## 🧱 Tech Stack

- .NET 8  
- ASP.NET Core Minimal API  
- C#  

---

## 📁 Project Structure

- `Program.cs` – Minimal API definition and endpoints for GET, POST, PUT, DELETE  
- `TaskItem.cs` – Task model definition  

Notes:

- Uses in-memory `List<TaskItem>` to store tasks  
- Ready for extension with database integration  

---

## 🧠 Key Learning Outcomes

- Understanding HTTP verbs and RESTful patterns  
- Returning proper HTTP status codes (200 OK, 201 Created, 404 Not Found)  
- Minimal API structure and routing  
- Model binding and basic validation  

---

## 📌 Running the Application

1. Navigate to the project folder.  
2. Run `dotnet watch run` (or `dotnet run`)  
3. Test endpoints via Postman, Swagger, or any HTTP client:  

| Verb   | Endpoint        | Description                  |
|--------|----------------|------------------------------|
| GET    | `/tasks`       | Retrieve all tasks           |
| GET    | `/tasks/{id}`  | Retrieve a single task by ID |
| POST   | `/tasks`       | Add a new task               |
| PUT    | `/tasks/{id}`  | Update an existing task      |
| DELETE | `/tasks/{id}`  | Delete a task                |

- When creating/updating tasks, JSON booleans (`true` / `false`) are required for `isCompleted`.

---

## 💡 Possible Future Enhancements

- Replace in-memory storage with **EF Core and PostgreSQL**  
- Auto-generate task IDs on POST  
- Move endpoints into a separate file or service for better separation of concerns  
- Add proper input validation  
- Extend Swagger/OpenAPI documentation  
- Unit testing for endpoints  

> These enhancements will be implemented in a **separate folder/project** to keep the course version intact.
