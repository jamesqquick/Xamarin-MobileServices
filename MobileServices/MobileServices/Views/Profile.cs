using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MobileServices
{
	public class Profile : ContentPage
	{
		Label username;
		Label location;
		Image profile;
		Label header;
		Label description;
		public Profile()
		{
			header = new Label
			{
				Text = "Mobile Services",
				FontSize = 56,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.StartAndExpand
			};

			username = new Label
			{
				FontSize = 36,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.StartAndExpand
			};

			location = new Label
			{
				FontSize = 36,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.StartAndExpand
			};

			description = new Label
			{
				FontSize = 24,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.StartAndExpand,

			};

			Button listButton = new Button
			{
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.End,
				Text = "View ToDo List"
			};
			listButton.Clicked += ListButton_Clicked;

			profile = new Image
			{
				HorizontalOptions = LayoutOptions.Center,
				HeightRequest = 144,
				WidthRequest = 144,
				Aspect = Aspect.AspectFill,
				VerticalOptions = LayoutOptions.StartAndExpand

			};


			StackLayout stack = new StackLayout
			{
				Children = { header, profile, username, location, description, listButton }
			};
			this.Content = stack;
		}

		private void ListButton_Clicked(object sender, EventArgs e)
		{
			Navigation.PushAsync(new ToDoList());
		}


		protected async override void OnAppearing()
		{
			JToken response = await App.MobileService.InvokeApiAsync("getuserprofile");
			TwitterUser Twitterprofile = JsonConvert.DeserializeObject<TwitterUser>(response.ToString());
			header.Text = (string)response.SelectToken("name");
			username.Text = Twitterprofile.screen_name;
			location.Text = Twitterprofile.location;
			description.Text = Twitterprofile.description;
			profile.Source = Twitterprofile.profile_image_url;

		}
	}
}
