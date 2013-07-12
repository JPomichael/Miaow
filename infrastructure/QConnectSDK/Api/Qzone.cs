using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using QConnectSDK.Context;
using QConnectSDK.Config;
using QConnectSDK.Models;
using QConnectSDK.Exceptions;
using QConnectSDK.Authenticators;
using RestSharp.Deserializers;
using System.Net;
using RestSharp;

namespace QConnectSDK.Api
{
    public partial class RestApi
    {
        /// <summary>
        /// 通过Authorization Code获取Access Token
        /// </summary>
        /// <param name="oAuthVericode"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public OAuthToken GetAccessToken(string oAuthVericode, string state)
        {
            var request = _requestHelper.CreateTokenRequest(context.Config, oAuthVericode, state);
            var response = Execute(request);
            var accessToken = GetUserAccessToken(response.Content);
            var openid = GetOpenId(accessToken.AccessToken);
            accessToken.OpenId = openid;
            return accessToken;
        }

        private string GetOpenId(string accessToken)
        {
            var request = _requestHelper.CreateOpenIDRequest(accessToken);
            var response = Execute(request);
            var openid = GetUserOpenId(response.Content);
            return openid;
        }

        private string GetUserOpenId(string content)
        {
            string strJson = content.Replace("callback(", "").Replace(");", "");
            var payload = Deserialize<Callback>(strJson);
            return payload.openid;
        }

        private OAuthToken GetUserAccessToken(string urlParams)
        {
            OAuthToken token = new OAuthToken(); 
            var parameters = urlParams.Split('&');
            foreach (var parameter in parameters)
            {
                var accessTokens = parameter.Split('=');
                if (accessTokens[0] == "access_token")
                {
                    token.AccessToken = accessTokens[1];
                     
                }
                if (accessTokens[0] == "expires_in")
                {
                    token.ExpiresAt = Convert.ToInt32(accessTokens[1]);
                    
                }
            }
            return token;
        }

        /// <summary>
        /// 获取当前的登陆用户信息
        /// </summary>
        /// <returns>当前登陆用户信息</returns>
        public User GetCurrentUser()
        {
            _restClient.Authenticator = new OAuthUriQueryParameterAuthenticator(context.AccessToken.OpenId, context.AccessToken.AccessToken, context.Config.GetAppKey());
            var request = _requestHelper.CreateAccountInfoRequest();
            var response = Execute(request);
            string content = response.Content;
            var payload = Deserialize<User>(content);
            return payload;
        }

        /// <summary>
        /// 第三方网站可以调用本分享接口，在用户授权的情况下，可以以用户的名义发布一条动态（feeds）到QQ空间和朋友网上，
        /// 此外还可在腾讯微博上发一条微博（用户可自己选择是否转发到微博）。
        /// 1. 网站主动推送。当用户在网站上进行操作（例如上传视频，图片，发表评论等）后，以该用户的名义发布一条feeds到QQ空间中。 
        /// 2. 用户主动分享。用户在网站上点击“分享”按钮，发布一条feeds到QQ空间中，分享某个视频，网页或者其它内容。 例如：某用户在某个第三方网站上对某条新闻发表了评论，网站将以该用户的名义发表一条动态到QQ空间中，动态的具体展示如下： 
        /// 上图中的1-6标注对feeds的组成以及规格进行了说明： 
        /// 1. 用户评论：用户在第三方网站发布的评论等UGC信息，选填项。
        /// 2. 分享的内容标题，含源网页URL，点击跳转至第三方网站网页，必填项。
        /// 3. 详细描述：网页摘要，选填项。
        /// 4. 外部图片：引用外部图片（大小不超过100 x 100 px），选填项。
        /// 5. 分享的场景：支持以下场景 1.通过网页 2.通过手机 3.通过软件 4.通过IPHONE 5.通过IPAD，选填项。
        /// 6：来源网站名称及域名：标明分享的来源，必填项。
        /// </summary>
        /// <param name="title">feeds的标题，对应上文接口说明中的2。最长36个中文字，超出部分会被截断。</param>
        /// <param name="url">分享所在网页资源的链接，点击后跳转至第三方网页，对应上文接口说明中2的超链接。请以http://开头。 </param>
        /// <param name="comment">用户评论内容，也叫发表分享时的分享理由，对应上文接口说明的1。禁止使用系统生产的语句进行代替。最长40个中文字，超出部分会被截断。</param>
        /// <param name="summary">所分享的网页资源的摘要内容，或者是网页的概要描述，对应上文接口说明的3。最长80个中文字，超出部分会被截断。</param>
        /// <param name="images">所分享的网页资源的代表性图片链接"，对应上文接口说明的4。
        /// 请以http://开头，长度限制255字符。多张图片以竖线（|）分隔，目前只有第一张图片有效，图片规格100*100为佳。</param>
        /// <param name="source">分享的场景，对应上文接口说明的6。取值说明：1.通过网页 2.通过手机 3.通过软件 4.通过IPHONE 5.通过 IPAD。 </param>
        /// <param name="type">分享内容的类型。4表示网页；5表示视频（type=5时，必须传入playurl）。 </param>
        /// <param name="playurl">长度限制为256字节。仅在type=5的时候有效。</param>
        /// <param name="nswb">值为1时，表示分享不默认同步到微博，其他值或者不传此参数表示默认同步到微博</param>
        /// <returns>是否成功</returns>
        public QzoneBase AddFeeds(string title, string url, string comment = "", string summary = "", string images = "", string source = "", string type = "", string playurl = "", string nswb = "")
        {
            _restClient.Authenticator = new OAuthUriQueryParameterAuthenticator(context.AccessToken.OpenId, context.AccessToken.AccessToken, context.Config.GetAppKey());
            var request = _requestHelper.CreateAddFeedsRequest(title, url,comment,summary,images,source,type,playurl,nswb);
            var response = Execute(request);
            var payload = Deserialize<QzoneBase>(response.Content);
            return payload;
        }

