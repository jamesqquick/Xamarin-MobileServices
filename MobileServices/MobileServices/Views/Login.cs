using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MobileServices
{
	public class Login : ContentPage
	{
		public Login ()
		{
			Label title = new Xamarin.Forms.Label
			{
				Text = "Mobile Services",
				FontSize=42,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.StartAndExpand
				
			};

			//twitter login button
			Image twitterLogin = new Image()
			{
				HorizontalOptions = LayoutOptions.Center,

			};
			twitterLogin.Source = ImageSource.FromFile("twitterlogin.png");
			var twitterTapGestureRecognizer = new TapGestureRecognizer();
			twitterTapGestureRecognizer.Tapped += TwitterTapGestureRecognizer_Tapped;
			twitterLogin.GestureRecognizers.Add(twitterTapGestureRecognizer);

			//facebook login button
			Image facebookLogin = new Image()
			{
				HorizontalOptions = LayoutOptions.Center,

			};
			facebookLogin.Source = ImageSource.FromFile("facebooklogin.png");
			var facebookTapGestureRecognizer = new TapGestureRecognizer();
			facebookTapGestureRecognizer.Tapped += FacebookTapGestureRecognizer_Tapped;
			facebookLogin.GestureRecognizers.Add(facebookTapGestureRecognizer);

			//Google login button
			Image googleLogin = new Image()
			{
				HorizontalOptions = LayoutOptions.Center,

			};
			googleLogin.Source = ImageSource.FromFile("googlelogin.png");
			var googleTapGestureRecognizer = new TapGestureRecognizer();
			googleTapGestureRecognizer.Tapped += GoogleTapGestureRecognizer_Tapped;
			googleLogin.GestureRecognizers.Add(googleTapGestureRecognizer);

			//Microsft Login Button
			Image microsoftLogin = new Image()
			{
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.StartAndExpand

			};
			microsoftLogin.Source = ImageSource.FromFile("windowslogin.png");
			var microsoftTapGestureRecognizer = new TapGestureRecognizer();
			microsoftTapGestureRecognizer.Tapped += MicrosoftTapGestureRecognizer_Tapped;
			microsoftLogin.GestureRecognizers.Add(microsoftTapGestureRecognizer);
			
			StackLayout stack = new StackLayout
			{
				Children = {title, twitterLogin, facebookLogin, googleLogin, microsoftLogin}
			};
			Content = stack;
			
		}

		private void TwitterTapGestureRecognizer_Tapped(object sender, EventArgs e)
		{
			LoginUser(MobileServiceAuthenticationProvider.Twitter);
		}

		private void MicrosoftTapGestureRecognizer_Tapped(object sender, EventArgs e)
		{
			LoginUser(MobileServiceAuthenticationProvider.MicrosoftAccount);
		}

		private void GoogleTapGestureRecognizer_Tapped(object sender, EventArgs e)
		{
			LoginUser(MobileServiceAuthenticationProvider.Google);
		}

		private void FacebookTapGestureRecognizer_Tapped(object sender, EventArgs e)
		{
			LoginUser(MobileServiceAuthenticationProvider.Facebook);
		}

		private async void LoginUser(MobileServiceAuthenticationProvider provider)
		{
			while (App.MobileService.CurrentUser == null)
			{

#if WINDOWS_PHONE
				string message;
				try
				{
					// Sign-in using Twitter authentication.
					await App.MobileService.LoginAsync(provider);
					message =
						string.Format("You are now signed in - {0}", App.MobileService.CurrentUser.UserId);
				}
				catch (InvalidOperationException)
				{
					message = "You must log in. Login Required";
				}
#endif
#if __ANDROID__
				DependencyService.Get<IMobileServiceLogin>().loginAsync(MobileServiceAuthenticationProvider.Twitter);

#endif
#if __IOS__
				DependencyService.Get<IMobileServiceLogin>().loginAsync(MobileServiceAuthenticationProvider.Twitter);
#endif
			}
			await DisplayAlert("Login Successful", "Logged in as: " + App.MobileService.CurrentUser.UserId, "OK");
			//User is logged in, now navigate to next page
			await Navigation.PushAsync(new NavigationPage(new ToDoList()));
		}
	}
}
