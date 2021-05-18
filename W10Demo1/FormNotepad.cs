using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace W10Demo1
{
    public partial class FormNotepad : Form
    {
        public FormNotepad()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("正在新建文件");
        }

        private void tsmiToolbar_Click(object sender, EventArgs e)
        {
            if (tsmiToolbar.CheckState == CheckState.Checked)
            {
                tsmiToolbar.CheckState = CheckState.Unchecked;
                toolStrip1.Visible = false;
            }
            else
            {
                tsmiToolbar.CheckState = CheckState.Checked;
                toolStrip1.Visible = true;
            }
        }

        private void rtxtMain_TextChanged(object sender, EventArgs e)
        {
            tsslbl.Text = $"字数:{rtxtMain.Text.Length}";
        }

        private void tsmiToolbar_CheckStateChanged(object sender, EventArgs e)
        {
            if (tsmiToolbar.CheckState == CheckState.Checked)
            {
                toolStrip1.Visible = false;
            }
            else
            {
                toolStrip1.Visible = true;
            }
        }

        private void FormNotepad_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
                notifyIcon1.ShowBalloonTip(2 * 1000);
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            if (Visible)
            {
                Hide();
            }
            else Show();
        }

        private void 退出XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        bool changeIcon = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            changeIcon = !changeIcon;
            if (changeIcon) notifyIcon1.Icon = Properties.Resources.handwrite;
            else notifyIcon1.Icon = Properties.Resources.scan;

            // Console.WriteLine($"changeIcon={changeIcon}");
        }

        bool isFlash = false;
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            isFlash = !isFlash;
            if (isFlash)
            {
                timer1.Enabled = true;
                timer1.Start();
            }
            else
            {
                timer1.Stop();
                timer1.Enabled = false;
                notifyIcon1.Icon = Properties.Resources.write;
            }
            // Console.WriteLine($"isFlash={isFlash}");
        }

        private void FormNotepad_Load(object sender, EventArgs e)
        {
            tslblDir.Text = $"当前目录:{Application.StartupPath}";
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "文本文件|*.txt|日记文件|*.log|特殊文件|*.csf";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                rtxtMain.Text = File.ReadAllText(openFileDialog1.FileName);
                tslblDir.Text = Path.GetDirectoryName(openFileDialog1.FileName);
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "文本文件|*.txt|日记文件|*.log|特殊文件|*.csf";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.AppendAllText(saveFileDialog1.FileName, rtxtMain.Text, Encoding.UTF8);
                MessageBox.Show("保存成功");
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                tslblDir.Text = folderBrowserDialog1.SelectedPath;
        }
    }
}
