using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using ZXing.Barcode.Demo.Command;
using ZXing.Barcode.Demo.Services;

namespace ZXing.Barcode.Demo.ViewModel {
    class PosProductListViewModel : BaseViewModel {

        private string totalPrice;

        private readonly ICurrencyLocalizationService currencyLocalizationService;

        public string TotalPrice {
            get { return totalPrice; }
            set { 
                totalPrice = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<ProductDataViewModel> Products { get; } = new ObservableCollection<ProductDataViewModel>();
        public ICommand ScanBarcodeCommand { get; }

        public PosProductListViewModel() {
            ScanBarcodeCommand = new ScanBarcodeCommand(
                viewModel: this,
                barcodeScanner: DependencyService.Get<IBarcodeScannerFactory>().GetScanner(),
                productDataService: DependencyService.Get<IProductDataService>()
            );

            currencyLocalizationService = DependencyService.Get<ICurrencyLocalizationService>();

            Products.CollectionChanged += OnProductListChanged;
        }

        private void OnProductListChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) {
            decimal totalPrice = 0m;
            foreach (var product in Products) {
                totalPrice += product.GetTotalGrossPrice();
            }

            TotalPrice = currencyLocalizationService.ToLocalizedString(totalPrice);
        }
    }
}
