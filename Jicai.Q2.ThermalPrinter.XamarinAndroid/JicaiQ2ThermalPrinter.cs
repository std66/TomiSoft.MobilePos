using Android.Content;
using Android.OS;
using Com.Iposprinter.Iposprinterservice;
using System;
using System.Threading.Tasks;

namespace Jicai.Q2.ThermalPrinter.XamarinAndroid {
    public class JicaiQ2ThermalPrinter : Java.Lang.Object, IServiceConnection, IJicaiQ2ThermalPrinter {
        private IPosPrinterService printerService;

        public static event EventHandler<IJicaiQ2ThermalPrinter> ServiceConnected;

        public void OnServiceConnected(ComponentName name, IBinder service) {
            printerService = IPosPrinterServiceStub.AsInterface(service);

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

        public Task<bool> InitializePrinterAsync() {
            var t = new TaskCompletionSource<bool>();

            PrinterCallback callback = new PrinterCallback();
            callback.RunResult += (o, e) => t.TrySetResult(e);

            Printer.PrinterInit(callback);

            return t.Task;
        }

        public Task<bool> PrintTextAsync(string text) {
            var t = new TaskCompletionSource<bool>();

            PrinterCallback callback = new PrinterCallback();
            callback.ReturnString += (o, e) => t.TrySetResult(e == "CACHE PRINTDATA  DATA OK!");
            Printer.PrintText(text, callback);

            return t.Task;
        }

        public Task<bool> SendEscPosCommandsAsync(byte[] commands) {
            var t = new TaskCompletionSource<bool>();

            PrinterCallback callback = new PrinterCallback();
            callback.ReturnString += (o, e) => t.TrySetResult(e == "CACHE PRINTDATA  DATA OK!");

            Printer.SendUserCMDData(commands, callback);

            return t.Task;
        }

        public Task<bool> PerformPrint(int feedLines) {
            PrinterStatus printerStatus = GetPrinterStatus();
            if (printerStatus != PrinterStatus.Ready)
                return Task.FromResult(false);

            var t = new TaskCompletionSource<bool>();

            PrinterCallback callback = new PrinterCallback();
            callback.RunResult += (o, e) => t.TrySetResult(e);
            callback.ReturnString += (o, e) => t.TrySetResult(false);

            Printer.PrinterPerformPrint(feedLines, callback);

            return t.Task;
        }

        public PrinterStatus GetPrinterStatus() {
            switch (Printer.GetPrinterStatus()) {
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