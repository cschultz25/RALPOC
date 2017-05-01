using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace TaskList.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			/*// Use for CHapter 1
			global::Xamarin.Forms.Forms.Init();

			Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();

			LoadApplication(new App());
			return base.FinishedLaunching(app, options);*/


			// User for Chapter 3
            SQLitePCL.Batteries.Init();

            Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();

            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new TaskList3.App());

            return base.FinishedLaunching(app, options);
		}
	}
}
