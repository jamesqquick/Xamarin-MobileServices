using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;
using MobileServices.Droid;

[assembly: Dependency(typeof(MobileServiceLogin))]

namespace MobileServices.Droid
{
	class MobileServiceLogin : IMobileServiceLogin
	{
		public async void loginAsync(MobileServiceAuthenticationProvider provider)
		{
			

			string message;
			try
			{
				// Sign-in using Twitter authentication.
				await App.MobileService.LoginAsync(Forms.Context, provider);
				message =
					string.Format("You are now signed in - {0}", App.MobileService.CurrentUser.UserId);
			}
			catch (InvalidOperationException)
			{
				message = "You must log in. Login Required";
			}

			catch (Exception e)
			{

			}
		}
	}
}