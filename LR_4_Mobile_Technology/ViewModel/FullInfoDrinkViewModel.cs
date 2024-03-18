using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Bar_Card.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bar_Card.ViewModel
{
	[QueryProperty(nameof(Drinks), nameof(Drinks))]
	public partial class FullInfoDrinkViewModel : ObservableObject
	{
		[ObservableProperty]
		private Drinks drinks;
	}
}
