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
	public class FirstViewModel : WCTViewModel
	{
		public RelayCommand MessageCommand { get; set; }

		public FirstViewModel()
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
			ValueChangedMessage<string> msg = new ValueChangedMessage<string>("Pokemon viewmodel just sent a message!");
			WeakReferenceMessenger.Default.Send(msg);
		}

		private void CreateTestData()
		{
			ItemList = new ObservableCollection<PokemonModel>();
			ItemList.Add(new PokemonModel()
			{
				Name = "Pikachu",
				Type = "Electric",
				Number = 1
			});
			ItemList.Add(new PokemonModel()
			{
				Name = "Squirtle",
				Type = "Water",
				Number = 2
			});
			ItemList.Add(new PokemonModel()
			{
				Name = "Charmander",
				Type = "Fire",
				Number = 3
			});
			ItemList.Add(new PokemonModel()
			{
				Name = "Bulbasaur",
				Type = "Grass",
				Number = 4
			});
			ItemList.Add(new PokemonModel()
			{
				Name = "Jigglypuff",
				Type = "Poofy",
				Number = 5
			});
		}

		private ObservableCollection<PokemonModel> itemList;
		public ObservableCollection<PokemonModel> ItemList
		{
			get => itemList;
			set
			{
				SetProperty(ref itemList, value);
			}
		}

		public string Title
		{
			get => "Pokemans ViewModel";
		}

		public string About
		{
			get => "This ViewModel has Pokemon stufff";
		}

		public string Contains
		{
			get => ItemList != null ? $"{ItemList.Count} Pokemon" : "No Pokemon :c";
		}
	}
}
