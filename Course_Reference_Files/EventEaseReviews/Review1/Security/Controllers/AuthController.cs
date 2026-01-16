using Microsoft.AspNetCore.Mvc;
using SafeVault.Models;
using SafeVault.Services;

namespace SafeVault.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthenticationService _authService;
        
        public AuthController(AuthenticationService authService)
        {
            _authService = authService;
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            // Sanitize inputs to prevent XSS
            request.Username = InputValidationService.SanitizeInput(request.Username);
            
            var user = await _authService.AuthenticateAsync(request.Username, request.Password);
            
            if (user == null)
                return Unauthorized(new { message = "Invalid credentials" });
            
            var token = _authService.GenerateJwtToken(user);
            
            return Ok(new
            {
                token,
                user = new
                {
                    user.UserID,
                    user.Username,
                    user.Email,
                    user.Role
                }
            });
        }
        
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var user = await _authService.RegisterAsync(request);
            
            if (user == null)
                return BadRequest(new { message = "User already exists or invalid data" });
            
            var token = _authService.GenerateJwtToken(user);
            
            return Ok(new
            {
                token,
                user = new
                {
                    user.UserID,
                    user.Username,
                    user.Email,
                    user.Role
                }
            });
        }
    }
}