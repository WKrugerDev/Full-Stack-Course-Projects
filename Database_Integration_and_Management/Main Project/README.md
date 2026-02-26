# SmartShop Inventory System – SQL Project

This repository contains SQL queries for the **SmartShop Inventory System**, demonstrating practical use of SQL for managing inventory, sales, and supplier data across multiple stores.  

The project was developed using **Microsoft Copilot** for query generation, debugging, and optimization.

---

## 🧱 Tech Stack

- PostgreSQL
- Standard SQL
- Microsoft Copilot assistance

---

## 📁 Project Structure

### 1️⃣ SmartShopInventoryLab.sql  
**Basic, complex, and optimized SQL queries (generic syntax)**

**Demonstrates:**

- Basic querying and filtering:
  - SELECT statements with column selection
  - Filtering with `WHERE`
  - Sorting with `ORDER BY`
- Complex queries:
  - Multi-table JOINs (Products, Sales, Stores)
  - Nested queries and aggregate functions (SUM, MAX)
  - CTEs for optimized query structure
- Debugging & optimization:
  - Corrected ambiguous column references
  - Suggestions from Copilot for indexing and performance improvements

**Copilot assistance notes:**  

- Suggested JOINs and aliases for clarity and correctness  
- Recommended using CTEs to reduce unnecessary computations  
- Identified potential aggregation errors and helped correct GROUP BY clauses  
- Suggested indexes for frequently queried columns (ProductID, StoreID, SaleDate, DeliveryDelayDays)  

---

### 2️⃣ SmartShopInventoryLab_PostgreSQL.sql  
**PostgreSQL-specific SQL queries for the same project**

**Demonstrates:**

- PostgreSQL-compliant syntax:
  - Double-quoted table and column names
  - `INTERVAL` syntax for date arithmetic
  - Explicit aliasing for clarity
- All basic, complex, and optimized queries translated to PostgreSQL
- Copilot-assisted debugging and optimization applied to PostgreSQL version

**Copilot assistance notes:**  

- Ensured PostgreSQL syntax compatibility for all queries  
- Recommended indexing and query restructuring for performance and readability  
- Corrected ambiguous column references and JOIN logic  

---

## 🧠 Key Learning Outcomes

- Writing precise SQL queries for inventory and sales data retrieval  
- Filtering, sorting, and aggregating data across multiple tables  
- Using joins, nested queries, and CTEs for optimized query performance  
- Applying Copilot for debugging, optimization, and query suggestions  
- Translating queries to PostgreSQL-compliant syntax for real-world usage

---

## 📌 Running the Scripts

- Both SQL files are self-contained and can be executed independently.  
- PostgreSQL clients recommended:  
  - **pgAdmin**  
  - **psql**  
  - Any SQL-compatible IDE  

---

## 💡 Possible Future Enhancements

- Populate tables with sample data to test query performance  
- Apply actual indexing and measure execution plans  
- Add foreign key constraints for relational integrity  
- Extend to include more advanced analytical queries and reporting  
- Automate database setup with idempotent scripts
