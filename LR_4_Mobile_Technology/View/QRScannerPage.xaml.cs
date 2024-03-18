using Bar_Card.Data;
using System.Text.Json;
using ZXing.Net.Maui.Readers;

namespace Bar_Card.View;

public partial class QRScannerPage : ContentPage
{
	private Drinks drink = null;
	public QRScannerPage()
	{
		InitializeComponent();
	}
	private void BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
	{
		Dispatcher.DispatchAsync(async () =>
		{
			string str = $"{e.Results[0].Value}";
			drink = JsonSerializer.Deserialize<Drinks>(str);
			var navigationParameter = new Dictionary<string, object>
			{
				{ "Name", drink.Name },
				{ "Price", drink.Price },
				{ "Consists", drink.Consists },
				{ "Volume", drink.Volume }
			};
			barcodeReader.IsDetecting = false;
			await Shell.Current.GoToAsync("//AddDrink", navigationParameter);
		});
	}
}