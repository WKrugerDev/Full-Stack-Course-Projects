using System.Collections.Generic;

namespace EFCoreModelApp.Models
{
    public class Department
    {
        public int DepartmentID { get; set; } // Primary Key
        public string Name { get; set; } = null!;

        public List<Employee> Employees { get; set; } = new();
    }
}