using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace Unit07Work
{
    public static class DBHelper<T> where T:class
    {
        private static string connStr = "Data Source=.;Initial Catalog=Blog_DB;Integrated Security=True";
        public static int ExecNonQuery(string str)
        {
            using (SqlConnection conn=new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(str,conn);
                return cmd.ExecuteNonQuery();
            }
        }
        public static DataTable GetTable(string str)
        {
            using (SqlConnection conn=new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(str,conn);
                DataTable dt = new DataTable();
                SqlDataAdapter dpt = new SqlDataAdapter(cmd);
                dpt.Fill(dt);
                return dt;
            }
        }
        public static List<T>  GetList(string str)
        {
            var dt = GetTable(str);
            return JsonConvert.DeserializeObject<List<T>>(JsonConvert.SerializeObject(dt));
        }
    }
}