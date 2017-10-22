using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyStuff
{
    public class SearchViewModel : BaseViewModel
    {
        public ICommand SearchCommand { get; private set; }
        private string searchText;
        private List<Box> boxes;

		private string name, notes;

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

		public string SearchText
		{
			get { return searchText; }
			set
			{
				searchText = value;
				OnPropertyChanged();
			}
		}

		public List<Box> Boxes
		{
			get { return boxes; }
			set
			{
				boxes = value;
				OnPropertyChanged();
			}
		}

        public SearchViewModel()
        {
            SearchCommand = new Command(Search);
        }

        private void Search() {
            boxes = App.Database.GetItemsWithName(searchText).Result;
        }

    }
}
