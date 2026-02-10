using System;

namespace EFCoreModelApp.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }  // Primary Key

        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public DateTime HireDate { get; set; }

        public int DepartmentID { get; set; }  // Foreign Key
        public Department Department { get; set; } = null!; // Navigation
    }
}