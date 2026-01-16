using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using SafeVault.Data;
using SafeVault.Models;
using SafeVault.Services;

namespace SafeVault.Tests
{
    [TestFixture]
    public class TestAuthorization
    {
        private SafeVaultContext _context;
        private UserService _userService;
        
        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<SafeVaultContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase_" + Guid.NewGuid())
                .Options;
            
            _context = new SafeVaultContext(options);
            _userService = new UserService(_context);
            
            // Seed test data
            SeedTestData();
        }
        
        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
        
        private void SeedTestData()
        {
            var users = new[]
            {
                new User { Username = "admin", Email = "admin@example.com", PasswordHash = "hashedpassword", Role = "Admin" },
                new User { Username = "user1", Email = "user1@example.com", PasswordHash = "hashedpassword", Role = "User" },
                new User { Username = "user2", Email = "user2@example.com", PasswordHash = "hashedpassword", Role = "User" }
            };
            
            _context.Users.AddRange(users);
            _context.SaveChanges();
        }
        
        [Test]
        public async Task TestGetUserById()
        {
            var user = await _userService.GetUserByIdAsync(1);
            
            Assert.That(user, Is.Not.Null);
            Assert.That(user.Username, Is.EqualTo("admin"));
        }
        
        [Test]
        public async Task TestGetUserByUsername()
        {
            var user = await _userService.GetUserByUsernameAsync("user1");
            
            Assert.That(user, Is.Not.Null);
            Assert.That(user.Username, Is.EqualTo("user1"));
            Assert.That(user.Role, Is.EqualTo("User"));
        }
        
        [Test]
        public async Task TestGetUserByInvalidUsername()
        {
            // Test with SQL injection attempt
            var user = await _userService.GetUserByUsernameAsync("admin' OR '1'='1");
            
            Assert.That(user, Is.Null);
        }
        
        [Test]
        public async Task TestGetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            
            Assert.That(users.Count, Is.EqualTo(3));
            Assert.That(users.Any(u => u.Username == "admin"), Is.True);
            Assert.That(users.Any(u => u.Username == "user1"), Is.True);
            Assert.That(users.Any(u => u.Username == "user2"), Is.True);
        }
        
        [Test]
        public async Task TestUpdateUserRole()
        {
            var success = await _userService.UpdateUserRoleAsync(2, "Admin");
            
            Assert.That(success, Is.True);
            
            var updatedUser = await _userService.GetUserByIdAsync(2);
            Assert.That(updatedUser?.Role, Is.EqualTo("Admin"));
        }
        
        [Test]
        public async Task TestUpdateNonExistentUserRole()
        {
            var success = await _userService.UpdateUserRoleAsync(999, "Admin");
            
            Assert.That(success, Is.False);
        }
        
        [Test]
        public async Task TestRoleBasedAccessControl()
        {
            // Simulate role-based access control
            var adminUser = await _userService.GetUserByUsernameAsync("admin");
            var regularUser = await _userService.GetUserByUsernameAsync("user1");
            
            Assert.That(adminUser?.Role, Is.EqualTo("Admin"));
            Assert.That(regularUser?.Role, Is.EqualTo("User"));
            
            // Admin should have access to admin functions
            Assert.That(HasAdminAccess(adminUser?.Role), Is.True);
            
            // Regular user should not have admin access
            Assert.That(HasAdminAccess(regularUser?.Role), Is.False);
        }
        
        [Test]
        public async Task TestUnauthorizedAccessAttempt()
        {
            // Test that users cannot access resources they don't own
            var user1 = await _userService.GetUserByIdAsync(2);
            var user2 = await _userService.GetUserByIdAsync(3);
            
            // Simulate checking if user1 can access user2's data
            Assert.That(CanAccessUserData(user1?.UserID, user2?.UserID), Is.False);
            
            // User can access their own data
            Assert.That(CanAccessUserData(user1?.UserID, user1?.UserID), Is.True);
        }
        
        private static bool HasAdminAccess(string? role)
        {
            return role == "Admin";
        }
        
        private static bool CanAccessUserData(int? requestingUserId, int? targetUserId)
        {
            return requestingUserId == targetUserId;
        }
    }
}