using System.Collections.Generic;

namespace Wettkampf.ViewModels
{
    public interface IItemFactory<T>
    {
        IEnumerable<T> CreateItems();
    }
}