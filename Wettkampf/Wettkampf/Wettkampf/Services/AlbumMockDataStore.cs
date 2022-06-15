

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
        new Album { Title = "Verein 1", Description = "This is an album description." },
        new Album { Title = "Verein 2", Description = "This is an album description." },
        new Album { Title = "Verein 3", Description = "This is an album description." },
        new Album { Title = "Verein 4", Description = "This is an album description." },
        new Album { Title = "Verein 5", Description = "This is an album description." },
        new Album { Title = "Verein 6", Description = "This is an album description." }
      };
    }
  }
}