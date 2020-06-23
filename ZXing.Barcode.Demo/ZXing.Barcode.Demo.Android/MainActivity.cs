
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Jicai.Q2.ThermalPrinter.XamarinAndroid;
using Xamarin.Forms;
using ZXing.Barcode.Demo.Services;
using ZXing.Mobile;

namespace ZXing.Barcode.Demo.Droid {
    [Activity(Label = "ZXing.Barcode.Demo", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState) {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            Forms.Init(this, savedInstanceState);

            MobileBarcodeScanner.Initialize(Application);

            JicaiQ2ThermalPrinter.ServiceConnected += (o, e) => DependencyService.RegisterSingleton<IPosPrinter>(new ThermalPrinterAdapter(e));
            bool result = JicaiQ2ThermalPrinter.InitializeBinding(this);

            ConfigureServices();

            LoadApplication(new App());
        }

        private static void ConfigureServices() {
            //DependencyService.Register<IPosPrinter, BluetoothPosPrinter>();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            Net.Mobile.Android.PermissionsHandler.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}