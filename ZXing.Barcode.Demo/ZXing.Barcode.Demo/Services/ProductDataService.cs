using System;
using System.Threading.Tasks;
using ZXing.Barcode.Demo.Model;

namespace ZXing.Barcode.Demo.Services {
    public class ProductDataService : IProductDataService {
        private readonly Random random = new Random();

        public Task<ProductBM> GetProductDataAsync(string barcode) {
            return Task.FromResult(
                new ProductBM($"Teszt termék {barcode}", barcode, "db", random.Next(100, 1500) / 10 * 10, 0.27m)
            );
        }
    }
}
