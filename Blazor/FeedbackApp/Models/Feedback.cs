using System.ComponentModel.DataAnnotations;

namespace FeedbackApp.Models
{
    public class Feedback
    {
        [Required(ErrorMessage = "Name is required.")]
        public string UserName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Email is required.")] 
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; } = string.Empty;

        [MaxLength(500, ErrorMessage = "Comment cannot exceed 500 characters.")]
        public string Comment { get; set; } = string.Empty;
       
        public DateTime SubmittedAt { get; set; }// Timestamp of when the feedback was submitted
    }
}