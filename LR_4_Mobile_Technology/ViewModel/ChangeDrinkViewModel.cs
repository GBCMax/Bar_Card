using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Bar_Card.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Java.Util.Jar.Attributes;

namespace Bar_Card.ViewModel
{
	[QueryProperty(nameof(Drinks), nameof(Drinks))]
	public partial class ChangeDrinkViewModel : ObservableObject
	{
		[ObservableProperty]
		private Drinks drinks;

		[RelayCommand]
		private async Task ChangeDrink()
		{
			if(Drinks.Name != String.Empty && Drinks.Price != null && Drinks.Consists != string.Empty && Drinks.Volume != null)
			{
				await App.Database.UpdateDrinkAsync(Drinks);
				await Application.Current.MainPage.DisplayAlert("Есть сэр", "Изменено", "Есть сэр");
				DataUpdater.InformAboutDataUpdatedEvent();
			}
			else
			{
				await Application.Current.MainPage.DisplayAlert("Никак нет", "Введены не все поля", "Никак нет");
			}
		}
	}
}
