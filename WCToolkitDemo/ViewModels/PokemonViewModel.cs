using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm.Input;
using WCToolkitDemo.Models;

namespace WCToolkitDemo.ViewModels
{
	public class PokemonViewModel : WCTViewModel
	{
		public RelayCommand NextCommand { get; set; }
		public RelayCommand PreviousCommand { get; set; }

		public const string ElectricType = "Electric";
		public const string WaterType = "Water";
		public const string FireType = "Fire";
		public const string GrassType = "Grass";
		public const string PoofyType = "Poofy";

		private int currPokemon = 0;

		public PokemonViewModel()
		{
			SetupCommands();

			CreateTestData();
		}

		private void SetupCommands()
		{
			NextCommand = new RelayCommand(() =>
			{
				NextPokemon();
			});
			PreviousCommand = new RelayCommand(() =>
			{
				PreviousPokemon();
			});
		}

		public void PreviousPokemon()
		{
			if (currPokemon == 0)
			{
				currPokemon = Pokemon.Count - 1;
			}
			else
			{
				currPokemon--;
			}
			CurrentPokemon = Pokemon[currPokemon];
		}

		public void NextPokemon()
		{
			if (currPokemon == Pokemon.Count - 1)
			{
				currPokemon = 0;
			}
			else
			{
				currPokemon++;
			}
			CurrentPokemon = Pokemon[currPokemon];
		}

		private void CreateTestData()
		{
			Pokemon = new ObservableCollection<PokemonModel>();
			Pokemon.Add(new PokemonModel()
			{
				Name = "Pikachu",
				Type = ElectricType,
				Number = 1
			});
			Pokemon.Add(new PokemonModel()
			{
				Name = "Squirtle",
				Type = WaterType,
				Number = 2
			});
			Pokemon.Add(new PokemonModel()
			{
				Name = "Charmander",
				Type = FireType,
				Number = 3
			});
			Pokemon.Add(new PokemonModel()
			{
				Name = "Bulbasaur",
				Type = GrassType,
				Number = 4
			});
			Pokemon.Add(new PokemonModel()
			{
				Name = "Jigglypuff",
				Type = PoofyType,
				Number = 5
			});
			CurrentPokemon = Pokemon[currPokemon];
		}

		public string PageTitle
		{
			get => "Pokemans!";
		}

		private PokemonModel currentPokemon;
		public PokemonModel CurrentPokemon
		{
			get => currentPokemon;
			set
			{
				SetProperty(ref currentPokemon, value);
			}
		}

		private ObservableCollection<PokemonModel> pokemon;
		public ObservableCollection<PokemonModel> Pokemon
		{
			get => pokemon;
			set
			{
				SetProperty(ref pokemon, value);
			}
		}

	}
}
