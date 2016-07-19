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
            SetStyle(ControlStyles.Selectable, false);

            Size = new Size(40, 18);
            TabStop = false;
            FlatAppearance.BorderSize = 0;
            FlatAppearance.CheckedBackColor = Color.Transparent;
            FlatStyle = FlatStyle.Flat;
            BackColor = Color.FromArgb(50, 50, 50);
        }

        protected override bool ShowFocusCues
        {
            get
            {
                return false;
            }
        }

        protected override void WndProc(ref Message m)
        {
            switch((uint)m.Msg)
            {
                case WinApi.WM_ACTIVATE:
                case WinApi.WM_NCACTIVATE:
                case WinApi.WM_SETFOCUS:
                case WinApi.WM_MOUSEACTIVATE:
                    return;
            }

            base.WndProc(ref m);
        }
    }
}
