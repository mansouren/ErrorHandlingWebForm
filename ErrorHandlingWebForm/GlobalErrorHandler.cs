using System;
using System.Web;
using System.Collections.Specialized;
using System.Reflection;
using System.Diagnostics;

namespace ErrorHandlingWebForm
{
	public class GlobalErrorHandler : IHttpModule
	{
		public void Init (HttpApplication app)
		{
			app.Error += new System.EventHandler (OnError);
		}

		public void OnError (object obj, EventArgs args)
		{
			// At this point we have information about the error
			HttpContext ctx = HttpContext.Current;
			HttpResponse response = ctx.Response;
			HttpRequest request = ctx.Request;

			Exception exception = ctx.Server.GetLastError();

			response.Write("Your request could not processed. Please press the back button on your browser and try again.<br/>");
			response.Write("If the problem persists, please contact technical support<p/>");
			response.Write("Information below is for technical support:<p/>");
			
			string errorInfo = "<p/>URL: " + ctx.Request.Url.ToString () + "<p/>Stacktrace:---<br/>" + exception.InnerException.StackTrace.ToString() + "<p/>Error Message:<br/>" + exception.InnerException.Message;

			response.Write("Querystring:<p/>");

			for(int i=0;i<request.QueryString.Count;i++)
			{
				response.Write("<br/>" + request.QueryString.Keys[i].ToString() + " :--" + request.QueryString[i].ToString() + "--<br/>");// + nvc.
			}

			response.Write("<p>-------------------------<p/>Form:<p/>");

			for(int i=0;i<request.Form.Count;i++)
			{
				response.Write("<br/>" + request.Form.Keys[i].ToString() + " :--" + request.Form[i].ToString() + "--<br/>");// + nvc.
			}

			response.Write("<p>-------------------------<p/>ErrorInfo:<p/>");

			response.Write (errorInfo);

			// --------------------------------------------------
			// To let the page finish running we clear the error
			// --------------------------------------------------
			ctx.Server.ClearError ();
		}

		public void Dispose () {}
	}
}
