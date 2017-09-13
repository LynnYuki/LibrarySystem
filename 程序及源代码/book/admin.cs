using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace book
{
    public partial class admin : Form
    {
        
        public admin()
        {
            InitializeComponent();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
        

        private void admin_Load(object sender, EventArgs e)
        {
           
            toolStrip1.Text=string.Format ("管理员：{}登录",userhelper.adminid);

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            addbook a = new addbook();
            a.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            addreader addreader = new addreader();
            addreader.Show();
        
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            publisher a=new publisher();
            a.Show ();
      
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            adminsearchbook a = new adminsearchbook();
            a.Show();

        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            adminreturnbook a = new adminreturnbook();
            a.Show();
        }

        private void 添加图书ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addbook a = new addbook();
            a.Show();
        }

        private void 删除图书ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            adminsearchbook a = new adminsearchbook();
            a.Show();
        }

        private void 查询图书ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            adminsearchbook a = new adminsearchbook();
            a.Show();
        }

        private void 查询学生借阅信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            adminreturnbook a = new adminreturnbook();
            a.Show();
        }

      

        

        private void 借书信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            adminreturnbook a = new adminreturnbook();
            a.Show();
        }

        private void 还书信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            adminreturnbook a = new adminreturnbook();
            a.Show();
        }

        private void 查询出版社信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            publisher a = new publisher();
            a.Show();
          
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            deletereader a = new deletereader();
            a.Show();
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deletereader a = new deletereader();
            a.Show();
        }

        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addbook a = new addbook();
            a.Show();

        }

        private void 修改出版社信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            publisher a = new publisher();
            a.Show();
        }

        private void toolStripButton6_Click_1(object sender, EventArgs e)
        {
            readersearch a = new readersearch();
            a.Show();
        }

        private void 切换帐号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            login a = new login();
            this.Hide();
            a.Show();
          
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            borrowsearch a = new borrowsearch();
            a.Show();
            
           
            
        }
    }
}