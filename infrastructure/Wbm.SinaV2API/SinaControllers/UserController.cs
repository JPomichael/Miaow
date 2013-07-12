/*
 This file was create by Xusion at 2011.10.27
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using Wbm.SinaV2API.SinaModels;
using Wbm.SinaV2API.SinaServices;
using Wbm.SinaV2API.Helpers;

namespace Wbm.SinaV2API.SinaControllers
{
    public static class UserController
    {
        /// <summary>
        /// OAuth授权之后，获取授权用户的UID
        /// <para>1. 用户OAuth授权之后获取用户UID，作用相当于旧版接口的（account/verify_credentials）</para>
        /// <para>2. 此接口不计入访问频次中</para>
        /// </summary>
        /// <returns></returns>
        public static long GetUserId()
        {
            try
            {
                oAuthSina oauth = SinaBase.oAuth();
                SinaApiService sina = new SinaApiService();
                Dictionary<string, object> dicUser = HttpUtil.ParseJson<Dictionary<string, object>>(sina.account_get_uid(oauth));
                long user_id = long.TryParse(HttpUtil.GetDicValue(dicUser, "uid"), out user_id) ? user_id : 0;
                return user_id;

            }
            catch (Exception ex)
            {
                ApiLogHelper.Append(ex);
                throw ex;
            }
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        public static SinaMUser GetUser()
        {
            long uid = GetUserId();
            return GetUser(uid);
        }

        /// <summary>
        /// 获取指定用户信息
        /// </summary>
        /// <param name="uid">用户Id</param>
        /// <returns></returns>
        public static SinaMUser GetUser(long uid)
        {
            try
            {
                oAuthSina oauth = SinaBase.oAuth();
                SinaApiService sina = new SinaApiService();
                string json = sina.users_show(oauth, uid);
                return HttpUtil.ParseJson<SinaMUser>(json);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取关注人列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static SinaMUserList GetFriendList(long id)
        {
            try
            {
                oAuthSina oauth = SinaBase.oAuth();
                SinaApiService sina = new SinaApiService();
                string json = sina.friends(oauth, id);
                return HttpUtil.ParseJson<SinaMUserList>(json);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取粉丝列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static SinaMUserList GetFollowerList(long id)
        {
            try
            {
                oAuthSina oauth = SinaBase.oAuth();
                SinaApiService sina = new SinaApiService();
                string json = sina.followers(oauth, id);
                return HttpUtil.ParseJson<SinaMUserList>(json);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 批量获取用户的基本信息
        /// <para>高级接口（需要授权）</para>
        /// </summary>
        /// <param name="uids">需要查询的用户ID</param>
        /// <returns></returns>
        public static SinaMUserList GetUsersShowBatch(string[] ids)
        {
            try
            {
                oAuthSina oauth = SinaBase.oAuth();
                SinaApiService sina = new SinaApiService();
                long uid = GetUserId();
                string json = sina.users_show_batch(oauth, ids);
                return HttpUtil.ParseJson<SinaMUserList>(json);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
