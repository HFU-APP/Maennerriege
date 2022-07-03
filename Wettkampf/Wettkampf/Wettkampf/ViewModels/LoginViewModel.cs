﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
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
        private string _password;
        private string _textToEncrypt = "SuperSalt1234";
        private string _output;
        public Command LoginCommand { get; }
        public string AccountName { get; set; }
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }
        public string Output
        {
            get => _output;
            set => SetProperty(ref _output, value);
        }
        public string TextToEncrypt
        {
            get => _textToEncrypt;
            set => SetProperty(ref _output, value);
        }
        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            //EncryptCommand = new Command(EncryptWithPassword);
        }


        private (IPasswordEncryptionService service, byte[] key) GetEncryptionTools()
        {
            var service = DependencyService.Get<IPasswordEncryptionService>();
            var key = service.GenerateKey(Password);

            return (service, key);
        }

        private void Show(string title, string message)
        {
            App.Services.GetInstance<IDialogService>().Show(title, message);
        }

        private async void OnLoginClicked(object obj)
        {
            if (string.IsNullOrEmpty(AccountName))
            {
                Show("Kein User Name", "Bitte geben Sie ein Benutzername ein");

                return;
            }
            if (string.IsNullOrEmpty(Password))
            {
                Show("Kein Passwort", "Bitte geben ein Passwort ein");

                return;
            }

            var (service, key) = GetEncryptionTools();
            var encryptedValue = service.Encrypt(Encoding.UTF8.GetBytes(TextToEncrypt), key);

            Output = Convert.ToBase64String(encryptedValue);



            if (await checkLogin(Output, AccountName))
            {
                await Application.Current.MainPage.Navigation.PushAsync(new VereinePage(AccountName));
            }

        }

        public async Task<bool> checkLogin(string password, string accountName)
        {
            var dialogService = App.Services.GetInstance<IDialogService>();
            AccountMockDataStore accountMockDataStore = new AccountMockDataStore();
            var items = await accountMockDataStore.GetItemsAsync(true);
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
            await dialogService.Show("Login", "Login fehlgeschlagen. Bitte überprüfen Sie Ihre Eingaben");
            return false;
            }
    
    }


}
