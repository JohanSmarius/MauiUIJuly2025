using MauiAIJuly.ViewModels;


namespace MauiAIJuly.Views;
public partial class AddEventPage : ContentPage
{
    public AddEventPage(AddEventPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}

