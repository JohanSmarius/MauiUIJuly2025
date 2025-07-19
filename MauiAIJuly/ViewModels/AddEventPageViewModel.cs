using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiAIJuly.Models;
using System;

namespace MauiAIJuly.ViewModels
{
    public partial class AddEventPageViewModel : ObservableObject
    {
        [ObservableProperty] string name;
        [ObservableProperty] string client;
        [ObservableProperty] string address;
        [ObservableProperty] DateTime startDate = DateTime.Today;
        [ObservableProperty] TimeSpan startTime = DateTime.Now.TimeOfDay;
        [ObservableProperty] DateTime endDate = DateTime.Today;
        [ObservableProperty] TimeSpan endTime = DateTime.Now.TimeOfDay;
        [ObservableProperty] int volunteersNeeded;

        [RelayCommand]
        public void AddEvent()
        {
            // Add event logic here
        }
    }
}
