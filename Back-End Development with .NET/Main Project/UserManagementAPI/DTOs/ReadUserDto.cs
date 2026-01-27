using  UserManagementApi.Models;
using System.ComponentModel.DataAnnotations;

namespace UserManagementApi.DTOs
{
    /// <summary>
    /// Class for reading/fetching users - made in case password wants to get added for a user, this will only fetch non-sensitive data, not passwords, etc.
    /// </summary>
    public class ReadUserDto
    {
        /// <summary>The unique ID of the user</summary>
        public int Id { get; set; }
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