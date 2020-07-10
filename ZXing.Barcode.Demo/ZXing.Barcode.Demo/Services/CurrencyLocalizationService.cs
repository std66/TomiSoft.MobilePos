using ZXing.Barcode.Demo.Model;

namespace ZXing.Barcode.Demo.Services {
    public class CurrencyLocalizationService : ICurrencyLocalizationService {
        private readonly string CurrencyMark = "Ft";
        private readonly int CurrencyDecimals = 0;
        private readonly CurrencyMarkPosition CurrencyMarkPosition = CurrencyMarkPosition.AfterAmount;

        public string ToLocalizedString(decimal amount) {
            return AddCurrencyMark(FormatAmount(amount));
        }

        public decimal RoundAmount(decimal amount) {
            return amount;
        }

        private string AddCurrencyMark(string amountText) {
            if (CurrencyMarkPosition == CurrencyMarkPosition.BeforeAmount)
                return $"{CurrencyMark} {amountText}";
            else
                return $"{amountText} {CurrencyMark}";
        }

        private string FormatAmount(decimal amount) {
            string format;

            if (CurrencyDecimals == 0)
                format = "#,##0";
            else
                format = $"#,##0.{new string('#', CurrencyDecimals)}";

            return amount.ToString(format);
        }
    }
}
