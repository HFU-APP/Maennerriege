using System;
using System.Collections.Generic;
using System.Text;
using Turnverein.Views;
using Wettkampf;
using Wettkampf.Models;
using Wettkampf.Services;
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
            var dialogService = App.Services.GetInstance<IDialogService>();
            Account account = new Account(Password, AccountName);
            if (true)/*(checkLogin(Password, AccountName))*/
            {
                
                await dialogService.Show("Login", "Login erfolgreich");
                //Application.Current.MainPage = new NavigationPage(new DisziplinPage());
                await Application.Current.MainPage.Navigation.PushAsync(new DisziplinPage());
            }
            else
            {
                await dialogService.Show("Login", "Login nicht korrekt, kein Benutzername oder kein Passwort");
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
