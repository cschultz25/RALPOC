using TaskList3.Abstractions;
using TaskList3.Helpers;
using TaskList3.Services;
using Xamarin.Forms;

namespace TaskList3
{
    public class App : Application
    {

		public App()
		{
			ServiceLocator.Add<ICloudService, AzureCloudService>();
			MainPage = new NavigationPage(new Pages.EntryPage());
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
    }
}