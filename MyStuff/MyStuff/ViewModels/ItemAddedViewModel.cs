using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyStuff
{
    public class ItemAddedViewModel : BaseViewModel
    {
		private string itemName, itemNotes, boxName;
        public ICommand SaveCommand { protected set; get; }
        public ICommand CancelCommand { protected set; get; }
		
        public string ItemName
		{
			get { return itemName; }
			set
			{
				itemName = value;
				OnPropertyChanged();
			}
		}

		public string ItemNotes
		{
			get { return itemNotes; }
			set
			{
				itemNotes = value;
				OnPropertyChanged();
			}
		}

		//public string BoxName
		//{
		//	get { return boxName; }
		//	set
		//	{
		//		boxName = value;
		//		OnPropertyChanged();
		//	}
		//}

        INavigation Navigation;
        public ItemAddedViewModel(string box_name, INavigation PageNav)
        {
            Navigation = PageNav;
            boxName = box_name;
            SaveCommand = new Command(Save);
            CancelCommand = new Command(Cancel);
        }

        private void Save()
        {
            App.ItemDatabase.SaveItemAsync(new Item()
			{
                ItemName = this.itemName,
                ItemNotes = this.itemNotes,
                BoxName = this.boxName
			});

            Navigation.PopAsync();
        }

        private void Cancel() 
        {
            Navigation.PopAsync();
        }
    }
}
