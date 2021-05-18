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

namespace W12DemoC1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TreeNode tn = new TreeNode("我的电脑");
            treeView1.Nodes.Add(tn);

            foreach (var drive in DriveInfo.GetDrives())
            {
                TreeNode node = new TreeNode(drive.Name);
                node.Tag = drive.Name;
                tn.Nodes.Add(node);
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var tn = treeView1.SelectedNode;
            if (tn == null) return;
            if (tn.Tag == null) return;

            var path = tn.Tag.ToString();

            var dir = new DirectoryInfo(path);
            listView1.Items.Clear();
            tn.Nodes.Clear();
            foreach (var di in dir.GetDirectories())
            {
                ListViewItem lvi = new ListViewItem(new string[] { di.Name, di.CreationTime.ToString(), "文件夹", "", di.LastWriteTime.ToString() });
                listView1.Items.Add(lvi);

                var node = tn.Nodes.Add(di.Name);
                node.Tag = di.FullName;
            }
            tn.ExpandAll();

            foreach (var fi in dir.GetFiles())
            {
                ListViewItem lvi = new ListViewItem(new string[] { fi.Name, fi.CreationTime.ToString(), fi.Extension, fi.Length.ToString(), fi.LastWriteTime.ToString() });

                listView1.Items.Add(lvi);
            }

        }
    }
}
