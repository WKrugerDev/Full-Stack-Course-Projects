using UserManagementApi.Models;
using System.ComponentModel.DataAnnotations;

namespace UserManagementApi.DTOs
{
    /// <summary>
    /// Class for Creating Users
    /// </summary>
    public class CreateUserDto
    {
        /// <summary>The unique ID of the user</summary>
        public int Id { get; set; }
        /// <summary>The name of the user</summary>
        [Required]
        public required string Name { get; set; }
        /// <summary>The email of the user</summary>
        [Required]
        [EmailAddress]
        public required string Email { get; set; }
        /// <summary>The role assigned to the user</summary>
        [Required]
        [EnumDataType(typeof(UserRole), ErrorMessage = "Invalid Role Value")]
        public required UserRole Role { get; set; }
    }
}