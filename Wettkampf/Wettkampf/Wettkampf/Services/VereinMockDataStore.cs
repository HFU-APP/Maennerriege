

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
        new Verein { Title = "Verein 1"},
        new Verein { Title = "Verein 2"},
        new Verein { Title = "Verein 3"},
        new Verein { Title = "Verein 4"},
        new Verein { Title = "Verein 5"},
        new Verein { Title = "Verein 6"}
      };
    }
  }
}