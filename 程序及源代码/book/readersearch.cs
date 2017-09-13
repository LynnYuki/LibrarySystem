using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace book
{
    public partial class readersearch : Form
    {
        private DataSet dataset = new DataSet();
        private SqlDataAdapter dataadapter;
        public readersearch()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("请输入借阅证号", "温馨提示");
                }
                if(textBox1.Text != "")
                {
                    Dbconnect.connection.Open();
                    string id = textBox1.Text;
                    string sql = string.Format("select * from reader where readerid='{0}'", id);
                    SqlCommand co = new SqlCommand(sql, Dbconnect.connection);
                    dataadapter = new SqlDataAdapter(sql, Dbconnect.connection);
                    dataadapter.Fill(dataset, "reader");
                    dataGridView1.DataSource = dataset.Tables["reader"];
                    SqlDataReader c = co.ExecuteReader();
                    if (c.HasRows)
                    {

                        MessageBox.Show("查询成功", "温馨提示");
                        button2.Visible = true;
                        textBox1.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("没有查询到相关信息，请检查您输入的借阅证号是否正确或您没有添加该学生信息", "温馨提示");
                        return;
                    }
                }
            }
            catch
            {
                MessageBox.Show("操作数据库错误", "温馨提示");
            }
            finally
            {
                Dbconnect.connection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataset.Tables["reader"].Clear();
            textBox1.Text = "";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string id = textBox1.Text;
                string sql = "select * from reader";
                dataadapter = new SqlDataAdapter(sql, Dbconnect.connection);
                dataadapter.Fill(dataset, "reader");
                dataGridView1.DataSource = dataset.Tables["reader"];
                button2.Visible = true;
            }
            catch
            {
                MessageBox.Show("操作数据库错误", "温馨提示");
            }
            finally
            {
                Dbconnect.connection.Close();
            }
        }
    }
}