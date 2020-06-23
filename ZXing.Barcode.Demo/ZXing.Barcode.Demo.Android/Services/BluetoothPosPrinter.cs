using Android.Bluetooth;
using ESCPOS;
using ESCPOS.Utils;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ZXing.Barcode.Demo.Services;
using static ESCPOS.Commands;

namespace ZXing.Barcode.Demo.Droid.Services {
    class BluetoothPosPrinter : IPosPrinter {
        public Task Print() {
            // First you get the BluetoothAdapter:
            BluetoothAdapter adapter = BluetoothAdapter.DefaultAdapter;
            // then, you get the device:
            BluetoothDevice device = adapter.BondedDevices.FirstOrDefault(d => d.Name == "IposPrinter");
            // now you create the socket
            BluetoothSocket socket = device.CreateRfcommSocketToServiceRecord(Java.Util.UUID.FromString("00001101-0000-1000-8000-00805F9B34FB"));
            socket.Connect();
            // and now, you're able to get OOS:
            Stream outputStream = socket.OutputStream;

            // then, you can send esc/pos commands:
            using BinaryWriter writer = new BinaryWriter(outputStream);

            List<string> lines = new List<string>() {
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
                "	",
                "Női táska             ",
                "    1db    ÁFA: 27%   1.500 Ft",
                "	",
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
                "=== NEM ADÓÜGYI BIZONYLAT! ==="
            };

            List<byte> data = new List<byte>();
            data.AddRange(ESCPOS.Commands.InitializePrinter);
            data.AddRange(SelectCharacterFont(Font.A));

            foreach (var line in lines) {
                if (string.IsNullOrWhiteSpace(line))
                    data.AddRange(LineFeed);
                else
                    data.AddRange(line.ToBytes());

                data.AddRange(LineFeed);
            }

            data.AddRange(LineFeed);
            data.AddRange(LineFeed);
            data.AddRange(LineFeed);
            data.AddRange(LineFeed);
            data.AddRange(LineFeed);
            data.AddRange(LineFeed);
            data.AddRange(LineFeed);

            writer.Write(data.ToArray());
            return Task.CompletedTask;
        }
    }
}