using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BorderlessApp
{
    public partial class TitleButton : Button
    {
        public TitleButton()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            Size = new Size(40, 18);
            TabStop = false;
            FlatAppearance.BorderSize = 0;
            FlatStyle = FlatStyle.Flat;
            BackColor = Color.FromArgb(50, 50, 50);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WinApi.WM_SETFOCUS)
            {
                m.Result = (IntPtr)1;
                return;
            }

            if (m.Msg == WinApi.WM_ACTIVATE)
                return;

            if (m.Msg == WinApi.WM_MOUSEACTIVATE)
                return;

            if (m.Msg == WinApi.WM_IME_SELECT)
                return;

            if (m.Msg == WinApi.WM_NCPAINT)
                return;

            base.WndProc(ref m);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            //base.OnGotFocus(e);
        }
    }
}
