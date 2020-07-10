namespace ZXing.Barcode.Demo.Model {
    public class ProductBM {
        public ProductBM(string localizedName, string barcode, string unit, decimal unitNetPrice, decimal tax) {
            LocalizedName = localizedName;
            Barcode = barcode;
            Unit = unit;
            UnitNetPrice = unitNetPrice;
            Tax = tax;
        }

        public string LocalizedName { get; }
        public string Barcode { get; }
        public string Unit { get; }
        public decimal UnitNetPrice { get; }
        public decimal Tax { get; }
    }
}
