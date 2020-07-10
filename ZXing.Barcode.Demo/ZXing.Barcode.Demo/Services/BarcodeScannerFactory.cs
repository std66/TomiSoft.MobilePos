namespace ZXing.Barcode.Demo.Services {
    public class BarcodeScannerFactory : IBarcodeScannerFactory {
        public IBarcodeScanner GetScanner() => new ZXingBarcodeScanner();
    }
}
