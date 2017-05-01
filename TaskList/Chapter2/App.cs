using TaskList2.Abstractions;
using TaskList2.Helpers;
using TaskList2.Services;
using Xamarin.Forms;

namespace TaskList2
{
    public class App : Application
    {
        public App()
        {
            ServiceLocator.Instance.Add<ICloudService, AzureCloudService>();
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
