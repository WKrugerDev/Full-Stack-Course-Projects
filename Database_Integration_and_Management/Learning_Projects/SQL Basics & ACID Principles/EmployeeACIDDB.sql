-- Create database
CREATE DATABASE EmployeeDB;

-- Create Employees table
CREATE TABLE Employees(
    EmployeeID INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    Department VARCHAR(50),
    SALARY DECIMAL(10,2),
    HireDate DATE
);

-- Insert sample data
INSERT INTO Employees(firstname,lastname,department,salary,hiredate) VALUES
    ('Aisha', 'Khan', 'Finance', 85000.00, '2019-03-15'),
    ('Luis', 'Garcia', 'IT', 95000.00, '2020-07-22'),
    ('Chloe', 'Nguyen', 'Marketing', 72000.00, '2018-10-05'),
    ('Amara', 'Smith', 'HR', 67000.00, '2021-01-18'),
    ('Ravi', 'Patel', 'Finance', 88000.00, '2017-11-03');

-- Verify inserted data
SELECT * FROM Employees;

--Create Stored procedure to inscrease salary for a selected department
CREATE OR REPLACE PROCEDURE IncreaseSalary(
    deptname VARCHAR (50),
    increaseincrement DECIMAL(10,2)
)
LANGUAGE plpgsql
As $$
DECLARE
    affected_rows INT;
BEGIN
    --Ensure increment is positive
    IF increaseincrement <= 0 THEN
        RAISE EXCEPTION 'Increment must be positive';
    END IF;

    --Update salaries
    UPDATE Employees
    SET salary = salary + increaseincrement
    WHERE department = deptname;

    --Get number of affected rows
    GET DIAGNOSTICS affected_rows = ROW_COUNT;

    --Check if department existed
    IF affected_rows = 0 THEN
        RAISE EXCEPTION 'Department not found';
    END IF;
END;
$$;

--Testing procedure
CALL IncreaseSalary ('Finance', 5000);

--Checking again for updates salary
SELECT * FROM Employees;

--Create scalar function to calculate annual bonus for employee based on their salary
CREATE OR REPLACE FUNCTION CalculateBonus (salary DECIMAL(10,2))
RETURNS DECIMAL(10,2)
LANGUAGE plpgsql
AS $$
BEGIN
    --Checks for positive salary number
    IF salary <= 0 THEN
        RAISE EXCEPTION 'Salary must be positive';
    END IF;
    RETURN salary * 0.10;
END;
$$;

--Test function
SELECT 
    firstname, 
    lastname, 
    CalculateBonus(salary) AS Bonus 
FROM Employees;

--Create Log table to add log of actions (part of showcasing ACID principles with transactions)
Create TABLE SalaryAuditLog (
    LogID INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    Department VARCHAR(50),
    IncrementAmount DECIMAL(10,2),
    ChangeTimestamp TIMESTAMPTZ DEFAULT NOW()
);

--Clean Transaction Example
BEGIN;

CALL IncreaseSalary ('Finance', 5000);

INSERT INTO SalaryAuditLog (Department, IncrementAmount)
VALUES ('Finance', 5000);

COMMIT;

--Example for rollback failure
BEGIN;

CALL IncreaseSalary('NonExistentDepartment', 5000);

INSERT INTO SalaryAuditLog (Department, IncrementAmount)
VALUES ('NonExistentDepartment', 5000);

COMMIT;

--Rollback after failure
ROLLBACK;