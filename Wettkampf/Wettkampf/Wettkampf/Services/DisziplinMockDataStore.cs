

using System.Collections.Generic;
using Wettkampf.Models;

namespace Wettkampf.Services
{
  public class DisziplinMockDataStore : MockDataStore<Disziplin>
  {
    public DisziplinMockDataStore()
    {
      Items = new List<Disziplin>()
      {
        new Disziplin { Title = "Disziplin 1"},
        new Disziplin { Title = "Disziplin 2"},
        new Disziplin { Title = "Disziplin 3"},
        new Disziplin { Title = "Disziplin 4"},
        new Disziplin { Title = "Disziplin 5"},
        new Disziplin { Title = "Disziplin 6"}
      };
    }
  }
}