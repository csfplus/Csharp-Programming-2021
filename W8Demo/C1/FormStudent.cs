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
    public partial class FormStudent : Form
    {
        public FormStudent()
        {
            InitializeComponent();
        }

        private void cbbxy_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbzy.Items.Clear();
            if (cbbxy.Text == "信工院")
                cbbzy.Items.AddRange(new string[] { "计算机", "软件工程", "物联网", "大数据" });
            else if (cbbxy.Text == "外语院")
                cbbzy.Items.AddRange(new string[] { "英语", "日语", "鸟语" });
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            lblValue.Text = trackBar1.Value + "%";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblMsg.Left -= 10;
            if (lblMsg.Right < 0) lblMsg.Left = panelScroll.Right;
        }

        private void FormStudent_Load(object sender, EventArgs e)
        {
            lblMsg.Left = panelScroll.Right;
            timer1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormMain frm = new FormMain();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var frm = new Form5();
            frm.Show();
        }
    }
}
