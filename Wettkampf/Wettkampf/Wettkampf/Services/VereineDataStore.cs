// <copyright file="VereineDataStore.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

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

      var initialAlbums = await _vereineWebService.Get();

      await Connection.InsertAllAsync(initialAlbums);
    }
  }
}