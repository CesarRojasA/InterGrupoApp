using Newtonsoft.Json;
using SearchLocationXamarinApp.Interfaces;
using SearchLocationXamarinApp.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace SearchLocationXamarinApp.Services
{
    public class ApiService : IApiService
    {
        public async Task<ApiResponse<T>> GetAsync<T>(string service) where T : class
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                HttpRequestMessage request = new HttpRequestMessage
                {
                    RequestUri = new Uri($"{AppSettings.ApiCountriesUrl}/{service}"),
                    Method = HttpMethod.Get
                };
                request.Headers.Add(AppSettings.AcceptString, AppSettings.AcceptValue);
                request.Headers.Add(AppSettings.AuthorizationString, await SecureStorage.GetAsync(AppSettings.Auth_tokenString));

                HttpResponseMessage response = await httpClient.SendAsync(request);
                string responseString = await response.Content.ReadAsStringAsync();
                T result = JsonConvert.DeserializeObject<T>(responseString);

                return new ApiResponse<T> { IsSuccess = response.IsSuccessStatusCode, Result = result };
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
