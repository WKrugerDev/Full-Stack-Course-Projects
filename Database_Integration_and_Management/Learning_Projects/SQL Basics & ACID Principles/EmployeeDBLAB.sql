CREATE DATABASE EmployeeDB;

CREATE TABLE Employees (
    id SERIAL PRIMARY KEY,
    firstname VARCHAR(50),
    lastname VARCHAR(50),
    department VARCHAR(50),
    salary DECIMAL(10,2),
    yearsexperience INT
);


INSERT INTO employees (firstname, lastname, department, salary, yearsexperience) VALUES
('John', 'Doe', 'HR', 60000, 10),
('Jane', 'Smith', 'Finance', 70000, 8),
('Michael', 'Brown', 'IT', 50000, 5),
('Emily', 'Davis', 'HR', 45000, 2),
('Chris', 'Wilson', 'Finance', 80000, 15);

SELECT * FROM Employees;

Select firstname, lastname FROM Employees;

SELECT DISTINCT department FROM Employees;

SELECT * FROM Employees WHERE department = 'HR';

SELECT * FROM Employees WHERE department = 'Finance' AND salary > 60000;

SELECT * FROM Employees WHERE yearsexperience > 5 AND salary < 70000;

SELECT * FROM Employees ORDER BY lastname;

SELECT * FROM Employees WHERE department = 'HR' ORDER BY salary DESC;

SELECT * FROM Employees ORDER BY salary DESC LIMIT 3;

SELECT * FROM Employees WHERE department = 'IT' AND yearsexperience > 3 ORDER BY yearsexperience DESC;

SELECT * FROM Employees WHERE Salary BETWEEN 50000 AND 75000 ORDER BY firstname;