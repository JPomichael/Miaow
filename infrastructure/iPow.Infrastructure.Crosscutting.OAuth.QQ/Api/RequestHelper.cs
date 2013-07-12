using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;

using iPow.Infrastructure.Crosscutting.OAuth.QQ.Config;

namespace iPow.Infrastructure.Crosscutting.OAuth.QQ.Api
{
    internal  class RequestHelper
    {
        public RequestHelper()
        {
            
        }

        internal RestRequest CreateTokenRequest(QQConnectConfig config, string code, string state="")
        {
            var request = new RestRequest(Method.GET);
            if (!string.IsNullOrEmpty(state))
            {
                request.Resource = "oauth2.0/token?grant_type=authorization_code&client_id={appkey}&client_secret={appsecret}&code={code}&state={state}&redirect_uri={callbackurl}";
                request.AddParameter("state", state, ParameterType.UrlSegment);
            }
            else
            {
                request.Resource = "oauth2.0/token?grant_type=authorization_code&client_id={appkey}&client_secret={appsecret}&code={code}&redirect_uri={callbackurl}";

            } 
            request.AddParameter("appkey", config.GetAppKey(), ParameterType.UrlSegment);
            request.AddParameter("appsecret", config.GetAppSecret(), ParameterType.UrlSegment);
            request.AddParameter("code", code, ParameterType.UrlSegment);
            request.AddParameter("callbackurl", config.GetCallBackURI(), ParameterType.UrlSegment);
            return request;
        }

        internal RestRequest CreateOpenIDRequest(string accesstoken)
        {
            var request = new RestRequest(Method.GET);
            request.Resource = "oauth2.0/me?access_token={accesstoken}";
            request.AddParameter("accesstoken", accesstoken, ParameterType.UrlSegment);
            return request;
        }

        internal RestRequest CreateAccountInfoRequest()
        {
            var request = new RestRequest(Method.GET);             
            request.RequestFormat = DataFormat.Json;
            //request.AddHeader("Content-Type", "application/json");
            request.Resource = "user/get_user_info";     
            return request;
        }

        internal RestRequest CreateAddFeedsRequest(string title, string url, string comment, string summary,
            string images, string source, string type, string playurl, string nswb)
        {
            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.Resource = "share/add_share";
            request.AddParameter("title", title);
            request.AddParameter("url", url);
            if (!string.IsNullOrEmpty(comment))
            {
                request.AddParameter("comment", comment);
            }
            if (!string.IsNullOrEmpty(summary))
            {
                request.AddParameter("summary", summary);
            }
            if (!string.IsNullOrEmpty(images))
            {
                request.AddParameter("images", images);
            }
            if (!string.IsNullOrEmpty(source))
            {
                request.AddParameter("source", source);
            }
            if (!string.IsNullOrEmpty(type))
            {
                request.AddParameter("type", type);
            }
            if (!string.IsNullOrEmpty(playurl))
            {
                request.AddParameter("playurl", playurl);
            }
            if (!string.IsNullOrEmpty(nswb))
            {
                request.AddParameter("nswb", nswb);
            }            
            return request;
        }

        internal RestRequest CreateCheckPagefansRequest(string qq)
        {
            var request = new RestRequest(Method.GET);
            request.RequestFormat = DataFormat.Json;
            request.Resource = "user/check_page_fans";
            request.AddParameter("page_id", qq);
            return request;
        }

        internal RestRequest CreateAddWeiboRequest(string content, string clientip, string jing, string wei, int syncflag)
        {
            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.Resource = "t/add_t";
            request.AddParameter("content", content);
            if (!string.IsNullOrEmpty(clientip))
            {
                request.AddParameter("clientip", clientip);
            }
            if (!string.IsNullOrEmpty(jing))
            {
                request.AddParameter("jing", jing);
            }
            if (!string.IsNullOrEmpty(wei))
            {
                request.AddParameter("wei", wei);
            }
            request.AddParameter("syncflag", syncflag);
            return request;
        }

        internal RestRequest CreateDelWeiboRequest(Int64 id)
        {
            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.Resource = "t/del_t";
            request.AddParameter("id", id);
            return request;
        }

        internal RestRequest CreateAddPictureWeiboRequest(string content, string clientip, string jing, string wei, int syncflag, string fileName, byte[] bytes)
        {
            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            var boundary = string.Concat("--", Util.GenerateRndNonce());
            request.AddHeader("Content-Type", string.Concat("multipart/form-data; boundary=", boundary));
            request.Resource = "t/add_pic_t";
            request.AddParameter("content", content);
            
            if (!string.IsNullOrEmpty(clientip))
            {
                request.AddParameter("clientip", clientip);
            }
            if (!string.IsNullOrEmpty(jing))
            {
                request.AddParameter("jing", jing);
            }
            if (!string.IsNullOrEmpty(wei))
            {
                request.AddParameter("wei", wei);
            }
            request.AddParameter("syncflag", syncflag);
            request.AddFile("pic", bytes, fileName);
            return request;
        }

        internal RestRequest CreateGetRepostlistRequest(string flag, string rootid, string pageflag, string pagetime, string reqnum, string twitterid)
        {
            var request = new RestRequest(Method.GET);
            request.RequestFormat = DataFormat.Json;      
            request.Resource = "t/get_repost_list";
            request.AddParameter("flag", flag);
            request.AddParameter("rootid", rootid);
            request.AddParameter("pageflag", pageflag);
            request.AddParameter("pagetime", pagetime);
            request.AddParameter("reqnum", reqnum);
            request.AddParameter("twitterid", twitterid);
            return request;
        }

