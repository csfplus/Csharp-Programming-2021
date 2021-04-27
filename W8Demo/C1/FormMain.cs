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
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.Text = "我又改变窗体名称了";
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Text = "你就这么狠心拒绝吗？";
            this.BackColor = Color.Green;
            //e.Cancel = true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://ssl.zc.qq.com/v3/index-chs.html?from=client&regkey=7DB509618D069676A576765FD1AAB6FA02BB5E26C41ADA43003DC47042276147&ADUIN=0&ADSESSION=0&ADTAG=CLIENT.QQ.5809_NewAccount_Btn.0&ADPUBNO=27133");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start($"https://aq.qq.com/v2/uv_aq/html/reset_pwd/pc_reset_pwd_input_account.html?v=3.0&old_ver_account={txtUserName.Text}");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text) || string.IsNullOrEmpty(txtPwd.Text))
            {
                MessageBox.Show("帐号或密码不能为空");
                return;
            }

            if (txtUserName.Text == "admin" && txtPwd.Text == "123456")
            {
                MessageBox.Show("Success");
                Form3 frm = new Form3();
                frm.Show();
            }
            else
            {
                MessageBox.Show("帐号或密码错误！！！");
            }
        }

        private void btnChangeAvatar_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            var idx = rnd.Next(imageList1.Images.Count);
            pbAvatar.Image = imageList1.Images[idx];
        }
    }
}
