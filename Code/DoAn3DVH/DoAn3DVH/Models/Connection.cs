using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DoAn3DVH.Models
{
    public class Connection
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        string str = ConfigurationManager.ConnectionStrings["strconnect"].ConnectionString;
        public Connection()
        {
            cn = new SqlConnection(str);
        }
        public DataTable GetData(string query)
        {
            cn.Open();
            da = new SqlDataAdapter(query, cn);
            dt = new DataTable();
            da.Fill(dt);
            cn.Close();
            return dt;
        }

        public void WriteData(string query)
        {
            cn.Open();
            cmd = new SqlCommand(query, cn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            cn.Close();
        }

        internal DataTable GetData(string v1, string id, string v2)
        {
            throw new NotImplementedException();
        } 
    }
}