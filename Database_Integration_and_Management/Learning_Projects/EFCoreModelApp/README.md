# EFCoreModelApp

A minimal **.NET 8 console application** demonstrating **EF Core 8** with **PostgreSQL**, including **code-first database creation**, **entity relationships**, and **CRUD operations**.  

This project focuses on understanding:

- **DbContext configuration**
- **Entity relationships and navigation properties**
- **Seeding data**
- **Migrations**
- **Querying and updating a real PostgreSQL database from C#**
- **Best practices for portfolio-level database projects**

---

## 🚀 Features

- **Entities & Relationships**
  - Employee ↔ Department (many-to-one)
- **EF Core Migrations**
  - Code-first migrations applied to PostgreSQL
- **Data Seeding**
  - Pre-populated departments and employees
- **CRUD Demonstration**
  - Queries employees with their departments
  - Filters employees by department
  - Adds new employees
- **Portfolio-friendly**
  - PostgreSQL database created for the project
  - Database schema reproducible via migrations or raw SQL

---

## 🧱 Tech Stack

- .NET 8 console application  
- EF Core 8  
- PostgreSQL  
- Npgsql Entity Framework Core provider  

---

## ✅ Key Details

- **DbContext Setup**
  - Configured with `appsettings.json` for connection string
  - Uses `UseNpgsql()` to connect to PostgreSQL
- **Entities**
  - Employee: FirstName, LastName, HireDate, DepartmentID
  - Department: Name, Employees
- **Relationships**
  - Employee has a navigation property to Department
  - Department has a collection of Employees
- **Seeding**
  - Departments: HR, Engineering
  - Employees: seeded with UTC timestamps for `timestamptz` compatibility

---

## 🧠 Key Learning Points

- How EF Core maps **C# classes to PostgreSQL tables**
- How to configure **DbContext** for PostgreSQL
- How to apply **migrations** for schema creation
- How to **seed initial data** and work around PostgreSQL `timestamptz` issues
- Querying and filtering with **LINQ + Include**
- Demonstrating **CRUD operations** from code
- How to document database creation for portfolio presentation

---

## 📌 PostgreSQL Setup

1. Ensure PostgreSQL is installed and running
2. Create a new database for this project with name hr_db with PostgreSQL
3. Update appsettings.json with your credentials.
4. Apply migrations to create tables and seed data

---

## 🗄️ Raw SQL Example

For portfolio purposes and to demonstrate understanding of **raw SQL**, this project includes a file `DatabaseSchema.sql` which contains the SQL commands to:

- Create the **Departments** and **Employees** tables  
- Define relationships with foreign keys  
- Seed initial data for both tables  

This allows reviewers to see how the database can be created **manually** without EF Core migrations, highlighting knowledge of SQL syntax and PostgreSQL features.

> **Note:** While the SQL file is for demonstration, the project itself uses **PostgreSQL with EF Core migrations** for all CRUD operations. This is intentionally more production-ready than the SQLite approach used in the lab instructions.

---

## ▶️ Running the Application

1. Ensure PostgreSQL is running and the database `hr_db` is accessible.  
2. Update `appsettings.json` with your PostgreSQL credentials (username/password).  
3. Apply EF Core migrations if not already applied:
        dotnet ef database update
4. Run the Console application:
        dotnet run
5. Expected output (example summary):
 - Lists all employees with their department names
 - Filters and shows only employees in the HR department
 - Confirms a new employee has been added
6. What will be seen in console:
All Employees:
Alice Smith - HR
Bob Jones - Engineering
New Employee - Engineering

HR Department Employees:
Alice Smith

New employee added.

---

## 💾 Included Database

To make this project **reviewer-ready**, the database dump has been included as part of the repository in a way that demonstrates the **data created via this lab**. This allows reviewers to inspect:

- Tables  
- Seeded records  
- Relationships  
- Query results

**Note:** The database dump is included for demonstration purposes, dump will have to be restored.

### ⚡ Restoring the Database from SQL Dump

You can recreate the `hr_db` database from the included SQL dump (this was added to show my output from the exercise):


# Create a new empty database (if not exists)
createdb -U postgres -h localhost -p 5127 hr_db

# Restore from SQL dump
psql -U postgres -h localhost -p 5127 -d hr_db -f hr_db_dump.sql


---

## 💡 Future Improvements

- Add **update** and **delete** operations to complete CRUD demonstration  
- Introduce **input validation** when adding new employees  
- Move database credentials to **environment variables** for security  
- Implement **repository pattern** for better separation of concerns  
- Add **unit tests** for DbContext queries  
- Expand database schema with additional entities (e.g., Projects, Tasks)  
- Provide **automated seeding scripts** for multiple environments  
- Include **logging** for database operations and error handling