

using System.Threading.Tasks;
using Wettkampf.Models;

namespace Wettkampf.Services
{
  public class DiszilpinDataStore : SQLiteDataStore<Disziplin>
  {
    private readonly IWebService<Disziplin> _vereineWebService;

    public DiszilpinDataStore(IWebService<Disziplin> vereineWebService)
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