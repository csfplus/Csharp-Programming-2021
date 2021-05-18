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

namespace W11DemoC2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            TreeNode tn = new TreeNode("我的电脑");
            treeView1.Nodes.Add(tn);

            foreach (var di in DriveInfo.GetDrives())
            {
                TreeNode node = new TreeNode(di.Name);
                node.Tag = di.Name;
                tn.Nodes.Add(node);
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView1.SelectedNode == null) return;
            var node = treeView1.SelectedNode;
            if (node.Tag == null) return;

            var path = node.Tag.ToString();

            treeView1.Nodes.Clear();
            var dir = new DirectoryInfo(path);
            foreach (var di in dir.GetDirectories())
            {
                var lvi = new ListViewItem(new string[] { di.Name, di.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss"), "" });
                listView1.Items.Add(lvi);

                TreeNode tn = new TreeNode(di.Name);
                tn.Tag = di.FullName;
                node.Nodes.Add(tn);
            }

            foreach (var fi in dir.GetFiles())
            {
                var lvi = new ListViewItem(new string[] { fi.Name, fi.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss"), fi.Extension, fi.Length.ToString() });
                listView1.Items.Add(lvi);
            }


        }
    }
}
