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
    public partial class addbook : Form
    {
        public addbook()
        {
            InitializeComponent();
        }

        private void addbook_Load(object sender, EventArgs e)
        {
            try
            {
                string sql1 = "select booktypename from booktype";
                SqlCommand command = new SqlCommand(sql1, Dbconnect.connection);
                Dbconnect.connection.Open();
                SqlDataReader datareader = command.ExecuteReader();
                string typename = "";
                while (datareader.Read())
                {
                    typename = (string)datareader[0];
                    comboBox2.Items.Add(typename);
                }
                datareader.Close();

                string sql2 = "select publishername from publisher";
                SqlCommand command1 = new SqlCommand(sql2, Dbconnect.connection);
                //Dbhelper.connection.Open();
                SqlDataReader datareader1 = command1.ExecuteReader();
                string publishername = "";
                while (datareader1.Read())
                {
                    publishername = (string)datareader1[0];
                    //MessageBox.Show(publishername);
                    comboBox1.Items.Add(publishername);
                }
                datareader1.Close();
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

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox4.Text = null;
            comboBox2.Text = null;
            textBox3.Text = null;
            comboBox1.Text = null;
        }

        private string typdid(string a)
        {
            string id = "";
            string sqltypeid = string.Format("select booktypeid from booktype where booktypename='{0}'", a);
           
            try
            {  SqlCommand command=new SqlCommand (sqltypeid,Dbconnect.connection);
                Dbconnect.connection.Open();
                id = Convert.ToString(command.ExecuteScalar());
                
               // MessageBox.Show(id);
             
                

            }
            catch
            {
                MessageBox.Show("error ");
            }
            finally
            {
                Dbconnect.connection.Close();
               
               
            }
            return id;
        }
        private string publisheid(string a)
        {
            string id = "";
            string sqlpublisheid = string.Format("select publisherid from publisher where publishername='{0}'", a);
            try
            {
                SqlCommand command = new SqlCommand(sqlpublisheid, Dbconnect.connection);
                Dbconnect.connection.Open();
                id = Convert.ToString(command.ExecuteScalar());
              
            }
            catch
            {
                MessageBox.Show("error ");
            }
            finally
            {
                Dbconnect.connection.Close();
                
            }return id;
        }
        private void button1_Click(object sender, EventArgs e)
        { 
            string name =textBox1 .Text ;
            string writter=textBox2 .Text ;  
            string publisher = comboBox1.Text; 
            string type=comboBox2.Text;
            string price = textBox4.Text;
            string typeid = typdid(type);
            string publisherid = publisheid(publisher);
            string bianhao = textBox3.Text;
            try
            {
                if (bianhao != "" && name != "" && writter != "" && publisher != "" && type != "" && price != "")
                {

                    Dbconnect.connection.Open();
                    string sql0 = string.Format("insert into book (bookid,bookname,bookwritter,publisherid,booktypeid,bookprice) values ('{0}','{1}','{2}','{3}','{4}',{5})", bianhao, name, writter, publisherid, typeid, price);
                    SqlCommand commmand = new SqlCommand(sql0, Dbconnect.connection);
                    int ab = commmand.ExecuteNonQuery();
                    if (ab != 0)
                    {
                        MessageBox.Show("添加成功", "温馨提示");
                    }
                    else
                    {
                        MessageBox.Show("添加失败", "温馨提示");
                        return;
                    }
                    }


                else if (name == "" || writter == "" || publisher == "" || type == "" || price == ""||bianhao=="")

                {
                    MessageBox.Show("请输入完整图书信息", "温馨提示");
                }
                
            }





            catch 
            {

                MessageBox.Show( "输入有误，请您检查价格（大于0）和图书编号(大于0)是否输入正确，或已经添加该图书","温馨提示");
            }
            finally
            {
                Dbconnect.connection.Close();
            } 
         
          

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    }
