using System;
using System.Collections.Generic;
namespace Wbm.TencV2SDK.Models
{
    /// <summary>
    /// 微博信息实体类
    /// </summary>
    [Serializable]
    public class TencMTweet
    {
        /// <summary>
        /// 微博内容
        /// </summary>
        public string text { set; get; }
        /// <summary>
        /// 原始内容
        /// </summary>
        public string origtext { set; get; }
        /// <summary>
        /// 微博被转次数
        /// </summary>
        public int count { set; get; }
        /// <summary>
        /// 点评次数
        /// </summary>
        public int mcount { set; get; }
        /// <summary>
        /// 来源
        /// </summary>
        public string from { set; get; }
        /// <summary>
        /// 微博唯一id
        /// </summary>
        public long id { set; get; }
        /// <summary>
        /// 图片url列表
        /// </summary>
        public List<string> image { set; get; }
        /// <summary>
        /// 视频信息
        /// </summary>
        public TencMVideo video { set; get; }
        /// <summary>
        /// 音频信息
        /// </summary>
        public TencMMusic music { set; get; }
        /// <summary>
        /// 发表人帐户名
        /// </summary>
        public string name { set; get; }
        /// <summary>
        /// 用户唯一id，与name相对应
        /// </summary>
        public string openid { set; get; }
        /// <summary>
        /// 发表人昵称
        /// </summary>
        public string nick { set; get; }
        /// <summary>
        /// 是否自已发的的微博，0-不是，1-是
        /// </summary>
        public int self { set; get; }
        /// <summary>
        /// 发表时间
        /// </summary>
        public long timestamp { set; get; }
        /// <summary>
        /// 微博类型，1-原创发表，2-转载，3-私信，4-回复，5-空回，6-提及，7-评论
        /// </summary>
        public int type { set; get; }
        /// <summary>
        /// 发表者头像url
        /// </summary>
        public string head { set; get; }
        /// <summary>
        /// 发表者所在地
        /// </summary>
        public string location { set; get; }
        /// <summary>
        /// 发表者所在地经度
        /// </summary>
        public float jing { set; get; }
        /// <summary>
        /// 发表者所在地纬度
        /// </summary>
        public float wei { set; get; }
        /// <summary>
        /// 国家码（与地区发表时间线一样）
        /// </summary>
        public string country_code { set; get; }
        /// <summary>
        /// 省份码（与地区发表时间线一样）
        /// </summary>
        public string province_code { set; get; }
        /// <summary>
        /// 城市码（与地区发表时间线一样）
        /// </summary>
        public string city_code { set; get; }
        /// <summary>
        /// 是否微博认证用户，0-不是，1-是
        /// </summary>
        public int isvip { set; get; }
        /// <summary>
        /// 发表者地理信息
        /// </summary>
        public string geo { set; get; }
        /// <summary>
        /// 微博状态，0-正常，1-系统删除，2-审核中，3-用户删除，4-根删除（根节点被系统审核删除）
        /// </summary>
        public string status { set; get; }
        /// <summary>
        /// 当type=2时，source即为源tweet
        /// </summary>
        public TencMTweet source { set; get; }
    }

}
/*
 * Author: xusion
 * Created: 2012.06.22
 * Support: http://wobumang.com
 */