using System.Threading.Tasks;

namespace BlazorSample.Client.LocalStorage.Services
{
    public interface ILocalStorageService
    {
        Task SetAsync<T>(string key, T value);
        Task<T> GetAsync<T>(string key);
        Task RemoveAsync(string key);
        Task ClearAsync();
    }
}