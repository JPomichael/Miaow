using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QConnectSDK.Api;
using QConnectSDK.Context;
using QConnectSDK.Models;

namespace QConnectSDK
{
    /// <summary>
    /// QQ登录 API 入口
    /// </summary>
    [Serializable]
    public class QOpenClient
    {
        RestApi restApi;
        /// <summary>
        /// 构造函数，用于用户接受授权后使用Authorization Code获取AccessToken
        /// </summary>
        /// <param name="verifierCode">Authorization Code（注意此code会在10分钟内过期）。</param>
        /// <param name="state">client端的状态值。用于第三方应用防止CSRF攻击，成功授权后回调时会原样带回</param>
        public QOpenClient(string verifierCode,string state)
        {
            var context = new QzoneContext(verifierCode);
            if (!string.IsNullOrEmpty(verifierCode))
            {
                this.OAuthToken = context.GetAccessToken(state); 
            }
            restApi = new RestApi(context);
        }

        /// <summary>
        /// 构造函数，用于用户已经完成授权后，将OAuthToken持久化保存后，使用这个函数从持久化介质中获取到的
        /// OAuthToken，进行后续的API调用。
        /// </summary>
        /// <param name="oAuthToken"></param>
        public QOpenClient(OAuthToken oAuthToken)
        {
            this._oAuthToken = oAuthToken;
            var context = new QzoneContext(oAuthToken);
            restApi = new RestApi(context);
        }

        private OAuthToken _oAuthToken ;

        /// <summary>
        /// 访问QQ互联的SDK的AccessToken
        /// </summary>
        public OAuthToken OAuthToken 
        {
            get { return _oAuthToken; }
            set { _oAuthToken = value; }
        }

        /// <summary>
        /// 获取用户在QQ空间的个人资料
        /// </summary>
        /// <returns></returns>
        public User GetCurrentUser()
        {
            return restApi.GetCurrentUser();
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
            return restApi.AddFeeds(title, url,comment,summary,images,source,type,playurl,nswb);
        }

        /// <summary>
        /// 验证登录的用户是否为某个认证空间的粉丝
        /// </summary>
        /// <param name="qq">认证空间的QQ号</param>
        /// <returns></returns>
        public CheckPageResult CheckPagefans(string qq)
        {
            return restApi.CheckPagefans(qq);
        }

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
            return restApi.AddWeibo(content, clientip, jing, wei, syncflag);
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
            return restApi.AddWeiboPicture(content, fileName, picBytes, clientip, jing, wei, syncflag);
        }

        /// <summary>
        /// 根据微博ID删除指定微博。
        /// </summary>
        /// <param name="id">微博ID</param>
        /// <returns></returns>
        public DelWeiboResult DelWeibo(Int64 id)
        {
            return restApi.DelWeibo(id);
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
            return restApi.GetRepostlist(flag, rootid, pageflag, pagetime, reqnum, twitterid);
        }

        /// <summary>
        /// 获取腾讯微博登录用户的用户资料。
        /// </summary>
        /// <returns></returns>
        public  WeiboUser GetWeiboUserInfo()
        {
            return restApi.GetWeiboUserInfo();
        }

        /// <summary>
        /// 获取腾讯微博其他用户详细信息。
        /// name和fopenids至少选一个，若同时存在则以name值为主。
        /// </summary>
        /// <param name="name">其他用户的账户名</param>
        /// <param name="openId">其他用户的openid</param>
        /// <returns></returns>
        public WeiboUser GetWeiboUserInfo(string name, string openId)
        {
            return restApi.GetOtherWeiboUserInfo(name, openId);
        }

        /// <summary>
        /// 获取登录用户的听众列表
        /// </summary>
        /// <param name="reqnum">求获取的听众个数。取值范围为1-30。</param>
        /// <param name="startindex">请求获取听众列表的起始位置。第一页：0；继续向下翻页：reqnum*（page-1）</param>
        public  WeiboFan GetFansList(int reqnum, int startindex)
        {
            return restApi.GetFansList(reqnum, startindex);
        }

