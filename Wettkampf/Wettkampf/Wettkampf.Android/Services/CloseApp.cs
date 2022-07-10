using Android.App;
using Wettkampf.Droid.Services;
using Wettkampf.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(CloseApp))]

namespace Wettkampf.Droid.Services
{
    internal class CloseApp : ICloseApp
    {
        public void QuitApplication()
        {
            var activity = MainActivity.Instance as Activity;
            activity.Finish();
        }
    }
}