        /// <summary>
        /// 验证登录的用户是否为某个认证空间的粉丝
        /// </summary>
        /// <param name="qq">认证空间的qq号</param>
        /// <returns></returns>
        public CheckPageResult CheckPagefans(string qq)
        {
            _restClient.Authenticator = new OAuthUriQueryParameterAuthenticator(context.AccessToken.OpenId, context.AccessToken.AccessToken, context.Config.GetAppKey());
            var request = _requestHelper.CreateCheckPagefansRequest(qq);

            var response = Execute(request);
            string content = response.Content;
            var payload = Deserialize<CheckPageResult>(content);
            return payload;
        }

        /// <summary>
        /// 获取登录用户的相册列表。
        /// </summary>
        /// <returns></returns>
        public UserAlbums GetCurrentUserListAlbum()
        {
            _restClient.Authenticator = new OAuthUriQueryParameterAuthenticator(context.AccessToken.OpenId, context.AccessToken.AccessToken, context.Config.GetAppKey());
            var request = _requestHelper.CreateGetUserListAlbumRequest();

            var response = Execute(request);
            string content = response.Content;
            var payload = Deserialize<UserAlbums>(content);
            return payload;
        }

        /// <summary>
        /// 登录用户创建相册
        /// </summary>
        /// <param name="albumname">相册名，不能超过30个字符。</param>
        /// <param name="albumdesc">相册描述，不能超过200个字符。</param>
        /// <param name="priv">相册权限，其取值含义为： 1=公开；3=只主人可见； 4=QQ好友可见； 5=问答加密。
        /// 不传则相册默认为公开权限。
        /// 如果priv取值为5，即相册是问答加密的，则必须包含问题和答案两个参数：
        /// -question: 问题，不能超过30个字符。
        /// -answer: 答案，不能超过30个字符。</param>
        /// <param name="question">问题，不能超过30个字符</param>
        /// <param name="answer">答案，不能超过30个字符。</param>
        /// <returns></returns>
        public Album AddAlbum(string albumname, string albumdesc = "", int priv = 1, string question = "", string answer = "")
        {
            _restClient.Authenticator = new OAuthUriQueryParameterAuthenticator(context.AccessToken.OpenId, context.AccessToken.AccessToken, context.Config.GetAppKey());
            var request = _requestHelper.CreateAddAlbumRequest(albumname, albumdesc, priv, question, answer);

            var response = Execute(request);
            string content = response.Content;
            var payload = Deserialize<Album>(content);
            return payload;
        }

