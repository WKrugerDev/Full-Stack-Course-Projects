using System.ComponentModel.DataAnnotations;

namespace UserAuthApi.Shared;

public class UserBase   
{
    public string? Username { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Surname { get; set; }
    public string? DisplayName { get; set; }
}
