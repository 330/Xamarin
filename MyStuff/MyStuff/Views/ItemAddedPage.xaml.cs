using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MyStuff
{
    public partial class ItemAddedPage : ContentPage
    {
        public ItemAddedPage(string boxName)
        {
            InitializeComponent();
            BindingContext = new ItemAddedViewModel(boxName, Navigation);
        }

  //      async void OnSaveClicked(object sender, EventArgs e)
  //      {
  //          var item = (Item)BindingContext;
  //          await App.ItemDatabase.SaveItemAsync(item);
  //          await Navigation.PopAsync();
  //      }
		//async void OnCancelClicked(object sender, EventArgs e)
		//{
		//	await Navigation.PopAsync();
		//}
    }
}
