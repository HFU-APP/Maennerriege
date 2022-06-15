using Wettkampf.Services;
using Xamarin.Forms;

namespace Wettkampf.ViewModels
{
  public class ItemViewModelBase<T> : ViewModelBase
  {
    protected IDataStore<T> DataStore => DependencyService.Get<IDataStore<T>>();
  }
}
