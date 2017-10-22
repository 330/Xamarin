using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyStuff
{
    public class ItemInfoViewModel : BaseViewModel
    {
		private string itemName, itemNotes, boxName;
        private Box movedBoxName;
        public ICommand DeleteCommand { protected set; get; }
        public ICommand SaveCommand { protected set; get; }

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

		public string BoxName
		{
			get { return boxName; }
			set
			{
				boxName = value;
				OnPropertyChanged();
			}
		}
		public Box MovedBoxName
		{
			get { return movedBoxName; }
			set
			{
				movedBoxName = value;
				OnPropertyChanged();
			}
		}

        Item this_item;
        INavigation Navigation;

        public ItemInfoViewModel(Item item, INavigation navPg)
        {
            Navigation = navPg;

            itemName = item.ItemName;
            itemNotes = item.ItemNotes;
            boxName = item.BoxName;
            this_item = item;

            DeleteCommand = new Command(Delete);
            SaveCommand = new Command(Save);
        }

        private void Delete()
        {
            App.ItemDatabase.DeleteItemAsync(this_item);
            Navigation.PopAsync();
        }
		private void Save()
		{
            this_item.BoxName = movedBoxName.Name;
            App.ItemDatabase.SaveItemAsync(this_item);
			Navigation.PopAsync();
		}
    }
}
