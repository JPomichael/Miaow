using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Configuration;
using System.Web;

namespace QConnectSDK.Config
{
    /// <summary>
    /// QQ互联的配置数据
    /// </summary>
    [Serializable]
    public class QQConnectConfig
    {
        private NameValueCollection QzoneSection = (NameValueCollection)ConfigurationManager.GetSection("QQSectionGroup/QzoneSection");

        /// <summary>
        /// 获取Authorization Code的URL地址
        /// </summary>
        /// <returns></returns>
        public string GetAuthorizeURL()
        {
            return QzoneSection["ipowTencentAuthorizeURL"];
        }
        /// <summary>
        /// 申请QQ登录成功后，分配给应用的appid
        /// </summary>
        /// <returns>string AppKey</returns>
        public string GetAppKey()
        {
            return QzoneSection["ipowTencentAppKey"];
        }

        /// <summary>
        /// 申请QQ登录成功后，分配给网站的appkey
        /// </summary>
        /// <returns>string AppSecret</returns>
        public string GetAppSecret()
        {
            return QzoneSection["ipowTencentAppSecret"];
        }

        /// <summary>
        /// 得到回调地址
        /// </summary>
        /// <returns></returns>
        public Uri GetCallBackURI()
        {
            string callbackUrl = QzoneSection["ipowTencentAppCallback"];
            if (!Uri.IsWellFormedUriString(callbackUrl, UriKind.Absolute))
            {
                var current = HttpContext.Current;
                if(current != null)
                {
                    var currentUrl = current.Request.Url;
                    callbackUrl = string.Format("{0}://{1}:{2}{3}",currentUrl.Scheme,currentUrl.Host, currentUrl.Port, callbackUrl);
                }
            }
            return new Uri(callbackUrl);
        }
    }
}
