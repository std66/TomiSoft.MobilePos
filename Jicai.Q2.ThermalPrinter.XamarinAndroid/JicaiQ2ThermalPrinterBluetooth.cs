using Jicai.Q2.ThermalPrinter.XamarinAndroid.Android;
using System.IO;
using System.Threading.Tasks;

namespace Jicai.Q2.ThermalPrinter.XamarinAndroid {
    internal class JicaiQ2ThermalPrinterBluetooth : IJicaiQ2ThermalPrinter {
        private readonly IBluetoothSocket socket;

        public bool IsConnected => socket.IsConnected;

        internal JicaiQ2ThermalPrinterBluetooth(IBluetoothSocket socket) {
            this.socket = socket;
        }

        public PrinterStatus GetPrinterStatus() {
            return PrinterStatus.Ready;
        }

        public Task<bool> InitializePrinterAsync() {
            return Task.FromResult(true);
        }

        public Task<bool> PerformPrintAsync() {
            return Task.FromResult(true);
        }

        public Task<bool> SendEscPosCommandsAsync(byte[] commands) {
            BinaryWriter writer = new BinaryWriter(socket.OutputStream);
            writer.Write(commands);
            writer.Flush();

            return Task.FromResult(true);
        }
    }
}