using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm.Messaging;
using Microsoft.Toolkit.Mvvm.Messaging.Messages;

namespace WCToolkitDemo.ViewModels
{
	public class MainViewModel : WCTViewModel
	{
		public MainViewModel()
		{
			// any setup we might need
			SelectedItem = NavItems[0];
			WeakReferenceMessenger.Default.Register<ValueChangedMessage<string>>(this, UpdateMessageText);
		}

		private void UpdateMessageText(object recipient, ValueChangedMessage<string> message)
		{
			MessageText = message.Value;
		}

		private List<string> navItems = new List<string>()
		{
			"Home", "Pokemon", "Demo"
		};
		public List<string> NavItems
		{
			get => navItems;
		}

		private string selectedItem = "";
		public string SelectedItem
		{
			get => selectedItem;
			set
			{
				SetProperty(ref selectedItem, value);
			}
		}

		private string messageText = "";
		public string MessageText
		{
			get => messageText;
			set
			{
				SetProperty(ref messageText, value);
			}
		}
	}
}
