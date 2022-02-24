using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace ErrorHandlingWebForm
{
    public static class ExceptionLogging
    {
        public static void LogErrorToDB(Exception ex)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("********************" + " Error Log - " + DateTime.Now + "*********************");
            sb.Append(Environment.NewLine);
            sb.Append(Environment.NewLine);
            sb.Append("Exception Type : " + ex.GetType().Name);
            sb.Append(Environment.NewLine);
            sb.Append("Error Message : " + ex.Message);
            sb.Append(Environment.NewLine);
            sb.Append("Error Source : " + ex.Source);
            sb.Append(Environment.NewLine);
            if (ex.StackTrace != null)
            {
                sb.Append("Error Trace : " + ex.StackTrace);
            }
            Exception innerEx = ex.InnerException;
            while (innerEx != null)
            {
                sb.Append(Environment.NewLine);
                sb.Append(Environment.NewLine);
                sb.Append("Exception Type : " + innerEx.GetType().Name);
                sb.Append(Environment.NewLine);
                sb.Append("Error Message : " + innerEx.Message);
                sb.Append(Environment.NewLine);
                sb.Append("Error Source : " + innerEx.Source);
                sb.Append(Environment.NewLine);
                if (ex.StackTrace != null)
                {
                    sb.Append("Error Trace : " + innerEx.StackTrace);
                }
                innerEx = innerEx.InnerException;
            }
            string Connection = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;
            SqlConnection conn = new SqlConnection(Connection);
            SqlCommand cmd = new SqlCommand("Sp_LogException", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter();
            cmd.Parameters.Add("@ExceptionMessage", SqlDbType.NVarChar).Value = sb.ToString();
            cmd.Parameters.Add("@Source", SqlDbType.VarChar).Value = "Your Appliaction Name";
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}