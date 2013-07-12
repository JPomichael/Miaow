using System;
namespace Wbm.TencV2SDK.Models
{
    /// <summary>
    /// 视频信息实体类
    /// </summary>
    [Serializable]
    public class TencMVideo
    {
        /// <summary>
        /// 缩略图
        /// </summary>
        public string picurl { set; get; }

        /// <summary>
        /// 播放器地址
        /// </summary>
        public string player { set; get; }

        /// <summary>
        /// 视频原地址
        /// </summary>
        public string realurl { set; get; }

        /// <summary>
        /// 视频的短url
        /// </summary>
        public string shorturl { set; get; }

        /// <summary>
        /// 视频标题
        /// </summary>
        public string title { set; get; }

    }

}
/*
 * Author: xusion
 * Created: 2012.06.22
 * Support: http://wobumang.com
 */