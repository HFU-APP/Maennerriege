// <copyright file="NeueDisziplinPage.xaml.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

using System;
using Wettkampf.Models;
using Xamarin.Forms;
using Wettkampf.Services;

namespace Wettkampf.Views
{
  public partial class NeueDisziplinPage : ContentPage
  {
      private readonly IDisziplinSaver disziplinSaver;
        public Disziplin Disziplin { get; set; }

    public NeueDisziplinPage()
    {
      InitializeComponent();

      disziplinSaver = App.Services.GetInstance<IDisziplinSaver>();
            Disziplin = new Disziplin();

      BindingContext = this;
    }

    private async void Save_Clicked(object sender, EventArgs e)
    {
        if (await disziplinSaver.TrySaveAsync(Disziplin))
        {
            MessagingCenter.Send(this, "AddItem", Disziplin);
            await Navigation.PopModalAsync();
        }
        }

    private async void Cancel_Clicked(object sender, EventArgs e)
    {
        if (await disziplinSaver.TrySaveAsync(Disziplin))
        {
            MessagingCenter.Send(this, "AddItem", Disziplin);
            await Navigation.PopModalAsync();
        }
        }
  }
}