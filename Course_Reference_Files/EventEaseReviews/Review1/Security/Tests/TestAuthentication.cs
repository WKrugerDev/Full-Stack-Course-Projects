using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using SafeVault.Data;
using SafeVault.Models;
using SafeVault.Services;
using Microsoft.Extensions.Configuration;

namespace SafeVault.Tests
{
    [TestFixture]
    public class TestAuthentication
    {
        private SafeVaultContext _context;
        private AuthenticationService _authService;
        private IConfiguration _configuration;
        
        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<SafeVaultContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase_" + Guid.NewGuid())
                .Options;
            
            _context = new SafeVaultContext(options);
            
            var inMemorySettings = new Dictionary<string, string> {
                {"Jwt:Key", "TestSecretKey123456789012345678901234567890"}
            };
            _configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings!)
                .Build();
            
            _authService = new AuthenticationService(_context, _configuration);
        }
        
        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
        
        [Test]
        public async Task TestSuccessfulRegistration()
        {
            var request = new RegisterRequest
            {
                Username = "testuser",
                Email = "test@example.com",
                Password = "password123"
            };
            
            var user = await _authService.RegisterAsync(request);
            
            Assert.That(user, Is.Not.Null);
            Assert.That(user.Username, Is.EqualTo("testuser"));
            Assert.That(user.Email, Is.EqualTo("test@example.com"));
            Assert.That(user.Role, Is.EqualTo("User"));
            Assert.That(user.PasswordHash, Is.Not.EqualTo("password123")); // Password should be hashed
        }
        
        [Test]
        public async Task TestDuplicateUserRegistration()
        {
            var request = new RegisterRequest
            {
                Username = "testuser",
                Email = "test@example.com",
                Password = "password123"
            };
            
            await _authService.RegisterAsync(request);
            var duplicateUser = await _authService.RegisterAsync(request);
            
            Assert.That(duplicateUser, Is.Null);
        }
        
        [Test]
        public async Task TestSuccessfulAuthentication()
        {
            var request = new RegisterRequest
            {
                Username = "testuser",
                Email = "test@example.com",
                Password = "password123"
            };
            
            await _authService.RegisterAsync(request);
            var authenticatedUser = await _authService.AuthenticateAsync("testuser", "password123");
            
            Assert.That(authenticatedUser, Is.Not.Null);
            Assert.That(authenticatedUser.Username, Is.EqualTo("testuser"));
        }
        
        [Test]
        public async Task TestFailedAuthenticationWithWrongPassword()
        {
            var request = new RegisterRequest
            {
                Username = "testuser",
                Email = "test@example.com",
                Password = "password123"
            };
            
            await _authService.RegisterAsync(request);
            var authenticatedUser = await _authService.AuthenticateAsync("testuser", "wrongpassword");
            
            Assert.That(authenticatedUser, Is.Null);
        }
        
        [Test]
        public async Task TestFailedAuthenticationWithNonExistentUser()
        {
            var authenticatedUser = await _authService.AuthenticateAsync("nonexistent", "password123");
            
            Assert.That(authenticatedUser, Is.Null);
        }
        
        [Test]
        public async Task TestSQLInjectionInAuthentication()
        {
            // Attempt SQL injection in username
            var maliciousUsername = "admin' OR '1'='1";
            var authenticatedUser = await _authService.AuthenticateAsync(maliciousUsername, "anypassword");
            
            // Should return null, not bypass authentication
            Assert.That(authenticatedUser, Is.Null);
        }
        
        [Test]
        public async Task TestJwtTokenGeneration()
        {
            var request = new RegisterRequest
            {
                Username = "testuser",
                Email = "test@example.com",
                Password = "password123"
            };
            
            var user = await _authService.RegisterAsync(request);
            var token = _authService.GenerateJwtToken(user!);
            
            Assert.That(token, Is.Not.Null);
            Assert.That(token, Is.Not.Empty);
            Assert.That(token.Split('.').Length, Is.EqualTo(3)); // JWT has 3 parts
        }
        
        [Test]
        public async Task TestInvalidInputRegistration()
        {
            var invalidRequests = new[]
            {
                new RegisterRequest { Username = "ab", Email = "test@example.com", Password = "password123" }, // Too short
                new RegisterRequest { Username = "test@user", Email = "test@example.com", Password = "password123" }, // Invalid chars
                new RegisterRequest { Username = "testuser", Email = "invalid-email", Password = "password123" }, // Invalid email
                new RegisterRequest { Username = "testuser", Email = "test@example.com", Password = "12345" } // Weak password
            };
            
            foreach (var request in invalidRequests)
            {
                var user = await _authService.RegisterAsync(request);
                Assert.That(user, Is.Null);
            }
        }
    }
}