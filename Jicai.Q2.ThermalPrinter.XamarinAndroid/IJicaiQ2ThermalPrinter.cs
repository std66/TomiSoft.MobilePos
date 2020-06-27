using System.Threading.Tasks;

namespace Jicai.Q2.ThermalPrinter.XamarinAndroid {
    public interface IJicaiQ2ThermalPrinter {
        bool IsConnected { get; }
        Task<bool> InitializePrinterAsync();
        Task<bool> SendEscPosCommandsAsync(byte[] commands);
        Task<bool> PerformPrintAsync();
        PrinterStatus GetPrinterStatus();
    }
}