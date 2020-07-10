namespace ZXing.Barcode.Demo.Services {
    public interface ICurrencyLocalizationService {
        string ToLocalizedString(decimal amount);
    }
}