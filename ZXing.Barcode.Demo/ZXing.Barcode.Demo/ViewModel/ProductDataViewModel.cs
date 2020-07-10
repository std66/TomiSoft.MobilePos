namespace ZXing.Barcode.Demo.ViewModel {
    public class ProductDataViewModel : BaseViewModel {
        public string LocalizedName { get; set; }
        public string Barcode { get; set; }
        public decimal UnitNetPrice { get; set; }
        public string Unit { get; set; }
        public decimal Tax { get; set; }
        public decimal Amount { get; set; }

        public decimal GetUnitGrossPrice() {
            return UnitNetPrice + (UnitNetPrice * Tax);
        }

        public decimal GetTotalGrossPrice() => GetUnitGrossPrice() * Amount;
    }
}
