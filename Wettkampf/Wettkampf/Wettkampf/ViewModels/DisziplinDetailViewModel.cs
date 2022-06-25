
using Wettkampf.Models;

namespace Wettkampf.ViewModels
{
  public class DisziplinDetailViewModel : ItemViewModelBase<Disziplin>
  {
    public DisziplinDetailViewModel(Disziplin disziplin = null)
    {
      Title = disziplin?.Title;
      Disziplin = disziplin;
    }

    public Disziplin Disziplin { get; set; }
  }
}
