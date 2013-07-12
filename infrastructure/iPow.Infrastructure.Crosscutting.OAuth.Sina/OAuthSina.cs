using System;
using System.Net;
using System.IO;
using System.Collections.Specialized;
using System.Text;
using System.Globalization;
using System.Web;

namespace iPow.Infrastructure.Crosscutting.OAuth.Sina
{
    public class OAuthSina : OAuthBase
    {
        public enum Method { GET, POST, PUT, DELETE };
        private const string REQUEST_TOKEN = "http://api.t.sina.com.cn/oauth/request_token";
        private const string AUTHORIZE = "http://api.t.sina.com.cn/oauth/authorize";
        private const string ACCESS_TOKEN = "http://api.t.sina.com.cn/oauth/access_token";

        private string _appKey = "";
        private string _appSecret = "";
        private string _token = "";
        private string _tokenSecret = "";

        #region Properties
        public string appKey
        {
            get
            {
                if (_appKey.Length == 0)
                {
                    _appKey = System.Configuration.ConfigurationManager.AppSettings["ipowSinaAppKey"];
                }
                return _appKey;
            }
            set { _appKey = value; }
        }
        public string appSecret
        {
            get
            {
                if (_appSecret.Length == 0)
                {
                    _appSecret = System.Configuration.ConfigurationManager.AppSettings["ipowSinaAppSecret"];
                }
                return _appSecret;
            }
            set { _appSecret = value; }
        }
        public string token { get { return _token; } set { _token = value; } }
        public string tokenSecret { get { return _tokenSecret; } set { _tokenSecret = value; } }
        #endregion
        private string _WebRequest(Method method, string url, string postData)
        {
            HttpWebRequest webRequest = null;
            StreamWriter requestWriter = null;
            string responseData = "";

            webRequest = System.Net.WebRequest.Create(url) as HttpWebRequest;
            webRequest.Method = method.ToString();
            webRequest.ServicePoint.Expect100Continue = false;

            if (method == Method.POST)
            {
                webRequest.ContentType = "application/x-www-form-urlencoded";
                requestWriter = new StreamWriter(webRequest.GetRequestStream());
                try
                {
                    requestWriter.Write(postData);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    requestWriter.Close();
                    requestWriter = null;
                }
            }

            responseData = _WebResponseGet(webRequest);

            webRequest = null;

            return responseData;

        }

        private string _WebResponseGet(HttpWebRequest webRequest)
        {
            StreamReader responseReader = null;
            string responseData = "";
            try
            {
                responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream());
                responseData = responseReader.ReadToEnd();
            }
            catch
            {
                throw;
            }
            finally
            {
                webRequest.GetResponse().GetResponseStream().Close();
                responseReader.Close();
                responseReader = null;
            }

            return responseData;
        }
        public string oAuthWebRequest(Method method, string url, string postData)
        {
            string outUrl = "";
            string querystring = "";
            string ret = "";
            postData += "&source=" + appKey;
            if (method == Method.POST)
            {
                if (postData.Length > 0)
                {
                    NameValueCollection qs = HttpUtility.ParseQueryString(postData);
                    postData = "";
                    foreach (string key in qs.AllKeys)
                    {
                        if (postData.Length > 0)
                        {
                            postData += "&";
                        }
                        qs[key] = HttpUtility.UrlEncode(qs[key]);
                        qs[key] = this.UrlEncode(qs[key]);
                        postData += (key + "=" + qs[key]);

                    }
                    if (url.IndexOf("?") > 0)
                    {
                        url += "&";
                    }
                    else
                    {
                        url += "?";
                    }
                    url += postData;
                }
            }

            Uri uri = new Uri(url);

            string nonce = this.GenerateNonce();
            string timeStamp = this.GenerateTimeStamp();

            //Generate Signature
            string sig = this.GenerateSignature(uri,
                this.appKey,
                this.appSecret,
                this.token,
                this.tokenSecret,
                method.ToString(),
                timeStamp,
                nonce,
                out outUrl,
                out querystring);


            querystring += "&oauth_signature=" + HttpUtility.UrlEncode(sig);

            if (method == Method.POST)
            {
                postData = querystring;
                querystring = "";
            }

            if (querystring.Length > 0)
            {
                outUrl += "?";
            }

            if (method == Method.POST || method == Method.GET)
                ret = _WebRequest(method, outUrl + querystring, postData);
            return ret;
        }

        /*Get request token and token secret*/
        public void RequestTokenGet()
        {
            string response = oAuthWebRequest(Method.GET, REQUEST_TOKEN, String.Empty);
            if (response.Length > 0)
            {
                NameValueCollection qs = HttpUtility.ParseQueryString(response);
                if (qs["oauth_token"] != null)
                {
                    this.token = qs["oauth_token"];
                    this.tokenSecret = qs["oauth_token_secret"];
                }
            }
        }