        /// <summary>
        /// 登录用户上传照片。
        /// </summary>
        /// <param name="photodesc">照片描述，注意照片描述不能超过200个字符。</param>
        /// <param name="title">照片的命名，必须以.jpg, .gif, .png, .jpeg, .bmp此类后缀结尾。</param>
        /// <param name="albumid">相册id，不填则传到默认相册</param>
        /// <param name="x">照片拍摄时的地理位置的经度。请使用原始数据（纯经纬度，0-360）。</param>
        /// <param name="y">照片拍摄时的地理位置的纬度。请使用原始数据（纯经纬度，0-360）。</param>
        /// <param name="picture">上传照片的文件名</param>
        /// <param name="pictureData">上传照片的内容</param>
        /// <returns></returns>
        public Picture UploadPic(string photodesc, string title, string albumid, int? x, int? y, string picture, byte[] pictureData)
        {
            _restClient.Authenticator = new OAuthUriQueryParameterAuthenticator(context.AccessToken.OpenId, context.AccessToken.AccessToken, context.Config.GetAppKey());
            var request = _requestHelper.CreateUploadPicRequest(photodesc, title, albumid, x, y, picture, pictureData);
            var response = Execute(request);
            string content = response.Content;
            var payload = Deserialize<Picture>(content);
            return payload;
        }

        /// <summary>
        /// 登录用户发表一篇新日志
        /// </summary>
        /// <param name="title">日志标题（纯文本，最大长度128个字节，utf-8编码）</param>
        /// <param name="content">文章内容（html数据，最大长度100*1024个字节，utf-8编码）.</param>
        /// <returns></returns>
        public AddBlogResult AddBlog(string title, string content)
        {
            _restClient.Authenticator = new OAuthUriQueryParameterAuthenticator(context.AccessToken.OpenId, context.AccessToken.AccessToken, context.Config.GetAppKey());
            var request = _requestHelper.CreateAddBlogRequest(title, content);
            var response = Execute(request);
            string strContent = response.Content;
            var payload = Deserialize<AddBlogResult>(strContent);
            return payload;            
        }

        /// <summary>
        /// 登录用户发布心情，发布以后，将在QQ空间的说说下添加一条动态，以分享给好友。
        /// 用户发布心情时，可以是纯文本，也可以带超链接，视频，或者图片的富文本。
        /// 本接口支持LBS信息，即用户动态中可以包含位置信息，例如经纬度，地点名称及描述。 
        /// </summary>
        /// <param name="richtype">
        /// 发布心情时引用的信息的类型。
        /// 1表示图片； 2表示网页； 3表示视频。
        /// </param>
        /// <param name="richval">发布心情时引用的信息的值。有richtype时必须有richval 
        /// （1）当richtype为图片（即richtype为1，应用场景为针对QQ空间相册中的某张图片发表评论）时，richval需包含下列参数的值，每个值中间用逗号分隔，如下所示 ：
        /// “albumid,pictureid,sloc,pictype,picheight,picwidth”。
        /// 这些值都需要通过调用相册OpenAPI来获得。参数意义如下：
        /// 参数名称  是否必须  类型  描述  
        /// albumid  必须  string  图片所属空间相册的ID
        /// pictureid  必须  string  图片ID  
        /// sloc  必须  string  小图ID
        /// pictype   string  图片类型（JPG = 1；GIF = 2；PNG = 3）
        /// picheight   string  图片高度，单位： px  
        /// picwidth   string  图片宽度，单位： px
        /// （2）当richtype为网页（即richtype为2，应用场景为针对某网页发表评论）时，richval需要传入该网页的URL，发表为feeds时，后台会自动将该URL转换为短URL。
        /// （3）当richtype为视频（即richtype为3，应用场景为针对某视频发表评论）时，richval需要传入该视频的URL，发表为feeds时，后台会对该URL进行解析，在feeds上显示播放器，视频源及缩略图。
        /// </param>
        /// <param name="con">发布的心情的内容。</param>
        /// <param name="lbs_nm">地址文。例如：广东省深圳市南山区高新科技园腾讯大厦。lbs_nm，lbs_x，lbs_y通常一起使用，来明确标识一个地址。 </param>
        /// <param name="lbs_x">经度。请使用原始数据（纯经纬度，0-360）。</param>
        /// <param name="lbs_y">纬度。请使用原始数据（纯经纬度，0-360）。</param>
        /// <param name="third_source">第三方应用的平台类型。1表示QQ空间； 2表示腾讯朋友； 3表示腾讯微博平台； 4表示腾讯Q+平台。 </param>
        /// <returns></returns>
        public QzoneBase AddTopic(string richtype, string richval, string con, string lbs_nm, string lbs_x, string lbs_y, string third_source)
        {
            _restClient.Authenticator = new OAuthUriQueryParameterAuthenticator(context.AccessToken.OpenId, context.AccessToken.AccessToken, context.Config.GetAppKey());
            var request = _requestHelper.CreateAddTopicRequest(richtype, richval, con, lbs_nm, lbs_x, lbs_y, third_source);
            var response = Execute(request);
            string strContent = response.Content;
            var payload = Deserialize<QzoneBase>(strContent);
            return payload;            
        }
    }
}
