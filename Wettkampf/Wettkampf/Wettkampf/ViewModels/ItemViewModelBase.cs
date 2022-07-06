using Wettkampf.Services;

namespace Wettkampf.ViewModels
{
  public class ItemViewModelBase<T> : ViewModelBase
  {
      protected IDataStore<T> DataStore => App.Services.GetInstance<IDataStore<T>>();
  }
}
