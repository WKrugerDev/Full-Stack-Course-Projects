CREATE DATABASE EmployeesDB;

CREATE TABLE Employees(
    EmployeeID INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    firstname VARCHAR(50),
    lastname VARCHAR(50),
    department VARCHAR(50),
    salary DECIMAL (10,2),
    hiredate DATE
);

INSERT INTO Employees(firstname, lastname, department, salary, hiredate) VALUES
    ('Liam', 'Nguyen', 'Engineering', 85000.00, '2020-03-15'),
    ('Sophia', 'Smith', 'Marketing', 72000.00, '2019-05-22'),
    ('Raj', 'Patel', 'Sales', 64000.00, '2021-07-01'),
    ('Aisha', 'Khan', 'HR', 60000.00, '2020-09-12'),
    ('Carlos', 'Martinez', 'Engineering', 93000.00, '2018-12-01'),
    ('Chen', 'Zhao', 'Marketing', 77000.00, '2017-11-05'),
    ('Amara', 'Okafor', 'Sales', 67000.00, '2022-03-18');

SELECT concat(firstname,' ',lastname) AS FullName FROM Employees;

SELECT upper(department) AS Department FROM Employees;

SELECT lower(lastname) AS lowersurname FROM Employees;

SELECT length(firstname) AS firstnamelength FROM Employees;

SELECT substring(lastname FROM 1 FOR 3) AS lastnameshort FROM Employees;

SELECT COUNT(*) AS EmployeeCount FROM Employees;

SELECT SUM(salary) AS TotalSalaryExpenditure FROM Employees;

SELECT AVG(salary) As EngineerAverage FROM Employees WHERE department = 'Engineering';

SELECT Min(salary) AS LowestSalary FROM Employees;

SELECT MAX(salary) As HighestSalary FROM Employees WHERE department = 'Sales';

SELECT SUM(salary) AS DepartmentSum, department FROM Employees GROUP BY department;

SELECT AVG(salary) AS DepartmentAverage, department FROM Employees GROUP BY department;

SELECT COUNT(*) AS NumberofEmployees, department FROM Employees GROUP BY department;

SELECT concat(firstname,' ',lastname) AS fullname, length(concat(firstname,' ',lastname)) AS fullnamelength FROM Employees;

SELECT extract(YEAR FROM hiredate) as hireyear, COUNT(*) as EmployeeCount FROM Employees GROUP BY hireyear ORDER BY hireyear;

SELECT extract(YEAR FROM hiredate) as hireyear, SUM(salary) as totalsalary FROM Employees GROUP BY hireyear ORDER BY hireyear;