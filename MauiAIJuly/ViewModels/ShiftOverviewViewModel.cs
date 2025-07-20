using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiAIJuly.Models;
using MauiAIJuly.Services;
using System.Collections.ObjectModel;

namespace MauiAIJuly.ViewModels
{
    public partial class ShiftOverviewViewModel : ObservableObject
    {
        private readonly IVolunteerService _volunteerService;
        
        [ObservableProperty]
        ObservableCollection<EventParticipation> eventParticipation = new();

        [ObservableProperty]
        bool isRefreshing;

        [ObservableProperty]
        string statusMessage;

        [ObservableProperty]
        int totalVolunteers;

        [ObservableProperty]
        int totalCompletedShifts;

        public ShiftOverviewViewModel(IVolunteerService volunteerService)
        {
            _volunteerService = volunteerService;
            
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
