using System;
using Xamarin.Forms;

namespace Wettkampf.Models
{
  public class Verein : ContentItem
  {
      public String Name { get; set; }
      public String Vorname { get; set; }
      public String Vereinname { get; set; }
      public string ResultatLauf { get; set; }
      public String ResultBallwerfen { get; set; }
      public DateTime Geburtsdatum { get; set; }
  }
}
