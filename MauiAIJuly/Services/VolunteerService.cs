using MauiAIJuly.Models;

namespace MauiAIJuly.Services
{
    public class VolunteerService : IVolunteerService
    {
        private List<Volunteer> _volunteers;

        public VolunteerService()
        {
            // Generate dummy data for volunteers
            _volunteers = GenerateDummyVolunteers(20);
        }

        public async Task<IEnumerable<Volunteer>> GetVolunteersAsync()
        {
            await Task.Delay(200); // Simulate network delay
            return _volunteers;
        }

        public async Task<IEnumerable<Volunteer>> GetTopVolunteersAsync(int count = 10)
        {
            var volunteers = await GetVolunteersAsync();
            return volunteers.OrderByDescending(v => v.CompletedShifts).Take(count);
        }

        public async Task<Volunteer> GetVolunteerByIdAsync(string id)
        {
            await Task.Delay(100);
            return _volunteers.FirstOrDefault(v => v.Id == id);
        }

        public async Task<bool> AddVolunteerAsync(Volunteer volunteer)
        {
            await Task.Delay(100);
            _volunteers.Add(volunteer);
            return true;
        }

        public async Task<bool> UpdateVolunteerAsync(Volunteer volunteer)
        {
            await Task.Delay(100);
            var existingVolunteer = _volunteers.FirstOrDefault(v => v.Id == volunteer.Id);
            if (existingVolunteer != null)
            {
                existingVolunteer.Name = volunteer.Name;
                existingVolunteer.Email = volunteer.Email;
                existingVolunteer.Phone = volunteer.Phone;
                existingVolunteer.TotalShifts = volunteer.TotalShifts;
                existingVolunteer.CompletedShifts = volunteer.CompletedShifts;
                existingVolunteer.CancelledShifts = volunteer.CancelledShifts;
                existingVolunteer.LastShiftDate = volunteer.LastShiftDate;
                return true;
            }
            return false;
        }

        private List<Volunteer> GenerateDummyVolunteers(int count)
        {
            var random = new Random();
            var volunteers = new List<Volunteer>();
            var firstNames = new[] { "John", "Jane", "Michael", "Emily", "David", "Sarah", "James", "Emma", "Daniel", "Olivia" };
            var lastNames = new[] { "Smith", "Johnson", "Williams", "Jones", "Brown", "Davis", "Miller", "Wilson", "Taylor", "Clark" };

            var today = DateTime.Now;

            for (int i = 0; i < count; i++)
            {
                var firstName = firstNames[random.Next(firstNames.Length)];
                var lastName = lastNames[random.Next(lastNames.Length)];
                var name = $"{firstName} {lastName}";
                var email = $"{firstName.ToLower()}.{lastName.ToLower()}@example.com";

                var joinDate = today.AddDays(-random.Next(30, 365));
                var totalShifts = random.Next(1, 50);
                var completedShifts = random.Next(1, totalShifts);
                var cancelledShifts = random.Next(0, totalShifts - completedShifts);
                var lastShiftDate = joinDate.AddDays(random.Next(1, (int)(today - joinDate).TotalDays));

                volunteers.Add(new Volunteer
                {
                    Name = name,
                    Email = email,
                    Phone = $"{random.Next(100, 999)}-{random.Next(100, 999)}-{random.Next(1000, 9999)}",
                    TotalShifts = totalShifts,
                    CompletedShifts = completedShifts,
                    CancelledShifts = cancelledShifts,
                    JoinDate = joinDate,
                    LastShiftDate = lastShiftDate
                });
            }

            return volunteers;
        }
    }
}
