using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web;
namespace Web.Helper
{
    public static class WebUtility 
    {
        private const string CURRENTUSERKEY = "CurrentUser";
        public static User CurrentUser
        {
            get { return (User)HttpContext.Current.Session[CURRENTUSERKEY]; }
            set { HttpContext.Current.Session[CURRENTUSERKEY] = value; }
        }

        public static void ClearAllSession()
        {
            CurrentUser = null; // And the other props
        }
    }
}