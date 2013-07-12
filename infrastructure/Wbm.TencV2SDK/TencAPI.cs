using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace Wbm.TencV2SDK
{
    /// <summary>
    /// 请求API
    /// </summary>
    public static class TencAPI
    {
        /// <summary>
        /// 同步方式发起http get请求
        /// </summary>
        /// <param name="cfgApiNodeName">api子节点的Name</param>
        /// <param name="queryParas">请求参数列表</param>
        /// <returns>返回json字符串</returns>
        public static string HttpGetName(string cfgApiNodeName, NameValueCollection queryParas)
        {
            var url = TencConfig.GetConfigAPI(cfgApiNodeName);
            return HttpGetUrl(url, queryParas);

        }

        /// <summary>
        /// 同步方式发起http get请求
        /// </summary>
        /// <typeparam name="T">Json转自定义类型</typeparam>
        /// <param name="cfgApiNodeName">api子节点的Name</param>
        /// <param name="queryParas">请求参数列表</param>
        /// <returns>返回Json转自定义类型对象</returns>
        public static T HttpGetNameJson<T>(string cfgApiNodeName, NameValueCollection queryParas)
        {
            var url = TencConfig.GetConfigAPI(cfgApiNodeName);
            return HttpGetUrlJson<T>(url, queryParas);
        }


        /// <summary>
        /// 同步方式发起http post请求
        /// </summary>
        /// <param name="cfgApiNodeName">api子节点的Name</param>
        /// <param name="queryParas">请求参数列表</param>
        /// <returns>返回json字符串</returns>
        public static string HttpPostName(string cfgApiNodeName, NameValueCollection queryParas)
        {
            var url = TencConfig.GetConfigAPI(cfgApiNodeName);
            return HttpPostUrl(url, queryParas);
        }

        /// <summary>
        /// 同步方式发起http post请求
        /// </summary>
        /// <typeparam name="T">Json转自定义类型</typeparam>
        /// <param name="cfgApiNodeName">api子节点的Name</param>
        /// <param name="queryParas">请求参数列表</param>
        /// <returns>返回Json转自定义类型对象</returns>
        public static T HttpPostNameJson<T>(string cfgApiNodeName, NameValueCollection queryParas)
        {

            var url = TencConfig.GetConfigAPI(cfgApiNodeName);
            return HttpPostUrlJson<T>(url, queryParas);
        }

        /// <summary>
        /// 同步方式发起http post请求，可以同时上传文件
        /// </summary>
        /// <param name="cfgApiNodeName">api子节点的Name</param>
        /// <param name="queryParas">请求参数列表</param>
        /// <returns>返回json字符串</returns>
        public static string HttpPostNameWithFile(string cfgApiNodeName, NameValueCollection queryParas, NameValueCollection files)
        {

            var url = TencConfig.GetConfigAPI(cfgApiNodeName);
            return HttpPostUrlWithFile(url, queryParas, files);

        }

        /// <summary>
        /// 同步方式发起http post请求，可以同时上传文件
        /// </summary>
        /// <typeparam name="T">Json转自定义类型</typeparam>
        /// <param name="cfgApiNodeName">api子节点的Name</param>
        /// <param name="queryParas">请求参数列表</param>
        /// <returns>返回Json转自定义类型对象</returns>
        public static T HttpPostNameJsonWithFile<T>(string cfgApiNodeName, NameValueCollection queryParas, NameValueCollection files)
        {
            var url = TencConfig.GetConfigAPI(cfgApiNodeName);
            return HttpPostUrlJsonWithFile<T>(url, queryParas, files);
        }


        /// <summary>
        /// 同步方式发起http get请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="queryParas">请求参数列表</param>
        /// <returns>返回json字符串</returns>
        public static string HttpGetUrl(string url, NameValueCollection queryParas)
        {

            return Helpers.HttpHelper.HttpGet(url, queryParas);

        }

        /// <summary>
        /// 同步方式发起http get请求
        /// </summary>
        /// <typeparam name="T">Json转自定义类型</typeparam>
        /// <param name="url">请求地址</param>
        /// <param name="queryParas">请求参数列表</param>
        /// <returns>返回Json转自定义类型对象</returns>
        public static T HttpGetUrlJson<T>(string url, NameValueCollection queryParas)
        {

            var response = Helpers.HttpHelper.HttpGet(url, queryParas);
            return Helpers.UtilHelper.ParseJson<T>(response);

        }
        /// <summary>
        /// 同步方式发起http post请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="queryParas">请求参数列表</param>
        /// <returns>返回json字符串</returns>
        public static string HttpPostUrl(string url, NameValueCollection queryParas)
        {
            return Helpers.HttpHelper.HttpPost(url, queryParas);
        }

        /// <summary>
        /// 同步方式发起http post请求
        /// </summary>
        /// <typeparam name="T">Json转自定义类型</typeparam>
        /// <param name="url">请求地址</param>
        /// <param name="queryParas">请求参数列表</param>
        /// <returns>返回Json转自定义类型对象</returns>
        public static T HttpPostUrlJson<T>(string url, NameValueCollection queryParas)
        {
            var response = Helpers.HttpHelper.HttpPost(url, queryParas);
            return Helpers.UtilHelper.ParseJson<T>(response);
        }

        /// <summary>
        /// 同步方式发起http post请求，可以同时上传文件
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="queryParas">请求参数列表</param>
        /// <returns>返回json字符串</returns>
        public static string HttpPostUrlWithFile(string url, NameValueCollection queryParas, NameValueCollection files)
        {
            return Helpers.HttpHelper.HttpPostWithFile(url, queryParas, files);
        }

        /// <summary>
        /// 同步方式发起http post请求，可以同时上传文件
        /// </summary>
        /// <typeparam name="T">Json转自定义类型</typeparam>
        /// <param name="url">请求地址</param>
        /// <param name="queryParas">请求参数列表</param>
        /// <returns>返回Json转自定义类型对象</returns>
        public static T HttpPostUrlJsonWithFile<T>(string url, NameValueCollection queryParas, NameValueCollection files)
        {
            var response = Helpers.HttpHelper.HttpPostWithFile(url, queryParas, files);
            return Helpers.UtilHelper.ParseJson<T>(response);
        }
    }
}
/*
 * Author: xusion
 * Created: 2012.06.22
 * Support: http://wobumang.com
 */