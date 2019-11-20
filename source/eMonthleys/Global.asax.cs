using System;
using System.Web.Caching;

namespace eMonthleys
{
    public class Global : System.Web.HttpApplication
    {
        public void SessionEnded(string key, object val, CacheItemRemovedReason r)
        {
        }

        protected void Application_Start(object sender, EventArgs e)
        {
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
        }
    }
}