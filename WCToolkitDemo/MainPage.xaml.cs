using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using WCToolkitDemo.ViewModels;
using WCToolkitDemo.Views;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WCToolkitDemo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            DataContext = new MainViewModel();

			MainNav.ItemInvoked += MainNav_ItemInvoked;
            MainContent.Navigate(typeof(HomePage));
        }

		private void MainNav_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
		{
            string selectedPage = args.InvokedItem as string;

            if (selectedPage == ViewModel.SelectedItem)
			{
                return;
			}

            if (selectedPage == "Home")
			{
                MainContent.Navigate(typeof(HomePage));
			}
            else if (selectedPage == "Pokemon")
			{
                MainContent.Navigate(typeof(PokemonPage));
			}
            else if (selectedPage == "Demo")
			{
                MainContent.Navigate(typeof(DemoPage));
			}
            else
			{
                MainContent.Navigate(typeof(HomePage));
			}
		}

        private MainViewModel ViewModel
		{
            get => DataContext as MainViewModel;
		}
	}
}
