using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFirstWinFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Red;
            this.Text = "你未满18岁！";
            MessageBox.Show("密码错误!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("我也喜欢你");
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            Random r = new Random();
            button3.Location = new Point(r.Next(this.ClientSize.Width-button3.Width), r.Next(ClientSize.Height-button3.Height));
        }
    }
}
