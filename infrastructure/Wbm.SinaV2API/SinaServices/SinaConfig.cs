/*
 This file was create by Xusion at 2011.10.27
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Configuration;
using System.Collections.Specialized;
using System.Xml;
using Wbm.SinaV2API.Helpers;
using Wbm.SinaV2API.Entitys;

namespace Wbm.SinaV2API.SinaServices
{
    /// <summary>
    /// 定制新浪Key
    /// </summary>
    public static class SinaConfig
    {
        private const string CONFIG_BASE = "/configuration/base/";
        /// <summary>
        /// 获取配置文件
        /// </summary>
        private static XmlHelper Config
        {
            get
            {
                const string CONFIG_PATH = "~/iPow.SinaV2.config";
                const string CONFIG = "Wbm.SinaV2_CONFIG";
                try
                {
                    XmlHelper xml = null;
                    object cache = System.Web.HttpContext.Current.Cache[CONFIG];
                    if (cache == null)
                    {
                        string path = System.Web.HttpContext.Current.Server.MapPath(CONFIG_PATH);
                        xml = new XmlHelper();
                        xml.Load(path);
                        System.Web.Caching.CacheDependency depe = new System.Web.Caching.CacheDependency(path);
                        System.Web.HttpContext.Current.Cache.Insert(CONFIG, xml, depe);
                    }
                    else
                    {
                        xml = (XmlHelper)cache;
                    }

                    return xml;
                }
                catch
                {
                    throw new Exception(string.Format("{0}文件加载错误", CONFIG_PATH));
                }
            }
        }
        /// <summary>
        /// 获取配置文件(Wbm.SinaV2.config)的application
        /// </summary>
        /// <param name="configAppKeyName">application子节点的Name</param>
        /// <returns>APPKey实体</returns>
        public static ApplicationEntity GetAppKey(string configAppKeyName)
        {
            if (string.IsNullOrEmpty(configAppKeyName)) { throw new ArgumentException("configAppKeyName 参数不能为空"); }

            const string CONFIG_APPLICATION = "/configuration/application/";
            const string CONFIG_APPLICATION_KEY = "/clientId";
            const string CONFIG_APPLICATION_SECRET = "/clientSecret";
            const string CONFIG_APPLICATION_REDIRECTURI = "/redirectUri";

            string key = CONFIG_APPLICATION + configAppKeyName + CONFIG_APPLICATION_KEY;
            string secret = CONFIG_APPLICATION + configAppKeyName + CONFIG_APPLICATION_SECRET;
            string redirecturi = CONFIG_APPLICATION + configAppKeyName + CONFIG_APPLICATION_REDIRECTURI;
            if (Config.IsExists(key) && Config.IsExists(secret) && Config.IsExists(redirecturi))
            {
                return GetAppKey(Config.SelectSingleNodeText(key), Config.SelectSingleNodeText(secret), Config.SelectSingleNodeText(redirecturi), configAppKeyName);
            }
            else
            {
                throw new Exception(string.Format("{0}节点：{1}，{2}和{3}不能为空值", CONFIG_APPLICATION, key, secret, redirecturi));
            }
        }

        /// <summary>
        /// 获取配置文件的AppKey
        /// </summary>
        /// <param name="AppKey">App Key</param>
        /// <param name="AppSecret">App Secret</param>
        /// <param name="AppName">名字，只是做判断使用，但不能重复</param>
        /// <returns>新浪APPKey实体</returns>
        public static ApplicationEntity GetAppKey(string AppKey, string AppSecret, string RedirectUri, string AppName)
        {
            if (string.IsNullOrEmpty(AppName)) { throw new ArgumentException("AppName 参数不能为空"); }
            if (string.IsNullOrEmpty(AppKey)) { throw new ArgumentException("AppKey 参数不能为空"); }
            if (string.IsNullOrEmpty(AppSecret)) { throw new ArgumentException("AppSecret 参数不能为空"); }
            if (string.IsNullOrEmpty(RedirectUri)) { throw new ArgumentException("RedirectUri 参数不能为空"); }

            return new ApplicationEntity(AppName, AppKey, AppSecret, RedirectUri); ;
        }

        /// <summary>
        /// 日志保存目录 请确认此文件夹具有写权限
        /// </summary>
        /// <returns></returns>
        public static string ApiLogPath
        {
            get
            {
                const string CONFIG_BASE_APILOGPATH = "apiLogPath";

                string xpath = CONFIG_BASE + CONFIG_BASE_APILOGPATH;
                if (Config.IsExists(xpath) && !string.IsNullOrEmpty(Config.SelectSingleNodeText(xpath)))
                {
                    return Config.SelectSingleNodeText(xpath);
                }
                else
                {
                    throw new ArgumentException(string.Format("{0}节点：apiLogPath 参数不能为空", CONFIG_BASE));
                }
            }
        }

        /// <summary>
        /// 缓存模式：Session|Cookies|Cache 其中Cookies数据自动加密，默认Session
        /// </summary>
        /// <returns></returns>
        public static string KeyCacheMode
        {
            get
            {
                const string CONFIG_BASE_KEYCACHEMODE = "apiCacheMode";

                string xpath = CONFIG_BASE + CONFIG_BASE_KEYCACHEMODE;
                if (Config.IsExists(xpath) && !string.IsNullOrEmpty(Config.SelectSingleNodeText(xpath)))
                {
                    return Config.SelectSingleNodeText(xpath);
                }
                else
                {
                    return "Session";
                }
            }
        }

        /// <summary>
        /// 缓存过期超时 单位：分钟 默认：1440分钟
        /// </summary>
        /// <returns></returns>
        public static int KeyCacheTimeout
        {
            get
            {
                const string CONFIG_BASE_KEYCACHETIMEOUT = "apiCacheTimeout";

                string xpath = CONFIG_BASE + CONFIG_BASE_KEYCACHETIMEOUT;
                int timeout = 0;
                return (Config.IsExists(xpath) && int.TryParse(Config.SelectSingleNodeText(xpath), out timeout)) ? timeout : 1440;
            }
        }
    }

}

