using SearchLocApp.Interfaces;
using SearchLocApp.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SearchLocApp.Repository
{
    public class CountryRepository : ICountryRepository
    {
        public bool SaveCountriesListAsync(ObservableCollection<Country> countries)
        {
            try
            {
                return App.Database.SaveItemListAsync(countries);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            
        }

        public async Task<ObservableCollection<Country>> GetAllCountriesAsync()
        {
            try
            {
                return await App.Database.GetItemsAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

            
        }

    }
}
