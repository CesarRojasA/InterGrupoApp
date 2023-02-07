using SearchLocationXamarinApp.Interfaces;
using SearchLocationXamarinApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SearchLocationXamarinApp.Services
{
    public class CountryService : IContryService
    {
        private readonly IApiService _apiService;
        private readonly ICountryInfoService _countryInfoService;

        public CountryService(IApiService apiService, ICountryInfoService countryInfoService)
        {
            _apiService = apiService;
            _countryInfoService = countryInfoService;
        }
        public async Task<ObservableCollection<Country>> GetAllCountriesAsync()
        {
            try
            {
                ObservableCollection<Country> countries;
                ApiResponse<List<Country>> response = await _apiService.GetAsync<List<Country>>(AppSettings.ServiceCuntriesString);
                if (response == null)
                    return null;
                countries = new ObservableCollection<Country>(response.Result);
                return await InsertCountryInfoByCountry(countries);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        private async Task<ObservableCollection<Country>> InsertCountryInfoByCountry(ObservableCollection<Country> countries)
        {
            try
            {
                foreach (Country item in countries)
                {
                    CountryInfo info = await _countryInfoService.GetCountryInfoByCountryName(item.Country_name);
                    item.Capital = info.CapitalCountry;
                    item.Region = info.Region;
                }
                return countries;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }

    }
}
