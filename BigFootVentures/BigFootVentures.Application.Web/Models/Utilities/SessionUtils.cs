using BigFootVentures.Business.Objects.Management;
using System;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace BigFootVentures.Application.Web.Models.Utilities
{
    public static class SessionUtils
    {
        public static UserAccount GetUserAccount()
        {
            var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            var cookie = FormsAuthentication.Decrypt(authCookie.Value).Name;
            var values = cookie.Split(new char[] { ' ' }, 3);

            return new UserAccount
            {
                ID = Convert.ToInt32(values.First()),
                Username = values.ElementAt(1),
                DisplayName = values.Last()
            };
        }

        public static DateTime GetCurrentDateTime()
        {
            return DateTime.UtcNow;
        }
    }
}