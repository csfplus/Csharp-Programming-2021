using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace W10Demo1
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        AnchorStyles stopAnchor;
        private void FormMain_LocationChanged(object sender, EventArgs e)
        {
            if (Left <= 0) stopAnchor = AnchorStyles.Left;
            else stopAnchor = AnchorStyles.None;

        }

        private void FormMain_MouseLeave(object sender, EventArgs e)
        {
            switch (stopAnchor)
            {
                case AnchorStyles.Left:
                    Left = -Width + 20;
                    break;
            }
        }

        private void FormMain_MouseEnter(object sender, EventArgs e)
        {
            switch (stopAnchor)
            {
                case AnchorStyles.Left:
                    Left = 0;
                    break;
            }
        }

        private void 添加窗体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNotepad frm = new FormNotepad();
            frm.MdiParent = this;
            frm.Show();
        }

        private void 水平ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void 垂直ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void 层叠ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }
    }
}
