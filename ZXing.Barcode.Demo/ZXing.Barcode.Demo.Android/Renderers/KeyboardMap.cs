using Android.Views;
using System.Collections.Generic;

namespace ZXing.Barcode.Demo.Droid.Renderers {
    class KeyboardMap {
        public static readonly IReadOnlyDictionary<Keycode, char> Mapping = new Dictionary<Keycode, char> {
            [Keycode.A] = 'A',
            [Keycode.B] = 'B',
            [Keycode.C] = 'C',
            [Keycode.D] = 'D',
            [Keycode.E] = 'E',
            [Keycode.F] = 'F',
            [Keycode.G] = 'G',
            [Keycode.H] = 'H',
            [Keycode.I] = 'I',
            [Keycode.J] = 'J',
            [Keycode.K] = 'K',
            [Keycode.L] = 'L',
            [Keycode.M] = 'M',
            [Keycode.N] = 'N',
            [Keycode.O] = 'O',
            [Keycode.P] = 'P',
            [Keycode.Q] = 'Q',
            [Keycode.R] = 'R',
            [Keycode.S] = 'S',
            [Keycode.T] = 'T',
            [Keycode.U] = 'U',
            [Keycode.V] = 'V',
            [Keycode.W] = 'W',
            [Keycode.X] = 'X',
            [Keycode.Y] = 'Y',
            [Keycode.Z] = 'Z',
            
            [Keycode.Num0] = '0',
            [Keycode.Num1] = '1',
            [Keycode.Num2] = '2',
            [Keycode.Num3] = '3',
            [Keycode.Num4] = '4',
            [Keycode.Num5] = '5',
            [Keycode.Num6] = '6',
            [Keycode.Num7] = '7',
            [Keycode.Num8] = '8',
            [Keycode.Num9] = '9',

            [Keycode.Numpad0] = '0',
            [Keycode.Numpad2] = '2',
            [Keycode.Numpad3] = '3',
            [Keycode.Numpad4] = '4',
            [Keycode.Numpad5] = '5',
            [Keycode.Numpad6] = '6',
            [Keycode.Numpad7] = '7',
            [Keycode.Numpad8] = '8',
            [Keycode.Numpad1] = '1',
            [Keycode.Numpad9] = '9',

            [Keycode.Enter] = (char)13,
            [Keycode.NumpadEnter] = (char)13,
            [Keycode.Escape] = (char)27,
        };
    }
}