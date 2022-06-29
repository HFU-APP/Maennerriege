

using System.Collections.Generic;
using Wettkampf.Models;

namespace Wettkampf.Services
{
  public class AccountMockDataStore : MockDataStore<Account>
  {
    public AccountMockDataStore()
    {
      Items = new List<Account>()
      {
        new Account {AccountName = "Admin", Password = "admin"},
        new Account {AccountName = "User", Password = "user"}
      };
    }
  }
}