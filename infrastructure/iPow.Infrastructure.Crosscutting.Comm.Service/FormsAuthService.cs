using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Web;

namespace iPow.Infrastructure.Crosscutting.Comm.Service
{
    /// <summary>
    /// 
    /// </summary>
    public class FormsAuthService : IFormsAuthService
    {
        /// <summary>
        /// Signs the in.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="createPersistentCookie">if set to <c>true</c> [create persistent cookie].</param>
        public void Login(iPow.Domain.Dto.Sys_AdminUserDto user, bool createPersistentCookie)
        {
            var expirationTimeSpan = 1;
            var now =System.DateTime.Now;
            var ticket = new FormsAuthenticationTicket(
                1 /*version*/,
                user.username != null ? user.username : user.Email,
                now,now.AddDays(expirationTimeSpan),createPersistentCookie,
                user.username != null ? user.username : user.Email,
                FormsAuthentication.FormsCookiePath);

            var encryptedTicket = FormsAuthentication.Encrypt(ticket);

            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            cookie.HttpOnly = true;
            cookie.Expires = now.AddDays(expirationTimeSpan);
            cookie.Secure = FormsAuthentication.RequireSSL;
            cookie.Path = FormsAuthentication.FormsCookiePath;
            if (FormsAuthentication.CookieDomain != null)
            {
                cookie.Domain = FormsAuthentication.CookieDomain;
            }
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        /// <summary>
        /// Signs the out.
        /// </summary>
        public void LogOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}
