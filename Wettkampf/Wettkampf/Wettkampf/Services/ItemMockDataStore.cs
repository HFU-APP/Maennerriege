using System.Collections.Generic;
using Wettkampf.Models;

namespace Wettkampf.Services
{
  public class ItemMockDataStore : MockDataStore<Item>
  {
    public ItemMockDataStore()
    {
      Items = new List<Item>()
      {
        new Item { Text = "First item", Description = "This is an item description." },
        new Item { Text = "Second item", Description = "This is an item description." },
        new Item { Text = "Third item", Description = "This is an item description." },
        new Item { Text = "Fourth item", Description = "This is an item description." },
        new Item { Text = "Fifth item", Description = "This is an item description." },
        new Item { Text = "Sixth item", Description = "This is an item description." }
      };
    }
  }
}