using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turnverein.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Turnverein.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = _viewModel = new LoginViewModel();
            ent_user.Text = "Admin";
            ent_passw.Text = "admin";
        }
        private readonly LoginViewModel _viewModel;
    }
}