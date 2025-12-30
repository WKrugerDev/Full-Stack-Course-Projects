using Microsoft.EntityFrameworkCore;
using SafeVault.Data;
using SafeVault.Models;

namespace SafeVault.Services
{
    public class UserService
    {
        private readonly SafeVaultContext _context;
        
        public UserService(SafeVaultContext context)
        {
            _context = context;
        }
        
        // Secure method using parameterized queries to prevent SQL injection
        public async Task<User?> GetUserByIdAsync(int userId)
        {
            return await _context.Users
                .Where(u => u.UserID == userId)
                .FirstOrDefaultAsync();
        }
        
        // Secure method using parameterized queries
        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            // Validate and sanitize input
            if (!InputValidationService.IsValidUsername(username))
                return null;
                
            return await _context.Users
                .Where(u => u.Username == username)
                .FirstOrDefaultAsync();
        }
        
        // Secure method to get all users (admin only)
        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users
                .Select(u => new User
                {
                    UserID = u.UserID,
                    Username = u.Username,
                    Email = u.Email,
                    Role = u.Role,
                    CreatedAt = u.CreatedAt
                })
                .ToListAsync();
        }
        
        // Secure method to update user role
        public async Task<bool> UpdateUserRoleAsync(int userId, string newRole)
        {
            var user = await _context.Users
                .Where(u => u.UserID == userId)
                .FirstOrDefaultAsync();
                
            if (user == null)
                return false;
                
            user.Role = newRole;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}