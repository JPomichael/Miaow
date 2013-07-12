using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Crosscutting.OAuth.QQ.Models
{
    /// <summary>
    /// 转播或者评论
    /// </summary>
    public class WeiboRePost: MicroBlogBase
    {
        /// <summary>
        /// 转播或评论的信息列表。
        /// </summary>
        public RePost Data {get;set;} 

    }

    /// <summary>
    /// 转播或评论的信息
    /// </summary>
    public class RePost
    {
        /// <summary>
        /// 表示是否还有微博可以拉取。
        /// 0：还有微博可以拉取。
        /// 1：已拉取完。 
        /// </summary>
        public int Hasnext { get; set; }

        /// <summary>
        /// 服务器时间戳
        /// </summary>
        public UInt64 timestamp { get; set; }

        /// <summary>
        /// 总数
        /// </summary>
        public int Totalnum { get; set; }
        /// <summary>
        /// 微博的详细信息列表。
        /// </summary>
        public List<PostInfo> Info { get; set; }
    }

    public class PostInfo
    {
        /// <summary>
        /// 获取的微博的内容。
        /// </summary>
       public string Text{get;set;}    

        /// <summary>
        ///  获取源微博的内容。  
        /// </summary>
        public string Origtext {get;set;}
        /// <summary>
        /// 转播次数。
        /// </summary>
        public int Count  {get;set;}  
        /// <summary>
        ///  评论数。  
        /// </summary>
        public int MCount {get;set;}
        /// <summary>
        /// 微博来源。 
        /// </summary>
        public string From {get;set;} 
        /// <summary>
        /// 微博的ID，用来唯一标识一条微博。 
        /// </summary>
        public UInt64 Id  {get;set;} 
        /// <summary>
        /// 微博中的图片url。 
        /// </summary>
        public string Image  {get;set;} 
        /// <summary>
        /// 发表或转播微博的用户名称。
        /// </summary>
        public string Name  {get;set;}  
        /// <summary>
        /// 发表或转播微博的用户QQ号码对应的ID。 
        /// </summary>
        public string Openid  {get;set;} 
        /// <summary>
        /// 用户昵称。  
        /// </summary>
        public string Nick  {get;set;}
        /// <summary>
        /// 是否为自己发表的微博（0：不是； 1：是）。  
        /// </summary>
        public int Self {get;set;}
        /// <summary>
        /// 发表或转播微博的时间。
        /// </summary>
        public UInt64 Timestamp  {get;set;}  
        /// <summary>
        /// 表示微博的类型。
        /// 1：原创发表；
        /// 2：转播;
        /// 3：私信；
        /// 4：回复；
        /// 5：没有内容的回复；
        /// 6：提及；
        /// 7：评论。 
        /// </summary>
        public int Type {get;set;} 
 
        /// <summary>
        ///  用户的头像url。
        /// </summary>
        public string Head {get;set;}  
        /// <summary>
        /// 用户所在的省市。 
        /// </summary>
        public string Location {get;set;}  
        /// <summary>
        ///  用户所在的国家代码。  
        /// </summary>
        public string Country_code {get;set;}
        /// <summary>
        ///  用户所在的省代码。  
        /// </summary>
        public string Province_code {get;set;}
        /// <summary>
        ///  用户所在的城市代码  
        /// </summary>
        public string City_code  {get;set;}
  
        /// <summary>
        ///  用户是否为微博认证用户（0：不是； 1：是）。
        /// </summary>
        public int Isvip {get;set;}
        /// <summary>
        /// 用户地理信息。  
        /// </summary>
        public string Geo { get; set; }

    }
     
}
