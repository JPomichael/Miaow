using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using QConnectSDK.Authenticators;
using QConnectSDK.Models;

namespace QConnectSDK.Api
{
    public partial class RestApi
    {
        /// <summary>
        /// 发表一条微博信息（纯文本）到腾讯微博平台上
        /// </summary>
        /// <param name="content">表示要发表的微博内容。必须为UTF-8编码，最长为140个汉字，也就是420字节。
        /// 如果微博内容中有URL，后台会自动将该URL转换为短URL，每个URL折算成11个字节。</param>
        /// <param name="clientip">用户ip，以分析用户所在地</param>
        /// <param name="jing">用户所在地理位置的经度。为实数，最多支持10位有效数字。有效范围：-180.0到+180.0，+表示东经，默认为0.0</param>
        /// <param name="wei">用户所在地理位置的纬度。为实数，最多支持10位有效数字。有效范围：-90.0到+90.0，+表示北纬，默认为0.0。</param>
        /// <param name="syncflag">标识是否将发布的微博同步到QQ空间（0：同步； 1：不同步；），默认为0.</param>
        /// <returns></returns>
        public AddWeiboResult AddWeibo(string content, string clientip = "", string jing = "", string wei = "", int syncflag = 0)
        {
            _restClient.Authenticator = new OAuthUriQueryParameterAuthenticator(context.AccessToken.OpenId, context.AccessToken.AccessToken, context.Config.GetAppKey());
            var request = _requestHelper.CreateAddWeiboRequest(content, clientip,jing,wei,syncflag);

            var response = Execute(request);            
            var payload = Deserialize<AddWeiboResult>(response.Content);
            return payload;
        }

        
        /// <summary>
        /// 上传一张图片，并发布一条消息到腾讯微博平台上
        /// </summary>
        /// <param name="content">表示要发表的微博内容。必须为UTF-8编码，最长为140个汉字，也就是420字节。
        /// 如果微博内容中有URL，后台会自动将该URL转换为短URL，每个URL折算成11个字节。</param>
        /// <param name="picBytes">要上传的图片的文件名以及图片的内容（在发送请求时，图片内容以二进制数据流的形式发送。
        /// 图片仅支持JPEG、GIF、PNG格式（所有图片都会重新压缩，gif被重新压缩后不会再有有动画效果），图片size小于2M。</param>
        /// <param name="clientip">用户ip，以分析用户所在地</param>
        /// <param name="jing">用户所在地理位置的经度。为实数，最多支持10位有效数字。有效范围：-180.0到+180.0，+表示东经，默认为0.0</param>
        /// <param name="wei">用户所在地理位置的纬度。为实数，最多支持10位有效数字。有效范围：-90.0到+90.0，+表示北纬，默认为0.0。</param>
        /// <param name="syncflag">标识是否将发布的微博同步到QQ空间（0：同步； 1：不同步；），默认为0.</param>
        /// <returns></returns>
        public AddWeiboResult AddWeiboPicture(string content, string fileName, byte[] picBytes, string clientip = "", string jing = "", string wei = "", int syncflag = 0)
        {
            _restClient.Authenticator = new OAuthUriQueryParameterAuthenticator(context.AccessToken.OpenId, context.AccessToken.AccessToken, context.Config.GetAppKey());
            var request = _requestHelper.CreateAddPictureWeiboRequest(content, clientip, jing, wei, syncflag, fileName, picBytes);

            var response = Execute(request);
            var payload = Deserialize<AddWeiboResult>(response.Content);
            return payload;
        }

        /// <summary>
        /// 根据微博ID删除指定微博。
        /// </summary>
        /// <param name="id">微博ID</param>
        /// <returns></returns>
        public DelWeiboResult DelWeibo(Int64 id)
        {
            _restClient.Authenticator = new OAuthUriQueryParameterAuthenticator(context.AccessToken.OpenId, context.AccessToken.AccessToken, context.Config.GetAppKey());
            var request = _requestHelper.CreateDelWeiboRequest(id);

            var response = Execute(request);
            var payload = Deserialize<DelWeiboResult>(response.Content);
            return payload;
        }

        /// <summary>
        /// 获取一条微博的转播或评论信息列表。
        /// </summary>
        /// <param name="flag">标识获取的是转播列表还是点评列表。
        /// 0：获取转播列表；
        /// 1：获取点评列表；
        /// 2：转播列表和点评列表都获取。
        /// </param>
        /// <param name="rootid">转发或点评的源微博的ID.</param>
        /// <param name="pageflag">分页标识。
        /// 0：第一页；
        /// 1：向下翻页；
        /// 2：向上翻页。 
        /// </param>
        /// <param name="pagetime">本页起始时间。
        /// 第一页：0；
        /// 向下翻页：上一次请求返回的最后一条记录时间；
        /// 向上翻页：上一次请求返回的第一条记录的时间。 
        /// </param>
        /// <param name="reqnum">每次请求记录的条数。取值为1-100条。</param>
        /// <param name="twitterid">翻页时使用。
        /// 第1-100条：0；
        /// 继续向下翻页：上一次请求返回的最后一条记录id。
        /// </param>
        public WeiboRePost GetRepostlist(string flag, string rootid, string pageflag, string pagetime, string reqnum, string twitterid)
        {
            _restClient.Authenticator = new OAuthUriQueryParameterAuthenticator(context.AccessToken.OpenId, context.AccessToken.AccessToken, context.Config.GetAppKey());
            var request = _requestHelper.CreateGetRepostlistRequest(flag,rootid,pageflag,pagetime,reqnum,twitterid);

            var response = Execute(request);
            var payload = Deserialize<WeiboRePost>(response.Content);
            return payload;
        }

