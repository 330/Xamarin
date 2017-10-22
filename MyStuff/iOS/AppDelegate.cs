using System;
using System.Collections.Generic;
using System.Linq;
using CodeMill.VMFirstNav;
using Foundation;
using UIKit;
using Xamarin.Forms;

namespace MyStuff.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
			//global::Xamarin.Forms.Forms.Init();
			// affects all UISwitch controls in the app
			UISwitch.Appearance.OnTintColor = UIColor.FromRGB(0x91, 0xCA, 0x47);
			//DependencyService.Register<FileHelper>();
			//DependencyService.Register<ISQLitePlatform, SQLitePlatformIOS>();
			//LoadApplication(new App());

			//return base.FinishedLaunching(app, options);
			Forms.Init();
			LoadApplication(new App());
            NavigationService.Instance.RegisterViewModels(typeof(App).Assembly);
			return base.FinishedLaunching(app, options);
        }
    }
}
