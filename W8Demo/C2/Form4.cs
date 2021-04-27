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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void cbbxy_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbzy.Items.Clear();
            if (cbbxy.Text == "信息工程学院")
            {
                cbbzy.Items.AddRange(new string[] { "计算机", "软件工程", "物联网" });
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            lblValue.Text = trackBar1.Value + "";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblMsg.Left -= 10;

            if (lblMsg.Right < 0) lblMsg.Left = panel2.Width;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            lblMsg.Left = panel2.Width;
            timer1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form5 frm = new Form5();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("你好", "操作提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);


            MessageBox.Show(res.ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.ShowColor = true;
            if (fd.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Font = fd.Font;
                richTextBox1.ForeColor = fd.Color;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
                richTextBox1.BackColor = cd.Color;
        }
    }
}
