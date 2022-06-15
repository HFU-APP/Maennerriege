using System.ComponentModel;
using Wettkampf.ViewModels;
using Xamarin.Forms;

namespace Wettkampf.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}