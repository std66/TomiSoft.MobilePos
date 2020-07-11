
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Barcode.Demo.ViewModel;

namespace ZXing.Barcode.Demo.Pages {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PosProductListPage : ContentPage {
        private readonly PosProductListViewModel viewModel;

        public PosProductListPage() {
            InitializeComponent();

            viewModel = new PosProductListViewModel();
            BindingContext = viewModel;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e) {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
