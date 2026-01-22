using System.ComponentModel.DataAnnotations;

namespace EventEase.Models
{
    public class EventRegistration
    {
        [Required]
        public int EventId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email address. Must include a valid domain, e.g., .com, .co.uk")]
        public string Email { get; set; } = string.Empty;
    }
}
