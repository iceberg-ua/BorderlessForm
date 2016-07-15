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
    public partial class TitleBar : UserControl
    {
        Form _ownerForm;
        CloseButton _closeButton;
        MaximizeButton _maximizeButton;
        MinimizeButton _minimizeButton;
        FlowLayoutPanel _buttonsPannel;

        bool _mousePressed = false;

        public TitleBar()
        {
            InitializeComponent();

            _buttonsPannel = new FlowLayoutPanel();
            _buttonsPannel.Size = Size.Empty;
            _buttonsPannel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            _buttonsPannel.AutoSize = true;
            _buttonsPannel.BackColor = Color.Black;
            _buttonsPannel.Padding = new Padding(1,0,1,1);

            _closeButton = new CloseButton();
            _closeButton.Click += CloseButtonClick;
            _closeButton.Visible = true;
            _closeButton.Margin = Padding.Empty;

            _maximizeButton = new MaximizeButton();
            _maximizeButton.Click += MaximizeButtonClick;
            _maximizeButton.Visible = true;
            _maximizeButton.Margin = new Padding(0,0,1,0);

            _minimizeButton = new MinimizeButton();
            _minimizeButton.Click += MinimizeButtonClick;
            _minimizeButton.Visible = true;
            _minimizeButton.Margin = new Padding(0, 0, 1, 0);

            _buttonsPannel.Controls.Add(_minimizeButton);
            _buttonsPannel.Controls.Add(_maximizeButton);
            _buttonsPannel.Controls.Add(_closeButton);

            this.Controls.Add(_buttonsPannel);
        }

        public TitleBar(Form owner)
            : this()
        {
            _ownerForm = owner;
        }

        #region Properties

        protected override bool ShowFocusCues
        {
            get
            {
                return false;
            }
        }

        public override bool Focused
        {
            get
            {
                return false;
            }
        }

        #endregion

        #region Button handlers
        private void MaximizeButtonClick(object sender, EventArgs e)
        {
            if (_ownerForm.WindowState != FormWindowState.Maximized)
                _ownerForm.WindowState = FormWindowState.Maximized;
            else
                _ownerForm.WindowState = FormWindowState.Normal;
        }

        private void MinimizeButtonClick(object sender, EventArgs e)
        {
            Size size = _ownerForm.Size;
            if (_ownerForm.WindowState != FormWindowState.Maximized)
            {

            }
            _ownerForm.WindowState = FormWindowState.Minimized;
        }

        private void CloseButtonClick(object sender, EventArgs e)
        {
            while (_ownerForm.Size.Width > 2 && _ownerForm.Size.Height > 2)
            {
                _ownerForm.Location = new Point(_ownerForm.Location.X + 1, _ownerForm.Location.Y + 1);
                _ownerForm.Size = new Size(_ownerForm.Size.Width - 2, _ownerForm.Size.Height - 2);
            }
            _ownerForm.Close();
        }

        #endregion

        #region Form events

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            _buttonsPannel.Location = new Point(Right - _buttonsPannel.Width, 0);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            //base.OnGotFocus(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            //base.OnLostFocus(e);
        }

        protected override void OnDoubleClick(EventArgs e)
        {
            if (_ownerForm.WindowState != FormWindowState.Maximized)
                _ownerForm.WindowState = FormWindowState.Maximized;
            else
                _ownerForm.WindowState = FormWindowState.Normal;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
                _mousePressed = true;
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            _mousePressed = false;
            base.OnMouseUp(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            //base.OnMouseMove(e);
        }

        #endregion
    }
}
