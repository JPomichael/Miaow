/*
 This file was create by Xusion at 2011.10.27
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

using Wbm.SinaV2API.Helpers;
using Wbm.SinaV2API.Entitys;

namespace Wbm.SinaV2API.SinaServices
{
    public class SinaCache
    {
        /// <summary>
        /// oAuth 对象 缓存名字
        /// </summary>
        private const string ACCESSTOKEN = "WBM_ACCESSTOKEN";

        /// <summary>
        /// 缓存AppKeyName
        /// </summary>
        private string AppKeyName = string.Empty;

        /// <summary>
        /// 缓存AccessToken 
        /// </summary>
        public string AccessToken
        {
            set { ApiCacheHelper.SetValue(ACCESSTOKEN + AppKeyName, value); }
            get { return ApiCacheHelper.GetValue(ACCESSTOKEN + AppKeyName) != null ? ApiCacheHelper.GetValue(ACCESSTOKEN + AppKeyName).ToString() : null; }
        }       

        /// <summary>
        /// 缓存值
        /// </summary>
        /// <param name="appKeyName">应用名称</param>
        public SinaCache(string appKeyName)
        {
            this.AppKeyName = appKeyName;
        }       
    }
}
