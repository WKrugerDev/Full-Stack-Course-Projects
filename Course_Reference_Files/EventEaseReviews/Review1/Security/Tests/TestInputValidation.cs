using NUnit.Framework;
using SafeVault.Services;

namespace SafeVault.Tests
{
    [TestFixture]
    public class TestInputValidation
    {
        [Test]
        public void TestForSQLInjection()
        {
            // Test SQL injection attempts
            string[] maliciousInputs = {
                "'; DROP TABLE Users; --",
                "admin'; DELETE FROM Users WHERE '1'='1",
                "' OR '1'='1",
                "'; INSERT INTO Users VALUES ('hacker', 'hack@evil.com'); --",
                "admin'/**/OR/**/1=1--"
            };
            
            foreach (var input in maliciousInputs)
            {
                var sanitized = InputValidationService.SanitizeInput(input);
                
                // Verify SQL injection patterns are removed
                Assert.That(sanitized, Does.Not.Contain("'"));
                Assert.That(sanitized, Does.Not.Contain("--"));
                Assert.That(sanitized, Does.Not.Contain("DROP"));
                Assert.That(sanitized, Does.Not.Contain("DELETE"));
                Assert.That(sanitized, Does.Not.Contain("INSERT"));
                Assert.That(sanitized, Does.Not.Contain("SELECT"));
            }
        }
        
        [Test]
        public void TestForXSS()
        {
            // Test XSS attack attempts
            string[] xssInputs = {
                "<script>alert('XSS')</script>",
                "<img src=x onerror=alert('XSS')>",
                "javascript:alert('XSS')",
                "<svg onload=alert('XSS')>",
                "<iframe src='javascript:alert(\"XSS\")'></iframe>"
            };
            
            foreach (var input in xssInputs)
            {
                var sanitized = InputValidationService.PreventXSS(input);
                
                // Verify XSS patterns are neutralized
                Assert.That(sanitized, Does.Not.Contain("<script"));
                Assert.That(sanitized, Does.Not.Contain("javascript:"));
                Assert.That(sanitized, Does.Not.Contain("onerror="));
                Assert.That(sanitized, Does.Not.Contain("onload="));
            }
        }
        
        [Test]
        public void TestValidUsernameValidation()
        {
            // Test valid usernames
            string[] validUsernames = { "user123", "test_user", "admin", "user_123" };
            
            foreach (var username in validUsernames)
            {
                Assert.That(InputValidationService.IsValidUsername(username), Is.True);
            }
        }
        
        [Test]
        public void TestInvalidUsernameValidation()
        {
            // Test invalid usernames
            string[] invalidUsernames = { "us", "", "user@domain", "user space", "user-name", "a".PadRight(101, 'a') };
            
            foreach (var username in invalidUsernames)
            {
                Assert.That(InputValidationService.IsValidUsername(username), Is.False);
            }
        }
        
        [Test]
        public void TestValidEmailValidation()
        {
            // Test valid emails
            string[] validEmails = { "test@example.com", "user.name@domain.org", "admin@company.co.uk" };
            
            foreach (var email in validEmails)
            {
                Assert.That(InputValidationService.IsValidEmail(email), Is.True);
            }
        }
        
        [Test]
        public void TestInvalidEmailValidation()
        {
            // Test invalid emails
            string[] invalidEmails = { "invalid", "@domain.com", "user@", "user space@domain.com" };
            
            foreach (var email in invalidEmails)
            {
                Assert.That(InputValidationService.IsValidEmail(email), Is.False);
            }
        }
        
        [Test]
        public void TestPasswordValidation()
        {
            // Test valid passwords
            Assert.That(InputValidationService.IsValidPassword("password123"), Is.True);
            Assert.That(InputValidationService.IsValidPassword("Test123"), Is.True);
            
            // Test invalid passwords
            Assert.That(InputValidationService.IsValidPassword("12345"), Is.False); // Too short
            Assert.That(InputValidationService.IsValidPassword("password"), Is.False); // No numbers
            Assert.That(InputValidationService.IsValidPassword("123456"), Is.False); // No letters
            Assert.That(InputValidationService.IsValidPassword(""), Is.False); // Empty
        }
    }
}