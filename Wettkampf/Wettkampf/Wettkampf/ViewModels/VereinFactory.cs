using System.Collections.Generic;
using Wettkampf.Models;

namespace Wettkampf.ViewModels
{
    class VereinFactory : IItemFactory<Verein>
    {
        public IEnumerable<Verein> CreateItems()
        {
            yield return new Verein { Name = "Mayer", Vorname = "Hans", Vereinname = "Verein 1", ResultBallwerfen = 0, ResultatLauf = 0 };
            yield return new Verein { Name = "Grob", Vorname = "Uli", Vereinname = "Verein 2", ResultBallwerfen = 0, ResultatLauf = 0 };
            yield return new Verein { Name = "Weber", Vorname = "Robert", Vereinname = "Verein 3", ResultBallwerfen = 0, ResultatLauf = 0 };
        }
    }
}