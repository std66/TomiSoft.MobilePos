using System.Threading.Tasks;

namespace ZXing.Barcode.Demo.Services {
    public interface IBarcodeScanner {
        Task<string> Scan();
    }
}