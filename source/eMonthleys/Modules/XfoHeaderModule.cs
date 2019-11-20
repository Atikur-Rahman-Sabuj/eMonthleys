using System;
using System.Web;

namespace eMonthleys.Modules
{
    public class XfoHeaderModule :IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.PreSendRequestHeaders += context_PreSendRequestHeaders;
        }

        private void context_PreSendRequestHeaders(object sender, EventArgs e)
        {
            HttpContext.Current.Response.Headers.Add("X-Frame-Options", "Deny");
            HttpContext.Current.Response.Headers.Remove("Server");
            HttpContext.Current.Response.Headers.Remove("X-AspNet-Version");
        }

        public void Dispose()
        {

        }
    }
}