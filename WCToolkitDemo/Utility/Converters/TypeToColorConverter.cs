using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using WCToolkitDemo.ViewModels;

namespace WCToolkitDemo.Utility.Converters
{
	public class TypeToColorConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			string pokeType = value as string;
			Color color = new Color();
			switch (pokeType)
			{
				case PokemonViewModel.ElectricType:
					color = Colors.Yellow;
					break;
				case PokemonViewModel.WaterType:
					color = Colors.Blue;
					break;
				case PokemonViewModel.FireType:
					color = Colors.OrangeRed;
					break;
				case PokemonViewModel.GrassType:
					color = Colors.Green;
					break;
				case PokemonViewModel.PoofyType:
					color = Colors.HotPink;
					break;
				default:
					color = Colors.Transparent;
					break;
			}
			return new SolidColorBrush(color);
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			// currently no need for converting back
			return "";
		}
	}
}
