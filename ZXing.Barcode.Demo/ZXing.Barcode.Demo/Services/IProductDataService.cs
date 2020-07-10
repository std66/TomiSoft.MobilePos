using System.Threading.Tasks;
using ZXing.Barcode.Demo.Model;

namespace ZXing.Barcode.Demo.Services {
    public interface IProductDataService {
        Task<ProductBM> GetProductDataAsync(string barcode);
    }
}