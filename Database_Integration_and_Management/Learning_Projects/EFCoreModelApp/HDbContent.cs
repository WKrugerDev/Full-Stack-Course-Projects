using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using EFCoreModelApp.Models;
using System.IO;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace EFCoreModelApp
{
    public class HRDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Department> Departments { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                var connectionString = config.GetConnectionString("PostgresConnection");

                optionsBuilder.UseNpgsql(connectionString);
            }

            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Employee -> Department (many-to-one)
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(50);
                entity
                    .HasOne(e => e.Department)
                    .WithMany(d => d.Employees)
                    .HasForeignKey(e => e.DepartmentID);
            });
                

            //Seed Departments
            modelBuilder.Entity<Department>().HasData(
                new Department{DepartmentID=1, Name="HR"},
                new Department{DepartmentID=2, Name="Engineering"}
            );

            //Seed Employees
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeID = 1,
                    FirstName = "Alice",
                    LastName = "Smith",
                    HireDate = DateTime.UtcNow,
                    DepartmentID = 1
                },
                new Employee
                {
                    EmployeeID = 2,
                    FirstName = "Bob",
                    LastName = "Jones",
                    HireDate = DateTime.UtcNow,
                    DepartmentID = 2
                }
            );
        }
    }    
}