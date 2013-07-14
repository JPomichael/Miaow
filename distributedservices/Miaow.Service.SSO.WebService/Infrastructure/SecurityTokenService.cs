using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Miaow.Service.SSO.Entity;

namespace Miaow.Service.SSO.WebService
{
    public class SecurityTokenService
    {
        /// <summary>
        /// 
        /// </summary>
        static SecurityTokenCollection securityTokenList;

        /// <summary>
        /// Initializes the <see cref="SecurityTokenService"/> class.
        /// </summary>
        static SecurityTokenService()
        {
            securityTokenList = new SecurityTokenCollection();
        }

        /// <summary>
        /// Gets the security token list.
        /// </summary>
        /// <value>The security token list.</value>
        public static SecurityTokenCollection SecurityTokenList { get { return securityTokenList; } }
    }
}