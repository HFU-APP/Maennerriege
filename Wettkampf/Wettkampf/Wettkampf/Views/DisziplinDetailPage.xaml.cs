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
    private readonly DisziplinDetailViewModel _viewModel;

    public VereinDetailPage(DisziplinDetailViewModel viewModel)
    {
      InitializeComponent();

      BindingContext = _viewModel = viewModel;
    }

    public VereinDetailPage()
    {
      InitializeComponent();

      var album = new Disziplin
      {
        Title = "Disziplin 1",
      };

      _viewModel = new DisziplinDetailViewModel(album);
      BindingContext = _viewModel;
    }
  }
}
