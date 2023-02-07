using SearchLocationXamarinApp.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SearchLocationXamarinApp.Interfaces
{
    public interface ICountryRepository
    {
        bool SaveCountriesListAsync(ObservableCollection<Country> countries);
        Task<ObservableCollection<Country>> GetAllCountriesAsync();
    }
}
