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
        ObservableCollection<Volunteer> volunteers = new();

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
            LoadVolunteersAsync().ConfigureAwait(false);
        }

        [RelayCommand]
        private async Task RefreshAsync()
        {
            IsRefreshing = true;
            await LoadVolunteersAsync();
            IsRefreshing = false;
        }

        private async Task LoadVolunteersAsync()
        {
            try
            {
                var volunteersList = await _volunteerService.GetTopVolunteersAsync();

                MainThread.BeginInvokeOnMainThread(() =>
                {
                    Volunteers.Clear();
                    foreach (var volunteer in volunteersList)
                    {
                        Volunteers.Add(volunteer);
                    }

                    TotalVolunteers = Volunteers.Count;
                    TotalCompletedShifts = Volunteers.Sum(v => v.CompletedShifts);
                });
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error loading volunteers: {ex.Message}";
                System.Diagnostics.Debug.WriteLine($"Error loading volunteers: {ex.Message}");
            }
        }
    }
}
