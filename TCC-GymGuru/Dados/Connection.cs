﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class Connection
    {
        public static String conString = ConfigurationManager.ConnectionStrings["cnStrMysql"].ConnectionString;
        public static MySqlConnection SqlCon = new MySqlConnection();

        public static void getConnection()
        {
            try
            {
                if (Connection.SqlCon.State == System.Data.ConnectionState.Closed)
                {
                    Connection.SqlCon.ConnectionString = conString;
                    Connection.SqlCon.Open();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
