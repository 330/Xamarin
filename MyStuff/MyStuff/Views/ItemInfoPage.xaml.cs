using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MyStuff
{
    public partial class ItemInfoPage : ContentPage
    {
        public ItemInfoPage(Item item)
        {
            InitializeComponent();
            BindingContext = new ItemInfoViewModel(item, Navigation);
        }
		protected override async void OnAppearing()
		{
			base.OnAppearing();

			// Reset the 'resume' id, since we just want to re-start here
			((App)App.Current).ResumeAtBoxId = -1;
            picker.ItemsSource = await App.Database.GetItemsAsync();
		}
    }
}