        public string AuthorizationGet()
        {
            string ret = null;
            ret = AUTHORIZE + "?oauth_token=" + this.token;
            return ret;
        }
        /*Get access token and token secret*/
        public void AccessTokenGet()
        {
            string response = oAuthWebRequest(Method.GET, ACCESS_TOKEN, string.Empty);

            if (response.Length > 0)
            {
                NameValueCollection qs = HttpUtility.ParseQueryString(response);
                if (qs["oauth_token"] != null)
                {
                    this.token = qs["oauth_token"];
                }
                if (qs["oauth_token_secret"] != null)
                {
                    this.tokenSecret = qs["oauth_token_secret"];
                }
            }
        }
        /*Upload a message*/
        public string oAuthWebRequestWithPic(Method method, string url, string postData, string filepath)
        {
            var UploadApiUrl = url;
            string status = postData.Split('=').GetValue(1).ToString();
            postData += "&source=" + appKey;

            if (postData.Length > 0)
            {
                NameValueCollection qs = HttpUtility.ParseQueryString(postData);
                postData = "";
                foreach (string key in qs.AllKeys)
                {
                    if (postData.Length > 0)
                    {
                        postData += "&";
                    }
                    qs[key] = HttpUtility.UrlEncode(qs[key]);
                    qs[key] = this.UrlEncode(qs[key]);
                    postData += (key + "=" + qs[key]);

                }
                if (url.IndexOf("?") > 0)
                {
                    url += "&";
                }
                else
                {
                    url += "?";
                }
                url += postData;
            }

            var oauthSignaturePattern = "OAuth oauth_consumer_key=\"{0}\", oauth_signature_method=\"HMAC-SHA1\",oauth_timestamp=\"{1}\", oauth_nonce=\"{2}\", oauth_version=\"1.0\", oauth_token=\"{3}\",oauth_signature=\"{4}\"";

            var contentEncoding = "iso-8859-1";

            string normalizedString, normalizedParameters;
            var timestamp = this.GenerateTimeStamp();
            var nounce = this.GenerateNonce();

            var signature = this.GenerateSignature(
                                new Uri(url),
                                this.appKey,
                                this.appSecret,
                                this.token,
                                this.tokenSecret,
                                method.ToString(),
                                timestamp,
                                nounce,
                                out normalizedString,
                                out normalizedParameters);
            signature = HttpUtility.UrlEncode(signature);

            var boundary = Guid.NewGuid().ToString();
            var request = (HttpWebRequest)System.Net.WebRequest.Create(UploadApiUrl);

            request.PreAuthenticate = true;
            request.AllowWriteStreamBuffering = true;
            request.Method = method.ToString();
            request.UserAgent = "Jakarta Commons-HttpClient/3.1";
            var authorizationHeader = string.Format(
                                        CultureInfo.InvariantCulture,
                                        oauthSignaturePattern,
                                        this.appKey,
                                        timestamp,
                                        nounce,
                                        this.token,
                                        signature);
            request.Headers.Add("Authorization", authorizationHeader);

            var header = string.Format("--{0}", boundary);
            var footer = string.Format("--{0}--", boundary);

            var contents = new StringBuilder();
            request.ContentType = string.Format("multipart/form-data; boundary={0}", boundary);
            contents.AppendLine(header);
            contents.AppendLine(String.Format("Content-Disposition: form-data; name=\"{0}\"", "status"));
            contents.AppendLine("Content-Type: text/plain; charset=US-ASCII");
            contents.AppendLine("Content-Transfer-Encoding: 8bit");
            contents.AppendLine();
            contents.AppendLine(status);

            contents.AppendLine(header);
            contents.AppendLine(string.Format("Content-Disposition: form-data; name=\"{0}\"", "source"));
            contents.AppendLine("Content-Type: text/plain; charset=US-ASCII");
            contents.AppendLine("Content-Transfer-Encoding: 8bit");
            contents.AppendLine();
            contents.AppendLine(this.appKey);


            contents.AppendLine(header);
            string fileHeader = string.Format("Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"", "pic", filepath);
            string fileData = System.Text.Encoding.GetEncoding(contentEncoding).GetString(File.ReadAllBytes(@filepath));

            contents.AppendLine(fileHeader);
            contents.AppendLine("Content-Type: application/octet-stream; charset=UTF-8");
            contents.AppendLine("Content-Transfer-Encoding: binary");
            contents.AppendLine();
            contents.AppendLine(fileData);
            contents.AppendLine(footer);

            byte[] bytes = Encoding.GetEncoding(contentEncoding).GetBytes(contents.ToString());
            request.ContentLength = bytes.Length;

            var requestStream = request.GetRequestStream();
            try
            {
                requestStream.Write(bytes, 0, bytes.Length);
            }
            catch
            {
                throw;
            }
            finally
            {
                requestStream.Close();
                requestStream = null;
            }
            return _WebResponseGet(request);
        }
    }
}