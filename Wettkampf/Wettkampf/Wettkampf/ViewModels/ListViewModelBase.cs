using System;
using System.Collections.Generic;
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
      Title = "Liste der Mitglieder";
      Items = new ObservableCollection<TItem>();
      LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
      var dialogService = App.Services.GetInstance<IDialogService>();

      MessagingCenter.Subscribe<TPage, TItem>(this, "AddItem", async (obj, item) =>
      {
        Items.Add(item);
        await DataStore.AddItemAsync(item);
      });

      //MessagingCenter.Subscribe<object>(this, "GenerateNewItems", async (sender) =>
      //{
      //    //List<Verein> generierteVereine = GenerateNewItems();
      //    //foreach (Verein verein in  generierteVereine)
      //    //{
      //    //    await DataStore.AddItemAsync(verein as TItem);
      //    //}

      //    //GenerateNewItems();
      //    //await DataStore.AddItemAsync(ve as TItem);
      //});

            MessagingCenter.Subscribe<object>(this, "DeleteItem", async (sender) =>
      {
          if (Items.Count == 0)
          {
              dialogService.Show("Liste Leer", "Es sind keine Einträge vorhanden");
          }
          else
          {
              var lastItemInList = Items.Last();
              var lasteitem = lastItemInList as Verein;
              await DataStore.DeleteItemAsync(lasteitem.Id);
              await ExecuteLoadItemsCommand();
          }
      });

      MessagingCenter.Subscribe<object>(this, "DeleteAllItem", async (sender) =>
      {
          if (Items.Count == 0)
          {
              dialogService.Show("Liste Leer", "Es sind keine Einträge vorhanden");
          }
          else
          {
              foreach (var item in Items)
              {
                  var currentitem = item as Verein;
                  await DataStore.DeleteItemAsync(currentitem.Id);
              }
              await ExecuteLoadItemsCommand();
          }
      });

MessagingCenter.Subscribe<TPage, TItem>(this, "UpdateVerein", async (obj, item) =>
      {
          await DataStore.UpdateItemAsync(item);
      });
    }

    private List<Verein> GenerateNewItems()
    {
        List<Verein> list = new List<Verein>();
        list.Add(new Verein {Name = "Mayer", Vorname = "Hans", Vereinname = "Verein 1", ResultBallwerfen = "0", ResultatLauf = "0"});
        list.Add(new Verein { Name = "Grob", Vorname = "Uli", Vereinname = "Verein 2", ResultBallwerfen = "0", ResultatLauf = "0" });
        list.Add(new Verein { Name = "Weber", Vorname = "Robert", Vereinname = "Verein 3", ResultBallwerfen = "0", ResultatLauf = "0"});
        return list;
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