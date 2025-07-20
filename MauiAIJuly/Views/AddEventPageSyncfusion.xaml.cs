using MauiAIJuly.ViewModels;


namespace MauiAIJuly.Views;
public partial class AddEventPageSyncfusion : ContentPage
{
    public AddEventPageSyncfusion(AddEventPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    private void OnPickClicked(object sender, EventArgs e)
    {
        popup.Show();
    }

    private void OnDateSelected(object sender, EventArgs e)
    {
        popup.IsOpen = false;
    }
}

