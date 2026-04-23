using Microsoft.AspNetCore.Identity;

namespace UserAuthApi.Api.Models;

public class ApplicationUser : IdentityUser
{
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string? DisplayName { get; set; } //optional, nullable
}