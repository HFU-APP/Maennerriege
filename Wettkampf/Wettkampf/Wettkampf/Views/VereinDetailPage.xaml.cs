using System;
using Wettkampf.Models;
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
          Editor_Vereinname.IsEnabled = false;
          MyDatePicker.IsEnabled = false;
      }
      MyDatePicker.MaximumDate = DateTime.Now;
      MyDatePicker.Format = "dd MMMM yyyy";
      }

      private async void Save_Clicked(object sender, EventArgs e)
    {
        Console.WriteLine("test");
        Verein a = _viewModel.Verein as Verein;
        MessagingCenter.Send(a, "UpdateVerein");
    }
  }
}
