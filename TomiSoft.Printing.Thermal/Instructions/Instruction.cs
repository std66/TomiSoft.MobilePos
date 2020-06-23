using System.Collections.Generic;

namespace TomiSoft.Printing.Thermal.Instructions {
    public abstract class Instruction {
        internal abstract IEnumerable<byte> Compile(ThermalPrinterConfiguration config);
    }
}
