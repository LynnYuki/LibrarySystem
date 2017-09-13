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
    public partial class booksborrow : Form
    {
        public booksborrow()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string rid = textBox1.Text;
            string bid = textBox2.Text;



            try
            {
                if (rid != "" && bid != "")
                {
                    Dbconnect.connection.Open();
                    string sql1 = string.Format("insert into borrow(readerid,bookid) values('{0}','{1}')", rid, bid);
                    SqlCommand B = new SqlCommand(sql1, Dbconnect.connection);
                    int b = B.ExecuteNonQuery();

                    string sql2 = string.Format("update book set ifborrow='是' where bookid={0}", bid);
                    SqlCommand C = new SqlCommand(sql2, Dbconnect.connection);
                    int c = C.ExecuteNonQuery();
                    if (b != 0 && c != 0)
                    {

                        MessageBox.Show("借阅成功", "温馨提示");


                    }
                    else
                    {
                        MessageBox.Show("借阅失败", "温馨提示");
                        return;
                    }

                }


                else if (rid == "" || bid == "")
                {
                    MessageBox.Show("请输入所有信息", "温馨提示");
                }
            }


            catch
            {
                MessageBox.Show("借阅失败，没有找到相关图书，请检查图书编号是否正确", "温馨提示");


            }
            finally
            {
                Dbconnect.connection.Close();
            }
        }
     
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
          
        }

       
        }
    }
