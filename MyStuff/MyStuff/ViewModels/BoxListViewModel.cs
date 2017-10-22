using System;
using System.Windows.Input;
using CodeMill.VMFirstNav;
using Xamarin.Forms;

namespace MyStuff
{
    public class BoxListViewModel : BaseViewModel
    {
        public ICommand OnDelete { protected set; get; }
        public ICommand ItemAddedCommand { protected set; get; }
		private string name, notes;
		private string destination;

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

        Box selectedItem;
        public Box SelectedItem {
            get { return selectedItem; }
            set { 
                    selectedItem = value; 
                    OnPropertyChanged();
            }
        }

        INavigation Navigation;
        public BoxListViewModel(INavigation PageNav)
        {
            Navigation = PageNav;
            OnDelete = new Command(Delete);
            ItemAddedCommand = new Command(ItemAdded);
        }

        private void Delete() {
			App.Database.DeleteItemAsync(new Box()
			{
				Name = this.Name,
				Notes = this.Notes,
				Destination = this.Destination
			});
        }

        private void ItemAdded(){
            Navigation.PushAsync(new BoxPage());
        }

    }
}
