// <copyright file="AlbumDetailPage.xaml.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

using Wettkampf.Models;
using Wettkampf.ViewModels;
using Xamarin.Forms;

namespace Wettkampf.Views
{
  public partial class AlbumDetailPage : ContentPage
  {
    private readonly AlbumDetailViewModel _viewModel;

    public AlbumDetailPage(AlbumDetailViewModel viewModel)
    {
      InitializeComponent();

      BindingContext = _viewModel = viewModel;
    }

    public AlbumDetailPage()
    {
      InitializeComponent();

      var album = new Album
      {
        Title = "Album 1",
        Description = "This is an Album description."
      };

      _viewModel = new AlbumDetailViewModel(album);
      BindingContext = _viewModel;
    }
  }
}
