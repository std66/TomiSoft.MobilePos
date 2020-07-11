
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Jicai.Q2.ThermalPrinter.XamarinAndroid;
using System;
using Xamarin.Forms;
using ZXing.Barcode.Demo.Droid.Renderers;
using ZXing.Barcode.Demo.Services;
using ZXing.Mobile;

namespace ZXing.Barcode.Demo.Droid {
    [Activity(Label = "ZXing.Barcode.Demo", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : Xamarin.Forms.Platform.Android.FormsAppCompatActivity, IKeyboard
    {
        public event EventHandler<char> KeyPressed;

        protected override void OnCreate(Bundle savedInstanceState) {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            Forms.Init(this, savedInstanceState);

            MobileBarcodeScanner.Initialize(Application);

            JicaiQ2ThermalPrinter.ServiceConnected += (o, e) => DependencyService.RegisterSingleton<IPosPrinter>(new ThermalPrinterAdapter(e));
            bool result = JicaiQ2ThermalPrinter.InitializeBinding(this);
            //bool result = JicaiQ2ThermalPrinter.InitializeBluetooth("IposPrinter");

            ConfigureServices();

            LoadApplication(new App());
        }

        private void ConfigureServices() {
            //DependencyService.Register<IPosPrinter, BluetoothPosPrinter>();
            DependencyService.Register<IBarcodeScannerFactory, BarcodeScannerFactory>();
            DependencyService.Register<ICurrencyLocalizationService, CurrencyLocalizationService>();
            DependencyService.Register<IProductDataService, ProductDataService>();
            DependencyService.RegisterSingleton<IKeyboard>(this);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            Net.Mobile.Android.PermissionsHandler.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public override bool OnKeyUp([GeneratedEnum] Keycode keyCode, KeyEvent e) {
            var handled = false;

            Android.Util.Log.Info("TomiSoft.KeyboardInput", $"TomiSoft!! Keyboard input: {keyCode}");

            if (keyCode >= Keycode.A && keyCode <= Keycode.Z) {
                // Letter
                handled = true;
            }
            else if ((keyCode >= Keycode.Num0 && keyCode <= Keycode.Num9) ||
                        (keyCode >= Keycode.Numpad0 && keyCode <= Keycode.Num9)) {
                // Number
                handled = true;
            }
            else if (keyCode == Keycode.Enter || keyCode == Keycode.NumpadEnter
                    || keyCode == Keycode.Escape) {
                handled = true;
            }

            if (handled) {
                this.KeyPressed?.Invoke(this, KeyboardMap.Mapping[keyCode]);
            }

            return handled;
        }
    }
}