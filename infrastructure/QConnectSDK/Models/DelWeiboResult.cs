using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QConnectSDK.Models
{
    /// <summary>
    /// 删除微博的结果
    /// </summary>
    public class DelWeiboResult: MicroBlogBase
    {
        /// <summary>
        /// 删除的微博
        /// </summary>
        public WeiboData Data { get; set; }
    }
     
}
