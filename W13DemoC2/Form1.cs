using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data;
using System.Data.SqlClient;

namespace W13DemoC2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //1. 设置连接字符串
            string connstring = "Server=.;DataBase=db_test;uid=test; pwd=test!@#$;";
            //2. 打开连接
            using (SqlConnection conn = new SqlConnection(connstring))
            {
                conn.Open();

                //执行SQL语句
                /*
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = $"select count(1) from db_student where xh='{txtXh.Text}' and xm='{txtXM.Text}'";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                */

                // 方法二，带参数
                var sql = "select count(1) from db_student where xh=@xh and xm=@xm";
                SqlParameter[] pts = new SqlParameter[]
                {
                    new SqlParameter("@xh", txtXh.Text),
                    new SqlParameter("@xm", txtXM.Text)
                };
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddRange(pts);


                var obj = cmd.ExecuteScalar();
                var ret = (int)obj;

                if (ret == 0) MessageBox.Show("学号姓名不匹配");
                else MessageBox.Show("OK");


            }



        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            //
            string connstring = "Server=.;DataBase=db_test;uid=test; pwd=test!@#$;";
            using (SqlConnection conn = new SqlConnection(connstring))
            {
                conn.Open();

                MessageBox.Show("Open Success!");
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            string connstring = "Server=.;DataBase=db_test;uid=test; pwd=test!@#$;";
            using (SqlConnection conn = new SqlConnection(connstring))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("select xh,xm from db_student", conn);
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    richTextBox1.Text += $"{dr["xh"]}--{dr.GetString(1)}\n";
                }

            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            string connstring = "Server=.;DataBase=db_test;uid=test; pwd=test!@#$;";
            using (SqlConnection conn = new SqlConnection(connstring))
            {
                conn.Open();

                SqlDataAdapter da = new SqlDataAdapter("select * from db_student", conn);

                da.Fill(dt);
            }
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dt;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string connstring = "Server=.;DataBase=db_test;uid=test; pwd=test!@#$;";
            using (SqlConnection conn = new SqlConnection(connstring))
            {
                conn.Open();
                var sql = $"insert into db_student (xh,xm) values('{txtXh.Text}','{txtXM.Text}')";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                var ret = cmd.ExecuteNonQuery();
                if (ret > 0) MessageBox.Show("添加成功");
                else MessageBox.Show("Error");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string connstring = "Server=.;DataBase=db_test;uid=test; pwd=test!@#$;";
            using (SqlConnection conn = new SqlConnection(connstring))
            {
                conn.Open();
                var sql = $"update db_student set xm='{txtXM.Text}' where xh='{txtXh.Text}'";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                var ret = cmd.ExecuteNonQuery();
                if (ret > 0) MessageBox.Show("Update成功");
                else MessageBox.Show("Error");
            }
        }
    }
}
