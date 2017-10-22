using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MyStuff
{
    public partial class BoxPage : ContentPage
    {
        public BoxPage()
        {
            InitializeComponent();
            BindingContext = new BoxViewModel(Navigation);

        }


		async void OnSaveClicked(object sender, EventArgs e)
		{
			var box = (Box)BindingContext;
            await App.Database.SaveItemAsync(box);
			await Navigation.PopAsync();
		}

		//async void OnDeleteClicked(object sender, EventArgs e)
		//{
		//	var box = (Box)BindingContext;
		//	await App.Database.DeleteItemAsync(box);
		//	await Navigation.PopAsync();
		//}

		async void OnCancelClicked(object sender, EventArgs e)
		{
			await Navigation.PopAsync();
		}

		void OnSpeakClicked(object sender, EventArgs e)
		{
			var box = (Box)BindingContext;
			DependencyService.Get<ITextToSpeech>().Speak(box.Name + " " + box.Notes);
		}
    }
}
