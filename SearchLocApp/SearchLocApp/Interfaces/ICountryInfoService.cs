using SearchLocApp.Models;
using System.Threading.Tasks;

namespace SearchLocApp.Interfaces
{
    public interface ICountryInfoService
    {
        Task<CountryInfo> GetCountryInfoByCountryName(string countryName);
    }
}
