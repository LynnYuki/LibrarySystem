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
    public partial class borrowsearch : Form
    {
        private DataSet dataset = new DataSet();
        private SqlDataAdapter dataadapter;
        public borrowsearch()
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
                        string sql = string.Format("select borrow.readerid ,readername,borrow.bookid,bookname,borrowtime,returntime,outtime from borrow,reader,book where book.bookid=borrow.bookid and borrow.readerid=reader.readerid and reader.readerid='{0}'", id);
                        dataadapter = new SqlDataAdapter(sql, Dbconnect.connection);
                        SqlCommand co = new SqlCommand(sql, Dbconnect.connection);
                        dataadapter.Fill(dataset, "borrow");
                        dataGridView1.DataSource = dataset.Tables["borrow"];
                        SqlDataReader c = co.ExecuteReader();
                        if (c.HasRows)
                        {

                            MessageBox.Show("查询成功", "温馨提示");
                            button2.Visible = true;
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

      

 

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataset.Tables["borrow"].Clear();
            textBox1.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Dbconnect.connection.Close();
                string sql = string.Format("select borrow.readerid ,readername,borrow.bookid,bookname,borrowtime,returntime,outtime from borrow,reader,book where book.bookid=borrow.bookid and borrow.readerid=reader.readerid ");
                dataadapter = new SqlDataAdapter(sql, Dbconnect.connection);
                dataadapter.Fill(dataset, "borrow");
                dataGridView1.DataSource = dataset.Tables["borrow"];
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