

using System.Collections.Generic;
using Wettkampf.Models;

namespace Wettkampf.Services
{
  public class VereinMockDataStore : MockDataStore<Verein>
  {
    public VereinMockDataStore()
    {
      Items = new List<Verein>()
      {
        new Verein { Title = "Verein 1", Description = "This is an verein description." },
        new Verein { Title = "Verein 2", Description = "This is an verein description." },
        new Verein { Title = "Verein 3", Description = "This is an verein description." },
        new Verein { Title = "Verein 4", Description = "This is an verein description." },
        new Verein { Title = "Verein 5", Description = "This is an verein description." },
        new Verein { Title = "Verein 6", Description = "This is an verein description." }
      };
    }
  }
}