        /// <summary>
        /// 获取腾讯微博登录用户的用户资料。
        /// </summary>
        /// <returns></returns>
        public WeiboUser GetWeiboUserInfo()
        {
            _restClient.Authenticator = new OAuthUriQueryParameterAuthenticator(context.AccessToken.OpenId, context.AccessToken.AccessToken, context.Config.GetAppKey());
            var request = _requestHelper.CreateWeiboAccountInfoRequest();

            var response = Execute(request);
            string content = response.Content;
            var payload = Deserialize<WeiboUser>(content);
            return payload;
        }

        /// <summary>
        /// 获取腾讯微博其他用户详细信息。
        /// name和fopenids至少选一个，若同时存在则以name值为主。
        /// </summary>
        /// <param name="name">其他用户的账户名</param>
        /// <param name="openId">其他用户的openid</param>
        /// <returns></returns>
        public WeiboUser GetOtherWeiboUserInfo(string name,string openId)
        {
            _restClient.Authenticator = new OAuthUriQueryParameterAuthenticator(context.AccessToken.OpenId, context.AccessToken.AccessToken, context.Config.GetAppKey());
            var request = _requestHelper.CreateWeiboOtherAccountInfoRequest(name,openId);

            var response = Execute(request);
            string content = response.Content;
            var payload = Deserialize<WeiboUser>(content);
            return payload;
        }

        /// <summary>
        /// 获取登录用户的听众列表
        /// </summary>
        /// <param name="reqnum">求获取的听众个数。取值范围为1-30。</param>
        /// <param name="startindex">请求获取听众列表的起始位置。第一页：0；继续向下翻页：reqnum*（page-1）</param>
        public WeiboFan GetFansList(int reqnum, int startindex)
        {
            _restClient.Authenticator = new OAuthUriQueryParameterAuthenticator(context.AccessToken.OpenId, context.AccessToken.AccessToken, context.Config.GetAppKey());
            var request = _requestHelper.CreateGetFansListRequest(reqnum, startindex);

            var response = Execute(request);
            string content = response.Content;
            var payload = Deserialize<WeiboFan>(content);
            return payload;
        }

        /// <summary>
        /// 获取登录用户收听的人的列表。
        /// </summary>
        /// <param name="reqnum">求获取的收听个数。取值范围为1-30。</param>
        /// <param name="startindex">请求获取收听列表的起始位置。第一页：0；继续向下翻页：reqnum*（page-1）</param>
        public WeiboIdol GetIdolList(int reqnum, int startindex)
        {
            _restClient.Authenticator = new OAuthUriQueryParameterAuthenticator(context.AccessToken.OpenId, context.AccessToken.AccessToken, context.Config.GetAppKey());
            var request = _requestHelper.CreateGetIdolListRequest(reqnum, startindex);

            var response = Execute(request);
            string content = response.Content;
            var payload = Deserialize<WeiboIdol>(content);
            return payload;
        }

        /// <summary>
        /// 收听腾讯微博上的用户。
        /// name和fopenids至少选一个，若同时存在则以name值为主
        /// </summary>
        /// <param name="name">要收听的用户的账户名列表。多个账户名之间用“,”隔开，例如：abc,bcde,cde。 </param>
        /// <param name="fopenids">要收听的用户的openid列表。多个openid之间用“_”隔开，例如：B624064BA065E01CB73F835017FE96FA_B624064BA065E01CB73F835017FE96FB。</param>
        /// <returns></returns>
        public MicroBlogBase AddIdol(string name, string fopenids)
        {
            _restClient.Authenticator = new OAuthUriQueryParameterAuthenticator(context.AccessToken.OpenId, context.AccessToken.AccessToken, context.Config.GetAppKey());
            var request = _requestHelper.CreateAddIdolRequest(name, fopenids);

            var response = Execute(request);
            string content = response.Content;
            var payload = Deserialize<MicroBlogBase>(content);
            return payload;

        }

        /// <summary>
        /// 取消收听腾讯微博上的用户。        
        /// </summary>
        /// <param name="name">要取消收听的用户的账户名  </param>
        /// <param name="fopenid ">要取消收的用户的openid列表。 </param>
        /// <returns></returns>
        public MicroBlogBase DelIdol(string name, string fopenid)
        {
            _restClient.Authenticator = new OAuthUriQueryParameterAuthenticator(context.AccessToken.OpenId, context.AccessToken.AccessToken, context.Config.GetAppKey());
            var request = _requestHelper.CreateDelIdolRequest(name, fopenid);

            var response = Execute(request);
            string content = response.Content;
            var payload = Deserialize<MicroBlogBase>(content);
            return payload;

        }

    }
}
