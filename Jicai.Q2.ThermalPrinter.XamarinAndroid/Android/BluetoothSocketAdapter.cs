using Android.Bluetooth;
using System.IO;
using System.Threading.Tasks;

namespace Jicai.Q2.ThermalPrinter.XamarinAndroid.Android {
    internal class BluetoothSocketAdapter : IBluetoothSocket {
        private readonly BluetoothSocket socket;

        public BluetoothConnectionType ConnectionType => this.socket.ConnectionType;

        public Stream InputStream => this.socket.InputStream;

        public bool IsConnected => this.socket.IsConnected;

        public Stream OutputStream => this.socket.OutputStream;

        public BluetoothSocketAdapter(BluetoothSocket socket) {
            this.socket = socket;
        }

        public void Connect() {
            this.socket.Connect();
        }

        public Task ConnectAsync() {
            return this.socket.ConnectAsync();
        }
    }
}