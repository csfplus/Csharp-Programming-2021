using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace W8Demo
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://ssl.zc.qq.com/v3/index-chs.html?from=client&regkey=EB92F829BA4661A69B2EDE5E2930F0688780803DE8DB607BAADFF1EDFD564C02&ADUIN=0&ADSESSION=0&ADTAG=CLIENT.QQ.5809_NewAccount_Btn.0&ADPUBNO=27133");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            MessageBox.Show("正在登录中……");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            var idx = rnd.Next(5);
            pictureBox1.Image = imageList1.Images[idx];
        }
    }
}
