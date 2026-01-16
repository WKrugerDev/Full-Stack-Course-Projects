using System.Text.RegularExpressions;
using System.Web;

namespace SafeVault.Services
{
    public class InputValidationService
    {
        private static readonly Regex UsernameRegex = new(@"^[a-zA-Z0-9_]{3,100}$", RegexOptions.Compiled);
        private static readonly Regex EmailRegex = new(@"^[^\s@]+@[^\s@]+\.[^\s@]+$", RegexOptions.Compiled);
        
        public static string SanitizeInput(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;
                
            // Remove potentially dangerous characters
            input = input.Trim();
            input = HttpUtility.HtmlEncode(input);
            
            // Remove SQL injection patterns
            string[] sqlPatterns = { "'", "\"", ";", "--", "/*", "*/", "xp_", "sp_", "DROP", "DELETE", "INSERT", "UPDATE", "SELECT" };
            foreach (var pattern in sqlPatterns)
            {
                input = input.Replace(pattern, "", StringComparison.OrdinalIgnoreCase);
            }
            
            return input;
        }
        
        public static bool IsValidUsername(string username)
        {
            return !string.IsNullOrEmpty(username) && UsernameRegex.IsMatch(username);
        }
        
        public static bool IsValidEmail(string email)
        {
            return !string.IsNullOrEmpty(email) && EmailRegex.IsMatch(email) && email.Length <= 100;
        }
        
        public static bool IsValidPassword(string password)
        {
            return !string.IsNullOrEmpty(password) && 
                   password.Length >= 6 && 
                   password.Length <= 100 &&
                   password.Any(char.IsLetter) &&
                   password.Any(char.IsDigit);
        }
        
        public static string PreventXSS(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;
                
            // Encode HTML entities
            input = HttpUtility.HtmlEncode(input);
            
            // Remove script tags and javascript
            input = Regex.Replace(input, @"<script[^>]*>.*?</script>", "", RegexOptions.IgnoreCase);
            input = Regex.Replace(input, @"javascript:", "", RegexOptions.IgnoreCase);
            input = Regex.Replace(input, @"on\w+\s*=", "", RegexOptions.IgnoreCase);
            
            return input;
        }
    }
}