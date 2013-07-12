using System;
namespace Wbm.TencV2SDK.Models
{
    /// <summary>
    /// 音频信息实体类
    /// </summary>
    [Serializable]
    public class TencMMusic
    {
        /// <summary>
        /// 演唱者
        /// </summary>
        public string author { set; get; }

        /// <summary>
        /// 音频地址
        /// </summary>
        public string url { set; get; }

        /// <summary>
        /// 音频名字，歌名
        /// </summary>
        public string title { set; get; }

    }

}
/*
 * Author: xusion
 * Created: 2012.06.22
 * Support: http://wobumang.com
 */