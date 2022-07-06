using System;

namespace Wettkampf.Models
{
  public class Verein : ContentItem
  {
      public String Name { get; set; }
      public String Vorname { get; set; }
      public String Vereinname { get; set; }
      public double ResultatLauf { get; set; }
      public double ResultBallwerfen { get; set; }
      public DateTime Geburtsdatum { get; set; }
  }
}
