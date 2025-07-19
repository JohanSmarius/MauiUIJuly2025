using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiAIJuly.Models;
using MauiAIJuly.Services;
using System.Collections.ObjectModel;

namespace MauiAIJuly.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        private readonly IEventService _eventService;

        [ObservableProperty]
        ObservableCollection<Event> futureEvents = new();

        [ObservableProperty]
        ObservableCollection<Event> pastEvents = new();

        [ObservableProperty]
        bool isRefreshing;

        public MainPageViewModel(IEventService eventService)
        {
            _eventService = eventService;
            _eventService.EventsChanged += OnEventsChanged;
            LoadEventsAsync().ConfigureAwait(false);
        }

        // Clean up event subscriptions when the view model is no longer needed
        ~MainPageViewModel()
        {
            if (_eventService != null)
            {
                _eventService.EventsChanged -= OnEventsChanged;
            }
        }

        private void OnEventsChanged(object sender, EventArgs e)
        {
            LoadEventsAsync().ConfigureAwait(false);
        }

        [RelayCommand]
        private async Task RefreshAsync()
        {
            IsRefreshing = true;
            await LoadEventsAsync();
            IsRefreshing = false;
        }

        private async Task LoadEventsAsync()
        {
            try
            {
                var now = DateTime.Now;
                var allEvents = await _eventService.GetEventsAsync();

                MainThread.BeginInvokeOnMainThread(() =>
                {
                    FutureEvents.Clear();
                    PastEvents.Clear();

                    foreach (var ev in allEvents)
                    {
                        if (ev.End < now)
                            PastEvents.Add(ev);
                        else
                            FutureEvents.Add(ev);
                    }
                });
            }
            catch (Exception ex)
            {
                // In a real app, we would log this error and possibly show a message to the user
                System.Diagnostics.Debug.WriteLine($"Error loading events: {ex.Message}");
            }
        }
    }
}
