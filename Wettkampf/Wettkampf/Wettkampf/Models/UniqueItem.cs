using System;
using SQLite;

namespace Wettkampf.Models
{
  public class UniqueItem
  {
      // Another way to create a primary key is to use an integer and ask the database to auto-increment it
      // [PrimaryKey, AutoIncrement]
      // public int Id { get; set; }

      [PrimaryKey]
        public string Id { get; set; } = Guid.NewGuid().ToString();
  }
}