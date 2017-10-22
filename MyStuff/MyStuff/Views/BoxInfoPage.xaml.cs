using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyStuff
{   
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BoxInfoPage : ContentPage
    {
        //public BoxInfoPage()
        //{
        //    InitializeComponent();
        //}
        private string boxName;

		public BoxInfoPage(Box box)
		{
			InitializeComponent();
            BindingContext = new BoxInfoViewModel(box, Navigation);
            boxName = box.Name;
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();

			// Reset the 'resume' id, since we just want to re-start here
			((App)App.Current).ResumeAtItemId = -1;
            //listView.ItemsSource = await App.ItemDatabase.GetItemsAsync();
            listView.ItemsSource = await App.ItemDatabase.GetItemsInBoxAsync(boxName);
		}

		async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
            ((App)App.Current).ResumeAtItemId = (e.SelectedItem as Item).ID;
			Debug.WriteLine("setting ResumeAtBoxId = " + (e.SelectedItem as Item).ID);

			//await Navigation.PushAsync(new BoxInfoPage
			//{
			//  BindingContext = e.SelectedItem as Box

			//});
            await Navigation.PushAsync(new ItemInfoPage((e.SelectedItem as Item)));
		}
    }
}
