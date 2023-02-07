using Newtonsoft.Json;
using SearchLocApp.Interfaces;
using SearchLocApp.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SearchLocApp.Services
{
    public class CountryInfoService : ICountryInfoService
    {

        public async Task<CountryInfo> GetCountryInfoByCountryName(string countryName)
        {

            try
            {
                HttpClient httpClient = new HttpClient();
                HttpRequestMessage request = new HttpRequestMessage
                {
                    RequestUri = new Uri($"{AppSettings.ApiInfoCountriesUrl}/{countryName}"),
                    Method = HttpMethod.Get
                };
                HttpResponseMessage response = await httpClient.SendAsync(request);
                string responseString = await response.Content.ReadAsStringAsync();
                List<CountryInfo> result = JsonConvert.DeserializeObject<List<CountryInfo>>(responseString);
                CountryInfo capital = new CountryInfo();
                if (result.Count != 0)
                    capital = result[0];

                return capital;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new CountryInfo();
            }

        }
    }
}
