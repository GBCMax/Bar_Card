using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Bar_Card.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing.Common;
using ZXing;

namespace Bar_Card.ViewModel
{
    public partial class MainPageViewModel: ObservableObject
    {
        private string searchDrinkstring;
        public string SearchDrinkstring
        {
            get
            {
                return searchDrinkstring;
            }
            set
            {
                searchDrinkstring = value;
                SearchByName(searchDrinkstring);
                OnPropertyChanged();
            }
        }

        private bool isCheapDrink;
        public bool IsCheapDrink
        {
            get
            {
                return isCheapDrink;
            }
			set
			{
				isCheapDrink = value;
				if (value == false)
				{
					Drinks = new ObservableCollection<Drinks>(listOfDrinks);
					isCheapDrink = false;
				}
				else
				{
					isCheapDrink = true;
					FilterByCheap();
				}
			}
        }
        private ObservableCollection<Drinks> FilterByCheap()
        {
            Drinks = new ObservableCollection<Drinks>(listOfDrinks);
            Drinks = new ObservableCollection<Drinks>(Drinks.Where(x => x.Price < 500).ToList());

            return Drinks;
        }
        private ObservableCollection<Drinks> SearchByName(string search)
        {
            if(SearchDrinkstring != "")
            {
                Drinks = new ObservableCollection<Drinks>(Drinks.Where(x => x.Name.ToLower().Contains(search.ToLower())).ToList());
            }
            else
            {
                Drinks = new ObservableCollection<Drinks>(listOfDrinks);
            }
            return Drinks;
        }
        private bool isUsingFilter;
        public bool IsUsingFilter
        {
            get
            {
                return isUsingFilter;
            }
            set
            {
                isUsingFilter = value;
                if(value == false)
                {
                    Drinks = new ObservableCollection<Drinks>(listOfDrinks);
                    IsEnabledForFilters = false;
                }
                else
                {
                    IsEnabledForFilters = true;
                    if(isCheapDrink == true)
                    {
                        FilterByCheap();
                    }
                }
            }
        }
        private bool isEnabledForFilters;
        public bool IsEnabledForFilters
        {
            get
            {
                return isEnabledForFilters;
            }
            set
            {
                isEnabledForFilters = value;
                OnPropertyChanged();
            }
        }

        private List<Drinks> listOfDrinks = new List<Drinks>();

        [ObservableProperty]
        private ObservableCollection<Drinks> drinks = new ObservableCollection<Drinks>();

        [ObservableProperty]
        private Drinks selectedDrink;

        public MainPageViewModel() 
        {
            LoadDrinkAsync();
            DataUpdater.DataUpdated += LoadDrinkAsync;
        }
        public async void LoadDrinkAsync()
        {
            List<Drinks> drinkList = await App.Database.GetDrinkAsync();
            listOfDrinks.Clear();
            listOfDrinks.AddRange(drinkList);
            ObservableCollection<Drinks> drinksCollection = new ObservableCollection<Drinks>(drinkList);
            Drinks = drinksCollection;
        }

		[RelayCommand]
        private async Task ChangeDrink(Drinks drink)
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { "Drinks", drink }
            };
            await Shell.Current.GoToAsync("//DefaultPage/ChangeDrinkPage", navigationParameter);
            LoadDrinkAsync();
        }

		[RelayCommand]
		private async Task DeleteDrink(Drinks drink)
		{
			await App.Database.DeleteDrinkAsync(drink);
			await Application.Current.MainPage.DisplayAlert("Есть сэр", "Удалено", "Есть сэр");
            LoadDrinkAsync();
		}

		[RelayCommand]
		private async Task CheckInfoDrink(Drinks drink)
		{
			var navigationParameter = new Dictionary<string, object>
			{
				{ "Drinks", drink }
			};
			await Shell.Current.GoToAsync("//DefaultPage/FullInfoDrinkPage", navigationParameter);
		}
	}
}
