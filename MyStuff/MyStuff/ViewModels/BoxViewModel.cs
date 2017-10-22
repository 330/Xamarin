using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyStuff
{
    public class BoxViewModel : BaseViewModel
    {
		private string name, notes, destination;
        public ICommand SubmitCommand { protected set; get; }

        public string Name 
        {
            get { return name; }
            set 
            {
                name = value;
                OnPropertyChanged();
            }
        }

		public string Notes
		{
			get { return notes; }
			set
			{
				notes = value;
				OnPropertyChanged();
			}
		}

		public string Destination
		{
			get { return destination; }
			set
			{
				destination = value;
				OnPropertyChanged();
			}
		}

        INavigation Navigation;
		public BoxViewModel(INavigation PageNav)
		{
            Navigation = PageNav;
            SubmitCommand = new Command(Submit);
		}

        public void Submit()
        {
            App.Database.SaveItemAsync(new Box()
            {
                Name = this.Name,
                Notes = this.Notes,
                Destination = this.Destination
            });
            //Name = String.Empty;
            //Notes = String.Empty;
            //Destination = String.Empty;

            //NavigationService.Instance.PopAsync();
            Navigation.PopAsync();
        }
    }
}
