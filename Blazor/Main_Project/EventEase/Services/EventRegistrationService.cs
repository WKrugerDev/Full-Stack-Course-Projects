using EventEase.Models;

namespace EventEase.Services
{
    public class EventRegistrationService
    {
        private readonly List<EventRegistration> registrations = new();

        // Add a new registration
        public Task AddRegistrationAsync(EventRegistration registration)
        {
            registrations.Add(registration);
            return Task.CompletedTask;
        }

        // Get all registrations for a specific event
        public Task<List<EventRegistration>> GetRegistrationsForEventAsync(int eventId)
        {
            var result = registrations.Where(r => r.EventId == eventId).ToList();
            return Task.FromResult(result);
        }
    }
}
