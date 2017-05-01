using Microsoft.WindowsAzure.MobileServices;
using TaskList.Abstractions;
using System.Threading.Tasks;

namespace TaskList.Services
{
    public class AzureCloudService : ICloudService
    {
        MobileServiceClient client;

        public AzureCloudService()
        {
            client = new MobileServiceClient("https://azuresyncpocapp.azurewebsites.net");
        }

        public ICloudTable<T> GetTable<T>() where T : TableData
        {
            return new AzureCloudTable<T>(client);
        }
        /*
		#region Offline Sync Initialization
		async Task InitializeAsync()
		{
			// Short circuit - local database is already initialized
			if (client.SyncContext.IsInitialized)
				return;

			// Create a reference to the local sqlite store
			var store = new MobileServiceSQLiteStore("offlinecache.db");

			// Define the database schema
			store.DefineTable<TodoItem>();

			// Actually create the store and update the schema
			await Client.SyncContext.InitializeAsync(store);
		}
		#endregion*/
	}
}