using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data .SqlClient;
namespace book
{
    public partial class deletereader : Form
    {
        private DataSet dataset = new DataSet();
        private SqlDataAdapter dataadapter;
        
        public deletereader()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;
            if (textBox1.Text == "")
            {
                MessageBox.Show("请输入借阅证号", "温馨提示");
            }
            else
            {
                try
                {
                    if (id != "")
                    {
                        Dbconnect.connection.Open();
                        string sql = string.Format("select * from reader where readerid='{0}'", id);
                        dataadapter = new SqlDataAdapter(sql, Dbconnect.connection);
                        dataadapter.Fill(dataset, "reader");
                        dataGridView1.DataSource = dataset.Tables["reader"];
                        SqlCommand co = new SqlCommand(sql, Dbconnect.connection);
                        SqlDataReader c = co.ExecuteReader();
                        if (c.HasRows)
                        {

                            MessageBox.Show("查询成功", "温馨提示");
                            button3.Visible = true;
                            textBox1.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("没有查询到相关借阅信息，请检查您输入的借阅证是否正确", "温馨提示");
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
        }
        private void button2_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "")
            {
                try
                {
                    Dbconnect.connection.Open();

                    string sql1 = string.Format("delete from borrow  where readerid ='{0}'", textBox1.Text);
                    SqlCommand con = new SqlCommand(sql1, Dbconnect.connection);
                    int c = con.ExecuteNonQuery();


                    string sql = string.Format("delete from reader where readerid ='{0}'", textBox1.Text);
                    SqlCommand commmand = new SqlCommand(sql, Dbconnect.connection);
                    int ab = commmand.ExecuteNonQuery();


                    if (ab != 0 && c != 0)
                    {
                        MessageBox.Show("删除失败", "温馨提示");
                    }
                    else
                    {
                        MessageBox.Show("删除成功","温馨提示");
                        return;
                    }
                }
                catch 
                {
                    MessageBox.Show("操作数据库错误","温馨提示");
                }
                finally
                {
                    Dbconnect.connection.Close();

                }
            }
            else
            {
                MessageBox.Show("请输入借阅证号码","温馨提示");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataset.Tables["reader"].Clear();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string id = textBox1.Text;
                string sql = "select * from reader";
                dataadapter = new SqlDataAdapter(sql, Dbconnect.connection);
                dataadapter.Fill(dataset, "reader");
                dataGridView1.DataSource = dataset.Tables["reader"];
                button3.Visible = true;
                MessageBox.Show("查询成功","温馨提示");
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