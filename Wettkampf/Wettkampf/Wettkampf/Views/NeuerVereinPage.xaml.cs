// <copyright file="NeuerVereinPage.xaml.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

using System;
using Wettkampf.Models;
using Xamarin.Forms;

namespace Wettkampf.Views
{
  public partial class NeuerVereinPage : ContentPage
  {
    public Verein Verein { get; set; }

    public NeuerVereinPage()
    {
      InitializeComponent();

      Verein = new Verein();

      BindingContext = this;
    }

    private async void Save_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Verein.Title))
        {
            await DisplayAlert("Validation failed", "The title cannot be empty.", "OK");
        }
        else if (string.IsNullOrEmpty(Verein.Description))
        {
            await DisplayAlert("Validation failed", "The description cannot be empty.", "OK");
        }
        else
        {
            MessagingCenter.Send(this, "AddItem", Verein);
            await Navigation.PopModalAsync();
        }
    }

    private async void Cancel_Clicked(object sender, EventArgs e)
    {
      await Navigation.PopModalAsync();
    }
  }
}