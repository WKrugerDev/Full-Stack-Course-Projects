namespace EventEase.Models;

public class AttendanceRecord
{
    public int Id { get; set; }
    public int EventId { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string UserEmail { get; set; } = string.Empty;
    public DateTime RegistrationDate { get; set; }
    public bool IsAttended { get; set; }
}