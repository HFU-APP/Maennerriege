using System;
using System.Collections.Generic;
using System.Text;
using Turnverein.Views;
using Wettkampf.Models;
using Wettkampf.ViewModels;
using Wettkampf.Views;
using Xamarin.Forms;

namespace Turnverein.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public Command LoginCommand { get; }
        public string AccountName { get; set; }
        public string Password { get; set; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);

        }

        private async void OnLoginClicked(object obj)
        {
            Account account = new Account(Password, AccountName);
            if (true)/*(checkLogin(Password, AccountName))*/
            {
                await Application.Current.MainPage.DisplayAlert("Login", "Login erfolgreich", "Ok");
                //Application.Current.MainPage = new NavigationPage(new AlbumsPage());
                await Application.Current.MainPage.Navigation.PushAsync(new AlbumsPage());
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Login", "Login nicht korrekt, kein Benutzername oder kein Passwort", "Ok");
            }

            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            //await Shell.Current.GoToAsync($"//{nameof(ContestPage)}");
        }

        private bool checkLogin(string password, string accountName)
        {
            if (password == "1234" && AccountName == "ich")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    
}
