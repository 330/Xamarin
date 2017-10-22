
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MyStuff
{
    public partial class SearchPage : ContentPage
    {
        public SearchPage()
        {
            InitializeComponent();
            BindingContext = new SearchViewModel();
        }

		//protected override async void OnAppearing()
		//{
		//	base.OnAppearing();

		//	// Reset the 'resume' id, since we just want to re-start here
		//	((App)App.Current).ResumeAtBoxId = -1;
	 //   	listView.ItemsSource = await App.Database.GetItemsAsync();
		//}
    }
}
