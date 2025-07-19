namespace MauiAIJuly.Models
{
    public class Volunteer
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int TotalShifts { get; set; }
        public int CompletedShifts { get; set; }
        public int CancelledShifts { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime? LastShiftDate { get; set; }
    }
}
