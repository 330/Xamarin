using System;
using System.Windows.Input;
using CodeMill.VMFirstNav;
using Xamarin.Forms;

namespace MyStuff
{
public class BoxInfoViewModel : BaseViewModel, IViewModel 
    {
		private string name, notes, destination, itemName;
        public ICommand BoxEditCommand { get; private set; }
        public ICommand ItemAddedCommand { get; private set; }
		public string ItemName
		{
			get { return itemName; }
			set
			{
				itemName = value;
				OnPropertyChanged();
			}
		}

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
        Box box_edit;

        public BoxInfoViewModel(Box box, INavigation PageNav)
        {
            box_edit = box;
            name = box.Name;
            notes = box.Notes;
            destination = box.Destination;
            Navigation = PageNav;
            BoxEditCommand = new Command(Edit);
            ItemAddedCommand = new Command(Add);
        }


        private void Edit()
        {
            Navigation.PushAsync(new BoxEditPage(box_edit));
            //Navigation.PushAsync(new ItemAddedPage());
        }

        private void Add()
        {
            Navigation.PushAsync(new ItemAddedPage(name));
        }

    }
}
