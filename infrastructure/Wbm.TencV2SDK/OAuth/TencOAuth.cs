using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;

namespace Wbm.TencV2SDK.OAuth
{
    /// <summary>
    /// Oauth 2.0
    /// </summary>
    public class TencOAuth
    {
        public const string OAuthClientIdKey = "client_id";
        public const string OAuthClientSecretKey = "client_secret";
        public const string OAuthRedirectUriKey = "redirect_uri";
        public const string OAuthResponseTypeKey = "response_type";
        public const string OAuthStateKey = "state";
        public const string OAuthDisplayKey = "display";
        public const string OAuthAccessTokenKey = "access_token";
        public const string OAuthExpiresInKey = "expires_in";
        public const string OAuthRemindKey = "remind_in";
        public const string OAuthRefreshTokenKey = "refresh_token";
        public const string OAuthCodeKey = "code";
        public const string OAuthGrantTypeKey = "grant_type";
        public const string OAuthUserNameKey = "username";
        public const string OAuthPasswordKey = "password";
        public const string OAutHsignedRequestKey = "signed_request";
        public const string OAuthScopeKey = "scope";
        public const string OAuthConsumerKey = "oauth_consumer_key";
        public const string OAuthOpenIdKey = "openid";
        public const string OAuthClientIpKey = "clientip";
        public const string OAuthOauthVersionKey = "oauth_version";


        private ResponseTypeEnum _response_type = ResponseTypeEnum.code;
        private GrantTypeEnum _grant_type = GrantTypeEnum.authorization_code;
        private string _client_id = String.Empty;
        private string _client_secret = String.Empty;
        private string _redirect_uri = String.Empty;
        private string _access_token = String.Empty;
        private int _expires_in = 0;
        private int _remind_in = 0;
        private string _refresh_token = String.Empty;
        private string _code = String.Empty;
        private string _state = String.Empty;
        private DisplayEnum _display = DisplayEnum.Default;
        private string _username = String.Empty;
        private string _password = String.Empty;
        private string _scope = String.Empty;
        private string _openid = String.Empty;
        private string _clientip = "127.0.0.1";
        private string _oauth_version = "2.a";


        /// <summary>
        /// 授权类型，此值默认为“code”。
        /// </summary>
        public ResponseTypeEnum ResponseType { get { return _response_type; } set { _response_type = value; } }
        /// <summary>
        /// 授权类型，此值默认为“authorization_code”。
        /// </summary>
        public GrantTypeEnum GrantType { get { return _grant_type; } set { _grant_type = value; } }
        /// <summary>
        /// 申请应用时分配的AppKey
        /// </summary>
        public string ClientId { get { return _client_id; } set { _client_id = value; } }
        /// <summary>
        /// 申请应用时分配的AppSecret
        /// </summary>
        public string ClientSecret { get { return _client_secret; } set { _client_secret = value; } }
        /// <summary>
        /// 成功授权后的回调地址，建议设置为网站首页或网站的用户中心。
        /// </summary>
        public string RedirectUri { get { return _redirect_uri; } set { _redirect_uri = value; } }
        /// <summary>
        /// 通过Authorization Code获取Access Token
        /// </summary>
        public string AccessToken { get { return _access_token; } set { _access_token = value; } }
        /// <summary>
        /// accesstoken有效期时间,unix timestamp格式
        /// </summary>
        public int ExpiresIn { get { return _expires_in; } set { _expires_in = value; } }
        /// <summary>
        /// access_token的剩余时间,unix timestamp格式
        /// </summary>
        public int RemindIn { get { return _remind_in; } set { _remind_in = value; } }
        /// <summary>
        /// 刷新token,如果有获取权限则返回
        /// </summary>
        public string RefreshToken { get { return _refresh_token; } set { _refresh_token = value; } }
        /// <summary>
        /// 上一步返回的authorization code。
        /// </summary>
        public string Code { get { return _code; } set { _code = value; } }
        /// <summary>
        /// client端的状态值。用于第三方应用防止CSRF攻击，成功授权后回调时会原样带回。
        /// </summary>
        public string State { get { return _state; } set { _state = value; } }
        /// <summary>
        /// 用于展示的样式。不传则默认展示为为PC下的样式。
        /// </summary>
        public DisplayEnum Display { get { return _display; } set { _display = value; } }
        /// <summary>
        /// 授权用户的用户名
        /// </summary>
        public string UserName { get { return _username; } set { _username = value; } }
        /// <summary>
        /// 授权用户的密码
        /// </summary>
        public string Password { get { return _password; } set { _password = value; } }
        /// <summary>
        /// 请求用户授权时向用户显示的可进行授权的列表。
        /// <para>例如：scope=get_user_info,list_album,upload_pic,do_like</para>
        /// </summary>
        public string Scope { get { return _scope; } set { _scope = value; } }
        /// <summary>
        /// 用户的ID，与QQ号码一一对应。
        /// </summary>
        public string OpenId { get { return _openid; } set { _openid = value; } }
        /// <summary>
        /// 客户端的ip
        /// </summary>
        public string ClientIp { get { return _clientip; } set { _clientip = value; } }
        /// <summary>
        /// 版本号，必须为2.a
        /// </summary>
        public string OauthVersion { get { return _oauth_version; } set { _oauth_version = value; } }

