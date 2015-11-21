using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MobileServices
{
	public class App : Application
	{
		public static MobileServiceClient MobileService = new MobileServiceClient(
			"https://jqmobileservice.azure-mobile.net/",
			"NZYnwiPlQzQYNuiPmOPxvCKUEyuiTJ91"
		);
		public App ()
		{
			// The root page of your application
			MainPage = new Login();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
