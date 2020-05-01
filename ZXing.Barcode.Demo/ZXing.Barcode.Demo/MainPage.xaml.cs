using System;
using System.ComponentModel;
using Xamarin.Forms;
using ZXing.Mobile;

namespace ZXing.Barcode.Demo {
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]
	public partial class MainPage : ContentPage {
		public MainPage() {
			InitializeComponent();
		}

		private async void Button_Clicked(object sender, EventArgs e) {
			var scanner = new MobileBarcodeScanner();

			var result = await scanner.Scan();

			if (result != null)
				Barcode.Text = result.Text;
		}
	}
}
