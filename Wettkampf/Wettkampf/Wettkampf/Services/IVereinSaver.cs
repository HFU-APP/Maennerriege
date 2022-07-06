
using System.Threading.Tasks;
using Wettkampf.Models;

namespace Wettkampf.Services
{
  public interface IVereinSaver
  {
    Task<bool> TrySaveAsync(Verein verein);
  }
}
