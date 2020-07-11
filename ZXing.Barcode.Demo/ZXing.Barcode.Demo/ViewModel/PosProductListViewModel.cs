using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using ZXing.Barcode.Demo.Command;
using ZXing.Barcode.Demo.Model;
using ZXing.Barcode.Demo.Services;

namespace ZXing.Barcode.Demo.ViewModel {
    class PosProductListViewModel : BaseViewModel {

        private string totalPrice;
        private string keyboardInput = "";

        private readonly ICurrencyLocalizationService currencyLocalizationService;
        private readonly IProductDataService productDataService;
        private readonly IKeyboard keyboard;

        public string TotalPrice {
            get { return totalPrice; }
            set { 
                totalPrice = value;
                OnPropertyChanged();
            }
        }

        public string KeyboardInput {
            get => keyboardInput;
            set {
                keyboardInput = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<ProductDataViewModel> Products { get; } = new ObservableCollection<ProductDataViewModel>();
        public ICommand ScanBarcodeCommand { get; }

        public PosProductListViewModel() {
            ScanBarcodeCommand = new ScanBarcodeCommand(
                viewModel: this,
                barcodeScanner: DependencyService.Get<IBarcodeScannerFactory>().GetScanner()
            );

            currencyLocalizationService = DependencyService.Get<ICurrencyLocalizationService>();
            productDataService = DependencyService.Get<IProductDataService>();
            keyboard = DependencyService.Get<IKeyboard>();

            Products.CollectionChanged += OnProductListChanged;
            keyboard.KeyPressed += Keyboard_KeyPressed;

            this.TotalPrice = currencyLocalizationService.ToLocalizedString(0m);
        }

        private void Keyboard_KeyPressed(object sender, char e) {
            const char Enter = (char)13;
            const char Escape = (char)27;

            if (e == Enter) {
                AddProductByBarcode(KeyboardInput).ConfigureAwait(false);
                KeyboardInput = string.Empty;
            }
            else if (e == Escape) {
                KeyboardInput = string.Empty;
            }
            else {
                KeyboardInput += e;
            }
        }

        public async Task AddProductByBarcode(string barcode) {
            ProductBM product = await productDataService.GetProductDataAsync(barcode);
            ProductDataViewModel item = new ProductDataViewModel() {
                Amount = 1,
                Barcode = product.Barcode,
                LocalizedName = product.LocalizedName,
                Tax = product.Tax,
                UnitNetPrice = product.UnitNetPrice,
                Unit = product.Unit
            };

            Products.Add(item);
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
