-- ============================================================
-- SmartShopInventoryLab_PostgreSQL.sql
-- PostgreSQL-specific SQL Queries for SmartShop Inventory System
-- 
-- Purpose:
-- This file ensures all queries from SmartShopInventoryLab.sql 
-- are fully compatible with PostgreSQL syntax and features.
-- Includes basic, complex, and optimized queries.
-- Copilot-assisted notes included as comments.
-- ============================================================

-- ============================================================
-- Activity 1: Basic SQL Queries
-- ============================================================

-- 1a) Retrieve product details (ProductName, Category, Price, StockLevel)
-- PostgreSQL-specific: proper table aliases and explicit join syntax
SELECT 
    p."ProductName",
    c."CategoryName" AS "Category",
    p."Price",
    p."StockLevel"
FROM 
    "Products" p
JOIN 
    "Categories" c ON p."CategoryID" = c."CategoryID"
ORDER BY 
    p."ProductName";

-- 1b) Filter products in a specific category (example: Electronics)
SELECT 
    p."ProductName",
    c."CategoryName" AS "Category",
    p."Price",
    p."StockLevel"
FROM 
    "Products" p
JOIN 
    "Categories" c ON p."CategoryID" = c."CategoryID"
WHERE 
    c."CategoryName" = 'Electronics'
ORDER BY 
    p."ProductName";

-- 1c) Filter products with low stock levels (StockLevel < 10)
SELECT 
    p."ProductName",
    c."CategoryName" AS "Category",
    p."Price",
    p."StockLevel"
FROM 
    "Products" p
JOIN 
    "Categories" c ON p."CategoryID" = c."CategoryID"
WHERE 
    p."StockLevel" < 10
ORDER BY 
    p."ProductName";

-- 1d) Sort products by Price ascending
SELECT 
    p."ProductName",
    c."CategoryName" AS "Category",
    p."Price",
    p."StockLevel"
FROM 
    "Products" p
JOIN 
    "Categories" c ON p."CategoryID" = c."CategoryID"
ORDER BY 
    p."Price" ASC;

-- ============================================================
-- Activity 2: Complex SQL Queries
-- ============================================================

-- 2a) Multi-table JOINs (Products, Sales, Stores)
SELECT 
    p."ProductName",
    s."SaleDate",
    st."StoreLocation",
    s."UnitsSold"
FROM 
    "Sales" s
JOIN 
    "Products" p ON s."ProductID" = p."ProductID"
JOIN 
    "Stores" st ON s."StoreID" = st."StoreID"
ORDER BY 
    s."SaleDate" DESC, p."ProductName";

-- 2b) Total sales per product using SUM and GROUP BY
SELECT 
    p."ProductID",
    p."ProductName",
    SUM(s."UnitsSold") AS "TotalUnitsSold"
FROM 
    "Sales" s
JOIN 
    "Products" p ON s."ProductID" = p."ProductID"
GROUP BY 
    p."ProductID", p."ProductName"
ORDER BY 
    "TotalUnitsSold" DESC;

-- 2c) Suppliers with the most delayed deliveries using MAX
SELECT 
    sup."SupplierName",
    MAX(sup."DeliveryDelayDays") AS "MaxDelayDays"
FROM 
    "Suppliers" sup
GROUP BY 
    sup."SupplierName"
ORDER BY 
    "MaxDelayDays" DESC
LIMIT 5;

-- 2d) Optimized multi-table join using CTE for recent sales
WITH "RecentSales" AS (
    SELECT *
    FROM "Sales"
    WHERE "SaleDate" >= CURRENT_DATE - INTERVAL '30 days'
)
SELECT 
    p."ProductName",
    rs."SaleDate",
    st."StoreLocation",
    rs."UnitsSold"
FROM 
    "RecentSales" rs
JOIN 
    "Products" p ON rs."ProductID" = p."ProductID"
JOIN 
    "Stores" st ON rs."StoreID" = st."StoreID"
ORDER BY 
    rs."SaleDate" DESC, p."ProductName";

-- ============================================================
-- Activity 3: Debugging & Optimization Notes
-- ============================================================

-- Copilot-assisted debugging:
-- - Corrected ambiguous column references with table aliases
-- - Checked and corrected JOIN logic for PostgreSQL syntax
-- - Used CTEs for performance improvements and readability
-- - Recommended indexes on frequently queried columns:
--   ProductID, StoreID, SaleDate, DeliveryDelayDays

-- PostgreSQL index examples (for guidance, not executed here):
-- CREATE INDEX idx_sales_productid ON "Sales"("ProductID");
-- CREATE INDEX idx_sales_storeid ON "Sales"("StoreID");
-- CREATE INDEX idx_sales_saledate ON "Sales"("SaleDate");

-- Notes:
-- All queries are now fully PostgreSQL-compliant.
-- Queries maintain readability and maintainability, with Copilot suggestions incorporated.
-- Performance improvements should be validated on a populated PostgreSQL database.

-- ============================================================
-- End of SmartShopInventoryLab_PostgreSQL.sql
-- ============================================================
