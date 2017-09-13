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
    public partial class readerreturnbook : Form
    {
        private DataSet dataset = new DataSet();
        private SqlDataAdapter dataadapter;
        public readerreturnbook()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "个人借书")
            {

                if (textBox1.Text == "")
                {
                    MessageBox.Show("请输入借阅证号", "温馨提示");
                }
                else
                {
                    string id = textBox1.Text;
                    try
                    {
                        if (id != "")
                        {
                            Dbconnect.connection.Open();
                            string sql = string.Format("select borrow.readerid, readername, borrow.bookid, bookname, borrowtime, returntime, outtime from borrow, reader, book where book.bookid = borrow.bookid and borrow.readerid = reader.readerid and reader.readerid = '{0}'", id);
                            SqlCommand co = new SqlCommand(sql, Dbconnect.connection);
                            dataadapter = new SqlDataAdapter(sql, Dbconnect.connection);
                            dataadapter.Fill(dataset, "borrow");
                            dataGridView1.DataSource = dataset.Tables["borrow"];
                            SqlDataReader c = co.ExecuteReader();
                            if (c.HasRows)
                            {

                                MessageBox.Show("查询成功", "温馨提示");
                                button3.Visible = true;
                                textBox1.Text = "";
                            }
                            else
                            {
                                MessageBox.Show("没有查询到相关信息，请检查您输入的借阅证号是否正确或您没有借书记录", "温馨提示");
                                return;
                            }



                        }

                    }

                    catch
                    {
                        MessageBox.Show("系统错误");
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
            else if (comboBox1.Text == "全部借出的书")
            {
                try
                {
                    string id = textBox1.Text;
                    string sql = string.Format("select borrow.readerid, readername, borrow.bookid, bookname, borrowtime, returntime, outtime from borrow, reader, book where book.bookid = borrow.bookid and borrow.readerid = reader.readerid ");
                    dataadapter = new SqlDataAdapter(sql, Dbconnect.connection);
                    dataadapter.Fill(dataset, "borrow");
                    dataGridView1.DataSource = dataset.Tables["borrow"];
                    button3.Visible = true;
                    MessageBox.Show("查询成功", "温馨提示");

                }
                catch
                {
                    MessageBox.Show("操作数据库出错", "温馨提示");
                }
                finally
                {
                    Dbconnect.connection.Close();
                }


            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            groupBox1.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string rid = textBox2.Text;
            string bid = textBox3.Text;
            string id0 = Convert.ToString(textBox2.Text);
            if (rid != "" && bid != "")
            {
                if (id0 != userhelper.readerid)
                {
                    MessageBox.Show("输入账号与登陆账号不相同，请重新输入", "温馨提示");
                    textBox1.Text = "";
                    textBox1.Focus();
                }
                else
                {
                    try
                    {
                        Dbconnect.connection.Open();

                        string sql = string.Format("update borrow set returntime=getdate(),outtime='已还' where readerid= '{0}'and bookid='{1}' and outtime ='否'", rid, bid);
                        SqlCommand commmand = new SqlCommand(sql, Dbconnect.connection);

                        int ab = commmand.ExecuteNonQuery();

                        string sql1 = string.Format("update book set ifborrow='否' where bookid={0}", bid);
                        SqlCommand co = new SqlCommand(sql1, Dbconnect.connection);
                        int c = co.ExecuteNonQuery();
                        if (ab != 0 && c != 0)
                        {
                            MessageBox.Show("恭喜您，还书成功！", "温馨提示");
                        }
                        else
                        {
                            MessageBox.Show("对不起，还书失败,请检查借阅证号或图书编号是否有误，或者已经还书。", "温馨提示");
                            return;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("没有查询到相关信息，请检查您输入的借阅证号和图书编号是否正确", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    }
                    finally
                    {
                        Dbconnect.connection.Close();
                    }

                }
            }
            else if (rid == "" || bid == "")
            {
                MessageBox.Show("请完整输入借阅证号和图书编号", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            



        }
    

        private void button5_Click(object sender, EventArgs e)
        {

            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (groupBox1.Visible == false)
            { MessageBox.Show("请先点击还书操作", "温馨提示"); }
            else
            {
                groupBox1.Visible = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataset.Tables["borrow"].Clear();
            textBox1.Text = "";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox1.Text == "全部借出的书" || comboBox1.Text == "") { groupBox2.Visible = false; }
            if (comboBox1.Text == "个人借书") { groupBox2.Visible = true; }
        }
    }
}
