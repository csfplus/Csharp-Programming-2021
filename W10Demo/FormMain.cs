using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace W10Demo
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void 新建ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNotepad frm = new FormNotepad();
            frm.MdiParent = this;
            frm.Show();
        }

        private void 水平排列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void 垂直排列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void 层叠排列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
                notifyIcon1.ShowBalloonTip(2 * 1000);
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.Visible)
            {
                this.Hide();
                //notifyIcon1.ShowBalloonTip(2 * 1000);
            }
            else this.Show();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        bool changeIcon = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            changeIcon = !changeIcon;

            if (changeIcon) notifyIcon1.Icon = Properties.Resources.handwrite1;
            else notifyIcon1.Icon = Properties.Resources.scan;
        }

        bool isShow = false;
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            isShow = !isShow;

            if (isShow)
            {
                timer1.Enabled = true;
                timer1.Start();
            }
            else
            {
                timer1.Stop();
                timer1.Enabled = false;
                notifyIcon1.Icon = Properties.Resources.handwrite1;
            }
        }

        AnchorStyles stopAnchor;
        private void FormMain_LocationChanged(object sender, EventArgs e)
        {
            if (Left <= 0) stopAnchor = AnchorStyles.Left;
            else stopAnchor = AnchorStyles.None;

        }

        private void FormMain_MouseLeave(object sender, EventArgs e)
        {

        }

        private void FormMain_MouseEnter(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Point current = MousePosition;
            var screen = Screen.FromPoint(current);
            var rect = RectangleToScreen(ClientRectangle);
            if (rect.Contains(current))
            {
                switch (stopAnchor)
                {
                    case AnchorStyles.Left:
                        this.Left = -Width + 20;
                        break;
                }
            }
            else
            {
                switch (stopAnchor)
                {
                    case AnchorStyles.Left:
                        this.Left = 0;
                        break;
                }
            }
        }
    }
}
