using EventEase.Models;

namespace EventEase.Services;

public class AttendanceService
{
    private readonly List<AttendanceRecord> _attendanceRecords = new();
    private int _nextId = 1;

    public Task<bool> RegisterAttendeeAsync(int eventId, string userName, string userEmail)
    {
        var existingRecord = _attendanceRecords.FirstOrDefault(r => r.EventId == eventId && r.UserEmail == userEmail);
        
        if (existingRecord != null)
        {
            return Task.FromResult(false); // Already registered
        }

        var record = new AttendanceRecord
        {
            Id = _nextId++,
            EventId = eventId,
            UserName = userName,
            UserEmail = userEmail,
            RegistrationDate = DateTime.Now,
            IsAttended = false
        };

        _attendanceRecords.Add(record);
        return Task.FromResult(true);
    }

    public Task<List<AttendanceRecord>> GetEventAttendeesAsync(int eventId)
    {
        var attendees = _attendanceRecords.Where(r => r.EventId == eventId).ToList();
        return Task.FromResult(attendees);
    }

    public Task<int> GetAttendeeCountAsync(int eventId)
    {
        var count = _attendanceRecords.Count(r => r.EventId == eventId);
        return Task.FromResult(count);
    }

    public Task<bool> IsUserRegisteredAsync(int eventId, string userEmail)
    {
        var isRegistered = _attendanceRecords.Any(r => r.EventId == eventId && r.UserEmail == userEmail);
        return Task.FromResult(isRegistered);
    }
}