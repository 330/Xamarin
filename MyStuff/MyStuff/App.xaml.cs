using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MyStuff
{
    public partial class App : Application
    {
        static BoxDatabase database;
        static ItemDatabase itemDatabase;

        public App()
        {
			Resources = new ResourceDictionary();
			Resources.Add("primaryGreen", Color.FromHex("91CA47"));
			Resources.Add("primaryDarkGreen", Color.FromHex("6FA22E"));

			//var nav = new NavigationPage(new BoxListPage());
			//nav.BarBackgroundColor = (Color)App.Current.Resources["primaryGreen"];
			//nav.BarTextColor = Color.White;

			Current.MainPage = new TabbedPage
			{
                BarBackgroundColor = (Color)App.Current.Resources["primaryGreen"],
				Children =
				{
					new NavigationPage(new BoxListPage())
					{
						Title = "Box",
                        BarBackgroundColor = (Color)App.Current.Resources["primaryGreen"],
                        BarTextColor = Color.White,

					},
                    new NavigationPage(new SearchPage())
					{
						Title = "Search",
                        BarBackgroundColor = (Color)App.Current.Resources["primaryGreen"],
						BarTextColor = Color.White,
					},
				}
			};
			//MainPage = nav;
        }

        public static BoxDatabase Database
		{
			get
			{
				if (database == null)
				{
					database = new BoxDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("BoxSQLite.db3"));
				}
				return database;
			}
		}

        public int ResumeAtBoxId { get; set; }

        public static ItemDatabase ItemDatabase
		{
			get
			{
				if (itemDatabase == null)
				{
                    itemDatabase = new ItemDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("ItemSQLite.db3"));
				}
				return itemDatabase;
			}
		}

        public int ResumeAtItemId { get; set; }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
