using MauiAIJuly.Models;

namespace MauiAIJuly.Services
{
    public interface IEventService
    {
        Task<IEnumerable<Event>> GetEventsAsync();
        Task<IEnumerable<Event>> GetPastEventsAsync();
        Task<IEnumerable<Event>> GetFutureEventsAsync();
        Task<Event> GetEventByIdAsync(string id);
        Task<bool> AddEventAsync(Event newEvent);
        Task<bool> UpdateEventAsync(Event updatedEvent);
        Task<bool> DeleteEventAsync(string id);
    }
}
