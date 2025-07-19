using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiAIJuly.Models;
using MauiAIJuly.Services;
using System;

namespace MauiAIJuly.ViewModels
{
    public partial class AddEventPageViewModel : ObservableObject
    {
        private readonly IEventService _eventService;

        [ObservableProperty] string name;
        [ObservableProperty] string client;
        [ObservableProperty] string address;
        [ObservableProperty] DateTime startDate = DateTime.Today;
        [ObservableProperty] TimeSpan startTime = DateTime.Now.TimeOfDay;
        [ObservableProperty] DateTime endDate = DateTime.Today;
        [ObservableProperty] TimeSpan endTime = DateTime.Now.TimeOfDay;
        [ObservableProperty] int volunteersNeeded;
        [ObservableProperty] string statusMessage;
        [ObservableProperty] bool isBusy;

        public AddEventPageViewModel(IEventService eventService)
        {
            _eventService = eventService;
        }

        [RelayCommand]
        public async Task AddEventAsync()
        {
            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Client) || string.IsNullOrWhiteSpace(Address))
            {
                StatusMessage = "Please fill in all required fields";
                return;
            }

            IsBusy = true;
            StatusMessage = "Adding event...";

            try
            {
                var newEvent = new Event
                {
                    Name = Name,
                    Client = Client,
                    Address = Address,
                    Start = startDate.Date.Add(startTime),
                    End = endDate.Date.Add(endTime),
                    VolunteersNeeded = VolunteersNeeded,
                    State = "Requested"
                };

                var success = await _eventService.AddEventAsync(newEvent);

                if (success)
                {
                    // Clear form fields after successful addition
                    Name = string.Empty;
                    Client = string.Empty;
                    Address = string.Empty;
                    StartDate = DateTime.Today;
                    StartTime = DateTime.Now.TimeOfDay;
                    EndDate = DateTime.Today;
                    EndTime = DateTime.Now.TimeOfDay;
                    VolunteersNeeded = 0;
                    StatusMessage = "Event added successfully!";

                    // In a real app, we would navigate back to the events list
                    // Example: await Shell.Current.GoToAsync("...");
                }
                else
                {
                    StatusMessage = "Failed to add event. Please try again.";
                }
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
