using System;

namespace Wettkampf.Models
{
  public class UniqueItem
  {
    public string Id { get; set; } = Guid.NewGuid().ToString();
  }
}