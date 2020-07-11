using System;
using System.Windows.Input;
using ZXing.Barcode.Demo.Services;
using ZXing.Barcode.Demo.ViewModel;

namespace ZXing.Barcode.Demo.Command {
    class ScanBarcodeCommand : ICommand {
        private readonly PosProductListViewModel viewModel;
        private readonly IBarcodeScanner barcodeScanner;

        public event EventHandler CanExecuteChanged {
            add { }
            remove { }
        }

        public ScanBarcodeCommand(PosProductListViewModel viewModel, IBarcodeScanner barcodeScanner) {
            this.viewModel = viewModel;
            this.barcodeScanner = barcodeScanner;
        }

        public bool CanExecute(object parameter) {
            return true;
        }

        public async void Execute(object parameter) {
            var barcode = await barcodeScanner.Scan();
            if (barcode == null)
                return;

            await viewModel.AddProductByBarcode(barcode);
        }
    }
}
