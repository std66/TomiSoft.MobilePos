using System;
using System.ComponentModel;
using Xamarin.Forms;
using ZXing.Barcode.Demo.Pages;
using ZXing.Barcode.Demo.Services;

namespace ZXing.Barcode.Demo {
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
	public partial class MainPage : ContentPage {

		public MainPage() {
			InitializeComponent();
		}

		private async void Button_Clicked(object sender, EventArgs e) {
			await Navigation.PushAsync(
				new SearchProductPage()
			);
		}

		private async void Button_Clicked_1(object sender, EventArgs e) {
			IPosPrinter printer = DependencyService.Get<IPosPrinter>();
			if (printer == null)
				await DisplayAlert("Error", "Printer is NULL", "OK");
			else
				await printer.Print();
		}
	}
}