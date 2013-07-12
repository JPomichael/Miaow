/*
 This file was create by Xusion at 2011.10.27
 */
using System;
namespace Wbm.SinaV2API.SinaModels
{
    /// <summary>
    /// 实体类MStatuses 。
    /// </summary>
    [Serializable]
    public class SinaMStatus
    {
        public SinaMStatus()
        { }
        #region Model
        /// <summary>
        /// 字符串型的微博ID
        /// </summary>
        public string idstr { set; get; }
        /// <summary>
        /// 微博ID 
        /// </summary>
        public long id { set; get; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string created_at { set; get; }
        /// <summary>
        /// 微博信息内容
        /// </summary>
        public string text { set; get; }
        /// <summary>
        /// 微博来源
        /// </summary>
        public string source { set; get; }
        /// <summary>
        /// 是否已收藏
        /// </summary>
        public bool favorited { set; get; }
        /// <summary>
        /// 是否被截断
        /// </summary>
        public bool truncated { set; get; }
        /// <summary>
        /// 回复ID 
        /// </summary>
        public string in_reply_to_status_id { set; get; }
        /// <summary>
        /// 回复人UID 
        /// </summary>
        public string in_reply_to_user_id { set; get; }
        /// <summary>
        /// 回复人昵称
        /// </summary>
        public string in_reply_to_screen_name { set; get; }
        /// <summary>
        /// 微博MID
        /// </summary>
        public long mid { set; get; }
        /// <summary>
        /// 缩略图
        /// </summary>
        public string thumbnail_pic { set; get; }
        /// <summary>
        /// 中型图片
        /// </summary>
        public string bmiddle_pic { set; get; }
        /// <summary>
        /// 原始图片
        /// </summary>
        public string original_pic { set; get; }
        /// <summary>
        /// 转发数
        /// </summary>
        public int reposts_count { set; get; }
        /// <summary>
        /// 评论数
        /// </summary>
        public int comments_count { set; get; }
        /// <summary>
        /// 微博附加注释信息
        /// </summary>
        public object annotations { set; get; }
        /// <summary>
        /// 地理信息字段
        /// </summary>
        public object geo { set; get; }
        /// <summary>
        /// 微博作者的用户信息字段
        /// </summary>
        public SinaMUser user { set; get; }
        /// <summary>
        /// 转发的博文ID，内容为status
        /// </summary>
        public SinaMStatus retweeted_status { set; get; }
        #endregion Model

    }
}

