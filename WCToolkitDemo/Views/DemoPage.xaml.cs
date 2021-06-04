using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using WCToolkitDemo.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace WCToolkitDemo.Views
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class DemoPage : Page
	{
		private FirstViewModel vm1;
		private SecondViewModel vm2;

		public DemoPage()
		{
			this.InitializeComponent();

			vm1 = new FirstViewModel();
			vm2 = new SecondViewModel();

			Button1.Click += Button1_Click;
			Button2.Click += Button2_Click;

			Loaded += DemoPage_Loaded;
			Unloaded += DemoPage_Unloaded;
		}

		private void DemoPage_Loaded(object sender, RoutedEventArgs e)
		{
			vm1.OnLoaded();
			vm2.OnLoaded();
		}

		private void DemoPage_Unloaded(object sender, RoutedEventArgs e)
		{
			vm1.OnUnloaded();
			vm2.OnUnloaded();
		}

		private void Button1_Click(object sender, RoutedEventArgs e)
		{
			DataContext = vm1;
		}

		private void Button2_Click(object sender, RoutedEventArgs e)
		{
			DataContext = vm2;
		}
	}
}
