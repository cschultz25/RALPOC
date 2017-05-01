using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using TaskList3.Models;

namespace TaskList3.Abstractions
{
    public interface ICloudService
    {
        Task<ICloudTable<T>> GetTableAsync<T>() where T : TableData;

        Task<MobileServiceUser> LoginAsync();

        Task LogoutAsync();

        Task<AppServiceIdentity> GetIdentityAsync();

        Task SyncOfflineCacheAsync();
    }
}
