using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiAIJuly.Models;
using MauiAIJuly.Services;
using System.Collections.ObjectModel;

namespace MauiAIJuly.ViewModels
{
    public partial class ShiftOverviewViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<EventParticipation> eventParticipation = new();

        public ShiftOverviewViewModel()
        {
            for (int i = 1; i <= 5; i++)
            {
                eventParticipation.Add(new EventParticipation
                {
                    Volunteer = $"Volunteer-{i}",
                    TotalNumberOfEventHours = new Random().Next(100)
                });
            }
        }

    }
}
