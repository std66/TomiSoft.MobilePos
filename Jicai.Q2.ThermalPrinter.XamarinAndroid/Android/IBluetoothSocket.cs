using System.IO;
using System.Threading.Tasks;

namespace Jicai.Q2.ThermalPrinter.XamarinAndroid.Android {
    public interface IBluetoothSocket {
         Stream InputStream { get; }
         bool IsConnected { get; }
         Stream OutputStream { get; }

         void Connect();
         Task ConnectAsync();
    }
}