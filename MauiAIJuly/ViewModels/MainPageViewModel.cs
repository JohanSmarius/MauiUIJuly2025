using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiAIJuly.Models;
using System.Collections.ObjectModel;

namespace MauiAIJuly.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Event> futureEvents = new();

        [ObservableProperty]
        ObservableCollection<Event> pastEvents = new();

        [ObservableProperty]
        bool isRefreshing;

        public MainPageViewModel()
        {
            LoadEvents();
        }

        [RelayCommand]
        private void Refresh()
        {
            IsRefreshing = true;
            LoadEvents();
            IsRefreshing = false;
        }

        private void LoadEvents()
        {
            FutureEvents.Clear();
            PastEvents.Clear();
            var now = DateTime.Now;
            var allEvents = new List<Event>
            {
                new Event { Name = "Charity Run", Start = now, End = now.AddHours(4), Address = "123 Main St", Client = "Red Cross", VolunteersNeeded = 4, State = "Requested" },
                new Event { Name = "Health Fair", Start = now.AddDays(1), End = now.AddDays(1).AddHours(6), Address = "456 Elm St", Client = "Local Hospital", VolunteersNeeded = 6, State = "Confirmed" },
                new Event { Name = "Completed Event", Start = now.AddDays(-2), End = now.AddDays(-2).AddHours(3), Address = "789 Oak St", Client = "Charity Org", VolunteersNeeded = 2, State = "Confirmed" }
            };
            foreach (var ev in allEvents)
            {
                if (ev.End < now)
                    PastEvents.Add(ev);
                else
                    FutureEvents.Add(ev);
            }
        }
    }
}
