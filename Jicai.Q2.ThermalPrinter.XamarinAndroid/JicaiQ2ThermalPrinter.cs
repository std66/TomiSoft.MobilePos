using Android.Bluetooth;
using Android.Content;
using Android.OS;
using Com.Iposprinter.Iposprinterservice;
using Jicai.Q2.ThermalPrinter.XamarinAndroid.Android;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Jicai.Q2.ThermalPrinter.XamarinAndroid {
    public class JicaiQ2ThermalPrinter : Java.Lang.Object, IServiceConnection, IJicaiQ2ThermalPrinter {
        private IPosPrinterService printerService;

        public static event EventHandler<IJicaiQ2ThermalPrinter> ServiceConnected;

        public void OnServiceConnected(ComponentName name, IBinder service) {
            printerService = PosPrinterServiceStub.AsInterface(service);

            if (printerService != null)
                ServiceConnected?.Invoke(null, this);
        }

        public void OnServiceDisconnected(ComponentName name) {
            printerService = null;
        }

        public bool IsConnected => printerService != null;

        private IPosPrinterService Printer {
            get {
                if (!IsConnected) {
                    throw new InvalidOperationException($"The printer service is currently not connected. Please check if {nameof(InitializeBinding)} has succeeded.");
                }

                return printerService;
            }
        }

        private JicaiQ2ThermalPrinter() {}

        public static bool InitializeBinding(Context context) {
            Intent i = new Intent();
            i.SetPackage("com.iposprinter.iposprinterservice");
            i.SetAction("com.iposprinter.iposprinterservice.IPosPrintService");

            IServiceConnection serviceConnection = new JicaiQ2ThermalPrinter();
            return context.BindService(i, serviceConnection, Bind.AutoCreate);
        }

        public static bool InitializeBluetooth(string deviceName) {
            BluetoothDevice device = BluetoothAdapter.DefaultAdapter.BondedDevices.Where(x => x.Name == deviceName).SingleOrDefault();
            if (device == null)
                return false;

            BluetoothSocket socket = device.CreateRfcommSocketToServiceRecord(Java.Util.UUID.FromString("00001101-0000-1000-8000-00805F9B34FB"));
            socket.Connect();
            ServiceConnected?.Invoke(null, new JicaiQ2ThermalPrinterBluetooth(new BluetoothSocketAdapter(socket)));
            
            return true;
        }

        public Task<bool> InitializePrinterAsync() {
            var t = new TaskCompletionSource<bool>();

            PrinterCallback callback = new PrinterCallback();
            callback.RunResult += (o, e) => t.TrySetResult(e && GetPrinterStatus() == PrinterStatus.Ready);

            Printer.PrinterInit(callback);

            return t.Task;
        }

        public Task<bool> SendEscPosCommandsAsync(byte[] commands) {
            var t = new TaskCompletionSource<bool>();

            PrinterCallback callback = new PrinterCallback();
            callback.ReturnString += (o, e) => t.TrySetResult(e == "CACHE PRINTDATA  DATA OK!");

            Printer.SendUserCMDData(commands, callback);

            return t.Task;
        }

        public Task<bool> PerformPrintAsync() {
            PrinterStatus printerStatus = GetPrinterStatus();
            if (printerStatus != PrinterStatus.Ready)
                return Task.FromResult(false);

            var t = new TaskCompletionSource<bool>();

            PrinterCallback cb = new PrinterCallback();
            cb.ReturnString += (o, e) => t.TrySetResult(e == "UserCMDData is Paesed OK!");

            Printer.PrinterPerformPrint(0, cb);

            return t.Task;
        }

        public PrinterStatus GetPrinterStatus() {
            switch (Printer.PrinterStatus) {
                case 0: return PrinterStatus.Ready;
                case 1: return PrinterStatus.OutOfPaper;
                case 2: return PrinterStatus.PrintingHeadOverheat;
                case 3: return PrinterStatus.MotorOverheat;
                case 4: return PrinterStatus.Busy;
                default: return PrinterStatus.Unknown;
            }
        }
    }
}