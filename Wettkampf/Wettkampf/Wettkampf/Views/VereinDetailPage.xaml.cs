// <copyright file="VereinDetailPage.xaml.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

using System;
using System.Diagnostics;
using Wettkampf.Models;
using Wettkampf.Services;
using Wettkampf.ViewModels;
using Xamarin.Forms;

namespace Wettkampf.Views
{
  public partial class VereinDetailPage : ContentPage
  {
      private readonly VereinDetailViewModel _viewModel;


      public VereinDetailPage(VereinDetailViewModel viewModel, string accountname)
    {
      InitializeComponent();

      BindingContext = _viewModel = viewModel;

      if (accountname == "User")
      {
          Editor_Nachname.IsEnabled = false;
          Editor_Vorname.IsEnabled = false;
          Editor_Geburtstag.IsEnabled = false;
          Editor_Vereinname.IsEnabled = false;
      }
    }

    //public VereinDetailPage()
    //{
    //  InitializeComponent();

    //  var verein = new Verein
    //  {
    //    Name = "Verein 1",
    //    Vorname = "This is an Verein description."
    //  };

    //  _viewModel = new VereinDetailViewModel(verein);
    //  BindingContext = _viewModel;
    //}

    private async void Save_Clicked(object sender, EventArgs e)
    {
        //var id = _viewModel.Verein.Id;
        //Debug.WriteLine(id);
        //Debug.WriteLine(_viewModel.Verein.ResultatLauf);
        //string[] array = {id, _viewModel.Verein.ResultatLauf};
        Debug.WriteLine(_viewModel.Verein.Id);
        Debug.WriteLine(_viewModel.Verein is Verein);
            //MessagingCenter.Send(this, "UpdateVerein", _viewModel.Verein);
            
            await Navigation.PopToRootAsync();
    }
  }
}
