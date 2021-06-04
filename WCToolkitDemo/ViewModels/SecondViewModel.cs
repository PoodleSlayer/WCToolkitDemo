using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCToolkitDemo.Models;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using Microsoft.Toolkit.Mvvm.Messaging.Messages;

namespace WCToolkitDemo.ViewModels
{
	public class SecondViewModel : WCTViewModel
	{
		public RelayCommand MessageCommand { get; set; }

		public SecondViewModel()
		{
			CreateTestData();
			SetupCommands();
		}

		public void OnLoaded()
		{

		}

		public void OnUnloaded()
		{

		}

		private void SetupCommands()
		{
			MessageCommand = new RelayCommand(SendMessage);
		}

		private void SendMessage()
		{
			ValueChangedMessage<string> msg = new ValueChangedMessage<string>("Cool message from the airplane viewmodel.");
			WeakReferenceMessenger.Default.Send(msg);
		}

		private void CreateTestData()
		{
			ItemList = new ObservableCollection<PlaneModel>();
			ItemList.Add(new PlaneModel()
			{
				Designation = "F-14",
				Name = "TomCat",
				Type = "Fighter",
				Number = 1
			});
			ItemList.Add(new PlaneModel()
			{
				Designation = @"F/A-18",
				Name = "Hornet",
				Type = @"Fighter/Attack",
				Number = 2
			});
			ItemList.Add(new PlaneModel()
			{
				Designation = "B-2",
				Name = "Spirit",
				Type = "Bomber",
				Number = 3
			});
			ItemList.Add(new PlaneModel()
			{
				Designation = "A-10",
				Name = "Warthog",
				Type = @"Attack/Bomber",
				Number = 4
			});
			ItemList.Add(new PlaneModel()
			{
				Designation = "F-16",
				Name = "Falcon",
				Type = "Fighter",
				Number = 5
			});
			ItemList.Add(new PlaneModel()
			{
				Designation = "F-15",
				Name = "Eagle",
				Type = "Fighter",
				Number = 6
			});
			ItemList.Add(new PlaneModel()
			{
				Designation = "F-117",
				Name = "Nighthawk",
				Type = @"Stealth Fighter/Bomber",
				Number = 7
			});
			ItemList.Add(new PlaneModel()
			{
				Designation = "C-5",
				Name = "Galaxy",
				Type = "Cargo",
				Number = 8
			});
			ItemList.Add(new PlaneModel()
			{
				Designation = "C-130",
				Name = "Hercules",
				Type = @"Cargo/Gunship",
				Number = 9
			});
		}

		private ObservableCollection<PlaneModel> itemList;
		public ObservableCollection<PlaneModel> ItemList
		{
			get => itemList;
			set
			{
				SetProperty(ref itemList, value);
			}
		}

		public string Title
		{
			get => "Airplane ViewModel";
		}

		public string About
		{
			get => "Airplanes, duh";
		}

		public string Contains
		{
			get => ItemList != null ? $"{ItemList.Count} airplanes" : "No airplanes :c";
		}
	}
}
