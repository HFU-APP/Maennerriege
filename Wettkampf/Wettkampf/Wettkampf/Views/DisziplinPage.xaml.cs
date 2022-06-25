// <copyright file="DisziplinPage.xaml.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

using System;
using Wettkampf.Models;
using Wettkampf.Services;
using Wettkampf.ViewModels;
using Xamarin.Forms;

namespace Wettkampf.Views
{
  public partial class DisziplinPage : ContentPage
  {
    private readonly DisziplineViewModel _viewModel;
    

        public DisziplinPage()
    {
      InitializeComponent();

      BindingContext = _viewModel = new DisziplineViewModel();
    }

    private async void OnAlbumSelected(object sender, EventArgs args)
    {
      var layout = (BindableObject)sender;
      var album = (Disziplin)layout.BindingContext;
      await Navigation.PushAsync(new VereinDetailPage(new DisziplinDetailViewModel(album)));
    }

    private async void AddAlbumClicked(object sender, EventArgs e)
    {
      await Navigation.PushModalAsync(new NavigationPage(new NeueDisziplinPage()));
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
