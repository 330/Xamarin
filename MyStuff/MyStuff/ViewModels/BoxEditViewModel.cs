using System;
using System.Windows.Input;
using CodeMill.VMFirstNav;
using Xamarin.Forms;

namespace MyStuff
{
    public class BoxEditViewModel : BaseViewModel
    {
		private string name, notes, destination;
        private string room;
		public ICommand OnSaveClicked { get; private set; }
		public ICommand OnDeleteClicked { get; private set; }

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

		public string Room
		{
            get { return room; }
			set
			{
				room = value;
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

        private Box edit_box;
        private INavigation Navigation;
        public BoxEditViewModel(Box box,INavigation PageNav)
        {
            Navigation = PageNav;

            name = box.Name;
            notes = box.Notes;
            destination = box.Destination;

            edit_box = box;

            OnSaveClicked = new Command(Save);
            OnDeleteClicked = new Command(Delete);
        }

        private void Delete()
        {
            App.Database.DeleteItemAsync(edit_box);
            Navigation.PopAsync();
        }

        private void Save()
        {
            edit_box.Destination = room;
            App.Database.SaveItemAsync(edit_box);
            Navigation.PopAsync();
        }
    }
}
