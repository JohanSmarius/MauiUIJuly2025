using MauiAIJuly.Models;

namespace MauiAIJuly.Services
{
    public interface IVolunteerService
    {
        Task<IEnumerable<Volunteer>> GetVolunteersAsync();
        Task<IEnumerable<Volunteer>> GetTopVolunteersAsync(int count = 10);
        Task<Volunteer> GetVolunteerByIdAsync(string id);
        Task<bool> AddVolunteerAsync(Volunteer volunteer);
        Task<bool> UpdateVolunteerAsync(Volunteer volunteer);
    }
}
