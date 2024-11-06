using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Kom_System_Common.CommonClass
{
    /// <summary>
    /// フォームの画面描画抑制を制御するオブジェクトを提供します。
    /// </summary>
    public class FormRedrawSuspension : IDisposable
    {
        private System.Windows.Forms.Form _form;

        /// <summary>
        /// オブジェクトを構築し、画面描画を抑制します。オブジェクトを破棄すると画面描画抑制が解除されます。
        /// </summary>
        /// <param name="form">制御するフォーム</param>
        public FormRedrawSuspension(System.Windows.Forms.Form form)
        {
            _form = form;
            SendSetRedrawMessage(false);
        }

        /// <summary>
        /// 画面描画抑制を解除してフォームを再描画させ、オブジェクトを破棄します。
        /// </summary>
        public void Dispose()
        {
            SendSetRedrawMessage(true);
            _form.Refresh();
        }

        private void SendSetRedrawMessage(bool enableRedraw)
        {
            NativeMethods.SendMessage(_form.Handle, NativeMethods.WM_SETREDRAW, enableRedraw ? new IntPtr(1) : IntPtr.Zero, IntPtr.Zero);
        }

        private class NativeMethods
        {
            // https://docs.microsoft.com/ja-jp/visualstudio/code-quality/ca1060-move-p-invokes-to-nativemethods-class
            private NativeMethods() { }

            [DllImport("user32.dll")]
            internal static extern IntPtr SendMessage(IntPtr hWnd, UInt32 dwMsg, IntPtr wParam, IntPtr lParam);

            internal const UInt32 WM_SETREDRAW = 11;
        }
    }
}
