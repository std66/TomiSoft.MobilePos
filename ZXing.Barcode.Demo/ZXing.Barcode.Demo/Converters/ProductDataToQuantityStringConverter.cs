using ZXing.Barcode.Demo.ViewModel;

namespace ZXing.Barcode.Demo.Converters {
    public class ProductDataToQuantityStringConverter : ProductDataToStringConverterBase {
        protected override string ProductDataToString(ProductDataViewModel productDataViewModel) {
            return $"{productDataViewModel.Amount:0.##} {productDataViewModel.Unit}";
        }
    }
}
