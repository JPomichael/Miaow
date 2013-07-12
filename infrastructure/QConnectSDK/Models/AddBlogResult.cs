using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QConnectSDK.Models
{
    /// <summary>
    /// 登录用户发表一篇新日志的结果
    /// </summary>
    public class AddBlogResult : QzoneBase
    {
        /// <summary>
        ///  固定为http://i.qq.com。用户在登录态下，可以通过该URL直接进入空间首页（这里不直接返回新发表日志的URL是为了避免泄漏用户信息） 
        /// </summary>
        public string Url { get; set; }
    }
}
