using System;
using System.Windows.Input;
using ZXing.Barcode.Demo.Model;
using ZXing.Barcode.Demo.Services;
using ZXing.Barcode.Demo.ViewModel;

namespace ZXing.Barcode.Demo.Command {
    class ScanBarcodeCommand : ICommand {
        private readonly PosProductListViewModel viewModel;
        private readonly IBarcodeScanner barcodeScanner;
        private readonly IProductDataService productDataService;

        public event EventHandler CanExecuteChanged {
            add { }
            remove { }
        }

        public ScanBarcodeCommand(PosProductListViewModel viewModel, IBarcodeScanner barcodeScanner, IProductDataService productDataService) {
            this.viewModel = viewModel;
            this.barcodeScanner = barcodeScanner;
            this.productDataService = productDataService;
        }

        public bool CanExecute(object parameter) {
            return true;
        }

        public async void Execute(object parameter) {
            var barcode = await barcodeScanner.Scan();
            if (barcode == null)
                return;

            ProductBM product = await productDataService.GetProductDataAsync(barcode);
            ProductDataViewModel item = new ProductDataViewModel() {
                Amount = 1,
                Barcode = product.Barcode,
                LocalizedName = product.LocalizedName,
                Tax = product.Tax,
                UnitNetPrice = product.UnitNetPrice,
                Unit = product.Unit
            };

            viewModel.Products.Add(item);
        }
    }
}
