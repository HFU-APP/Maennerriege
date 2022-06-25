using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Wettkampf.Models;
using Xamarin.Forms;

namespace Wettkampf.ViewModels
{
  public class ListViewModelBase<TItem, TPage> : ItemViewModelBase<TItem>
    where TPage : class
  {
    public ObservableCollection<TItem> Items { get; set; }

    public Command LoadItemsCommand { get; set; }

    public ListViewModelBase()
    {
      Title = "Liste der Diszipline";
      Items = new ObservableCollection<TItem>();
      LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

      MessagingCenter.Subscribe<TPage, TItem>(this, "AddItem", async (obj, item) =>
      {
          Items.Add(item);
          await DataStore.AddItemAsync(item);
          
      });

      MessagingCenter.Subscribe<object>(this, "DeleteItem", async (sender) =>
      {
          var firstListItem = Items.First();
          var a = firstListItem as Disziplin;
          await DataStore.DeleteItemAsync(a.Id);
          await ExecuteLoadItemsCommand();
      });
    }

    private async Task ExecuteLoadItemsCommand()
    {
      IsBusy = true;

      try
      {
        Items.Clear();
        var items = await DataStore.GetItemsAsync(true);
        foreach (var item in items)
        {
          Items.Add(item);
        }
      }
      catch (Exception ex)
      {
        Debug.WriteLine(ex);
      }
      finally
      {
        IsBusy = false;
      }
    }
  }
}