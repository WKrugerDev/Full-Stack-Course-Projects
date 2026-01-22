using System;

namespace EventEase.Services
{
    public class AppState
    {
        public int? SelectedEventId { get; private set; }
        public string? CurrentUser { get; private set; }
        public DateTime LastActivity { get; private set; }
        public bool IsLoggedIn => !string.IsNullOrEmpty(CurrentUser);

        public event Action? OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();

        // Track when an event is selected
        public void SelectEvent(int eventId)
        {
            SelectedEventId = eventId;
            LastActivity = DateTime.Now;
            Console.WriteLine($"[AppState] Event {eventId} selected at {LastActivity}");
            NotifyStateChanged();
        }

        // Track when user logs in
        public void Login(string username)
        {
            CurrentUser = username;
            LastActivity = DateTime.Now;
            Console.WriteLine($"[AppState] User '{username}' logged in at {LastActivity}");
            NotifyStateChanged();
        }

        // Track when user logs out
        public void Logout()
        {
            Console.WriteLine($"[AppState] User '{CurrentUser}' logged out at {DateTime.Now}");
            CurrentUser = null;
            LastActivity = DateTime.Now;
            NotifyStateChanged();
        }

        // Optional: update activity timestamp (for session tracking)
        public void UpdateActivity()
        {
            LastActivity = DateTime.Now;
            Console.WriteLine($"[AppState] Activity updated at {LastActivity}");
            NotifyStateChanged();
        }
    }
}
