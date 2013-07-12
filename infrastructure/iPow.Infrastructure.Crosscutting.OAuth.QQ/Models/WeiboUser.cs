using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Crosscutting.OAuth.QQ.Models
{
    /// <summary>
    /// 微博的用户数据
    /// </summary>
    public class WeiboUser: MicroBlogBase
    {
        /// <summary>
        /// 登录用户的详细信息列表。
        /// </summary>
        public UserInfo Data  {get;set;}  

    }

    /// <summary>
    /// 用户数据
    /// </summary>
    public class UserInfo
    {
        /// <summary>
        /// 登录用户的帐号名。
        /// </summary>
        public string Name {get;set;}   
        /// <summary>
        /// 登录用户的唯一ID，与QQ号码一一对应。
        /// </summary>
        public string Openid  {get;set;}  

        /// <summary>
        /// 登录用户昵称。
        /// </summary>
        public string Nick {get;set;}
        /// <summary>
        /// 登录用户头像url。 
        /// </summary>
        public string Head  {get;set;} 

        /// <summary>
        ///  登录用户所在地。 
        /// </summary>
        public string Location {get;set;} 
        /// <summary>
        /// 登录用户是否为微博认证用户（0：不是； 1：是）。
        /// </summary>
        public int Isvip  {get;set;}
        /// <summary>
        /// 登录用户是否为企业机构（0：不是； 1：是）。
        /// </summary>
        public int Isent {get;set;} 
        /// <summary>
        /// 登录用户的个人介绍。
        /// </summary>
        public string Introduction  {get;set;}  
        /// <summary>
        /// 认证信息。
        /// </summary>
        public string Verifyinfo  {get;set;}  
        /// <summary>
        /// 登录用户出生年。
        /// </summary>
        public int Birth_year  {get;set;}  
        /// <summary>
        /// 登录用户出生月份。
        /// </summary>
        public int Birth_month  {get;set;}  
        /// <summary>
        /// 登录用户出生日。
        /// </summary>
        public int Birth_day  {get;set;}  
        /// <summary>
        /// 登录用户所在的国家代码。 
        /// </summary>
        public int Country_code  {get;set;} 
        /// <summary>
        /// 登录用户所在的省代码。
        /// </summary>
        public int Province_code  {get;set;}  
        /// <summary>
        /// 登录用户所在的城市代码。
        /// </summary>
        public int City_code {get;set;}
        /// <summary>
        ///   登录用户性别（1：男； 2：女； 3：未知）。
        /// </summary>
        public int Sex {get;set;}  
        /// <summary>
        ///  登录用户听众数。 
        /// </summary>
        public int Fansnum {get;set;} 
        /// <summary>
        /// 登录用户收听的人数。
        /// </summary>
        public int Idolnum  {get;set;}  
        /// <summary>
        /// 登录用户发表的微博数。  
        /// </summary>
        public int Tweetnum  {get;set;}
        /// <summary>
        /// 标签信息列表
        /// </summary>
        public List<UserTag> Tag  {get;set;}  
        /// <summary>
        /// 登录用户教育信息列表。
        /// </summary>
        public List<UserEdu> Edu  {get;set;}  
        /// <summary>
        /// 用户注册的邮箱。 
        /// </summary>
        public string Email  {get;set;}
    }

    /// <summary>
    /// 个人标签
    /// </summary>
    public class UserTag
    {
        /// <summary>
        /// 个人标签id
        /// </summary>
        public UInt64 Id {get;set;}
        /// <summary>
        ///  标签名。
        /// </summary>
        public string name {get;set;}
    }

    public class UserEdu
    {
        /// <summary>
        /// 学历记录ID。 
        /// </summary>
       public int Id {get;set;}  
        /// <summary>
        /// 入学年。  
        /// </summary>
        public int Year  {get;set;}
        /// <summary>
        /// 学校ID
        /// </summary>
        public int Schoolid {get;set;}
  
        /// <summary>
        ///  院系id。 
        /// </summary>
        public int Departmentid {get;set;} 
        /// <summary>
        /// 学历级别。
        /// </summary>
        public int Level { get; set; }
    }
}
