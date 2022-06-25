

using System.Threading.Tasks;
using Wettkampf.Models;

namespace Wettkampf.Services
{
  public class VereineDataStore : SQLiteDataStore<Verein>
  {
    private readonly IWebService<Verein> _vereineWebService;

    public VereineDataStore(IWebService<Verein> vereineWebService)
    {
        _vereineWebService = vereineWebService;
    }

    public override async Task Initialize()
    {
      await base.Initialize();
            //Hole Albums aus WebService
      var initialAlbums = await _vereineWebService.Get();

            //Connection von SQLite
      await Connection.InsertAllAsync(initialAlbums);
    }
  }
}