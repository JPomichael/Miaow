using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QConnectSDK.Models
{
    /// <summary>
    /// 微博的基类
    /// </summary>
    public class MicroBlogBase: QzoneBase
    {
        /// <summary>
        /// 二级错误码,http://wiki.opensns.qq.com/wiki/%E3%80%90QQ%E7%99%BB%E5%BD%95%E3%80%91%E5%BE%AE%E5%8D%9A%E7%A7%81%E6%9C%89%E8%BF%94%E5%9B%9E%E7%A0%81%E8%AF%B4%E6%98%8E
        /// </summary>
        public string Errcode { get; set; }
    }
}
