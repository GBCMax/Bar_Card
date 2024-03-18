using Bar_Card.View;

namespace Bar_Card
{
	public partial class AppShell : Shell
	{
		public AppShell()
		{
			InitializeComponent();
			Routing.RegisterRoute($"{nameof(DefaultPage)}/{nameof(ChangeDrinkPage)}", typeof(ChangeDrinkPage));
			Routing.RegisterRoute($"{nameof(AddDrink)}/{nameof(QRScannerPage)}", typeof(QRScannerPage));
			Routing.RegisterRoute($"{nameof(DefaultPage)}/{nameof(FullInfoDrinkPage)}", typeof(FullInfoDrinkPage));
		}
	}
}
