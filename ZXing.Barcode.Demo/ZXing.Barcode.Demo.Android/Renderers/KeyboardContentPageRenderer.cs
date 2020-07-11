using Android.Content;
using Android.Runtime;
using Android.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using ZXing.Barcode.Demo.Pages;

[assembly: ExportRenderer(typeof(KeyboardContentPage), typeof(ZXing.Barcode.Demo.Droid.Renderers.KeyboardContentPageRenderer))]

namespace ZXing.Barcode.Demo.Droid.Renderers {
    [Preserve(AllMembers = true)]
    class KeyboardContentPageRenderer : PageRenderer {
        private KeyboardContentPage _page => Element as KeyboardContentPage;

        public KeyboardContentPageRenderer(Context context) : base(context) {
            Focusable = true;
            FocusableInTouchMode = true;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e) {
            base.OnElementChanged(e);

            if (Visibility == ViewStates.Visible)
                RequestFocus();

            _page.Appearing += (sender, args) => {
                RequestFocus();
            };
        }

        public override bool OnKeyUp([GeneratedEnum] Keycode keyCode, KeyEvent e) {
            var handled = false;

            Android.Util.Log.Info("TomiSoft.KeyboardInput", $"TomiSoft!! Keyboard input: {keyCode}");

            if (keyCode >= Keycode.A && keyCode <= Keycode.Z) {
                // Letter
                handled = true;
            }
            else if ((keyCode >= Keycode.Num0 && keyCode <= Keycode.Num9) ||
                        (keyCode >= Keycode.Numpad0 && keyCode <= Keycode.Num9)) {
                // Number
                handled = true;
            }
            else if (keyCode == Keycode.Enter || keyCode == Keycode.NumpadEnter 
                    || keyCode == Keycode.Escape) {
                handled = true;
            }

            if (handled) {
                _page?.OnKeyUp(KeyboardMap.Mapping[keyCode]);
            }

            return handled || base.OnKeyUp(keyCode, e);
        }
    }
}