using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using CodeMill.VMFirstNav;
using Xamarin.Forms;

namespace MyStuff
{
    public partial class BoxListPage : ContentPage
    {
		public BoxListPage()
		{
			InitializeComponent();
            BindingContext = new BoxListViewModel(Navigation);

		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();

			// Reset the 'resume' id, since we just want to re-start here
			((App)App.Current).ResumeAtBoxId = -1;
			listView.ItemsSource = await App.Database.GetItemsAsync();
		}

		//async void OnItemAdded(object sender, EventArgs e)
		//{
  //          //await Navigation.PushAsync(new BoxPage
  //          //{
  //          //	BindingContext = new Box()
  //          //});
  //          await Navigation.PushAsync(new BoxPage());
		//}

		async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			((App)App.Current).ResumeAtBoxId = (e.SelectedItem as Box).ID;
			Debug.WriteLine("setting ResumeAtBoxId = " + (e.SelectedItem as Box).ID);

			//await Navigation.PushAsync(new BoxInfoPage
			//{
			//	BindingContext = e.SelectedItem as Box

			//});
            await Navigation.PushAsync(new BoxInfoPage((e.SelectedItem as Box)));
		}

		async void OnDelete(object sender, EventArgs e)
		{
            var box = (sender as MenuItem).BindingContext as Box;
            //Name.Remove(box.Name);
			await App.Database.DeleteItemAsync(box);

		}

   //     private ObservableCollection<string> name;

   //     private ObservableCollection<string> Name
   //     {
			//get { return name; }
			//set

			//{
			//	name = value;
			//	OnPropertyChanged();
			//}
        //}

    }
}
