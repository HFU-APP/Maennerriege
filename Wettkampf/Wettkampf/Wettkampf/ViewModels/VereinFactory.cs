using System.Collections.Generic;
using Bogus;
using Wettkampf.Models;

namespace Wettkampf.ViewModels
{
    class VereinFactory : IItemFactory<Verein>
    {
        public IEnumerable<Verein> CreateItems()
        {
            IEnumerable<Verein> person = new Faker<Verein>()
                .RuleFor(c => c.Name, f => f.Person.LastName)
                .RuleFor(c => c.Vorname, f => f.Person.FirstName)
                .RuleFor(c => c.Vereinname, f => f.Person.FullName).Generate(10);
            return person;



            //yield return new Verein { Name = "Mayer", Vorname = "Hans", Vereinname = "Verein 1", ResultBallwerfen = 0, ResultatLauf = 0 };
            //yield return new Verein { Name = "Grob", Vorname = "Uli", Vereinname = "Verein 2", ResultBallwerfen = 0, ResultatLauf = 0 };
            //yield return new Verein { Name = "Weber", Vorname = "Robert", Vereinname = "Verein 3", ResultBallwerfen = 0, ResultatLauf = 0 };
        }
    }
}