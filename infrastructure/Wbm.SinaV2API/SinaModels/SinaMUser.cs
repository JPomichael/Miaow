/*
 This file was create by Xusion at 2011.10.27
 */
using System;
namespace Wbm.SinaV2API.SinaModels
{
    /// <summary>
    /// 实体类MUsers 。
    /// </summary>
    [Serializable]
    public class SinaMUser
    {
        public SinaMUser()
        { }
        #region Model
        /// <summary>
        /// 用户UID 
        /// </summary>
        public long id { set; get; }
        /// <summary>
        /// 微博昵称 
        /// </summary>
        public string screen_name { set; get; }
        /// <summary>
        /// 友好显示名称，如Bill Gates
        /// </summary>
        public string name { set; get; }
        /// <summary>
        /// 省份编码（参考省份编码表）
        /// </summary>
        public int province { set; get; }
        /// <summary>
        /// 城市编码（参考城市编码表）
        /// </summary>
        public int city { set; get; }
        /// <summary>
        /// 地址
        /// </summary>
        public string location { set; get; }
        /// <summary>
        /// 个人描述
        /// </summary>
        public string description { set; get; }

        /// <summary>
        /// 用户博客地址
        /// </summary>
        public string url { set; get; }
        /// <summary>
        /// 自定义图像
        /// </summary>
        public string profile_image_url { set; get; }
        /// <summary>
        /// 用户个性化URL 
        /// </summary>
        public string domain { set; get; }
        /// <summary>
        /// 性别,m--男，f--女,n--未知 
        /// </summary>
        public string gender { set; get; }
        /// <summary>
        /// 粉丝数
        /// </summary>
        public long followers_count { set; get; }
        /// <summary>
        /// 关注数
        /// </summary>
        public long friends_count { set; get; }
        /// <summary>
        /// 微博数
        /// </summary>
        public long statuses_count { set; get; }
        /// <summary>
        /// 收藏数
        /// </summary>
        public long favourites_count { set; get; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string created_at { set; get; }
        /// <summary>
        /// 当前登录用户是否已关注该用户
        /// </summary>
        public bool following { set; get; }
        /// <summary>
        /// 是否允许所有人给我发私信
        /// </summary>
        public bool allow_all_act_msg { set; get; }
        /// <summary>
        /// 是否允许带有地理信息
        /// </summary>
        public bool geo_enabled { set; get; }
        /// <summary>
        /// 加V标示，是否微博认证用户
        /// </summary>
        public bool verified { set; get; }
        /// <summary>
        /// 是否允许所有人对我的微博进行评论
        /// </summary>
        public bool allow_all_comment { set; get; }
        /// <summary>
        /// 用户大头像地址
        /// </summary>
        public string avatar_large { set; get; }
        /// <summary>
        /// 认证原因
        /// </summary>
        public string verified_reason { set; get; }
        /// <summary>
        /// 该用户是否关注当前登录用户
        /// </summary>
        public bool follow_me { set; get; }
        /// <summary>
        /// 用户的在线状态，0：不在线、1：在线
        /// </summary>
        public int online_status { set; get; }
        /// <summary>
        /// 用户的互粉数
        /// </summary>
        public int bi_followers_count { set; get; }
        /// <summary>
        /// 用户的最近一条微博信息字段
        /// </summary>
        public SinaMStatus status { set; get; }
        #endregion Model

    }
}

