// <copyright file="NeuerVereinPage.xaml.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

using System;
using Wettkampf.Models;
using Xamarin.Forms;
using Wettkampf.Services;

namespace Wettkampf.Views
{
  public partial class NeuerVereinPage : ContentPage
  {
      private readonly IVereinSaver _vereinSaver;
        public Verein Verein { get; set; }

    public NeuerVereinPage()
    {
      InitializeComponent();

      _vereinSaver = App.Services.GetInstance<IVereinSaver>();
            Verein = new Verein();

      BindingContext = this;
    }

    private async void Save_Clicked(object sender, EventArgs e)
    {
        if (await _vereinSaver.TrySaveAsync(Verein))
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