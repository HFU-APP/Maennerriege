// <copyright file="VereinDetailPage.xaml.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

using Wettkampf.Models;
using Wettkampf.ViewModels;
using Xamarin.Forms;

namespace Wettkampf.Views
{
  public partial class VereinDetailPage : ContentPage
  {
    private readonly VereinDetailViewModel _viewModel;

    public VereinDetailPage(VereinDetailViewModel viewModel)
    {
      InitializeComponent();

      BindingContext = _viewModel = viewModel;
    }

    public VereinDetailPage()
    {
      InitializeComponent();

      var album = new Verein
      {
        Title = "Verein 1",
        Description = "This is an Verein description."
      };

      _viewModel = new VereinDetailViewModel(album);
      BindingContext = _viewModel;
    }
  }
}
