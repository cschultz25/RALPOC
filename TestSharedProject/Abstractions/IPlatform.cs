using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace TaskList3.Abstractions
{
    public interface IPlatform
    {
        MobileServiceUser RetrieveTokenFromSecureStore();
        void StoreTokenInSecureStore(MobileServiceUser user);
        void RemoveTokenFromSecureStore();

        Task<MobileServiceUser> LoginAsync(MobileServiceClient client);
        Task LogoutAsync();

        string GetSyncStore();
    }
}
