/*
 This file was create by Xusion at 2011.10.27
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Wbm.SinaV2API.SinaServices;
using Wbm.SinaV2API.SinaModels;
using Wbm.SinaV2API.Helpers;

namespace Wbm.SinaV2API.SinaControllers
{
    /// <summary>
    /// 微博控制器
    /// </summary>
    public static class StatusController
    {
        /// <summary>
        /// 返回用户最新发表的微博消息列表
        /// </summary>
        /// <returns></returns>
        public static SinaMStatusList UserTimeLine()
        {
            try
            {
                oAuthSina oauth = SinaBase.oAuth();
                SinaApiService sina = new SinaApiService();
                string json = sina.statuses_user_timeline(oauth);
                return HttpUtil.ParseJson<SinaMStatusList>(json);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 根据微博ID获取单条微博内容
        /// </summary>
        /// <param name="id">需要获取的微博ID。</param>
        /// <returns></returns>
        public static SinaMStatus Show(long id)
        {
            try
            {
                oAuthSina oauth = SinaBase.oAuth();
                SinaApiService sina = new SinaApiService();
                string json = sina.statuses_show(oauth, id);
                return HttpUtil.ParseJson<SinaMStatus>(json);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 发送微博信息
        /// </summary>
        /// <param name="strStatus">信息内容</param>
        public static bool Update(string strStatus)
        {
            try
            {
                oAuthSina oauth = SinaBase.oAuth();
                SinaApiService sina = new SinaApiService();
                string json = sina.statuses_update(oauth, strStatus);
                var status = HttpUtil.ParseJson<SinaMStatus>(json);
                return status != null && status.id > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 发送微博信息(带图片)
        /// </summary>
        /// <param name="strSatus">信息内容</param>
        /// <param name="filePath">图片实际地址</param>
        public static bool Update(string strStatus, string filePath)
        {
            try
            {
                oAuthSina oauth = SinaBase.oAuth();
                SinaApiService sina = new SinaApiService();
                string json = sina.statuses_upload(oauth, strStatus, filePath);
                var status = HttpUtil.ParseJson<SinaMStatus>(json);
                return status != null && status.id > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
