using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

// How to write a method?
//  Q1 : What is the purpose of your method?
//  Q2 : Does your method require formal parameters?
//  If NO ===> ()
//  If YES Specify it(them)
//  Each parameter : Type, Passing method (By value, by refference, by out)
//  Q3 : Does your method return a value explicitly?
//  Q4 : Where do yo use your method?

namespace Lab1_ConnectMode.DAL
{
    public class UtilityDB
    {
        /// <summary>
        /// This metods returns an active database connection
        /// </summary>
        /// <returns>Obj of type SqlConnection</returns>
        public static SqlConnection GetDBConnection()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            conn.Open();

            return conn;
        }
    }
}