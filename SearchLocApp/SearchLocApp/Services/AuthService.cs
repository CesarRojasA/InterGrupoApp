using Newtonsoft.Json;
using SearchLocApp.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace SearchLocApp.Services
{
    public static class AuthService
    {
        public static async Task<bool> GetAuthTokenAsync(string service)
        {
            try
            {

                if (!string.IsNullOrEmpty(await SecureStorage.GetAsync(AppSettings.Auth_tokenString)))
                    return true;
                HttpClient httpClient = new HttpClient();
                HttpRequestMessage request = new HttpRequestMessage
                {
                    RequestUri = new Uri($"{AppSettings.ApiCountriesUrl}/{service}"),
                    Method = HttpMethod.Get
                };
                request.Headers.Add(AppSettings.AcceptString, AppSettings.AcceptValue);
                request.Headers.Add(AppSettings.ApiTokenString, AppSettings.ApiTokenValue);
                request.Headers.Add(AppSettings.User_emailString, AppSettings.User_emailValue);

                HttpResponseMessage response = await httpClient.SendAsync(request);
                string responseString = await response.Content.ReadAsStringAsync();
                TokenAuthResponse result = JsonConvert.DeserializeObject<TokenAuthResponse>(responseString);
                await SecureStorage.SetAsync(AppSettings.Auth_tokenString, string.Format("Bearer {0}", result.Auth_token));
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
