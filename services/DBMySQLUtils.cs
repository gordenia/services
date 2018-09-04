using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace services
{
    class DBMySQLUtils
    {
        public static MySqlConnection
                GetDBConnection(string host, string database, string username, string password)
        {
            String connString = 
                "Server=" + host + 
                ";Database=" + database + 
                ";User=" + username + 
                ";password=" + password;

            MySqlConnection conn = new MySqlConnection(connString);

            return conn;
        }
    }
}
