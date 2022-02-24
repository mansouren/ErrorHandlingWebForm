using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace ErrorHandlingWebForm
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Error += Application_Error;
        }

        //private void Application_Error(object sender, EventArgs e)
        //{
        //    Exception exception = Server.GetLastError();
        //    Server.ClearError();
        //    ExceptionLogging.LogErrorToDB(exception);
        //    Server.Transfer("Error.aspx");
        //}
    }
}