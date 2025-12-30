using System.ComponentModel.DataAnnotations;

namespace EventEase.Models{

public class Event
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Event name is required")]
    [StringLength(100, ErrorMessage = "Event name cannot exceed 100 characters")]    
    public string Name { get; set; } = string.Empty;

    

    [Required(ErrorMessage = "Event date and time is required")]
    [DataType(DataType.DateTime)]
    public DateTime Date { get; set; }
    
    [Required(ErrorMessage = "Location is required")]
    [StringLength(100, ErrorMessage = "Location cannot exceed 100 characters")]
    public string Location { get; set; } = string.Empty;
}
}