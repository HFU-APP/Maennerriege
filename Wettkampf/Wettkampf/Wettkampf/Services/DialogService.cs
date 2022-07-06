
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Wettkampf.Services
{
  public class DialogService : IDialogService
  {
    public DialogService(Page page)
    {
      this.page = page;
    }

    public async Task Show(string title, string message)
    {
      await page.DisplayAlert(title, message, "OK");
    }

    public async Task<bool> Show(string title, string message, string positive, string negative)
    {
      return await page.DisplayAlert(title, message, positive, negative);
    }

    private readonly Page page;
  }
}
