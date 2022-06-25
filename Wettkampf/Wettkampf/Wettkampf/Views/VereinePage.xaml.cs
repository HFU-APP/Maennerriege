// <copyright file="VereinePage.xaml.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

using System;
using Wettkampf.Models;
using Wettkampf.Services;
using Wettkampf.ViewModels;
using Xamarin.Forms;

namespace Wettkampf.Views
{
  public partial class VereinePage : ContentPage
  {
    private readonly VereineViewModel _viewModel;

    public VereinePage()
    {
      InitializeComponent();

      BindingContext = _viewModel = new VereineViewModel();
    }

    private async void OnAlbumSelected(object sender, EventArgs args)
    {
      var layout = (BindableObject)sender;
      var album = (Verein)layout.BindingContext;
      await Navigation.PushAsync(new VereinDetailPage(new VereinDetailViewModel(album)));
    }

    private async void AddAlbumClicked(object sender, EventArgs e)
    {
      await Navigation.PushModalAsync(new NavigationPage(new NeuerVereinPage()));
    }

    private async void DeleteAlbumClicked(object sender, EventArgs e)
    {
        MessagingCenter.Send<object>(this, "DeleteItem");
    }

        protected override void OnAppearing()
    {
      base.OnAppearing();

      if (_viewModel.Items.Count == 0)
      {
        _viewModel.IsBusy = true;
      }
    }
  }
}
