using SearchLocationXamarinApp.Models;
using System.Threading.Tasks;

namespace SearchLocationXamarinApp.Interfaces
{
    public interface ICountryInfoService
    {
        Task<CountryInfo> GetCountryInfoByCountryName(string countryName);
    }
}
