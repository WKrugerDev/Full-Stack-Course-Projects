using UserAuthApi.Shared; 

namespace UserAuthApi.Api.DTOs
{
    public class RegisterDto : UserBase
    {
        public string? DisplayName { get; set; }
        public string Password { get; set; } = string.Empty;
        //Username from Userbase = login identifier
    }
}