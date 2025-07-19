using MauiAIJuly.Models;

namespace MauiAIJuly.Services
{
    public class EventService : IEventService
    {
        private List<Event> _events;

        // Event to notify subscribers when events list changes
        public event EventHandler EventsChanged;

        public EventService()
        {
            _events = new List<Event>
            {
                new Event { Name = "Charity Run", Start = DateTime.Now, End = DateTime.Now.AddHours(4), Address = "123 Main St", Client = "Red Cross", VolunteersNeeded = 4, State = "Requested" },
                new Event { Name = "Health Fair", Start = DateTime.Now.AddDays(1), End = DateTime.Now.AddDays(1).AddHours(6), Address = "456 Elm St", Client = "Local Hospital", VolunteersNeeded = 6, State = "Confirmed" },
                new Event { Name = "Food Drive", Start = DateTime.Now.AddDays(-2), End = DateTime.Now.AddDays(-2).AddHours(5), Address = "789 Oak St", Client = "Food Bank", VolunteersNeeded = 8, State = "Completed" },
                new Event { Name = "Beach Cleanup", Start = DateTime.Now.AddDays(3), End = DateTime.Now.AddDays(3).AddHours(3), Address = "Ocean Blvd", Client = "Environmental Group", VolunteersNeeded = 10, State = "Requested" }
            };
        }

        // Method to notify subscribers of changes
        private void NotifyEventsChanged()
        {
            EventsChanged?.Invoke(this, EventArgs.Empty);
        }

        public async Task<IEnumerable<Event>> GetEventsAsync()
        {
            // In a real app, this would fetch from a database or API
            await Task.Delay(300); // Simulate network delay
            return _events;
        }

        public async Task<IEnumerable<Event>> GetPastEventsAsync()
        {
            var events = await GetEventsAsync();
            return events.Where(e => e.End < DateTime.Now);
        }

        public async Task<IEnumerable<Event>> GetFutureEventsAsync()
        {
            var events = await GetEventsAsync();
            return events.Where(e => e.Start > DateTime.Now);
        }

        public async Task<Event> GetEventByIdAsync(string id)
        {
            // In a real app, we would have a unique ID for each event
            // For this demo, we'll just return the first event
            await Task.Delay(100);
            return _events.FirstOrDefault();
        }

        public async Task<bool> AddEventAsync(Event newEvent)
        {
            await Task.Delay(100);
            _events.Add(newEvent);
            NotifyEventsChanged();
            return true;
        }

        public async Task<bool> UpdateEventAsync(Event updatedEvent)
        {
            await Task.Delay(100);
            // In a real app, we would find the event by ID and update it
            // For this demo, we'll just return true
            NotifyEventsChanged();
            return true;
        }

        public async Task<bool> DeleteEventAsync(string id)
        {
            await Task.Delay(100);
            // In a real app, we would find the event by ID and delete it
            // For this demo, we'll just return true
            NotifyEventsChanged();
            return true;
        }
    }
}
