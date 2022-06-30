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
      internal string accountName;
      private List<Verein> vereinliste;

      public VereinePage(string accountname)
    {
      InitializeComponent();

      BindingContext = _viewModel = new VereineViewModel();
      accountName = accountname;
      if (accountname == "User")
      {
          BTN_Add.IsEnabled = false;
          BTN_Delete.IsEnabled = false;
          BTN_DeleteAll.IsEnabled = false;
          BTN_Generate.IsEnabled = false;
      }

      vereinliste = new List<Verein>();
      //ItemsCollectionView.ItemsSource = GetSearchResults(searchBar.Text);
    }

    public VereinePage()
    {
    }

    private async void OnAlbumSelected(object sender, EventArgs args)
    {
      var layout = (BindableObject)sender;
      var album = (Verein)layout.BindingContext;
      await Navigation.PushAsync(new VereinDetailPage(new VereinDetailViewModel(album), accountName));
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
    public List<Verein> GetSearchResults(string queryString)
    {
        var normalizedQuery = queryString?.ToLower() ?? "";
        return _viewModel.Items.Where(f => f.Vorname.Contains(normalizedQuery)).ToList();
    }
        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            //var suchwort = e.NewTextValue;
            //Debug.WriteLine(suchwort);

            //if (string.IsNullOrWhiteSpace(suchwort))
            //{
            //    suchwort = string.Empty;
            //    Debug.WriteLine(suchwort);
            //}

            //suchwort = suchwort.ToLower();

            //var uebereinstimmendeItems = _viewModel.Items.Where(value => value.Vorname.Contains(suchwort)).ToList();

            //foreach (var element3 in uebereinstimmendeItems)
            //{
            //    Debug.WriteLine(element3.Vorname);
            //}


            //foreach (var element in _viewModel.Items)
            //{
            //    if (!uebereinstimmendeItems.Contains(element))
            //    {
            //        _viewModel.Items.Remove(element);
            //        //vereinliste.Add(element);

            //        Debug.WriteLine(element.Vorname);
            //    }
            //    else if (!_viewModel.Items.Contains(element))
            //    {
            //        _viewModel.Items.Add(element);
            //        //vereinliste.Remove(element);
            //    }


            //}

            //for (int i = _viewModel.Items.Count - 1; i >= 0; i--)
            //{
            //    if (!uebereinstimmendeItems.Contains(_viewModel.Items[i]))
            //    {
            //        _viewModel.Items.Remove(_viewModel.Items[i]);
            //        //vereinliste.Add(_viewModel.Items[i]);

            //        Debug.WriteLine(_viewModel.Items[i].Vorname);
            //    }
            //    else if (!_viewModel.Items.Contains(_viewModel.Items[i]))
            //    {
            //        _viewModel.Items.Add(_viewModel.Items[i]);
            //        //vereinliste.Remove(_viewModel.Items[i]);
            //    }
            //}
            ItemsCollectionView.ItemsSource = GetSearchResults(e.NewTextValue);
        }
    }
}
