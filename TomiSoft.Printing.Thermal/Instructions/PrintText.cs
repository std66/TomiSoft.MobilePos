using ESCPOS.Utils;
using System.Collections.Generic;
using TomiSoft.Printing.Thermal.StringHandling;

namespace TomiSoft.Printing.Thermal.Instructions {
    public class PrintText : Instruction {
        private readonly string text;

        public PrintText(string text) {
            this.text = text;
        }

        internal override IEnumerable<byte> Compile(ThermalPrinterConfiguration config) {
            List<byte> result = new List<byte>();

            foreach (string line in StringHelper.DivideToMultipleLines(text, config.MaxLineLength)) {
                result.AddRange(line.ToBytes());
            }

            return result;
        }
    }
}
