
using Wettkampf.Models;

namespace Wettkampf.ViewModels
{
  public class VereinDetailViewModel : ItemViewModelBase<Verein>
  {
    public VereinDetailViewModel(Verein verein = null)
    { 
        Verein = verein;
        Title = verein.Id;
    }

    public Verein Verein { get; set; }
  }
}
