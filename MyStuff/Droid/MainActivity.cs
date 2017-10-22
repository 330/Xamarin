using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;
using CodeMill.VMFirstNav;

namespace MyStuff.Droid
{
    [Activity(Label = "MyStuff.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            //TabLayoutResource = Resource.Layout.Tabbar;
            //ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            //DependencyService.Register<FileHelper>();
            //DependencyService.Register<ISQLitePlatform, SQLitePlatformAndroid>();

            global::Xamarin.Forms.Forms.Init(this, bundle);
            NavigationService.Instance.RegisterViewModels(typeof(App).Assembly);
            LoadApplication(new App());
        }
    }
}
