using System;
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
                .RuleFor(c => c.Vereinname, f => f.Person.Company.Name)
                .RuleFor(c => c.Geburtsdatum, f => f.Date.Past(60, DateTime.Now)).Generate(10);
            return person;
        }
    }
}