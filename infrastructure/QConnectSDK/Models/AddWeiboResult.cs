using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QConnectSDK.Models
{
    
    /// <summary>
    /// 添加微博返回结果数据Json格式
    /// </summary>
    public class AddWeiboResult: MicroBlogBase
    {
        /// <summary>
        /// 微博数据
        /// </summary>
        public WeiboData Data { get; set; }
    }

    /// <summary>
    /// 微博
    /// </summary>
    public class WeiboData
    {
        /// <summary>
        /// 微博的Id
        /// </summary>
        public Int64 Id { get; set; }
        /// <summary>
        /// 微博消息的发表时间
        /// </summary>
        public TimeSpan Timestamp { get; set; }
    }
}
