using System;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Xml;

namespace Wbm.TencV2SDK
{
    /// <summary>
    /// 配置文件
    /// </summary>
    public static class TencConfig
    {
        private const string CONFIG_ROOT = "/configuration";
        private const string CONFIG_BASE = "/base";
        private const string CONFIG_APP = "/app";
        private const string CONFIG_API = "/api";

        /// <summary>
        /// 获取配置文件
        /// </summary>
        private static Helpers.XmlHelper XmlConfig
        {
            get
            {
                const string CONFIG_PATH = "~/Wbm.TencV2.config";
                const string CONFIG_CACHE = "Wbm_TencV2SDK_CONFIG";

                try
                {
                    Helpers.XmlHelper xml = null;
                    object cache = System.Web.HttpContext.Current.Cache[CONFIG_CACHE];
                    if (cache == null)
                    {
                        string path = System.Web.HttpContext.Current.Server.MapPath(CONFIG_PATH);
                        if (!System.IO.File.Exists(path)) { throw new System.IO.FileNotFoundException(string.Format("{0}配置文件不存在", CONFIG_PATH)); }

                        xml = new Helpers.XmlHelper();
                        xml.Load(path);

                        System.Web.Caching.CacheDependency depe = new System.Web.Caching.CacheDependency(path);
                        System.Web.HttpContext.Current.Cache.Insert(CONFIG_CACHE, xml, depe);
                    }
                    else
                    {
                        xml = (Helpers.XmlHelper)cache;
                    }

                    return xml;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        /// <summary>
        /// 获取配置文件(Wbm.TencV2.config)的application节点
        /// </summary>
        /// <param name="cfgAppNodeName">application子节点的Name</param>
        /// <returns>APPKey实体</returns>
        public static Entitys.AppEntity GetConfigApp(string cfgAppNodeName)
        {
            string xpath = CONFIG_ROOT + CONFIG_APP + "/" + cfgAppNodeName.Trim('/');
            string CONFIG_SCOPE_KEY = "/scope";
            string CONFIG_APPLICATION_KEY = "/clientId";
            string CONFIG_APPLICATION_SECRET = "/clientSecret";
            string CONFIG_APPLICATION_REDIRECTURI = "/redirectUri";
            string CONFIG_APPLICATION_USERNAME = "/userName";
            string CONFIG_APPLICATION_PASSWORD = "/password";

            string scope = xpath + CONFIG_SCOPE_KEY;
            string key = xpath + CONFIG_APPLICATION_KEY;
            string secret = xpath + CONFIG_APPLICATION_SECRET;
            string redirecturi = xpath + CONFIG_APPLICATION_REDIRECTURI;
            string username = xpath + CONFIG_APPLICATION_USERNAME;
            string password = xpath + CONFIG_APPLICATION_PASSWORD;


            var app = new Entitys.AppEntity();
            app.AppName = cfgAppNodeName;
            if (XmlConfig.IsExists(key) && !string.IsNullOrEmpty(XmlConfig.SelectSingleNodeText(key)))
            {
                if (XmlConfig.IsExists(secret) && !string.IsNullOrEmpty(XmlConfig.SelectSingleNodeText(secret)))
                {
                    if (XmlConfig.IsExists(redirecturi) && !string.IsNullOrEmpty(XmlConfig.SelectSingleNodeText(redirecturi)))
                    {
                        app.AppKey = XmlConfig.SelectSingleNodeText(key);
                        app.AppSecret = XmlConfig.SelectSingleNodeText(secret);
                        app.RedirectUri = XmlConfig.SelectSingleNodeText(redirecturi);
                        app.Scope = XmlConfig.SelectSingleNodeText(scope);
                    }
                    else
                    {
                        throw new ArgumentNullException(string.Format("{0}节点：找不到该节点或该值为空", redirecturi));
                    }
                }
                else
                {
                    throw new ArgumentNullException(string.Format("{0}节点：找不到该节点或该值为空", secret));
                }
            }
            else
            {
                throw new ArgumentNullException(string.Format("{0}节点：找不到该节点或该值为空", key));
            }

            return app;
        }

        public static string DesKey
        {
            get
            {
                string xpath = CONFIG_ROOT + CONFIG_BASE + "/desKey";

                if (XmlConfig.IsExists(xpath) && !string.IsNullOrEmpty(XmlConfig.SelectSingleNodeText(xpath)))
                {
                    return XmlConfig.SelectSingleNodeText(xpath);
                }
                else
                {
                    throw new ArgumentNullException(string.Format("{0}节点：找不到该节点或该值为空", xpath));
                }
            }
        }


        /// <summary>
        /// 获取配置文件(Wbm.TencV2.config)的api节点
        /// </summary>
        /// <param name="cfgApiNodeName">api子节点的Name</param>
        /// <returns></returns>
        public static string GetConfigAPI(string cfgApiNodeName)
        {
            string xpath = CONFIG_ROOT + CONFIG_API + "/" + cfgApiNodeName.Trim('/');
            if (XmlConfig.IsExists(xpath) && !string.IsNullOrEmpty(XmlConfig.SelectSingleNodeText(xpath)))
            {
                return XmlConfig.SelectSingleNodeText(xpath);
            }
            else
            {
                throw new ArgumentNullException(string.Format("{0}节点：找不到该节点或该值为空", xpath));
            }
        }


        /// <summary>
        /// 获取用户授权Token
        /// </summary>
        public static string Authorize
        {
            get
            {
                return GetConfigAPI("authorize");
            }
        }

        /// <summary>
        /// 获取授权过的AccessToken
        /// </summary>
        public static string AccessToken
        {
            get
            {
                return GetConfigAPI("access_token");
            }
        }

        /// <summary>
        /// 获取OpenId
        /// </summary>
        public static string Me
        {
            get
            {
                return GetConfigAPI("me");
            }
        }
    }

}

/*
 * Author: xusion
 * Created: 2012.06.22
 * Support: http://wobumang.com
 */