-- Create Departments table
CREATE TABLE Departments (
    DepartmentID SERIAL PRIMARY KEY,
    Name VARCHAR(50) NOT NULL
);

-- Create Employees table
CREATE TABLE Employees (
    EmployeeID SERIAL PRIMARY KEY,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    HireDate TIMESTAMPTZ NOT NULL,
    DepartmentID INT NOT NULL,
    CONSTRAINT FK_Employees_Department FOREIGN KEY(DepartmentID)
        REFERENCES Departments(DepartmentID)
);

-- Seed Departments
INSERT INTO Departments (DepartmentID, Name) VALUES
(1, 'HR'),
(2, 'Engineering');

-- Seed Employees
INSERT INTO Employees (EmployeeID, FirstName, LastName, HireDate, DepartmentID) VALUES
(1, 'Alice', 'Smith', '2022-01-10T00:00:00Z', 1),
(2, 'Bob', 'Jones', '2023-03-05T00:00:00Z', 2);