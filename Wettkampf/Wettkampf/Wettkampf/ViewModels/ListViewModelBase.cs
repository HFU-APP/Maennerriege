using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Wettkampf.Models;
using Wettkampf.Services;
using Xamarin.Forms;

namespace Wettkampf.ViewModels
{
    public class ListViewModelBase<TItem, TPage> : ItemViewModelBase<TItem>
    where TPage : class
  where TItem : class
  {
    public ObservableCollection<TItem> Items { get; set; }
    public ICommand DeleteCommand => new Command<TItem>(RemovePerson);
    public Command LoadItemsCommand { get; set; }

    public ListViewModelBase()
    {
      Title = "Liste der Mitglieder";
      if (Items == null)
      {
          Items = new ObservableCollection<TItem>();
      }

      LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
      var dialogService = App.Services.GetInstance<IDialogService>();
      itemFactory = App.Services.GetInstance<IItemFactory<TItem>>();

      MessagingCenter.Subscribe<TPage, TItem>(this, "AddItem", async (obj, item) =>
      {
          try
          {
              Items.Add(item);
              await DataStore.AddItemAsync(item);
              //await ExecuteLoadItemsCommand();
          }
          catch (SQLite.SQLiteException e)
          {
              Console.WriteLine(e);
              await dialogService.Show("Fehler beim hinzufügen", "Bitte fügen Sie die Person erneut hinzu");
          }


      });

      MessagingCenter.Subscribe<object>(this, "DeleteItem", async (sender) =>
      {
          if (Items.Count == 0)
          {
              await dialogService.Show("Liste Leer", "Es sind keine Einträge vorhanden");
          }
          else
          {
              var lastItemInList = Items.Last();
              var lasteitem = lastItemInList as Verein;
              await DataStore.DeleteItemAsync(lasteitem.Id.ToString());
              await ExecuteLoadItemsCommand();
          }
      });

      MessagingCenter.Subscribe<object>(this, "DeleteAllItem", async (sender) =>
      {
          if (Items.Count == 0)
          {
              await dialogService.Show("Liste Leer", "Es sind keine Einträge vorhanden");
          }
          else
          {
              foreach (var item in Items)
              {
                  var currentitem = item as Verein;
                  await DataStore.DeleteItemAsync(currentitem.Id.ToString());
              }
              await ExecuteLoadItemsCommand();
          }
      });

      MessagingCenter.Subscribe<object>(this, "GenerateItems", async (sender) =>
      { 
          foreach (var element in itemFactory.CreateItems())
          {
              Items.Add(element);
              await DataStore.AddItemAsync(element);
          }
          //await ExecuteLoadItemsCommand();
      });

      MessagingCenter.Subscribe<TItem>(this, "UpdateVerein", async (item) =>
      { 
          Console.WriteLine("Test3");
          await DataStore.UpdateItemAsync(item);
          await ExecuteLoadItemsCommand();
      });
    }

    private async void RemovePerson(TItem person)
    {
        var dialogService = App.Services.GetInstance<IDialogService>();
        var pers = person as Verein;
        Console.WriteLine($"$lösche: {pers.Vorname}");
        if (Items.Count == 0)
        {
            dialogService.Show("Liste Leer", "Es sind keine Einträge vorhanden");
        }
        if (Items.Contains(person))
        {
            Items.Remove(person);
            await DataStore.DeleteItemAsync(pers.Id.ToString());
            await ExecuteLoadItemsCommand();
        }
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

    private IItemFactory<TItem> itemFactory;
  }
}