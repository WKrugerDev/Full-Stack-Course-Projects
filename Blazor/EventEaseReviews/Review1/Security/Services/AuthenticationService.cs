using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BCrypt.Net;
using SafeVault.Data;
using SafeVault.Models;

namespace SafeVault.Services
{
    public class AuthenticationService
    {
        private readonly SafeVaultContext _context;
        private readonly IConfiguration _configuration;
        
        public AuthenticationService(SafeVaultContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        
        public async Task<User?> AuthenticateAsync(string username, string password)
        {
            // Use parameterized query to prevent SQL injection
            var user = await _context.Users
                .Where(u => u.Username == username)
                .FirstOrDefaultAsync();
                
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
                return null;
                
            return user;
        }
        
        public async Task<User?> RegisterAsync(RegisterRequest request)
        {
            // Validate input
            if (!InputValidationService.IsValidUsername(request.Username) ||
                !InputValidationService.IsValidEmail(request.Email) ||
                !InputValidationService.IsValidPassword(request.Password))
            {
                return null;
            }
            
            // Check if user exists using parameterized query
            var existingUser = await _context.Users
                .Where(u => u.Username == request.Username || u.Email == request.Email)
                .FirstOrDefaultAsync();
                
            if (existingUser != null)
                return null;
            
            var user = new User
            {
                Username = InputValidationService.SanitizeInput(request.Username),
                Email = InputValidationService.SanitizeInput(request.Email),
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                Role = "User"
            };
            
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            
            return user;
        }
        
        public string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"] ?? "DefaultSecretKey123456789");
            
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.UserID.ToString()),
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddHours(24),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}