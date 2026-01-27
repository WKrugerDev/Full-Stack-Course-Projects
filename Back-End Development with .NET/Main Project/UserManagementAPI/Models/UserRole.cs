using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace UserManagementApi.Models
{
    /// <summary>
    /// Represents the different user roles in the system
    /// </summary>
    public enum UserRole
    {
        /// <summary>Administrator with full access</summary>
        Admin,
        /// <summary>Regular user with limited access</summary>
        User,
        /// <summary>Guest user with minimal access</summary>
        Guest
    }
}

   