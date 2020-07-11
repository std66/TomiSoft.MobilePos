using System;

namespace ZXing.Barcode.Demo.Services {
    public interface IKeyboard {
        public event EventHandler<char> KeyPressed;
    }
}
