
using System.Threading.Tasks;

namespace Wettkampf.Services
{
  public interface IDialogService
  {
    Task Show(string title, string message);

    Task<bool> Show(string title, string message, string positive, string negative);
  }
}
