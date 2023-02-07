using SearchLocationXamarinApp.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SearchLocationXamarinApp.Interfaces
{
    public interface IContryService
    {
        Task<ObservableCollection<Country>> GetAllCountriesAsync();
    }
}
