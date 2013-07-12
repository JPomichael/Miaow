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
    public static class FriendshipsController
    {
        /// <summary>
        /// 关注一个用户
        /// </summary>
        /// <param name="uid">需要关注的用户ID</param>
        /// <returns></returns>
        public static bool FriendshipsCreate(long uid)
        {
            try
            {
                oAuthSina oauth = SinaBase.oAuth();
                SinaApiService sina = new SinaApiService();
                string json = sina.friendships_create(oauth);
                var user = HttpUtil.ParseJson<SinaMUser>(json);
                return user != null && user.id > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 取消关注一个用户
        /// </summary>
        /// <param name="uid">需要关注的用户</param>
        /// <returns></returns>
        public static bool FriendshipsDestroy(long uid)
        {
            try
            {
                oAuthSina oauth = SinaBase.oAuth();
                SinaApiService sina = new SinaApiService();
                string json = sina.friendships_destroy(oauth);
                var user = HttpUtil.ParseJson<SinaMUser>(json);
                return user != null && user.id > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
