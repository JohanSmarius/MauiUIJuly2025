namespace MauiAIJuly.Models
{
    public class Event
    {
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Address { get; set; }
        public string Client { get; set; }
        public int VolunteersNeeded { get; set; }
        public string State { get; set; }
    }
}
