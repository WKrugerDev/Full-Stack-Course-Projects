using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using EFCoreModelApp;
using EFCoreModelApp.Models;

class Program
{
    static void Main()
    {
        using var context = new HRDbContext();

        //Display all employees with their department names
        var allEmployees = context.Employees
                                  .Include(e => e.Department)
                                  .ToList();

        Console.WriteLine("All Employees:");
        foreach(var emp in allEmployees)
        {
            Console.WriteLine($"{emp.FirstName} {emp.LastName} - {emp.Department?.Name ?? "N/A"}");
        }

        Console.WriteLine();

        //Display employees in the HR department
        var hrEmployees = context.Employees
                                .Include(e => e.Department)
                                .Where(e => e.Department.Name == "HR")
                                .ToList();

        Console.WriteLine("HR Department Employees:");
        foreach (var emp in hrEmployees)
        {
            Console.WriteLine($"{emp.FirstName} {emp.LastName}");
        }

        Console.WriteLine();

        //Add a emploess to Engineering department
        var newEmployee = new Employee
        {
            FirstName = "Chris",
            LastName = "Smolders",
            HireDate = DateTime.UtcNow, //Use UTC for PostGreSQL timestamptz
            DepartmentID = 2
        };

        context.Employees.Add(newEmployee);
        context.SaveChanges();

        Console.WriteLine("New employee added");
    }
}