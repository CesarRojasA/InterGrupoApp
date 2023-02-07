using SearchLocApp.Models;
using System.Threading.Tasks;

namespace SearchLocApp.Interfaces
{
    public interface IApiService
    {
        Task<ApiResponse<T>> GetAsync<T>(string service) where T : class;
    
    }
}
