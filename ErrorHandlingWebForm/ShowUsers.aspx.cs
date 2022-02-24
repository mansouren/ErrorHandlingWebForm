using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ErrorHandlingWebForm
{
    public partial class ShowUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //    try
                //    {
                string connectionStrings = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;
                    SqlConnection con = new SqlConnection(connectionStrings);
                    string Sqlquery = "Select * from User";
                    SqlCommand cmd = new SqlCommand(Sqlquery, con);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "Users");
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                //}
                //catch (Exception)
                //{
                //    //Label1.Text = "Something went wrong,Please Contact Adminastrator!";
                //    //Page_Error(sender, e);
                    
                //}
             
            }

         
        }

        //protected void Page_Error(object sender, EventArgs e)
        //{
        //    Exception ex = Server.GetLastError();
        //    Server.ClearError();
        //    Response.Redirect("Error.aspx");
        //}
    }
}