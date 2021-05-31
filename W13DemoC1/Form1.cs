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
namespace W13DemoC1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            try
            {
                //1.设置连接字符串
                var connString = "Server=.;DataBase=db_test; uid=test; pwd=test!@#$";
                //2. 建立连接
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    //3. 打开连接
                    conn.Open();

                    MessageBox.Show("打开成功");

                    //4.关闭连接
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //1.设置连接字符串
            var connString = "Server=.;DataBase=db_test; uid=test; pwd=test!@#$";
            //2. 建立连接
            using (SqlConnection conn = new SqlConnection(connString))
            {
                //3. 打开连接
                conn.Open();

                //4. 创建Command对象

                /* //方法一
                var sql= $"select count(1) from tb_student where xh='{txtXH.Text}' and xm='{txtXM.Text}'";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                cmd.Connection = conn;
                */

                //方法二
                var sql = "select count(1) from tb_student where xh=@xh and xm=@xm";
                SqlParameter[] pts = new SqlParameter[]
                {
                    new SqlParameter("@xh",txtXH.Text),
                    new SqlParameter("@xm",txtXM.Text)
                };
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                cmd.Connection = conn;
                cmd.Parameters.AddRange(pts);


                var ret = (int)cmd.ExecuteScalar();

                if (ret > 0) MessageBox.Show("Success");
                else MessageBox.Show("学号和姓名不匹配");
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            //1.设置连接字符串
            var connString = "Server=.;DataBase=db_test; uid=test; pwd=test!@#$";
            //2. 建立连接
            using (SqlConnection conn = new SqlConnection(connString))
            {
                //3. 打开连接
                conn.Open();
                var sql = "select xm,xh,xb from tb_student";
                var cmd = new SqlCommand(sql, conn);
                var dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        richTextBox1.Text += $"{dr["xh"]}--{dr.GetString(0)}\n";
                    }
                }

            }
        }

        private void btnDataTable_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            //1.设置连接字符串
            var connString = "Server=.;DataBase=db_test; uid=test; pwd=test!@#$";
            //2. 建立连接
            using (SqlConnection conn = new SqlConnection(connString))
            {
                //3. 打开连接
                conn.Open();
                var sql = "select * from tb_student";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);

                da.Fill(dt);
            }
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dt;

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {

            //1.设置连接字符串
            var connString = "Server=.;DataBase=db_test; uid=test; pwd=test!@#$";
            //2. 建立连接
            using (SqlConnection conn = new SqlConnection(connString))
            {
                //3. 打开连接
                conn.Open();
                var sql = "insert into tb_student (xm,xh) values(@xm,@xh)";

                var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@xh", txtXH.Text);
                cmd.Parameters.Add(new SqlParameter("@xm", txtXM.Text));

                var ret = cmd.ExecuteNonQuery();
                if (ret > 0) MessageBox.Show("插入成功");
                else MessageBox.Show("Error");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //1.设置连接字符串
            var connString = "Server=.;DataBase=db_test; uid=test; pwd=test!@#$";
            //2. 建立连接
            using (SqlConnection conn = new SqlConnection(connString))
            {
                //3. 打开连接
                conn.Open();
                var sql = "update tb_student set xm=@xm where xh=@xh";

                var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@xh", txtXH.Text);
                cmd.Parameters.Add(new SqlParameter("@xm", txtXM.Text));

                var ret = cmd.ExecuteNonQuery();
                if (ret > 0) MessageBox.Show("更新成功");
                else MessageBox.Show("Error");
            }
        }
    }
}
