using System;
using System.Collections.Generic;
namespace Wbm.TencV2SDK.Models
{
    /// <summary>
    /// 用户信息实体类
    /// </summary>
    [Serializable]
    public class TencMUser
    {
        /// <summary>
        /// 出生天
        /// </summary>
        public int birth_day { set; get; }
        /// <summary>
        /// 出生月
        /// </summary>
        public int birth_month { set; get; }
        /// <summary>
        /// 出生年
        /// </summary>
        public int birth_year { set; get; }
        /// <summary>
        /// 城市id
        /// </summary>
        public string city_code { set; get; }
        /// <summary>
        /// 公司信息
        /// </summary>
        //public TencMComp comp { set; get; }
        /// <summary>
        /// 国家id
        /// </summary>
        public string country_code { set; get; }
        /// <summary>
        /// 教育信息
        /// </summary>
        //public List<TencMEdu> edu { set; get; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string email { set; get; }
        /// <summary>
        /// 听众数
        /// </summary>
        public string fansnum { set; get; }
        /// <summary>
        /// 收藏数
        /// </summary>
        public string favnum { set; get; }
        /// <summary>
        /// 头像url
        /// </summary>
        public string head { set; get; }
        /// <summary>
        /// 家乡所在城市id
        /// </summary>
        public string homecity_code { set; get; }
        /// <summary>
        /// 家乡所在国家id
        /// </summary>
        public string homecountry_code { set; get; }
        /// <summary>
        /// 个人主页
        /// </summary>
        public string homepage { set; get; }
        /// <summary>
        /// 家乡所在省id
        /// </summary>
        public string homeprovince_code { set; get; }
        /// <summary>
        /// 家乡所在城镇id
        /// </summary>
        public string hometown_code { set; get; }
        /// <summary>
        /// 收听的人数
        /// </summary>
        public string idolnum { set; get; }
        /// <summary>
        /// 行业id
        /// </summary>
        public string industry_code { set; get; }
        /// <summary>
        /// 个人介绍
        /// </summary>
        public string introduction { set; get; }
        /// <summary>
        /// 是否企业机构
        /// </summary>
        public string isent { set; get; }
        /// <summary>
        /// 是否在当前用户的黑名单中，0-不是，1-是
        /// </summary>
        public string ismyblack { set; get; }
        /// <summary>
        /// 是否是当前用户的听众，0-不是，1-是
        /// </summary>
        public string ismyfans { set; get; }
        /// <summary>
        /// 是否是当前用户的偶像，0-不是，1-是
        /// </summary>
        public string ismyidol { set; get; }
        /// <summary>
        /// 是否实名认证，0-老用户，1-已实名认证，2-未实名认证
        /// </summary>
        public string isrealname { set; get; }
        /// <summary>
        /// 是否认证用户
        /// </summary>
        public string isvip { set; get; }
        /// <summary>
        /// 所在地
        /// </summary>
        public string location { set; get; }
        /// <summary>
        /// 互听好友数
        /// </summary>
        public string mutual_fans_num { set; get; }
        /// <summary>
        /// 用户帐户名
        /// </summary>
        public string name { set; get; }
        /// <summary>
        /// 用户昵称
        /// </summary>
        public string nick { set; get; }
        /// <summary>
        /// 用户唯一id，与name相对应
        /// </summary>
        public string openid { set; get; }
        /// <summary>
        /// 地区id
        /// </summary>
        public string province_code { set; get; }
        /// <summary>
        /// 注册时间
        /// </summary>
        public string regtime { set; get; }
        /// <summary>
        /// 是否允许所有人给当前用户发私信，0-仅有偶像，1-名人+听众，2-所有人	
        /// </summary>
        public string send_private_flag { set; get; }
        /// <summary>
        /// 用户性别，1-男，2-女，0-未填写
        /// </summary>
        public int sex { set; get; }
        /// <summary>
        /// 标签
        /// </summary>
        public List<TencMTag> tag { set; get; }
        /// <summary>
        /// 最近的一条原创微博信息
        /// </summary>
        public List<TencMTweet> tweetinfo { set; get; }
        /// <summary>
        /// 发表的微博数
        /// </summary>
        public int tweetnum { set; get; }
        /// <summary>
        /// 认证信息	
        /// </summary>
        public string verifyinfo { set; get; }


    }

}
/*
 * Author: xusion
 * Created: 2012.06.22
 * Support: http://wobumang.com
 */