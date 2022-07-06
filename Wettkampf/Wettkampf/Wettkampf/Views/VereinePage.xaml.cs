using System;
using System.Collections.Generic;
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
      public VereinePage(string accountname)
    {
      InitializeComponent();

      BindingContext = _viewModel = new VereineViewModel();
      accountName = accountname;
      if (accountname == "User")
      {
          BTN_Add.IsEnabled = false;
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
      await Navigation.PushAsync(new VereinDetailPage(new VereinDetailViewModel(album), accountName));
    }

    private async void AddAlbumClicked(object sender, EventArgs e)
    {
      await Navigation.PushModalAsync(new NavigationPage(new NeuerVereinPage()));
    }

    private void DeleteAllClicked(object sender, EventArgs e)
    {
        MessagingCenter.Send<object>(this, "DeleteAllItem");
    }

    private void GenerateClicked(object sender, EventArgs e)
    {
        MessagingCenter.Send<object>(this, "GenerateItems");

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
        return _viewModel.Items.Where(f => f.Vorname.ToLower().Contains(normalizedQuery)).ToList();
    }
        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            ItemsCollectionView.ItemsSource = GetSearchResults(e.NewTextValue);
        }
  }
}
