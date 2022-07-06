
using Wettkampf.Models;

namespace Wettkampf.ViewModels
{
  public class VereinDetailViewModel : ItemViewModelBase<Verein>
  {
      public Verein Verein { get; set; }
        public VereinDetailViewModel(Verein verein = null)
    { 
        Verein = verein;
        Title = verein.Vorname;
        Vorname = verein.Vorname;
        Name = verein.Name;
        Vereinname = verein.Vereinname;
        ResultatLauf = verein.ResultatLauf;
        ResultBallwerfen = verein.ResultBallwerfen;
        Geburtsdatum = verein.Geburtsdatum;
    }
  }
}
