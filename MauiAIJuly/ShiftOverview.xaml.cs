using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiAIJuly.ViewModels;

namespace MauiAIJuly;

public partial class ShiftOverview : ContentPage
{
    public ShiftOverview(ShiftOverviewViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
