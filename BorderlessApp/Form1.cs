using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BorderlessApp
{
    public partial class BorderlessForm : Form
    {
        TitleBar _title;

        public BorderlessForm()
        {
            InitializeComponent();

            Padding = new Padding(1);

            _title = new TitleBar(this);
            _title.Height = 30;
            _title.Dock = DockStyle.Top;
            _title.BackColor = Color.LightSeaGreen;
            Controls.Add(_title);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (WindowState != FormWindowState.Maximized)
                e.Graphics.DrawRectangle(new Pen(Color.FromArgb(255, 0, 191, 255)), new Rectangle(0, 0, this.Width - 1, this.Height - 1));
        }
    }
}
