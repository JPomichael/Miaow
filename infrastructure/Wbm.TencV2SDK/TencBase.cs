using System;
using System.Text;
using System.Web;

namespace Wbm.TencV2SDK
{
    /// <summary>
    /// 基础对象
    /// </summary>
    public class TencBase : Wbm.TencV2SDK.OAuth.TencOAuth
    {
        /// <summary>
        /// oAuth 对象 缓存前缀
        /// </summary>
        private const string CahcePreName = "Wbm_TencV2SDK_";
        private Entitys.AppEntity app = null;

        /// <summary>
        /// 初始化APP
        /// </summary>
        /// <param name="cfgAppNodeName"></param>
        public TencBase(string cfgAppNodeName)
        {
            this.app = TencConfig.GetConfigApp(cfgAppNodeName);
            base.ClientId = this.app.AppKey;
            base.ClientSecret = this.app.AppSecret;
            base.RedirectUri = this.app.RedirectUri;
            base.Scope = this.app.Scope;
        }

        /// <summary>
        /// 当前应用
        /// </summary>
        public Entitys.AppEntity App
        {
            get
            {
                return this.app;
            }
        }

        /// <summary>
        /// 请求用户授权Token
        /// </summary>
        public string GetAuthorize()
        {
            return base.GetAuthorize(TencConfig.Authorize);
        }

        /// <summary>
        /// 获取授权过的Access Token
        /// </summary>
        public Models.TencMToken GetAccessToken()
        {
            return base.GetAccessToken(TencConfig.AccessToken);
        }



        /// <summary>
        /// 是否拥有Cookie缓存
        /// </summary>
        public bool HasCookie
        {
            get
            {
                return !string.IsNullOrEmpty(CookieValue);
            }
        }

        /// <summary>
        /// 是否拥有Session缓存
        /// </summary>
        public bool HasSession
        {
            get
            {
                return !string.IsNullOrEmpty(SessionValue);
            }
        }

        /// <summary>
        /// 获取Cookie缓存
        /// </summary>
        /// <returns>不存在返回null</returns>
        public string CookieValue
        {
            get
            {
                string name = CahcePreName + app.AppName;
                HttpCookie cookie = HttpContext.Current.Request.Cookies[name];
                if (cookie != null && !string.IsNullOrEmpty(cookie.Value))
                {
                    try
                    {
                        string value = Helpers.SecurityHelper.DesDecrypt(cookie.Value, TencConfig.DesKey);
                        var values = value.Split('|');
                        if (values.Length == 2)
                        {
                            base.AccessToken = values[0];
                            base.OpenId = values[1];
                        }
                        return value;
                    }
                    catch
                    {
                        //密文不正确
                        this.ClearCookie();
                    }
                }
                return null;
            }
        }

        /// <summary>
        /// 获取Session缓存
        /// </summary>
        /// <returns>不存在返回null</returns>
        public string SessionValue
        {
            get
            {
                string name = CahcePreName + app.AppName;
                var session = HttpContext.Current.Session[name];
                if (session != null)
                {
                    var value = session.ToString();
                    base.AccessToken = value;
                    return value;
                }
                return null;
            }
        }

        /// <summary>
        /// 更新Cooike缓存
        /// </summary>
        /// <param name="accessToken">认证缓存值</param>
        /// <param name="openId">用户id值</param>
        /// <param name="dtExpires">缓存时间</param>
        public void UpdateCookie(string accessToken, string openId, DateTime dtExpires)
        {
            string name = CahcePreName + app.AppName;
            string value = accessToken + "|" + openId;
            HttpCookie cookie = HttpContext.Current.Request.Cookies[name];
            if (cookie == null) { cookie = new HttpCookie(name); }
            cookie.Value = Helpers.SecurityHelper.DesEncrypt(value, TencConfig.DesKey);
            cookie.Expires = dtExpires;
            cookie.HttpOnly = true;
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// 更新session缓存
        /// </summary>
        /// <param name="strValue">缓存值</param>
        /// <param name="openId">用户id值</param>
        public void UpdateSession(string accessToken, string openId)
        {
            string name = CahcePreName + app.AppName;
            string value = accessToken + "|" + openId;
            HttpContext.Current.Session[name] = value;
        }

        /// <summary>
        /// 清除Cookie缓存
        /// </summary>
        public void ClearCookie()
        {
            UpdateCookie(string.Empty, string.Empty, DateTime.Now.AddDays(-1));
        }

        /// <summary>
        /// 清除Session缓存
        /// </summary>
        public void ClearSession()
        {
            UpdateSession(string.Empty, string.Empty);
        }
    }
}
/*
 * Author: xusion
 * Created: 2012.06.22
 * Support: http://wobumang.com
 */