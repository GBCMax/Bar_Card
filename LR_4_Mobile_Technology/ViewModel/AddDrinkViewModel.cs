using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Bar_Card.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bar_Card.ViewModel
{
	[QueryProperty(nameof(Name), nameof(Name))]
	[QueryProperty(nameof(Price), nameof(Price))]
	[QueryProperty(nameof(Consists), nameof(Consists))]
	[QueryProperty(nameof(Volume), nameof(Volume))]
	public partial class AddDrinkViewModel: ObservableObject
    {
        [ObservableProperty]
        private string name = String.Empty;

        [ObservableProperty]
        private double price;

        [ObservableProperty]
        private string consists = String.Empty;

        [ObservableProperty]
        private int volume;

        [RelayCommand]
        private async Task QRScan()
        {
            await Shell.Current.GoToAsync("//AddDrink/QRScannerPage");
        }

        [RelayCommand]
        private async Task AddDrink()
        {
            if (Name != string.Empty && Price != null && Consists != string.Empty && Volume != null)
            {
                await App.Database.SaveDrinkAsync(new Data.Drinks
                {
                    Name = this.Name,
                    Price = this.Price,
                    Consists = this.Consists,
                    Volume = this.Volume
                });
                await Application.Current.MainPage.DisplayAlert("Есть сэр", "Добавлено", "Есть сэр");
                ClearFields();
                DataUpdater.InformAboutDataUpdatedEvent();
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Ошибка", "Не все поля введены", "Никак нет");
            }
        }
        private void ClearFields()
        {
            Name = string.Empty;
            Price = 0;
            Consists = string.Empty;
            Volume = 0;
        }
    }
}
