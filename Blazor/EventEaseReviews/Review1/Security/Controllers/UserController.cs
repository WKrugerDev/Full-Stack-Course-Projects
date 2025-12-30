using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SafeVault.Services;

namespace SafeVault.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        
        public UserController(UserService userService)
        {
            _userService = userService;
        }
        
        [HttpGet("profile")]
        public async Task<IActionResult> GetProfile()
        {
            var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId))
                return Unauthorized();
            
            var user = await _userService.GetUserByIdAsync(userId);
            if (user == null)
                return NotFound();
            
            return Ok(new
            {
                user.UserID,
                user.Username,
                user.Email,
                user.Role,
                user.CreatedAt
            });
        }
        
        [HttpGet("all")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users.Select(u => new
            {
                u.UserID,
                u.Username,
                u.Email,
                u.Role,
                u.CreatedAt
            }));
        }
        
        [HttpPut("{id}/role")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateUserRole(int id, [FromBody] string newRole)
        {
            // Validate role input
            if (string.IsNullOrEmpty(newRole) || (newRole != "User" && newRole != "Admin"))
                return BadRequest("Invalid role");
            
            var success = await _userService.UpdateUserRoleAsync(id, newRole);
            if (!success)
                return NotFound();
            
            return Ok(new { message = "Role updated successfully" });
        }
        
        [HttpGet("admin-dashboard")]
        [Authorize(Roles = "Admin")]
        public IActionResult AdminDashboard()
        {
            return Ok(new { message = "Welcome to Admin Dashboard", timestamp = DateTime.UtcNow });
        }
    }
}