        /// <summary>
        /// Oauth 2.0
        /// </summary>
        public TencOAuth()
        {

        }

        /// <summary>
        /// 请求用户授权Token
        /// </summary>
        /// <returns></returns>
        public string GetAuthorize(string authorizeUrl)
        {

            var paras = new NameValueCollection();
            paras.Add(OAuthClientIdKey, this.ClientId);
            paras.Add(OAuthRedirectUriKey, this.RedirectUri);
            paras.Add(OAuthResponseTypeKey, this.ResponseType.ToString());
            paras.Add(OAuthDisplayKey, this.Display.ToString());
            paras.Add(OAuthScopeKey, this.Scope);
            if (!string.IsNullOrEmpty(this.State))
            {
                paras.Add(OAuthStateKey, this.State);
            }

            string ret = null;
            ret = authorizeUrl + "?" + Helpers.UtilHelper.GetQueryFromParas(paras);
            return ret;

        }

        /// <summary>
        /// 获取授权过的Access Token
        /// </summary>
        public Models.TencMToken GetAccessToken(string accessTokenUrl)
        {
            var token = new Models.TencMToken();
            if (HttpContext.Current.Request[OAuthStateKey] != null)
            {
                this.State = HttpContext.Current.Request[OAuthStateKey];
            }
            if (this.ResponseType == ResponseTypeEnum.code)
            {
                //response_type为code
                this.Code = HttpContext.Current.Request[OAuthCodeKey];
                this.OpenId = HttpContext.Current.Request[OAuthOpenIdKey];
                if (string.IsNullOrEmpty(this.Code))
                {
                    throw new ArgumentNullException(string.Format("{0} 为空值", OAuthCodeKey));
                }
                if (string.IsNullOrEmpty(this.OpenId))
                {
                    throw new ArgumentNullException(string.Format("{0} 为空值", OAuthOpenIdKey));
                }

            }
            else if (this.ResponseType == ResponseTypeEnum.token)
            {
                //response_type为token
                this.AccessToken = HttpContext.Current.Request[OAuthAccessTokenKey];
                this.ExpiresIn = int.TryParse(HttpContext.Current.Request[OAuthExpiresInKey], out _expires_in) ? _expires_in : 0;
                this.RefreshToken = HttpContext.Current.Request[OAuthRefreshTokenKey];
                this.OpenId = HttpContext.Current.Request[OAuthOpenIdKey];

                if (string.IsNullOrEmpty(this.OpenId) || ExpiresIn == 0 || string.IsNullOrEmpty(this.AccessToken))
                {
                    throw new ArgumentNullException(string.Format("{0},{1}或者{2} 为空值", OAuthOpenIdKey, OAuthAccessTokenKey, OAuthExpiresInKey));
                }
            }

            var paras = new NameValueCollection();
            paras.Add(OAuthClientIdKey, this.ClientId);
            paras.Add(OAuthClientSecretKey, this.ClientSecret);
            paras.Add(OAuthGrantTypeKey, this.GrantType.ToString());

            if (this.GrantType == GrantTypeEnum.authorization_code)
            {
                //grant_type为authorization_code时
                paras.Add(OAuthCodeKey, this.Code);
                paras.Add(OAuthRedirectUriKey, this.RedirectUri);
            }
            else if (this.GrantType == GrantTypeEnum.password)
            {
                //grant_type为password时
                paras.Add(OAuthUserNameKey, this.UserName);
                paras.Add(OAuthPasswordKey, this.Password);
            }
            else if (this.GrantType == GrantTypeEnum.refresh_token)
            {
                //grant_type为refresh_token时
                paras.Add(OAuthRefreshTokenKey, this.RefreshToken);
            }

            string response = Helpers.HttpHelper.HttpPost(accessTokenUrl, paras);
            if (!string.IsNullOrEmpty(response))
            {
                NameValueCollection qs = HttpUtility.ParseQueryString(response);

                if (qs["errorCode"] != null)
                {
                    token.ret = -1;
                    token.errcode = qs["errorCode"].ToString();
                    token.msg = qs["errorMsg"].ToString();
                }
                else
                {

                    if (qs[OAuthAccessTokenKey] != null)
                    {
                        this.AccessToken = qs[OAuthAccessTokenKey].ToString();
                        token.access_token = this.AccessToken;
                    }

                    if (qs[OAuthExpiresInKey] != null)
                    {
                        this.ExpiresIn = int.TryParse(qs[OAuthExpiresInKey].ToString(), out _expires_in) ? _expires_in : 0;

                        token.expires_in = this.ExpiresIn;
                    }
                    token.openid = this.OpenId;
                }
            }
            return token;
        }


