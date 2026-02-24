# PostgreSQL SQL Labs – Core Database Fundamentals

This repository contains three structured SQL labs demonstrating progressive understanding of relational database concepts using **PostgreSQL**.

The labs are organized to move from:

1. Basic querying and filtering  
2. CRUD operations and transactions  
3. SQL functions and aggregate analysis  

The focus of this repository is to demonstrate practical SQL knowledge using raw SQL scripts without ORMs or frameworks.

---

## 🧱 Tech Stack

- PostgreSQL
- Standard SQL
- PostgreSQL-specific features:
  - `SERIAL`
  - `GENERATED ALWAYS AS IDENTITY`
  - `EXTRACT()`

---

# 📁 Project Structure (In Learning Order)

---

## 1️⃣ EmployeeDBLab.sql  
### Querying & Data Retrieval Fundamentals

This lab focuses strictly on **data retrieval using SELECT statements**, filtering, sorting, and precision querying.

### Demonstrates:

- Database creation
- Table creation using `SERIAL`
- Inserting multiple rows
- Selecting all columns
- Selecting specific columns
- `DISTINCT`
- Filtering with `WHERE`
- Combining conditions using:
  - `AND`
- Range filtering using:
  - `BETWEEN`
- Sorting results with:
  - `ORDER BY`
  - `ASC` / `DESC`
- Limiting result sets with:
  - `LIMIT`
- Combining filtering and sorting

### Example Concepts Covered:

- Retrieving employees from a specific department  
- Filtering by salary and years of experience  
- Sorting by last name or salary  
- Selecting top N results  
- Applying multiple conditional filters  

This lab demonstrates understanding of **query depth and precision** when retrieving relational data.

---

## 2️⃣ SampleDBLab.sql  
### CRUD Operations & Transactions

This lab demonstrates fundamental data manipulation and transaction control.

### Demonstrates:

- Creating a database
- Creating tables with `SERIAL` primary key
- `INSERT` (single and multiple rows)
- `UPDATE` with conditions
- `DELETE` with conditions
- Viewing data using `SELECT`
- Transaction management:
  - `BEGIN`
  - `COMMIT`
  - `ROLLBACK`

### 🔄 Understanding Transactions

Transactions group multiple SQL statements into a single logical operation.

- `BEGIN` starts a transaction.
- `COMMIT` permanently saves changes.
- `ROLLBACK` cancels changes made during the transaction.

### Why Transactions Matter

Transactions ensure:

- **Atomicity** — either all operations succeed or none do  
- **Data integrity** — prevents partial updates  
- **Consistency** — protects against corruption during multi-step updates  

In real-world systems such as payroll, banking, or inventory management, transactions are essential for maintaining reliable and safe database operations.

---

## 3️⃣ EmployeesDBLab.sql  
### SQL Functions & Aggregate Analysis

This lab builds on the earlier exercises by introducing SQL functions and analytical querying.

### Demonstrates:

- Table creation using `GENERATED ALWAYS AS IDENTITY`
- String functions:
  - `CONCAT()`
  - `UPPER()`
  - `LOWER()`
  - `LENGTH()`
  - `SUBSTRING()`
- Aggregate functions:
  - `COUNT()`
  - `SUM()`
  - `AVG()`
  - `MIN()`
  - `MAX()`
- Grouping data using:
  - `GROUP BY`
- Extracting components from dates:
  - `EXTRACT(YEAR FROM hiredate)`
- Combining aggregation with sorting

### Key Concept

This lab demonstrates moving from simple retrieval to **data transformation and analytical querying**, including adapting MySQL-style instructions to PostgreSQL syntax where required (e.g., `EXTRACT()` instead of `YEAR()`).

---

## 4️⃣ EmployeeACIDDB.sql  
### Procedures, Functions & Transaction Handling

This lab introduces **stored procedures, scalar functions, error handling, audit logging, and transactions**, demonstrating PostgreSQL’s advanced database features and ACID principles.

### Demonstrates:

- Table creation using `GENERATED ALWAYS AS IDENTITY`
- Stored procedures:
  - `CREATE OR REPLACE PROCEDURE IncreaseSalary(...)`
  - Input validation (increment must be positive)
  - Error handling (department existence check)
- Scalar functions:
  - `CREATE OR REPLACE FUNCTION CalculateBonus(...)`
  - Input validation (salary must be positive)
- Audit logging:
  - `SalaryAuditLog` table
  - Recording transactional changes
- Transaction control:
  - `BEGIN` / `COMMIT`
  - `ROLLBACK` on failure
- ACID principles:
  - **Atomicity** – updates + logging succeed together or not at all
  - **Consistency** – validations prevent invalid data
  - **Isolation** – transactions run independently
  - **Durability** – committed changes persist permanently

### Key Concept

This lab moves beyond simple queries to **programmatic database logic**, showing how to:

- Encapsulate business rules in **procedures and functions**
- Maintain data integrity with **transactions**
- Implement **audit logging** for compliance and traceability
- Apply **error handling** for robust database operations

---

# 🧠 Key Learning Outcomes

Across all three labs, the following competencies are demonstrated:

- Creating relational databases and tables  
- Writing precise and readable SQL queries  
- Applying conditional logic to filter datasets  
- Sorting and limiting result sets  
- Performing CRUD operations  
- Managing transactions safely  
- Using SQL functions for data transformation  
- Performing aggregate analysis with `GROUP BY`  
- Understanding cross-database syntax differences  

---

# 📌 Running the Scripts

Each SQL file can be executed using a PostgreSQL client such as:

- pgAdmin  
- psql  
- Any SQL-compatible database IDE  

The scripts are self-contained and can be run independently.

---

# 💡 Possible Future Enhancements

Potential improvements to further elevate this project:

- Add `NOT NULL` and `CHECK` constraints for stronger data integrity  
- Introduce foreign key relationships between related tables  
- Add indexes to demonstrate performance optimization  
- Convert scripts into idempotent setup scripts using `DROP IF EXISTS`  
- Refactor into a more normalized schema with related entities (e.g., Departments, Roles, Projects)  
- Include example query execution plans for performance analysis  
- Expand transaction examples to simulate multi-step business logic scenarios  

---