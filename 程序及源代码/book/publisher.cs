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
    public partial class publisher : Form
    {
        private DataSet dataset = new DataSet();
        private SqlDataAdapter dataadapter;
        public publisher()
        {
            InitializeComponent();
        }

      

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;
           
            if (id != "")
            {
                try
                {
                    Dbconnect.connection.Open();
                    
                    string sql = string.Format("select * from publisher where publisherName like '%{0}%'", id);
                    dataadapter = new SqlDataAdapter(sql, Dbconnect.connection);
                    SqlCommand co = new SqlCommand(sql, Dbconnect.connection);
                    dataadapter.Fill(dataset, "publisher");
                    dataGridView1.DataSource = dataset.Tables["publisher"];
                 
                    SqlDataReader c = co.ExecuteReader();
                    if (c.HasRows)
                    {

                        MessageBox.Show("查询成功", "温馨提示");
                        button1.Visible = true;
                        button3.Visible = true;
                        textBox1.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("没有查询到相关借阅信息，请检查您输入的出版社名称是否正确", "温馨提示");
                        button1.Visible = true;
                        return;
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
            else
            {
                MessageBox.Show("请输入出版社名称","温馨提示");
            }
            }
        

        private void button3_Click(object sender, EventArgs e)
        {

        
            DialogResult result = MessageBox.Show("确实要保存修改吗？", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // 自动生成用于更新的命令
                SqlCommandBuilder builder = new SqlCommandBuilder(dataadapter);

                // 将数据集中修改过的数据，提交到数据库
                dataadapter.Update(dataset,"publisher");
                MessageBox.Show("修改成功","温馨提示");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataset.Tables["publisher"].Clear();
            textBox1.Text = "";
        
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Dbconnect.connection.Open();
                string sql = "select * from publisher";
                dataadapter = new SqlDataAdapter(sql, Dbconnect.connection);
                dataadapter.Fill(dataset, "publisher");
                dataGridView1.DataSource = dataset.Tables["publisher"];
                button1.Visible = true;
                button3.Visible = true;
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

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}