using Newtonsoft.Json;
using System;
using TomiSoft.ProductCatalog.Client.OpenApiGenerated.Api;
using TomiSoft.ProductCatalog.Client.OpenApiGenerated.Client;
using TomiSoft.ProductCatalog.Client.OpenApiGenerated.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Mobile;

namespace ZXing.Barcode.Demo.Pages {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchProductPage : ContentPage {
        public SearchProductPage() {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e) {
            var scanner = new MobileBarcodeScanner();

            var result = await scanner.Scan();

            if (result != null) {
                string barcode = result.Text;

                IProductApi api = new ProductApi("http://192.168.1.100:5000");
                try {
                    ProductInformationDto dto = await api.GetByBarcodeAsync(barcode);
                    ProductName.Text = dto.Name;
                }
                catch (ApiException ex) {
                    string message;

                    ErrorResultDto errorDto = JsonConvert.DeserializeObject<ErrorResultDto>(ex.ErrorContent.ToString());
                    switch (errorDto.ErrorCode) {
                        case ErrorResultDto.ErrorCodeEnum.GenericError:
                            message = "A szerver nem tudta feldolgozni a kérést";
                            break;
                        case ErrorResultDto.ErrorCodeEnum.ProductNotFound:
                            message = "Nincs termék ezzel a vonalkóddal";
                            break;
                        default:
                            message = "Ismeretlen hiba történt";
                            break;
                    }

                    await DisplayAlert("Hiba", message, "Ok");
                }
                catch (Exception ex) {
                    await DisplayAlert("Hiba", "Ismeretlen hiba történt", "Ok");
                }
            }
        }
    }
}