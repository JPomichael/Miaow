
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iPow.Service.SSO.WebService
{
    public class TimeOutService
    {
        /// <summary>
        /// Gets the login time out time in second.
        /// </summary>
        /// <value>The login time out time in second.</value>
        public static int LoginTimeOutTimeInSecond
        {
            get
            {
                var def = 120;
                var temp = System.Configuration.ConfigurationManager.AppSettings["loginTimeOutInSeconds"];
                int.TryParse(temp, out def);
                return def;
            }
        }

        /// <summary>
        /// Gets the token time out in second.
        /// </summary>
        /// <value>The token time out in second.</value>
        public static int TokenTimeOutInSecond
        {
            get
            {
                var def = 120;
                var temp = System.Configuration.ConfigurationManager.AppSettings["tokenTimeOutInSeconds"];
                int.TryParse(temp, out def);
                return def;
            }
        }

        /// <summary>
        /// Gets the clean up time in second.
        /// </summary>
        /// <value>The clean up time in second.</value>
        public static int CleanUpTimeInSecond
        {
            get
            {
                var def = 120;
                var temp = System.Configuration.ConfigurationManager.AppSettings["cleanUpTimeInSeconds"];
                int.TryParse(temp, out def);
                return def;
            }
        }
    }
}