        /// <summary>
        /// 获取oauth参数
        /// </summary>
        /// <returns></returns>
        public NameValueCollection GetOauthParas()
        {
            var paras = new NameValueCollection();
            paras.Add(OAuthClientIdKey, this.ClientId);
            paras.Add(OAuthClientSecretKey, this.ClientSecret);
            paras.Add(OAuthRedirectUriKey, this.RedirectUri);
            paras.Add(OAuthAccessTokenKey, this.AccessToken);
            paras.Add(OAuthOpenIdKey, this.OpenId);
            paras.Add(OAuthResponseTypeKey, this.ResponseType.ToString());
            paras.Add(OAuthStateKey, this.State);
            paras.Add(OAuthDisplayKey, this.Display.ToString());
            return paras;
        }

        /// <summary>
        /// 获取oauth参数
        /// </summary>
        /// <returns></returns>
        public string GetOauthQuery()
        {
            return Helpers.UtilHelper.GetQueryFromParas(GetOauthParas());
        }

        /// <summary>
        /// 获取token参数
        /// </summary>
        /// <returns></returns>
        public NameValueCollection GetTokenParas()
        {
            var paras = new NameValueCollection();
            paras.Add(OAuthConsumerKey, this.ClientId);
            paras.Add(OAuthAccessTokenKey, this.AccessToken);
            paras.Add(OAuthOpenIdKey, this.OpenId);
            paras.Add(OAuthOauthVersionKey, this.OauthVersion);
            paras.Add(OAuthClientIpKey, this.ClientIp);
            return paras;
        }

        /// <summary>
        /// 获取oauth参数
        /// </summary>
        /// <returns></returns>
        public string GetTokenQuery()
        {
            return Helpers.UtilHelper.GetQueryFromParas(GetTokenParas());
        }

        /// <summary>
        /// 获取新的参数
        /// </summary>
        /// <returns></returns>
        public NameValueCollection GetNewParas()
        {
            return new NameValueCollection();
        }

        /// <summary>
        /// 获取oath参数
        /// </summary>
        /// <returns></returns>
        public string GettTokenQuery()
        {
            return Helpers.UtilHelper.GetQueryFromParas(GetTokenParas());
        }

        /// <summary>
        /// 授权页面类型 可选范围
        /// </summary>
        public enum DisplayEnum
        {
            /// <summary>
            /// 默认授权页面
            /// </summary>
            Default,
            /// <summary>
            /// 支持html5的手机
            /// </summary>
            Mobile,
            /// <summary>
            /// 弹窗授权页
            /// </summary>
            Popup,
            /// <summary>
            /// wap1.2页面
            /// </summary>
            Wap12,
            /// <summary>
            /// 	wap2.0页面	
            /// </summary>
            Wap20,
            /// <summary>
            /// js-sdk 专用 授权页面是弹窗，返回结果为js-sdk回掉函数		
            /// </summary>
            Js,
            /// <summary>
            /// 站内应用专用,站内应用不传display参数,并且response_type为token时,默认使用改display.授权后不会返回access_token，只是输出js刷新站内应用父框架
            /// </summary>
            Apponweibo

        }

        /// <summary>
        /// 请求的类型,可以为:authorization_code ,password,refresh_token
        /// </summary>
        public enum GrantTypeEnum
        {
            /// <summary>
            /// grant_type为authorization_code时
            /// </summary>
            authorization_code,
            /// <summary>
            /// grant_type为password时
            /// </summary>
            password,
            /// <summary>
            /// grant_type为refresh_token时
            /// </summary>
            refresh_token
        }

        /// <summary>
        /// 支持的值包括 code 和token 默认值为code
        /// </summary>
        public enum ResponseTypeEnum
        {
            /// <summary>
            /// response_type为code
            /// </summary>
            code,
            /// <summary>
            /// response_type为token
            /// </summary>
            token
        }

    }
}
/*
 * Author: xusion
 * Created: 2012.06.22
 * Support: http://wobumang.com
 */