using MauiAIJuly.ViewModels;


namespace MauiAIJuly.Views;
public partial class AddEventPageSyncfusion : ContentPage
{
    public AddEventPageSyncfusion(AddEventPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}

