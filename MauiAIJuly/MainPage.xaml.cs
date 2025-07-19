using MauiAIJuly.ViewModels;

namespace MauiAIJuly;

public partial class MainPage : ContentPage
{
	private readonly MainPageViewModel _viewModel;

	public MainPage(MainPageViewModel viewModel)
	{
		_viewModel = viewModel;
		InitializeComponent();
	}

	
}
