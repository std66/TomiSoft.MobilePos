using System.Threading.Tasks;

namespace ZXing.Barcode.Demo.Services {
    public interface IPosPrinter {
        Task Print();
    }
}
