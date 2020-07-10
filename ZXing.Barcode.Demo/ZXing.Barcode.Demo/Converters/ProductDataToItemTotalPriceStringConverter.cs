using ZXing.Barcode.Demo.ViewModel;

namespace ZXing.Barcode.Demo.Converters {
    public class ProductDataToItemTotalPriceStringConverter : ProductDataPriceToStringConverterBase {
        protected override string ProductDataToString(ProductDataViewModel productDataViewModel) {
            return CurrencyLocalizationService.ToLocalizedString(productDataViewModel.GetTotalGrossPrice());
        }
    }
}
