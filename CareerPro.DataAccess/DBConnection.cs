using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerPro.DataAccess
{
    static class DBConnection
    {
        internal static SqlConnection GetConnection()
        {
            // this should be the only place in your app 
            // the connection string can be found.
            var connString = @"Data Source=localhost;Initial Catalog=CareerProDB;Integrated Security=True";
            var conn = new SqlConnection(connString);
            return conn;
        }
    }
}
