using System;
using System.Collections.Generic;
using CodeMill.VMFirstNav;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyStuff
{

    public partial class BoxEditPage : ContentPage
    {
        //public BoxEditPage()
        //{
        //    InitializeComponent();
        //}

		public BoxEditPage(Box box)
		{
			InitializeComponent();
            BindingContext = new BoxEditViewModel(box, Navigation);
		}
    }
}
