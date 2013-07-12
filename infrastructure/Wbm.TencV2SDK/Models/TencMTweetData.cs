using System;
using System.Collections.Generic;
namespace Wbm.TencV2SDK.Models
{
    /// <summary>
    /// 微博数据信息实体类
    /// </summary>
    [Serializable]
    public class TencMTweetData : TencMError
    {
        /// <summary>
        /// 微博数据
        /// </summary>
        public TencMTweet data { set; get; }       
    }

}
/*
 * Author: xusion
 * Created: 2012.06.22
 * Support: http://wobumang.com
 */