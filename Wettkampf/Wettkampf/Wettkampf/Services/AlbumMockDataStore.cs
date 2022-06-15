

using System.Collections.Generic;
using Wettkampf.Models;

namespace Wettkampf.Services
{
  public class AlbumMockDataStore : MockDataStore<Album>
  {
    public AlbumMockDataStore()
    {
      Items = new List<Album>()
      {
        new Album { Title = "First album", Description = "This is an album description." },
        new Album { Title = "Second album", Description = "This is an album description." },
        new Album { Title = "Third album", Description = "This is an album description." },
        new Album { Title = "Fourth album", Description = "This is an album description." },
        new Album { Title = "Fifth album", Description = "This is an album description." },
        new Album { Title = "Sixth album", Description = "This is an album description." }
      };
    }
  }
}