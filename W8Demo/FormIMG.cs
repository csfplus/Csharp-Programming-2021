using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace W8Demo
{
    public partial class FormIMG : Form
    {
        public FormIMG()
        {
            InitializeComponent();
        }

        private void FormIMG_Load(object sender, EventArgs e)
        {
            this.Text = "我又改名了";
        }

        private void FormIMG_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Text = "就这么狠心开闭我！";
            e.Cancel = true;
        }
    }
}
