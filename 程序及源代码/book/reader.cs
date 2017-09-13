using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
namespace book
{
    public partial class reader : Form
    {
        public reader()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           string   id =Convert.ToString (textBox1.Text);
            
            if (id!=userhelper.readerid)
            {
                MessageBox.Show("输入账号与登陆账号不相同，请重新输入","温馨提示");
                textBox1.Text = "";
                textBox1.Focus();
            }
            else 
                try 
               {
                    string sql = string.Format("update reader set islost='{0}'where readerid='{1}'", '是',id);
                    Dbconnect.connection.Open();
                    SqlCommand command = new SqlCommand(sql,Dbconnect.connection);
                    int result =  command.ExecuteNonQuery();
                    if (result < 1)
                   {
                       MessageBox.Show("修改失败");
                   }
                   else MessageBox.Show("挂失成功");

                
              }
                catch  
                 {
                        
                   MessageBox.Show("error");
                 }
                finally
                { 
                    Dbconnect.connection.Close();
                }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = true;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            groupBox2.Visible = false;
        }

       


    
        private void button5_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            groupBox2.Visible = false;
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolStrip1.Text = string.Format("学生：{0}",userhelper.readerid);
        }

        private void button4_Click(object sender, EventArgs e)
        {
           string  id =Convert.ToString (textBox2.Text);
            
            if (id!=userhelper.readerid)
            {
                MessageBox.Show("输入账号与登陆账号不相同，请重新输入","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                textBox1.Text = "";
                textBox1.Focus();
            }
            else if (textBox4.Text!=textBox5.Text)
            {
            MessageBox.Show ("两次密码输入不同");
            }
            else try 
      
               {
                    string sql = string.Format("update reader set readerpass='{0}' where readerid='{1}'", textBox4.Text,id);
                    Dbconnect.connection.Open();
                    SqlCommand command = new SqlCommand(sql,Dbconnect.connection);
                    int result =  command.ExecuteNonQuery();
                    if (result < 1)
                   {
                       MessageBox.Show("修改失败","温馨提示");
                   }
                   else MessageBox.Show("修改成功","温馨提示");

                
              }
                catch  
                 {
                        
                   MessageBox.Show("error");
                 }
                finally
                { 
                    Dbconnect.connection.Close();
                }
        }

      

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            addreader addreader = new addreader();
            addreader = new addreader();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            readerserchbook a = new readerserchbook();
            a.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            borrowsearch a = new borrowsearch();
            a.Show();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            stusearch a = new stusearch();
            a.Show();


         
        }

        private void 图书查询ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            


        }

        private void 结束查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            borrowsearch a = new borrowsearch();
            a.Show();
     

        }

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = true;

        }

        private void 挂失ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            groupBox2.Visible = false;
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            groupBox1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void toolStripButton6_Click_1(object sender, EventArgs e)
        {
            booksborrow a = new booksborrow();
            a.Show();

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            login a = new login();
            this.Hide();
            a.Show();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            readerreturnbook a = new readerreturnbook();
            a.Show();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            readermanage a = new readermanage();
            a.Show();
        }
    }
}