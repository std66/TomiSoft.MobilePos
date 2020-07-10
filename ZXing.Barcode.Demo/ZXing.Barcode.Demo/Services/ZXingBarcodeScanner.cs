using System.Threading.Tasks;
using ZXing.Mobile;

namespace ZXing.Barcode.Demo.Services {
    public class ZXingBarcodeScanner : IBarcodeScanner {
        public async Task<string> Scan() {
            MobileBarcodeScanner scanner = new MobileBarcodeScanner();
            var result = await scanner.Scan();

            return result?.Text;
        }
    }
}
