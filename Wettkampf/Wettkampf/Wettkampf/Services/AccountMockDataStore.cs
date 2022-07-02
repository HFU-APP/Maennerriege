

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
        new Account {AccountName = "Admin", Password = "GrZKy/5QWp7WrKf21hNZUA=="},
        new Account {AccountName = "User", Password = "IxA5mJA4ZpFBeiAsWLTFRQ=="}
      };
    }
  }
}