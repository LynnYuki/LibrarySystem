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
    public partial class readerserchbook : Form
    {
        private DataSet dataset = new DataSet();
        private SqlDataAdapter dataadapter;

        public readerserchbook()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = null;

            if (comboBox1.Text == "书名")
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("请输入书名", "温馨提示");
                }
                else
                {
                    string id = textBox1.Text;
                    try
                    {
                        if (id != "")
                        {
                            Dbconnect.connection.Open();
                            sql = string.Format("select bookid,bookname,bookwritter,booktype.booktypename,bookprice,booktype.floor,publisher.publishername,ifborrow from book,booktype,publisher where book.booktypeid=booktype.booktypeid and book.publisherid=publisher.publisherid and  bookname like '%{0}%'", textBox1.Text);
                            SqlCommand co = new SqlCommand(sql, Dbconnect.connection);
                            dataadapter = new SqlDataAdapter(sql, Dbconnect.connection);
                            dataadapter.Fill(dataset, "book");
                            dataGridView1.DataSource = dataset.Tables["book"];
                            SqlDataReader c = co.ExecuteReader();
                            if (c.HasRows)
                            {

                                MessageBox.Show("查询成功", "温馨提示");
                                button2.Visible = true;
                                textBox1.Text = "";
                            }
                            else
                            {
                                MessageBox.Show("没有查询到相关图书，请检查您输入的书名是否正确", "温馨提示");
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
            if (comboBox1.Text == "编号")
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("请输入编号", "温馨提示");
                }
                else
                {
                    string id = textBox1.Text;
                    try
                    {
                        if (id != "")
                        {
                            Dbconnect.connection.Open();
                            sql = string.Format("select bookid,bookname,bookwritter,booktype.booktypename,bookprice,booktype.floor,publisher.publishername,ifborrow from book,booktype,publisher where book.booktypeid=booktype.booktypeid and book.publisherid=publisher.publisherid and bookid like '%{0}%'", textBox1.Text);
                            SqlCommand co = new SqlCommand(sql, Dbconnect.connection);
                            dataadapter = new SqlDataAdapter(sql, Dbconnect.connection);
                            dataadapter.Fill(dataset, "book");
                            dataGridView1.DataSource = dataset.Tables["book"];
                            SqlDataReader c = co.ExecuteReader();
                            if (c.HasRows)
                            {

                                MessageBox.Show("查询成功", "温馨提示");
                                button2.Visible = true;
                                textBox1.Text = "";
                            }
                            else
                            {
                                MessageBox.Show("没有查询到相关图书，请检查您输入的编号是否正确", "温馨提示");
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
            if (comboBox1.Text == "作者")
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("请输入作者", "温馨提示");
                }
                else
                {
                    string id = textBox1.Text;
                    try
                    {
                        if (id != "")
                        {
                            Dbconnect.connection.Open();
                            sql = string.Format("select bookid,bookname,bookwritter,booktype.booktypename,bookprice,booktype.floor,publisher.publishername,ifborrow from book,booktype,publisher where book.booktypeid=booktype.booktypeid and book.publisherid=publisher.publisherid and bookwritter like '%{0}%'", textBox1.Text);
                            SqlCommand co = new SqlCommand(sql, Dbconnect.connection);
                            dataadapter = new SqlDataAdapter(sql, Dbconnect.connection);
                            dataadapter.Fill(dataset, "book");
                            dataGridView1.DataSource = dataset.Tables["book"];
                            SqlDataReader c = co.ExecuteReader();
                            if (c.HasRows)
                            {

                                MessageBox.Show("查询成功", "温馨提示");
                                button2.Visible = true;
                                textBox1.Text = "";
                            }
                            else
                            {
                                MessageBox.Show("没有查询到相关图书，请检查您输入的作者是否正确", "温馨提示");
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
            if (comboBox1.Text == "所属楼层")
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("请输入楼层", "温馨提示");
                }
                else
                {
                    string id = textBox1.Text;
                    try
                    {
                        if (id != "")
                        {
                            Dbconnect.connection.Open();
                            sql = string.Format("select bookid,bookname,bookwritter,booktype.booktypename,bookprice,booktype.floor,publisher.publishername,ifborrow from book,booktype,publisher where book.booktypeid=booktype.booktypeid and book.publisherid=publisher.publisherid and  booktype.floor like'%{0}%'", textBox1.Text);
                            SqlCommand co = new SqlCommand(sql, Dbconnect.connection);
                            dataadapter = new SqlDataAdapter(sql, Dbconnect.connection);
                            dataadapter.Fill(dataset, "book");
                            dataGridView1.DataSource = dataset.Tables["book"];
                            SqlDataReader c = co.ExecuteReader();
                            if (c.HasRows)
                            {

                                MessageBox.Show("查询成功", "温馨提示");
                                button2.Visible = true;
                                textBox1.Text = "";
                            }
                            else
                            {
                                MessageBox.Show("没有查询到相关图书，请检查您输入的楼层是否正确", "温馨提示");
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
            if (comboBox1.Text == "单价")
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("请输入单价", "温馨提示");
                }
                else
                {
                    string id = textBox1.Text;
                    try
                    {
                        if (id != "")
                        {
                            Dbconnect.connection.Open();
                            sql = string.Format("select bookid,bookname,bookwritter,booktype.booktypename,bookprice,booktype.floor,publisher.publishername,ifborrow from book,booktype,publisher where book.booktypeid=booktype.booktypeid and book.publisherid=publisher.publisherid and bookprice like '%{0}%'", textBox1.Text);
                            SqlCommand co = new SqlCommand(sql, Dbconnect.connection);
                            dataadapter = new SqlDataAdapter(sql, Dbconnect.connection);
                            dataadapter.Fill(dataset, "book");
                            dataGridView1.DataSource = dataset.Tables["book"];
                            SqlDataReader c = co.ExecuteReader();
                            if (c.HasRows)
                            {

                                MessageBox.Show("查询成功", "温馨提示");
                                button2.Visible = true;
                                textBox1.Text = "";
                            }
                            else
                            {
                                MessageBox.Show("没有查询到相关图书，请检查您输入的单价是否正确", "温馨提示");
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
            if (comboBox1.Text == "出版社")
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("请输入出版社名称", "温馨提示");
                }
                else
                {
                    string id = textBox1.Text;
                    try
                    {
                        if (id != "")
                        {
                            Dbconnect.connection.Open();
                            sql = string.Format("select bookid,bookname,bookwritter,booktype.booktypename,bookprice,booktype.floor,publisher.publishername,ifborrow from book,booktype,publisher where book.booktypeid=booktype.booktypeid and publisher.publishername like '%{0}%'", textBox1.Text);
                            SqlCommand co = new SqlCommand(sql, Dbconnect.connection);
                            dataadapter = new SqlDataAdapter(sql, Dbconnect.connection);
                            dataadapter.Fill(dataset, "book");
                            dataGridView1.DataSource = dataset.Tables["book"];
                            SqlDataReader c = co.ExecuteReader();
                            if (c.HasRows)
                            {

                                MessageBox.Show("查询成功", "温馨提示");
                                button2.Visible = true;
                                textBox1.Text = "";
                            }
                            else
                            {
                                MessageBox.Show("没有查询到相关图书，请检查您输入的出版社名称是否正确", "温馨提示");
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
            if (comboBox1.Text == "所属类别")
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("请输入类别", "温馨提示");
                }
                else
                {
                    string id = textBox1.Text;
                    try
                    {
                        if (id != "")
                        {
                            Dbconnect.connection.Open();
                            sql = string.Format("select bookid,bookname,bookwritter,booktype.booktypename,bookprice,booktype.floor,publisher.publishername,ifborrow from book,booktype,publisher where book.booktypeid=booktype.booktypeid and book.publisherid=publisher.publisherid and booktypename like '%{0}%'", textBox1.Text);
                            SqlCommand co = new SqlCommand(sql, Dbconnect.connection);
                            dataadapter = new SqlDataAdapter(sql, Dbconnect.connection);
                            dataadapter.Fill(dataset, "book");
                            dataGridView1.DataSource = dataset.Tables["book"];
                            SqlDataReader c = co.ExecuteReader();
                            if (c.HasRows)
                            {

                                MessageBox.Show("查询成功", "温馨提示");
                                button2.Visible = true;
                                textBox1.Text = "";
                            }
                            else
                            {
                                MessageBox.Show("没有查询到相关图书，请检查您输入的类别是否正确", "温馨提示");
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
            if (comboBox1.Text == "")
            {
                MessageBox.Show("请选择查询类别");
            }
            if (comboBox1.Text == "查询全部图书")
            {
                sql = "select bookid,bookname,bookwritter,booktype.booktypename,bookprice,booktype.floor,publisher.publishername,ifborrow from book,booktype,publisher where book.booktypeid=booktype.booktypeid and book.publisherid=publisher.publisherid";
                dataadapter = new SqlDataAdapter(sql, Dbconnect.connection);
                dataadapter.Fill(dataset, "book");
                dataGridView1.DataSource = dataset.Tables["book"];
                button2.Visible = true;
                MessageBox.Show("查询成功", "温馨提示");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataset.Tables["book"].Clear();
            textBox1.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "编号")
            {
                textBox1.Visible = true;
                label10.Visible = false;
                label2.Visible = true;
                label4.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
            }
            else if (comboBox1.Text == "作者")
            {
                textBox1.Visible = true;
                label10.Visible = false;
                label2.Visible = false;
                label4.Visible = true;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
            }
            else if (comboBox1.Text == "出版社")
            {
                textBox1.Visible = true;
                label10.Visible = false;
                label2.Visible = false;
                label4.Visible = false;
                label6.Visible = true;
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
            }
            else if (comboBox1.Text == "所属类别")
            {
                textBox1.Visible = true;
                label10.Visible = false;
                label2.Visible = false;
                label4.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = true;
                label9.Visible = false;

            }
            else if (comboBox1.Text == "单价")
            {
                textBox1.Visible = true;
                label10.Visible = false;
                label2.Visible = false;
                label4.Visible = false;
                label6.Visible = false;
                label7.Visible = true;
                label8.Visible = false;
                label9.Visible = false;

            }
            else if (comboBox1.Text == "所属楼层")
            {
                textBox1.Visible = true;
                label10.Visible = false;
                label2.Visible = false;
                label4.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = true;

            }
            else if (comboBox1.Text == "书名")
            {
                textBox1.Visible = true;
                label10.Visible = true;
                label2.Visible = false;
                label4.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
            }
            else
            {
                textBox1.Visible = false;
                label10.Visible = false;
                label2.Visible = false;
                label4.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
            }
        }
    }
}