         /// <summary>
        /// 获取登录用户收听的人的列表。
        /// </summary>
        /// <param name="reqnum">求获取的收听个数。取值范围为1-30。</param>
        /// <param name="startindex">请求获取收听列表的起始位置。第一页：0；继续向下翻页：reqnum*（page-1）</param>
        public WeiboIdol GetIdolList(int reqnum, int startindex)
        {
            return restApi.GetIdolList(reqnum, startindex);
        }

        /// <summary>
        /// 收听腾讯微博上的用户。
        /// name和fopenids至少选一个，若同时存在则以name值为主
        /// </summary>
        /// <param name="name">要收听的用户的账户名列表。多个账户名之间用“,”隔开，例如：abc,bcde,cde。 </param>
        /// <param name="fopenids">要收听的用户的openid列表。多个openid之间用“_”隔开，例如：B624064BA065E01CB73F835017FE96FA_B624064BA065E01CB73F835017FE96FB。</param>
        /// <returns></returns>
        public  MicroBlogBase AddIdol(string name, string fopenids)
        {
            return restApi.AddIdol(name, fopenids);
        }

         /// <summary>
        /// 取消收听腾讯微博上的用户。        
        /// </summary>
        /// <param name="name">要取消收听的用户的账户名  </param>
        /// <param name="fopenid ">要取消收的用户的openid列表。 </param>
        /// <returns></returns>
        public  MicroBlogBase DelIdol(string name, string fopenid)
        {
            return restApi.DelIdol(name, fopenid);
        }

        /// <summary>
        /// 获取登录用户的相册列表。
        /// </summary>
        /// <returns></returns>
        public UserAlbums GetCurrentUserListAlbum()
        {
            return restApi.GetCurrentUserListAlbum();
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
            return restApi.AddAlbum(albumname, albumdesc, priv, question, answer);
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
        public  Picture UploadPic(string photodesc, string title, string albumid, int? x, int? y, string picture, byte[] pictureData)
        {
            return restApi.UploadPic(photodesc, title,albumid, x, y, picture, pictureData);
        }

                /// <summary>
        /// 登录用户发表一篇新日志
        /// </summary>
        /// <param name="title">日志标题（纯文本，最大长度128个字节，utf-8编码）</param>
        /// <param name="content">文章内容（html数据，最大长度100*1024个字节，utf-8编码）.</param>
        /// <returns></returns>
        public AddBlogResult AddBlog(string title, string content)
        {
            return restApi.AddBlog(title, content);
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
        public QzoneBase AddTopic(string con, string richtype="", string richval="",  string lbs_nm="", string lbs_x="", string lbs_y="", string third_source="")
        {
            return restApi.AddTopic(richtype, richval, con, lbs_nm, lbs_x, lbs_y, third_source);
        }

        /// <summary>
        /// 获取财付通用户的收货地址。一个用户可能设置了多条收货地址信息。
        /// 查询的用户必须为财付通用户，否则查询将返回失败。
        /// </summary>
        /// <param name="offset">表示查询收货地址的偏移量，一般情况下offset可以不传值或传入0，表示从第一条开始读取。
        /// offset参数是为一种特殊情况准备的，即该收货人有很多条收获地址，需要分页展示，则offset可设置为该页显示的条数。例如如果offset为10，则会跳过第10条收货地址，从第11条收货地址开始读取。 
        /// </param>
        /// <param name="limit">表示查询收货地址的返回限制数（即最多期望返回几个收货地址）。 limit不传默认按照5来处理。
        /// </param>
        /// <param name="ver">用于接口版本控制。固定填1。</param>
        /// <returns></returns>
        public string GetTenpayAddr(string offset="0", string limit = "5", string ver = "1")
        {
            return restApi.GetTenpayAddr(offset, limit, ver);
        }
    }
}
