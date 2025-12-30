using EventEase.Models;

namespace EventEase.Services;

public class EventService
{
    private readonly List<Event> _events = new()
    {
        new Event { Id = 1, Name = "Tech Conference 2024", Date = DateTime.Now.AddDays(30), Location = "Seattle, WA", Description = "Annual technology conference featuring the latest innovations." },
        new Event { Id = 2, Name = "Marketing Summit", Date = DateTime.Now.AddDays(45), Location = "New York, NY", Description = "Strategic marketing insights and networking opportunities." },
        new Event { Id = 3, Name = "Product Launch", Date = DateTime.Now.AddDays(60), Location = "San Francisco, CA", Description = "Exclusive product launch event with live demonstrations." }
    };

    public Task<List<Event>> GetEventsAsync()
    {
        return Task.FromResult(_events.ToList());
    }

    public Task<Event?> GetEventByIdAsync(int id)
    {
        var eventItem = _events.FirstOrDefault(e => e.Id == id);
        return Task.FromResult(eventItem);
    }

    public Task<bool> IsValidEventIdAsync(int id)
    {
        return Task.FromResult(_events.Any(e => e.Id == id));
    }
}