using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;
using System.IO;
using RestSharp;
using RestSharp.Deserializers;
using QConnectSDK.Config;
using QConnectSDK.Exceptions;
using QConnectSDK.Models;
using QConnectSDK.Api;

namespace QConnectSDK.Context
{
    /// <summary>
    /// QQ登陆的上下文数据
    /// </summary>
    [Serializable]
    public class QzoneContext
    {
        private RestApi restApi;

        /// <summary>
        /// 用于用户接受授权后使用Authorization Code进行上下文设置
        /// </summary>
        /// <param name="authVericode">Authorization Code（注意此code会在10分钟内过期）</param>
        public QzoneContext(string authVericode)
        {
            this.oAuthVericode = authVericode;
            this.config = new QQConnectConfig();
            this.restApi = new RestApi(this);         
        }

        /// <summary>
        /// 用户将第一次使用QQ互联服务
        /// </summary>
        public QzoneContext()
            :this(string.Empty)
        {
            
        }

        /// <summary>
        /// 用于用户已经完成授权后，将OAuthToken持久化保存后，使用这个函数从持久化介质中获取到的
        /// OAuthToken，进行后续的API调用。
        /// </summary>
        /// <param name="oAuthToken"></param>
        public QzoneContext(OAuthToken oAuthToken)
        {
            this.oAuthToken = oAuthToken;
            this.config = new QQConnectConfig();
            this.restApi = new RestApi(this);   
        }

        private QQConnectConfig config = null;

        /// <summary>
        /// 配置数据
        /// </summary>
        public QQConnectConfig Config
        {
            get { return config; }
            set { config = value; }
        }

        /// <summary>
        /// 获取Authorization Code的URL地址
        /// </summary>
        /// <param name="state">client端的状态值。用于第三方应用防止CSRF攻击，成功授权后回调时会原样带回。</param>
        /// <param name="scope">请求用户授权时向用户显示的可进行授权的列表。可填写的值是【QQ登录】API文档中列出的接口，
        /// 以及一些动作型的授权（目前仅有：do_like），如果要填写多个接口名称，请用逗号隔开。
        /// 例如：scope=get_user_info,add_share,list_album,upload_pic,check_page_fans,add_t,add_pic_t,del_t,get_repost_list,get_info,get_other_info 
        /// get_fanslist,get_idolist,add_idol,del_idol
        /// 不传则默认请求对接口get_user_info进行授权。
        /// 建议控制授权项的数量，只传入必要的接口名称，因为授权项越多，用户越可能拒绝进行任何授权。</param>
        /// <returns></returns>
        public string GetAuthorizationUrl(string state,string scope="")
        {
            string url = string.Empty;
            if (string.IsNullOrEmpty(scope))
            {
                url = string.Format("{0}?response_type=code&client_id={1}&redirect_uri={2}&state={3}", config.GetAuthorizeURL(), config.GetAppKey(), config.GetCallBackURI().ToString(), state);
            }
            else
            {
                url = string.Format("{0}?response_type=code&client_id={1}&redirect_uri={2}&state={3}&scope={4}", config.GetAuthorizeURL(), config.GetAppKey(), config.GetCallBackURI().ToString(), state,scope);
            }
            return url;
        }


        private string oAuthVericode;
        /// <summary>
        /// 用于用户接受授权后使用Authorization Code，用于后续获取Access Token
        /// </summary>
        public string OAuthVericode
        {
            get
            {
                return oAuthVericode;
            }
            set
            {
                oAuthVericode = value;
            }
        }

        private OAuthToken oAuthToken;

        /// <summary>
        /// 通过Authorization Code获取到的Access Token
        /// </summary>
        public OAuthToken AccessToken
        {
            get
            {
                return oAuthToken;
            }
            set
            {
                oAuthToken = value;
            }
        }

        /// <summary>
        /// 通过Authorization Code获取Access Token
        /// </summary>
        /// <param name="oAuthVericode"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public OAuthToken GetAccessToken(string state)
        {
            oAuthToken = restApi.GetAccessToken(oAuthVericode, state);
            return oAuthToken;
        }

      
    }
}
