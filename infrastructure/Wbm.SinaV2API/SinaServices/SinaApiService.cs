/*
 This file was create by Xusion at 2011.10.27
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wbm.SinaV2API.Helpers;

namespace Wbm.SinaV2API.SinaServices
{
    public class SinaApiService
    {
        #region API服务 用户接口
        /// <summary>
        /// 根据用户ID获取用户信息
        /// <para>参数uid与screen_name二者必选其一，且只能选其一</para>
        /// </summary>
        /// <param name="oauth">oAuthSina</param>
        /// <param name="format">xml json</param>
        /// <param name="uid">需要查询的用户ID。</param>
        /// <param name="screen_name">需要查询的用户昵称。</param>
        /// <returns>JSON</returns>
        public string users_show(oAuthSina oauth, long uid = 0, string screen_name = null)
        {
            try
            {
                if (!(uid > 0 || screen_name != null)) { throw new ArgumentException("参数uid与screen_name二者必选其一，且只能选其一", "paras"); }

                List<QueryParameter> paras = oauth.GetOauthParas();
                if (uid > 0) { paras.Add(new QueryParameter("uid", uid)); }
                if (screen_name != null) { paras.Add(new QueryParameter("screen_name", screen_name)); }

                string httpUrl = "https://api.weibo.com/2/users/show.json";

                return ApiErrorHelper.IsSuccess(HttpHelper.HttpGet(httpUrl, paras));
            }
            catch (Exception ex)
            {
                ApiLogHelper.Append(ex);
                throw ex;
            }
        }
        /// <summary>
        /// 获取用户的关注列表
        /// <para>访问级别：普通接口</para>
        /// <para>参数uid与screen_name二者必选其一，且只能选其一</para>
        /// </summary>
        /// <param name="oauth"></param>
        /// <param name="uid">需要查询的用户UID。</param>
        /// <param name="screen_name">需要查询的用户昵称。</param>
        /// <param name="count">单页返回的记录条数，默认为50，最大不超过200。</param>
        /// <param name="cursor">返回结果的游标，下一页用返回值里的next_cursor，上一页用previous_cursor，默认为0。</param>
        /// <returns></returns>
        public string friends(oAuthSina oauth, long uid = 0, string screen_name = null, int count = 50, int cursor = 0)
        {
            try
            {
                if (!(uid > 0 || screen_name != null)) { throw new ArgumentException("参数uid与screen_name二者必选其一，且只能选其一", "paras"); }

                List<QueryParameter> paras = oauth.GetOauthParas();
                if (uid > 0) { paras.Add(new QueryParameter("uid", uid)); }
                if (screen_name != null) { paras.Add(new QueryParameter("screen_name", screen_name)); }
                if (count != 50) { paras.Add(new QueryParameter("count", count)); }
                if (cursor != 0) { paras.Add(new QueryParameter("cursor", cursor)); }

                string httpUrl = "https://api.weibo.com/2/friendships/friends.json";

                return ApiErrorHelper.IsSuccess(HttpHelper.HttpGet(httpUrl, paras));
            }
            catch (Exception ex)
            {
                ApiLogHelper.Append(ex);
                throw ex;
            }
        }

        /// <summary>
        /// 获取用户的粉丝列表
        /// <para>访问级别：普通接口</para>
        /// <para>参数uid与screen_name二者必选其一，且只能选其一</para>
        /// </summary>
        /// <param name="oauth"></param>
        /// <param name="uid">需要查询的用户UID。</param>
        /// <param name="screen_name">需要查询的用户昵称。</param>
        /// <param name="count">单页返回的记录条数，默认为50，最大不超过200。</param>
        /// <param name="cursor">返回结果的游标，下一页用返回值里的next_cursor，上一页用previous_cursor，默认为0。</param>
        /// <returns></returns>
        public string followers(oAuthSina oauth, long uid = 0, string screen_name = null, int count = 50, int cursor = 0)
        {
            try
            {
                if (!(uid > 0 || screen_name != null)) { throw new ArgumentException("参数uid与screen_name二者必选其一，且只能选其一", "paras"); }

                List<QueryParameter> paras = oauth.GetOauthParas();
                if (uid > 0) { paras.Add(new QueryParameter("uid", uid)); }
                if (screen_name != null) { paras.Add(new QueryParameter("screen_name", screen_name)); }
                if (count != 50) { paras.Add(new QueryParameter("count", count)); }
                if (cursor != 0) { paras.Add(new QueryParameter("cursor", cursor)); }

                string httpUrl = "https://api.weibo.com/2/friendships/followers.json";

                return ApiErrorHelper.IsSuccess(HttpHelper.HttpGet(httpUrl, paras));
            }
            catch (Exception ex)
            {
                ApiLogHelper.Append(ex);
                throw ex;
            }
        }

        /// <summary>
        /// 批量获取用户的基本信息
        /// <para>高级接口（需要授权）</para>
        /// </summary>
        /// <param name="oauth"></param>
        /// <param name="uids">需要查询的用户ID，用半角逗号分隔，一次最多20个。</param>
        /// <param name="screen_name">需要查询的用户昵称，用半角逗号分隔，一次最多20个。</param>
        /// <returns></returns>
        public string users_show_batch(oAuthSina oauth, string[] uids = null, string[] screen_name = null)
        {
            try
            {
                if (!(uids != null || screen_name != null)) { throw new ArgumentException("参数uids与screen_name二者必选其一，且只能选其一", "paras"); }

                if ((uids != null && uids.Length > 20) || (screen_name != null && screen_name.Length > 20)) { throw new ArgumentException("参数uid或screen_name一次最多20个", "paras"); }

                List<QueryParameter> paras = oauth.GetOauthParas();
                if (uids != null) { paras.Add(new QueryParameter("uids", string.Join(",", uids))); }
                if (screen_name != null) { paras.Add(new QueryParameter("screen_name", string.Join(",", screen_name))); }

                string httpUrl = "https://api.weibo.com/2/users/show_batch.json";

                return HttpHelper.HttpGet(httpUrl, paras);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region API服务 微博接口
        /// <summary>
        /// 获取某个用户最新发表的微博列表
        /// <para>参数uid与screen_name二者必选其一，且只能选其一</para>
        /// <para>参数uid与screen_name都没有或错误，则默认返回当前登录用户的数据</para>
        /// <para>用户最多只能请求到最近200条微博记录</para>
        /// </summary>
        /// <param name="oauth"></param>
        /// <param name="uid">需要查询的用户ID。</param>
        /// <param name="screen_name">需要查询的用户昵称。</param>
        /// <param name="since_id">若指定此参数，则返回ID比since_id大的微博（即比since_id时间晚的微博），默认为0。</param>
        /// <param name="max_id">若指定此参数，则返回ID小于或等于max_id的微博，默认为0。</param>
        /// <param name="count">单页返回的记录条数，默认为50。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <param name="base_app">是否只获取当前应用的数据。0为否（所有数据），1为是（仅当前应用），默认为0。</param>
        /// <param name="feature">过滤类型ID，0：全部、1：原创、2：图片、3：视频、4：音乐，默认为0。</param>
        /// <param name="trim_user">返回值中user信息开关，0：返回完整的user信息、1：user字段仅返回user_id，默认为0。</param>
        /// <returns></returns>
        public string statuses_user_timeline(oAuthSina oauth, long uid = 0, string screen_name = null, long since_id = 0, long max_id = 0, int count = 50, int page = 1, int base_app = 0, int feature = 0, int trim_user = 0)
        {
            try
            {
                if (uid > 0 && screen_name != null) { throw new ArgumentException("参数uid与screen_name二者必选其一，且只能选其一", "paras"); }

                List<QueryParameter> paras = oauth.GetOauthParas();
                if (uid > 0) { paras.Add(new QueryParameter("uid", uid)); }
                if (screen_name != null) { paras.Add(new QueryParameter("screen_name", screen_name)); }
                if (since_id > 0) { paras.Add(new QueryParameter("since_id", since_id)); }
                if (max_id > 0) { paras.Add(new QueryParameter("max_id", max_id)); }
                if (count > 0) { paras.Add(new QueryParameter("count", count)); }
                if (page > 0) { paras.Add(new QueryParameter("page", page)); }
                if (base_app > 0) { paras.Add(new QueryParameter("base_app", base_app)); }
                if (feature > 0) { paras.Add(new QueryParameter("feature", feature)); }
                if (trim_user > 0) { paras.Add(new QueryParameter("trim_user", trim_user)); }

                string httpUrl = "https://api.weibo.com/2/statuses/user_timeline.json";

                return ApiErrorHelper.IsSuccess(HttpHelper.HttpGet(httpUrl, paras));
            }
            catch (Exception ex)
            {
                ApiLogHelper.Append(ex);
                throw ex;
            }
        }

        /// <summary>
        /// 根据微博ID获取单条微博内容
        /// </summary>
        /// <param name="oauth"></param>
        /// <param name="id">需要获取的微博ID。</param>
        /// <returns></returns>
        public string statuses_show(oAuthSina oauth, long id)
        {
            try
            {
                if (id <= 0) { throw new ArgumentException("参数id必选", "paras"); }

                List<QueryParameter> paras = oauth.GetOauthParas();
                paras.Add(new QueryParameter("id", id));

                string httpUrl = "https://api.weibo.com/2/statuses/show.json";

                return ApiErrorHelper.IsSuccess(HttpHelper.HttpGet(httpUrl, paras));
            }
            catch (Exception ex)
            {
                ApiLogHelper.Append(ex);
                throw ex;
            }
        }


        /// <summary>
        /// 发布一条新微博
        /// <para>连续两次发布的微博不可以重复</para>
        /// </summary>
        /// <param name="oauth"></param>
        /// <param name="status">要发布的微博文本内容，必须做URLencode，内容不超过140个汉字。</param>
        /// <param name="lat">纬度，有效范围：-90.0到+90.0，+表示北纬，默认为0.0。</param>
        /// <param name="lng">经度，有效范围：-180.0到+180.0，+表示东经，默认为0.0。</param>
        /// <param name="annotations">元数据，主要是为了方便第三方应用记录一些适合于自己使用的信息，每条微博可以包含一个或者多个元数据，必须以json字串的形式提交，字串长度不超过512个字符，具体内容可以自定。</param>
        /// <returns></returns>
        public string statuses_update(oAuthSina oauth, string status, float lat = 0.0f, float lng = 0.0f, string annotations = null)
        {
            try
            {
                if (string.IsNullOrEmpty(status)) { throw new ArgumentException("参数status必选", "paras"); }

                List<QueryParameter> paras = oauth.GetOauthParas();
                paras.Add(new QueryParameter("status", status));
                if (lat != 0.0f) { paras.Add(new QueryParameter("lat", lat)); }
                if (lng != 0.0f) { paras.Add(new QueryParameter("long", lng)); }
                if (!string.IsNullOrEmpty(annotations)) { paras.Add(new QueryParameter("annotations", annotations)); }

                string httpUrl = "https://api.weibo.com/2/statuses/update.json";

                return ApiErrorHelper.IsSuccess(HttpHelper.HttpPost(httpUrl, paras));
            }
            catch (Exception ex)
            {
                ApiLogHelper.Append(ex);
                throw ex;
            }
        }

        /// <summary>
        /// 上传图片并发布一条新微博
        /// </summary>
        /// <param name="oauth"></param>
        /// <param name="status">要发布的微博文本内容，必须做URLencode，内容不超过140个汉字。</param>
        /// <param name="picFileName">要上传的图片，仅支持JPEG、GIF、PNG格式，图片大小小于5M。</param>
        /// <param name="lat">纬度，有效范围：-90.0到+90.0，+表示北纬，默认为0.0。</param>
        /// <param name="lng">经度，有效范围：-180.0到+180.0，+表示东经，默认为0.0。</param>
        /// <returns></returns>
        public string statuses_upload(oAuthSina oauth, string status, string picFileName, float lat = 0.0f, float lng = 0.0f)
        {
            try
            {
                if (string.IsNullOrEmpty(status)) { throw new ArgumentException("参数status必选", "paras"); }
                if (string.IsNullOrEmpty(picFileName)) { throw new ArgumentException("参数pic必选", "paras"); }

                List<QueryParameter> paras = oauth.GetOauthParas();
                paras.Add(new QueryParameter("status", status));
                if (lat != 0.0f) { paras.Add(new QueryParameter("lat", lat)); }
                if (lng != 0.0f) { paras.Add(new QueryParameter("long", lng)); }

                List<QueryParameter> files = new List<QueryParameter>();
                files.Add(new QueryParameter("pic", picFileName));

                string httpUrl = "https://api.weibo.com/2/statuses/upload.json";

                return ApiErrorHelper.IsSuccess(HttpHelper.HttpPostWithFile(httpUrl, paras, files));
            }
            catch (Exception ex)
            {
                ApiLogHelper.Append(ex);
                throw ex;
            }
        }
        #endregion

        #region API服务 关系接口
        /// <summary>
        /// 关注一个用户
        /// </summary>
        /// <param name="oauth"></param>
        /// <param name="uid">需要关注的用户ID。</param>
        /// <param name="screen_name">需要关注的用户昵称。</param>
        /// <returns></returns>
        public string friendships_create(oAuthSina oauth, long uid = 0, string screen_name = null)
        {
            try
            {
                if (!(uid > 0 || screen_name != null)) { throw new ArgumentException("参数uid与screen_name二者必选其一，且只能选其一", "paras"); }

                List<QueryParameter> paras = oauth.GetOauthParas();
                if (uid > 0) { paras.Add(new QueryParameter("uid", uid)); }

                string httpUrl = "https://api.weibo.com/2/friendships/create.json";

                return ApiErrorHelper.IsSuccess(HttpHelper.HttpGet(httpUrl, paras));
            }
            catch (Exception ex)
            {
                ApiLogHelper.Append(ex);
                throw ex;
            }
        }

        /// <summary>
        /// 取消关注一个用户
        /// </summary>
        /// <param name="oauth"></param>
        /// <param name="uid">需要关注的用户ID。</param>
        /// <param name="screen_name">需要关注的用户昵称。</param>
        /// <returns></returns>
        public string friendships_destroy(oAuthSina oauth, long uid = 0, string screen_name = null)
        {
            try
            {
                if (!(uid > 0 || screen_name != null)) { throw new ArgumentException("参数uid与screen_name二者必选其一，且只能选其一", "paras"); }

                List<QueryParameter> paras = oauth.GetOauthParas();
                if (uid > 0) { paras.Add(new QueryParameter("uid", uid)); }

                string httpUrl = "https://api.weibo.com/2/friendships/destroy.json";

                return ApiErrorHelper.IsSuccess(HttpHelper.HttpGet(httpUrl, paras));
            }
            catch (Exception ex)
            {
                ApiLogHelper.Append(ex);
                throw ex;
            }
        }

        #endregion

        #region API服务 账号接口
        /// <summary>
        /// 获取用户基本信息
        /// <para>高级接口（需要授权）</para>
        /// </summary>
        /// <param name="oauth"></param>
        /// <param name="uid">需要获取基本信息的用户UID，默认为当前登录用户。</param>
        /// <returns></returns>
        public string account_profile_basic(oAuthSina oauth, long uid = 0)
        {
            try
            {
                List<QueryParameter> paras = oauth.GetOauthParas();
                if (uid > 0) { paras.Add(new QueryParameter("uid", uid)); }

                string httpUrl = "https://api.weibo.com/2/account/profile/basic.json";

                return ApiErrorHelper.IsSuccess(HttpHelper.HttpGet(httpUrl, paras));
            }
            catch (Exception ex)
            {
                ApiLogHelper.Append(ex);
                throw ex;
            }
        }

        /// <summary>
        /// OAuth授权之后，获取授权用户的UID
        /// <para>1. 用户OAuth授权之后获取用户UID，作用相当于旧版接口的（account/verify_credentials）</para>
        /// <para>2. 此接口不计入访问频次中</para>
        /// </summary>
        /// <param name="oauth"></param>
        /// <returns></returns>
        public string account_get_uid(oAuthSina oauth)
        {
            try
            {
                List<QueryParameter> paras = oauth.GetOauthParas();

                string httpUrl = "https://api.weibo.com/2/account/get_uid.json";

                return ApiErrorHelper.IsSuccess(HttpHelper.HttpGet(httpUrl, paras));
            }
            catch (Exception ex)
            {
                ApiLogHelper.Append(ex);
                throw ex;
            }
        }
        #endregion


    }
}
