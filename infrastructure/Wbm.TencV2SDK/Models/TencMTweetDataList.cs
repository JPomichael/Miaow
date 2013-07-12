using System;
using System.Collections.Generic;
namespace Wbm.TencV2SDK.Models
{
    /// <summary>
    /// 微博数据列表实体类
    /// </summary>
    [Serializable]
    public class TencMTweetDataList : TencMError
    {
        /// <summary>
        /// 微博数据
        /// </summary>
        public TencMTweetInfo data { set; get; }

    }

    /// <summary>
    /// 微博数据信息实体类
    /// </summary>
    [Serializable]
    public class TencMTweetInfo
    {
        /// <summary>
        /// 所有记录的总数
        /// </summary>
        public int totalnum { set; get; }
        /// <summary>
        /// 服务器时间戳
        /// </summary>
        public long timestamp { set; get; }
        /// <summary>
        /// 0-表示还有数据，1-表示下页没有数据
        /// </summary>
        public int hasnext { set; get; }
        /// <summary>
        /// 微博数据列表
        /// </summary>
        public List<TencMTweet> info { set; get; }

    }
}


/*
 * Author: xusion
 * Created: 2012.06.22
 * Support: http://wobumang.com
 */