namespace ZXing.Barcode.Demo.Services {
    public interface IBarcodeScannerFactory {
        IBarcodeScanner GetScanner();
    }
}