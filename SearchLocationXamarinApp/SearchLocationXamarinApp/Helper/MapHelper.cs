using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SearchLocationXamarinApp.Helper
{
    public static class MapHelper
    {
        public static async Task OpenMap(string Country_name)
        {
            try
            {
                if (Device.RuntimePlatform == Device.iOS)
                    await Launcher.OpenAsync($"http://maps.apple.com/?q=" + Country_name);
                else if (Device.RuntimePlatform == Device.Android)
                    await Launcher.OpenAsync($"geo:0,0?q={Country_name}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
           
        }

    }

}
