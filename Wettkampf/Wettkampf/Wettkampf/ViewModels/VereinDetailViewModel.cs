
using Wettkampf.Models;

namespace Wettkampf.ViewModels
{
  public class VereinDetailViewModel : ItemViewModelBase<Verein>
  {
    public VereinDetailViewModel(Verein verein = null)
    {
      Title = verein?.Title;
      Verein = verein;
    }

    public Verein Verein { get; set; }
  }
}
