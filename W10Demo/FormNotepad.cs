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
    public partial class FormNotepad : Form
    {
        public FormNotepad()
        {
            InitializeComponent();
        }

        private void 设置字体FToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.ShowDialog();
        }

        private void 设置前置颜色CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.ShowDialog();
        }

        private void rtxtMain_TextChanged(object sender, EventArgs e)
        {
            tsslbl.Text = $"总字数为:{rtxtMain.Text.Length}";
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "文件文件|*.txt";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                rtxtMain.Text = System.IO.File.ReadAllText(openFileDialog1.FileName, Encoding.UTF8);
            }
        }

        private void 另存为AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "文件文件|*.txt|RTF文件|*.rtf";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.AppendAllText(saveFileDialog1.FileName, rtxtMain.Text, Encoding.UTF8);
                MessageBox.Show("保存成功");
            }

        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog1.ShowDialog()== DialogResult.OK)
            {
                toolStripStatusLabel1.Text = $"当前保存目录为:{folderBrowserDialog1.SelectedPath}";
            }
        }
    }
}
