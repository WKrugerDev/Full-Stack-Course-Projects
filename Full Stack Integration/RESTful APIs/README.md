# RESTful APIs Collection

This folder contains two versions of a minimal RESTful API project:

1. **In-Memory Database Version**  
   - Basic CRUD operations on `TaskItem` using an in-memory database.
   - Useful for quick testing without requiring a database server.

2. **PostgreSQL Version (`MinimalApiDemo.Postgres`)**  
   - CRUD operations persisted in PostgreSQL.
   - Includes EF Core migrations and connection management.
   - More robust, suitable for real development and testing.

### Getting Started

- Navigate into the project folder you want to run:

cd MinimalApiDemo.Postgres
dotnet run
