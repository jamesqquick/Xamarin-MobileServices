using Microsoft.WindowsAzure.MobileServices;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MobileServices
{
	public class ToDoList : ContentPage
	{
		ListView list;
		private MobileServiceCollection<ToDoItem, ToDoItem> items;
		private IMobileServiceTable<ToDoItem> SitesTable = App.MobileService.GetTable<ToDoItem>();
		List<string> myList;

		public ToDoList ()
		{
			Label title = new Label
			{
				Text = "ToDo List",
				FontSize = 42,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.StartAndExpand
			};

			list = new ListView();

			Button viewProfileButton = new Button
			{
				HorizontalOptions = LayoutOptions.Center,
				FontSize = 32,
				Text = "View Profile"
			};
			viewProfileButton.Clicked += ViewProfileButton_Clicked;

			Button refreshButton = new Button
			{
				HorizontalOptions = LayoutOptions.Center,
				FontSize = 32,
				Text = "Refresh"
			};
			refreshButton.Clicked += RefreshButton_Clicked;

			StackLayout stack = new StackLayout
			{
				Children = { title, list, refreshButton, viewProfileButton}
			};

			Content = stack;
		}

		private void RefreshButton_Clicked(object sender, System.EventArgs e)
		{
			RefreshAsync();
		}

		private async void RefreshAsync()
		{
			MobileServiceInvalidOperationException exception = null;
			try
			{
				// This code refreshes the entries in the list view by querying the TodoItems table.
				// The query excludes completed TodoItems
				items = await SitesTable.ToCollectionAsync();
				myList = new List<string>();
				foreach (ToDoItem item in items)
				{
					myList.Add(item.Text);
				}
			}
			catch (MobileServiceInvalidOperationException e)
			{
				exception = e;

			}

			if (exception != null)
			{
			}
			else
			{
				list.ItemsSource = myList;
			}
	}

		private async void ViewProfileButton_Clicked(object sender, System.EventArgs e)
		{
			await Navigation.PushAsync(new Profile());
		}

		protected override void OnAppearing()
		{
			RefreshAsync();
		}
	}
}
