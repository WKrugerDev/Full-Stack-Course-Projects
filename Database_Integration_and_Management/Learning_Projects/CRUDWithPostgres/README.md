# CRUDWithPostgres

A minimal **.NET 8 console application** demonstrating **EF Core 8** with **PostgreSQL**, including full CRUD operations and a supporting raw SQL schema file.

---

## 🚀 Features

### Entity

- Product
  - Id
  - Name
  - Price

### CRUD Demonstration

- Create a new product
- Retrieve all products
- Retrieve a product by ID
- Update an existing product
- Delete a product

### Database Integration

- PostgreSQL database
- EF Core 8 with Npgsql provider
- Code-first interaction

### SQL Knowledge Demonstration

- Separate SQL schema file included for manual database creation
- Demonstrates table creation, primary keys, and CRUD statements

---

## 🧱 Tech Stack

- .NET 8 Console Application
- EF Core 8
- PostgreSQL
- Npgsql Entity Framework Core Provider

---

## 🧠 Key Learning Points

- How EF Core maps C# classes to PostgreSQL tables
- How to configure DbContext to connect to PostgreSQL
- How Add, Find, ToList, Remove, and SaveChanges work
- How EF Core tracks entity state changes
- The SQL equivalent of EF Core CRUD operations
- Clean, minimal implementation focused on database fundamentals

---

## 🗄️ Raw SQL File

The repository includes:

DatabaseSchema.sql

This file contains SQL commands to:

- Create the Products table
- Define a primary key
- Insert sample data
- Perform SELECT, UPDATE, and DELETE operations

This demonstrates knowledge of both:

- ORM-based database interaction (EF Core)
- Manual SQL-based database creation

---

## ▶️ Running the Application

To run this project:

1. Ensure PostgreSQL is installed and running.
2. Create a PostgreSQL database for the project.
3. Update the connection string in appsettings.json.
4. Run the console application.

The program will:

- Insert a product
- Display all products
- Retrieve a product by ID
- Update the product price
- Delete the product

---

## 💾 Portfolio Notes

This project demonstrates:

- Practical understanding of EF Core with PostgreSQL
- Clean CRUD implementation
- Knowledge of both ORM and raw SQL approaches
- Clear documentation suitable for portfolio review

---

## 💡 Possible Extensions

- Add user input for dynamic CRUD operations
- Introduce migrations
- Add validation and error handling
- Implement repository/service layers
- Expand schema with additional related entities