        internal RestRequest CreateWeiboAccountInfoRequest()
        {
            var request = new RestRequest(Method.GET);
            request.RequestFormat = DataFormat.Json;             
            request.Resource = "user/get_info";
            return request;
        }

        internal RestRequest CreateWeiboOtherAccountInfoRequest(string name, string openId)
        {
            var request = new RestRequest(Method.GET);
            request.RequestFormat = DataFormat.Json;
            request.Resource = "user/get_other_info";
            if (!string.IsNullOrEmpty(name))
            {
                request.AddParameter("name", name);
            }
            if (!string.IsNullOrEmpty(openId))
            {
                request.AddParameter("openid", openId);
            }
            return request;
        }

        internal RestRequest CreateGetFansListRequest(int reqnum, int startindex)
        {
            var request = new RestRequest(Method.GET);
            request.RequestFormat = DataFormat.Json;
            request.Resource = "relation/get_fanslist";
            request.AddParameter("reqnum", reqnum);
            request.AddParameter("startindex", startindex);

            return request;
        }

        internal RestRequest CreateGetIdolListRequest(int reqnum, int startindex)
        {
            var request = new RestRequest(Method.GET);
            request.RequestFormat = DataFormat.Json;
            request.Resource = "relation/get_idollist";
            request.AddParameter("reqnum", reqnum);
            request.AddParameter("startindex", startindex);

            return request;
        }

        internal RestRequest CreateAddIdolRequest(string name, string fopenids)
        {
            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.Resource = "relation/add_idol";
            if (!string.IsNullOrEmpty(name))
            {
                request.AddParameter("name", name);
            }
            if (!string.IsNullOrEmpty(fopenids))
            {
                request.AddParameter("fopenids", fopenids);
            }
            return request;
        }

        internal RestRequest CreateDelIdolRequest(string name, string fopenid)
        {
            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.Resource = "relation/del_idol";
            if (!string.IsNullOrEmpty(name))
            {
                request.AddParameter("name", name);
            }
            if (!string.IsNullOrEmpty(fopenid))
            {
                request.AddParameter("fopenid", fopenid);
            }
            return request;
        }

        internal RestRequest CreateGetUserListAlbumRequest()
        {
            var request = new RestRequest(Method.GET);
            request.RequestFormat = DataFormat.Json;
            request.Resource = "photo/list_album";
            return request;
        }

        internal RestRequest CreateAddAlbumRequest(string albumname, string albumdesc, int priv, string question, string answer)
        {
            var request = new RestRequest(Method.POST); 
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.Resource = "photo/add_album";
            request.AddParameter("albumname", albumname);
            if (!string.IsNullOrEmpty(albumdesc))
            {
                request.AddParameter("albumdesc", albumdesc);
            }
            request.AddParameter("priv",priv);
            if (!string.IsNullOrEmpty(question))
            {
                request.AddParameter("question", question);
            }
            if (!string.IsNullOrEmpty(answer))
            {
                request.AddParameter("answer", answer);
            }
            return request;
        }

        internal RestRequest CreateUploadPicRequest(string photodesc, string title, string albumid, int? x, int? y, string picture, byte[] pictureData)
        {
            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            var boundary = string.Concat("--", Util.GenerateRndNonce());
            request.AddHeader("Content-Type", string.Concat("multipart/form-data; boundary=", boundary));
            request.Resource = "photo/upload_pic";
            request.AddParameter("photodesc", photodesc);
            if (!string.IsNullOrEmpty(title))
            {
                request.AddParameter("title", title);
            }
            if (!string.IsNullOrEmpty(albumid))
            {
                request.AddParameter("albumid", albumid);
            }
            if (x.HasValue)
            {
                request.AddParameter("x", x);
            }
            if (y.HasValue)
            {
                request.AddParameter("y", y);
            }
            request.AddFile("picture", pictureData, picture);
            return request;
        }

        internal RestRequest CreateAddBlogRequest(string title, string content)
        {
            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.Resource = "blog/add_one_blog";
            request.AddParameter("title", title);
            request.AddParameter("content", content);
            return request;
        }

        internal RestRequest CreateAddTopicRequest(string richtype, string richval, string con, string lbs_nm, string lbs_x, string lbs_y, string third_source)
        {
            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.Resource = "shuoshuo/add_topic";
            if (!string.IsNullOrEmpty(richtype))
            {
                request.AddParameter("richtype", richtype);
            }
            if (!string.IsNullOrEmpty(richval))
            {
                request.AddParameter("richval", richval);
            }          
           
            request.AddParameter("con", con);
           
            if (!string.IsNullOrEmpty(lbs_nm))
            {
                request.AddParameter("lbs_nm", lbs_nm);
            }
            if (!string.IsNullOrEmpty(lbs_x))
            {
                request.AddParameter("lbs_x", lbs_x);
            }
            if (!string.IsNullOrEmpty(lbs_y))
            {
                request.AddParameter("lbs_y", lbs_y);
            }
            if (!string.IsNullOrEmpty(third_source))
            {
                request.AddParameter("third_source", third_source);
            }
            return request;
        }

        internal RestRequest CreateGetTenpayAddrRequest(string offset, string limit, string ver)
        {
            var request = new RestRequest(Method.GET);
            request.RequestFormat = DataFormat.Json;
            request.Resource = "cft_info/get_tenpay_addr";
            request.AddParameter("offset", offset);
            request.AddParameter("limit", limit);
            request.AddParameter("ver",ver);
            return request;
        }
    }
}
