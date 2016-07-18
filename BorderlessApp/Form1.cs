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

        int borderThickness = 2;
        Padding _borderPadding;
        TitleBar _title;
        Panel _contentPanel;
        FlowLayoutPanel _layout = new FlowLayoutPanel();

        public BorderlessForm()
        {
            InitializeComponent();

            //_layout.Dock = DockStyle.Fill;
            //_layout.FlowDirection = FlowDirection.TopDown;
            //_layout.BackColor = SystemColors.ControlDarkDark;
            //_layout.Padding = Padding.Empty;
            //_layout.Margin = Padding.Empty;
            //Controls.Add(_layout);

            _borderPadding = new Padding(borderThickness);

            Padding = _borderPadding;

            _title = new TitleBar(this);
            _title.Padding = Padding.Empty;
            _title.Margin = Padding.Empty;
            _title.Height = 30;
            _title.Dock = DockStyle.Top;
            _title.BackColor = Color.FromArgb(45,45,45);

            _contentPanel = new Panel();
            _contentPanel.Padding = new Padding(5);
            _contentPanel.Margin = Padding.Empty;
            _contentPanel.Dock = DockStyle.Fill;
            _contentPanel.BackColor = SystemColors.ControlDark;
            _contentPanel.BorderStyle = BorderStyle.FixedSingle;

            //_layout.Controls.Add(_title);
            //_layout.Controls.Add(_contentPanel);

            Controls.Add(_title);
            Controls.Add(_contentPanel);

            BackColor = Color.FromArgb(255, 0, 191, 255);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = new CreateParams();

                createParams.X = 100;
                createParams.Y = 100;
                createParams.Width = 700;
                createParams.Height = 500;

                //createParams.Style |= ((int)WinApi.WindowStyles.WS_MINIMIZEBOX);

                createParams.ExStyle |= ((int)WinApi.WindowExStyles.WS_EX_APPWINDOW | (int)WinApi.WindowExStyles.WS_EX_CONTROLPARENT);
                return createParams;
            }
        }

        protected override void WndProc(ref Message m)
        {
            switch(m.Msg)
            {
                case (int)WinApi.WM_SIZE:
                    if((int)m.WParam == 2)
                    {
                        //hide window border when window is maximized
                        Padding = Padding.Empty;
                        WindowState = FormWindowState.Maximized;
                        break;
                    }
                    else if((int)m.WParam == 0)
                    {
                        Padding = _borderPadding;
                    }
                    break;
            }
            base.WndProc(ref m);
        }

        protected override void OnLocationChanged(EventArgs e)
        {
            base.OnLocationChanged(e);

            //change maximized bounds if window was moved to other screen
            MaximizedBounds = Screen.FromControl(this).WorkingArea;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            Cursor = Cursors.SizeWE;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            Cursor = Cursors.Arrow;
            base.OnMouseLeave(e);
        }
    }
}
