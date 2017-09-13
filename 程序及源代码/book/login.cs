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
    public partial class login : Form
    {
        public string password;  //用来存储密码
        public login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        // 验证用户是否合法
        // 传入用户名、密码、登录类型
        // 合法返回 True，不合法返回 False
        // message 参数用来记录验证失败的原因
        private bool yanzhengshuru()
        {

            password = password0.Text;
            if (Typename.Text.Trim() == "")
            {
                MessageBox.Show("请选择登录类型", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Typename.Focus();
                return false;
            }
            else if (loginid.Text.Trim() == "")
            {
                MessageBox.Show("请输入用户名", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loginid.Focus();
                return false;
            }
            else if (password == "")
            {
                MessageBox.Show("请输入密码", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                password0.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {

          
             userhelper.adminid= loginid.Text;  //用户账号
             password = password0.Text;//用户密码
             

            if (yanzhengshuru())
            {
                if (Typename.Text.Trim() == "管理员")
                {

                    string sql = string.Format("Select count(*) from admin where adminId='{0}' and adminpass='{1}'", loginid.Text, password);

                    try
                    {
                        // 创建 Command 对象

                        SqlCommand command = new SqlCommand(sql, Dbconnect.connection);

                        // 打开数据库连接
                        Dbconnect.connection.Open();

                        // 验证是否为合法用户
                        int count = (int)command.ExecuteScalar();
                        if (count < 1)
                        {
                           MessageBox.Show("用户名或密码错误，请重新输入","温馨提示");
                            //result = false;
                        }
                        else
                        {
                            admin admin = new admin();
                            admin.Show();
                            MessageBox.Show("恭喜您成功登录本系统", "温馨提示");
                            this.Hide();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("数据库出错，请检查是否已经成功连接数据库");
                        Console.WriteLine(ex.Message);
                        //result = false;
                    }
                    finally
                    {
                        // 关闭数据库连接
                        Dbconnect.connection.Close();
                    }
                   
          

                }
                 if (Typename.Text.Trim() == "借阅者")
                 {
                     userhelper.readerid =Convert .ToString (loginid.Text);
                     

                    string sql = string.Format("Select count(*) from reader where readerId='{0}' and  readerpass='{1}'", userhelper.readerid,password0.Text);

                    try
                    {
                        // 创建 Command 对象

                        SqlCommand command = new SqlCommand(sql, Dbconnect.connection);

                        // 打开数据库连接
                        Dbconnect.connection.Open();

                        // 验证是否为合法用户
                        int count = (int)command.ExecuteScalar();
                        if (count < 1)
                        {
                            MessageBox.Show("用户名或密码错误，请重新输入", "温馨提示");
                            //result = false;
                        }
                        else
                        {
                            reader reader = new reader();
                            reader.Show();
                            MessageBox.Show("恭喜您成功登录本系统", "温馨提示");
                            this.Hide();

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("数据库出错，请检查是否已经成功连接数据库");
                        Console.WriteLine(ex.Message);
                        //result = false;
                    }
                    finally
                    {
                        // 关闭数据库连接
                        Dbconnect.connection.Close();
                    }
                   
                }
               

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Typename.Text = "";
            loginid.Text = "";
            password0.Text = "";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            readerzhuce a = new readerzhuce();
            a.Show();
        }
    }
}