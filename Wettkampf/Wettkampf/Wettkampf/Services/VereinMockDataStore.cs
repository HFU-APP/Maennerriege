

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
        new Verein { Name = "Verein 1", Vorname = "This is an verein description." },
        new Verein { Name = "Verein 2", Vorname = "This is an verein description." },
        new Verein { Name = "Verein 3", Vorname = "This is an verein description." },
        new Verein { Name = "Verein 4", Vorname = "This is an verein description." },
        new Verein { Name = "Verein 5", Vorname = "This is an verein description." },
        new Verein { Name = "Verein 6", Vorname = "This is an verein description." }
      };
    }
  }
}