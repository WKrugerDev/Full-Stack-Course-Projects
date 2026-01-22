using EventEase.Models;

namespace EventEase.Services
{
    public class EventService
    {
        private List<Event> events;
        public EventService()
        {
            
            // Initialize with 3 example events
            events = new List<Event>
            {
                new Event { Id = 1, Name = "Christmas", Date = new DateTime(2025, 12, 25), Location = "Cape Town" },
                new Event { Id = 2, Name = "Boxing Day", Date = new DateTime(2025, 12, 26), Location = "Johannesburg" },
                new Event { Id = 3, Name = "New Year's Day", Date = new DateTime(2026, 1, 1), Location = "Durban" }
            };
        }

        public Task<List<Event>> GetEventsAsync()
        {
            // Simulate async data retrieval
            return Task.FromResult(events);
        }

        public Task<Event?> GetEventByIdAsync(int id)
        {
            var evt = events.FirstOrDefault(e => e.Id == id);
            return Task.FromResult(evt);
        }

        public Task AddEventAsync(Event newEvent)
        {
            newEvent.Id = events.Any() ? events.Max(e => e.Id) + 1 : 1;
            events.Add(newEvent);
            return Task.CompletedTask;
        }

    }
}