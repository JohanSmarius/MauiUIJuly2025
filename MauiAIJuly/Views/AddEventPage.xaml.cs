namespace MauiAIJuly.Views;

public partial class AddEventPage : ContentPage
{
    public AddEventPage()
    {
        InitializeComponent();
        BindingContext = new ViewModels.AddEventPageViewModel();
    }
}
