using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Diagnostics.CodeAnalysis;

namespace UserManagementApi.Models
{
    /// <summary>
    /// Represents a user in the system
    /// </summary>
    public class User
    {
        /// <summary>The unique ID of the user</summary>
        public int Id { get; private set; }

        /// <summary>The name of the user</summary>
        [Required]
        public string Name { get; set; }

        /// <summary>The email of the user</summary>
        [Required]
        [EmailAddress]
        public  string Email { get; set; }

        /// <summary>The role assigned to the user</summary>
        [Required]
        public UserRole Role { get; set; }

        /// <summary>
        /// Creates a new user with a system-assigned unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier assigned at creation time.</param>
        /// <param name="name">The user's full name.</param>
        /// <param name="email">The user's email address.</param>
        /// <param name="role">The role assigned to the user.</param>
        [SetsRequiredMembers]
        public User(int id, string name, string email, UserRole role)
        {
            Id = id;     // assigned ONCE
            Name = name;
            Email = email;
            Role = role;
        }   
    }
}