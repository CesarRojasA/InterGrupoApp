using SearchLocationXamarinApp.Models;
using System.Threading.Tasks;

namespace SearchLocationXamarinApp.Interfaces
{
    public interface IApiService
    {
        Task<ApiResponse<T>> GetAsync<T>(string service) where T : class;
    
    }
}
