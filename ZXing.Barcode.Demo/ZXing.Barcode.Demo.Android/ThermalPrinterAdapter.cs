using Com.Iposprinter.Iposprinterservice;
using ESCPOS.Utils;
using Jicai.Q2.ThermalPrinter.XamarinAndroid;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZXing.Barcode.Demo.Services;

namespace ZXing.Barcode.Demo.Droid {
    class ThermalPrinterAdapter : IPosPrinter {
        private readonly IJicaiQ2ThermalPrinter jicaiQ2ThermalPrinter;

        private readonly List<string> demoData = new List<string>() {
            "         SzuperKuckó          ",
            "4482 Kótaj, Kossuth L. utca 23",
            "",
            "       Sinku Tamás e.v.",
            "   Adószám: 66076072-1-35",
            " Szh: 4482 Kótaj, Petőfi út 5.",
            "",
            "       === Vásárlás ===       ",
            "",
            "Csúszda 2 méteres",
            "    1db    ÁFA: 27%  18.500 Ft",
            "",
            "Rattan kaspó",
            "    750 Ft/db",
            "    4db    ÁFA: 27%   3.000 Ft",
            "",
            "\"Injekció\" toll",
            "    500 Ft/db",
            "    2db    ÁFA: 27%   1.000 Ft",
            "",
            "Női táska             ",
            "    1db    ÁFA: 27%   1.500 Ft",
            "",
            "Rauch dobozos ital, 2dl",
            "    75 Ft/db",
            "    3db    ÁFA: 27%     225 Ft",
            "",
            "Összesen:            24.225 Ft",
            "Kerekítés:                0 Ft",
            "Kedvezmény:               0 Ft",
            "",
            "   Vásároljon nálunk még 2",
            "alkalommal, és 10% kedvezményt",
            "         adunk Önnek!",
            "",
            "    2020. 06. 21. 01:10:15",
            "         ID: 21923758",
            "",
            " == NEM ADÓÜGYI BIZONYLAT! =="
        };

        public ThermalPrinterAdapter(IJicaiQ2ThermalPrinter jicaiQ2ThermalPrinter) {
            this.jicaiQ2ThermalPrinter = jicaiQ2ThermalPrinter;
        }

        private PrinterCallback callback = new PrinterCallback();

        public async Task Print() {
            IPosPrinterService service = jicaiQ2ThermalPrinter.Service;
            service.PrinterInit(callback);
            byte[] data = GetEscPosData();
            string hexData = BitConverter.ToString(data).Replace("-", "");
            service.SendUserCMDData(data, callback);
            service.PrinterPerformPrint(0, callback);

            //foreach (string line in demoData) {
            //    await jicaiQ2ThermalPrinter.PrintTextAsync(line);
            //}
            //await jicaiQ2ThermalPrinter.PerformPrint(5);
        }

        private byte[] GetEscPosData() {
            List<byte> data = new List<byte>();

            data.AddRange(ESCPOS.Commands.InitializePrinter);
            data.AddRange(ESCPOS.Commands.SelectCharacterFont(ESCPOS.Font.A));
            data.AddRange(ESCPOS.Commands.SelectCodeTable(ESCPOS.CodeTable.Multilingual));

            foreach (string line in demoData) {
                if (string.IsNullOrWhiteSpace(line)) {
                    data.AddRange(ESCPOS.Commands.LineFeed);
                }
                else {
                    data.AddRange(line.ToBytes());
                }

                data.AddRange(ESCPOS.Commands.LineFeed);
            }

            data.AddRange(ESCPOS.Commands.PrintAndReturnToStandardMode);

            //data.AddRange(ESCPOS.Commands.PrintBarCode(ESCPOS.BarCodeType.EAN13, "599953876981"));

            return data.ToArray();
        }
    }
}