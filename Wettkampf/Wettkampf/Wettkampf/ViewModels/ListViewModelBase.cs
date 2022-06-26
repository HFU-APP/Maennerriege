using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Wettkampf.Models;
using Wettkampf.Services;
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
      Title = "Liste der Vereine";
      Items = new ObservableCollection<TItem>();
      LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

      MessagingCenter.Subscribe<TPage, TItem>(this, "AddItem", async (obj, item) =>
      {
        Items.Add(item);
        await DataStore.AddItemAsync(item);
      });

      MessagingCenter.Subscribe<object>(this, "DeleteItem", async (sender) =>
      {
          if (Items.Count == 0)
          {
              var dialogService = App.Services.GetInstance<IDialogService>();
              dialogService.Show("Liste Leer", "Es sind keine Einträge vorhanden");
          }
          else
          {
              var firstListItem = Items.First();
              var a = firstListItem as Verein;
              await DataStore.DeleteItemAsync(a.Id);
              await ExecuteLoadItemsCommand();
          }
      });

      MessagingCenter.Subscribe<TPage, TItem>(this, "UpdateVerein", async (obj, item) =>
      {
          await DataStore.UpdateItemAsync(item);
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