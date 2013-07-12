using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iPow.Service.SSO.Entity;

namespace iPow.Service.SSO.WebService
{
    public class OnLineUserService
    {
        /// <summary>
        /// 
        /// </summary>
        static OnlineUserCollection onlineUserList;

        /// <summary>
        /// Initializes the <see cref="OnLineUserService"/> class.
        /// </summary>
        static OnLineUserService()
        {
            onlineUserList = new OnlineUserCollection();
        }

        /// <summary>
        /// Gets the on line user list.
        /// </summary>
        /// <value>The on line user list.</value>
        public static OnlineUserCollection OnLineUserList { get { return onlineUserList; } }
    }
}