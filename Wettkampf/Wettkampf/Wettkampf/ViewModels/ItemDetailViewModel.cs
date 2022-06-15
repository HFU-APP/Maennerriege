
using Wettkampf.Models;

namespace Wettkampf.ViewModels
{
  public class ItemDetailViewModel : ItemViewModelBase<Item>
  {
    public Item Item { get; set; }
    public ItemDetailViewModel(Item item = null)
    {
      Title = item?.Text;
      Item = item;
    }
  }
}
