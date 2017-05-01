using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Backend.Startup))]
namespace Backend
{
	public partial class Startup
	{
		//This is called on startup by Owin...ie, start here!
		public void Configuration(IAppBuilder app)
		{
			ConfigureMobileApp(app);
		}
	}
}