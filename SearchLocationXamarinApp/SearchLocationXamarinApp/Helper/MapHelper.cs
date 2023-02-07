using Acr.UserDialogs;
using SearchLocationXamarinApp.Resources;
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
                await UserDialogs.Instance.AlertAsync("There was an error trying to open GoogleMaps, please check that it is installed",
                    "Error opening Google Maps", CountryResource.OKButton);
                Console.WriteLine(e.Message);
            }
           
        }

    }

}
