using MobileServices.iOS;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;
using UIKit;

[assembly: Dependency(typeof(MobileServiceLogin))]
namespace MobileServices.iOS
{
	class MobileServiceLogin : IMobileServiceLogin
	{
		public async void loginAsync(MobileServiceAuthenticationProvider provider)
		{
			var view = UIApplication.SharedApplication.KeyWindow.RootViewController;
			await App.MobileService.LoginAsync(view, provider);
		}
	}
}
