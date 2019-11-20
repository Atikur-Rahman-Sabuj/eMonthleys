using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using System.Web;
using System.Web.Caching;
using System.Web.Configuration;

namespace eMonthleys.BLL
{
    public abstract class BaseBLL
    {
        #region Current Context

        public static IPrincipal CurrentUser
        {
            get { return HttpContext.Current.User; }
        }

        protected static string CurrentUserName
        {
            get
            {
                string userName = string.Empty;
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                    userName = HttpContext.Current.User.Identity.Name;
                return userName;
            }
        }

        #endregion

        #region Caching

        protected static Cache Cache
        {
            get { return HttpContext.Current.Cache; }
        }

        protected static void PurgeCacheItems(string prefix)
        {
            prefix = prefix.ToLower();
            List<string> itemsToRemove = new List<string>();

            IDictionaryEnumerator enumerator = Cache.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (enumerator.Key.ToString().ToLower().StartsWith(prefix))
                    itemsToRemove.Add(enumerator.Key.ToString());
            }

            foreach (string item in itemsToRemove)
                Cache.Remove(item);
        }

        protected static bool CachingOn
        {
            get { return bool.Parse(WebConfigurationManager.AppSettings["CachingOn"]); }
        }

        protected static int CacheDuration
        {
            get { return int.Parse(WebConfigurationManager.AppSettings["CacheDuration"]); }
        }

        protected static void CacheData(string key, object data)
        {
            if (CachingOn && data != null)
            {
                Cache.Insert(key, data, null, DateTime.Now.AddSeconds(CacheDuration), TimeSpan.Zero);
            }
        }

        #endregion
    }
}
