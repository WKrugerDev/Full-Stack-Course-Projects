using  UserManagementApi.Models;
using System.ComponentModel.DataAnnotations;

namespace UserManagementApi.DTOs
{
    /// <summary>
    /// Class for Updating Users
    /// </summary>
    public class UpdateUserDto
    {
        /// <summary>The name of the user</summary>
        [Required]
        public required string Name { get; set; }
        /// <summary>The email of the user</summary>
        [Required]
        public required string Email { get; set; }
        /// <summary>The role assigned to the user</summary>
        [Required]
        public required UserRole Role { get; set; }
    }

}