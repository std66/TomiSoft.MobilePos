using Xamarin.Forms;
using ZXing.Barcode.Demo.Services;

namespace ZXing.Barcode.Demo.Converters {
    public abstract class ProductDataPriceToStringConverterBase : ProductDataToStringConverterBase {
        protected ICurrencyLocalizationService CurrencyLocalizationService { get; }

        private class MockCurrencyLocalizationService : ICurrencyLocalizationService {
            public string ToLocalizedString(decimal amount) {
                return $"Ft {amount}";
            }
        }

        public ProductDataPriceToStringConverterBase() : this(DependencyService.Get<ICurrencyLocalizationService>() ?? new MockCurrencyLocalizationService()) {

        }

        public ProductDataPriceToStringConverterBase(ICurrencyLocalizationService currencyLocalizationService) {
            this.CurrencyLocalizationService = currencyLocalizationService;
        }
    }
}
