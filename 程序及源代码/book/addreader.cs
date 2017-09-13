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
    public partial class addreader : Form
    {
        public addreader()
        {
            InitializeComponent();
        }

       
        private void button3_Click(object sender, EventArgs e)
        {
          
            this.Close();
        }
        //清除所有内容
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox6.Text = null;
            textBox2.Text = null;
            textBox4.Text = null; 
            textBox3.Text = null;
            textBox5.Text = null; 
            comboBox1.Text = null;
            textBox7.Text = null;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
             
           
            //连接数据库 
             
            

            //定义变量
            string name =textBox1 .Text ;
            string age=textBox2 .Text ;           
            string sex = comboBox1.Text; 
            string studentId=textBox3.Text;
            string dept = textBox4.Text;
            string zhuanye= textBox5.Text;
            string maxnumber = textBox7.Text;
            string pass = textBox6.Text;
            string passr = textBox8.Text;
            try
            {
                if (name != "" && age != "" && sex != "" && studentId != "" && dept != "" && zhuanye != "" && maxnumber != "" && pass != "" && passr != "")
                {
                    if (textBox6.Text.Trim().Equals(textBox8.Text.Trim()))
                    {
                        Dbconnect.connection.Open();

                        string sql = string.Format("insert into reader (readerid,readerpass,readername,readersex,readerage,readerdept,readerzhuanye,maxnumber) values ('{0}','{1}','{2}','{3}',{4},'{5}','{6}',{7})", studentId, pass, name, sex, age, dept, zhuanye, maxnumber);

                        SqlCommand commmand = new SqlCommand(sql, Dbconnect.connection);

                        int ab = commmand.ExecuteNonQuery();
                        if (ab != 0)
                        {
                            MessageBox.Show("保存成功", "温馨提示");
                        }
                        else
                        {
                            MessageBox.Show("添加失败", "温馨提示");
                            return;
                        }
                    }
                    if (!textBox6.Text.Trim().Equals(textBox8.Text.Trim()))
                    {
                        MessageBox.Show("两次密码输入不相同，请重新输入", "温馨提示");
                    }
                }

                else if (name == "" || age == "" || sex == "" || studentId == "" || dept == "" || zhuanye == "" || maxnumber == "" || passr == "")
                {
                    MessageBox.Show("请输入所有学生信息", "温馨提示");
                }
              }
            

            catch
            {
                MessageBox.Show("操作数据库出错,请检查输入的年龄是否属于（0-100）或检查其他输入信息是否正确", "温馨提示");


            }
            finally
            { Dbconnect.connection.Close(); }
            
      
          

        }

     

       

       
    }
}





        
      
       