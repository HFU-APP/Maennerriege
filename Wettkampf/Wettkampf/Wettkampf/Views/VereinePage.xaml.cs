// <copyright file="VereinePage.xaml.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Wettkampf.Models;
using Wettkampf.ViewModels;
using Xamarin.Forms;

namespace Wettkampf.Views
{
  public partial class VereinePage : ContentPage
  {
      public Verein Verein { get; set; }
      private readonly VereineViewModel _viewModel;

    public VereinePage(string accountname)
    {
      InitializeComponent();

      BindingContext = _viewModel = new VereineViewModel();

      if (accountname == "User")
      {
          BTN_Add.IsEnabled = false;
          BTN_Delete.IsEnabled = false;
          BTN_DeleteAll.IsEnabled = false;
          BTN_Generate.IsEnabled = false;
      }
    }

    public VereinePage()
    {
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
    private void DeleteAllClicked(object sender, EventArgs e)
    {
        MessagingCenter.Send<object>(this, "DeleteAllItem");
    }

    private async void GenerateClicked(object sender, EventArgs e)
    {
            //MessagingCenter.Send<object>(this, "GenerateNewItems");
            Verein = new Verein(){Name = "Muster", Vorname = "Hans"};
            MessagingCenter.Send(this, "AddItem", Verein);
            await Navigation.PopToRootAsync();
        }

    protected override void OnAppearing()
    { 
        base.OnAppearing(); 
        if (_viewModel.Items.Count == 0)
        {
         _viewModel.IsBusy = true;
        }
    }
    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var eingabe = e.NewTextValue;
            Debug.WriteLine(eingabe);

            if (string.IsNullOrWhiteSpace(eingabe))
            {
                eingabe = string.Empty;
                Debug.WriteLine(eingabe);
            }

            eingabe = eingabe.ToLower();

            var gefilterteItems = _viewModel.Items.Where(value => value.Vorname.Contains(eingabe)).ToList();

            foreach (var element3 in gefilterteItems)
            {
                Debug.WriteLine(element3.Vorname);
            }

            if (string.IsNullOrWhiteSpace(eingabe))
            {
                gefilterteItems = _viewModel.Items.ToList();
            }

            foreach (var element in _viewModel.Items.ToList())
            {
                if (!gefilterteItems.Contains(element))
                {
                    _viewModel.Items.Remove(element);
                    Debug.WriteLine(element.Vorname);
                }
                else if (!_viewModel.Items.Contains(element))
                {
                    _viewModel.Items.Add(element);
                }
            }
        }
    }
}
