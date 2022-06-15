
using Wettkampf.Models;

namespace Wettkampf.ViewModels
{
  public class AlbumDetailViewModel : ItemViewModelBase<Album>
  {
    public AlbumDetailViewModel(Album album = null)
    {
      Title = album?.Title;
      Album = album;
    }

    public Album Album { get; set; }
  }
}
