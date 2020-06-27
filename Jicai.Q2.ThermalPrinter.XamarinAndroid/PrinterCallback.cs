using Com.Iposprinter.Iposprinterservice;
using System;
using System.Runtime.CompilerServices;

namespace Jicai.Q2.ThermalPrinter.XamarinAndroid {
    public class PrinterCallback : IPosPrinterCallbackStub {
        private readonly string operationName;

        public event EventHandler<string> ReturnString;
        public event EventHandler<bool> RunResult;

        public PrinterCallback([CallerMemberName] string operationName = "") {
            this.operationName = operationName;
        }

        public override void OnReturnString(string result) {
            ReturnString?.Invoke(this, result);
        }

        public override void OnRunResult(bool isSuccess) {
            RunResult?.Invoke(this, isSuccess);
        }
    }
}