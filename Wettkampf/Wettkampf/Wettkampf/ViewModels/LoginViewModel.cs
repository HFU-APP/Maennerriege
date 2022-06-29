using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
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
            if (await checkLogin(Password, AccountName))
            {
                //Application.Current.MainPage = new NavigationPage(new VereinePage());
                await Application.Current.MainPage.Navigation.PushAsync(new VereinePage());
            }
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            //await Shell.Current.GoToAsync($"//{nameof(ContestPage)}");
        }

        private async Task<bool> checkLogin(string password, string accountName)
        {
            var dialogService = App.Services.GetInstance<IDialogService>();
            AccountMockDataStore accountMockDataStore = new AccountMockDataStore();
            var items = await accountMockDataStore.GetItemsAsync(true);
            bool succress = false;
            foreach (var item in items)
            {
                if (accountName == item.AccountName && password == item.Password)
                {
                    if (accountName == "Admin")
                    {
                        await dialogService.Show("Login", "Login als Admin erfolgreich");
                        return true;
                    }
                    await dialogService.Show("Login", "Login als User erfolgreich");
                    return true;
                }
            }
            await dialogService.Show("Login", "Login fehlgeschlagen");
            return false;
            }
    
    }


}
