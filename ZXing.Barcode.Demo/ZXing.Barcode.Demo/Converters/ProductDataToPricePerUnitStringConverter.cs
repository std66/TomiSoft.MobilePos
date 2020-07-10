using ZXing.Barcode.Demo.ViewModel;

namespace ZXing.Barcode.Demo.Converters {
    public class ProductDataToPricePerUnitStringConverter : ProductDataPriceToStringConverterBase {
        protected override string ProductDataToString(ProductDataViewModel productDataViewModel) {
            string localizedPrice = CurrencyLocalizationService.ToLocalizedString(productDataViewModel.GetUnitGrossPrice());
            return $"{localizedPrice}/{productDataViewModel.Unit}";
        }
    }
}
