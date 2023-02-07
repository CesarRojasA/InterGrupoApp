using SearchLocApp.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SearchLocApp.Interfaces
{
    public interface IContryService
    {
        Task<ObservableCollection<Country>> GetAllCountriesAsync();
    }
}
