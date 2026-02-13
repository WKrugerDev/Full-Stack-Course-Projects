-- Create database (run separately)
CREATE DATABASE productdb;

-- Connect to database
\c productdb;

-- Create Products table
CREATE TABLE "Products" (
    "Id" SERIAL PRIMARY KEY,
    "Name" TEXT NOT NULL,
    "Price" NUMERIC(18,2) NOT NULL
);

-- Insert product
INSERT INTO "Products" ("Name", "Price")
VALUES ('Sample Product', 9.99);

-- Select all products
SELECT * FROM "Products";

-- Select product by Id
SELECT * FROM "Products" WHERE "Id" = 1;

-- Update product
UPDATE "Products"
SET "Price" = 19.99
WHERE "Id" = 1;

-- Delete product
DELETE FROM "Products"
WHERE "Id" = 1;
