using System;
using System.Globalization;
using Xamarin.Forms;
using ZXing.Barcode.Demo.ViewModel;

namespace ZXing.Barcode.Demo.Converters {
    public abstract class ProductDataToStringConverterBase : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (!(value is ProductDataViewModel viewModel))
                return null;

            return ProductDataToString(viewModel);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return value;
        }

        protected abstract string ProductDataToString(ProductDataViewModel productDataViewModel);
    }
}
