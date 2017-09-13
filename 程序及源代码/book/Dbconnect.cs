using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
namespace book
{
    class Dbconnect
    {
        public static string connectionstring = @"Data Source=LYNNYUKI-PC;Initial Catalog=book;Integrated Security=True;";
        public static SqlConnection connection = new SqlConnection(connectionstring);
    }
}
