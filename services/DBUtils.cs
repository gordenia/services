using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace services
{
    class DBUtils
    {
        public static MySqlConnection GetDBConnection()
        {
            string host = "localhost";
            string database = "rtk_test";
            string username = "root";
            string password = "Rfccbjgtz";

            return DBMySQLUtils.GetDBConnection(host, database, username, password);
        }
    }
}
