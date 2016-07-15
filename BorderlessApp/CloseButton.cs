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
    public partial class CloseButton : TitleButton
    {
        Color _backColor = Color.Transparent;

        public CloseButton()
            :base()
        {
            BackColor = Color.FromArgb(225, 100, 100);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            //_backColor = BackColor;
            //BackColor = Color.FromArgb(225, 100, 100);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            //BackColor = _backColor;
        }
    }
}
