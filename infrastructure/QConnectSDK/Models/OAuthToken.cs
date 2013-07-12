using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QConnectSDK.Models
{
    /// <summary>
    /// QQ空间OAuth2.0
    /// </summary>
    [Serializable]
    public class OAuthToken
    {
        /// <summary>
        /// access token
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// 用户唯一标识
        /// </summary>
        public string OpenId { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        public int ExpiresAt { get; set; }

    }
}
