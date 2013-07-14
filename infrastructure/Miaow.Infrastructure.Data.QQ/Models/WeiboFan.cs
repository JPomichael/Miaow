using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Crosscutting.OAuth.QQ.Models
{
    /// <summary>
    /// 用户的粉丝
    /// </summary>
    public class WeiboFan : MicroBlogBase
    {
        /// <summary>
        /// 听众的列表信息。
        /// </summary>
        public UserData Data { get; set; }
    }

    /// <summary>
    /// 用户的听众
    /// </summary>
    public class WeiboIdol : MicroBlogBase
    {
        /// <summary>
        /// 听众的列表信息。
        /// </summary>
        public UserData Data { get; set; }
    }

    /// <summary>
    /// 微博用户数据
    /// </summary>
    public class UserData
    {
        /// <summary>
        /// 服务器时间戳。 
        /// </summary>
        public Int64 Timestamp { get; set; }
        /// <summary>
        ///  表示是否还有听众信息可以拉取。
        ///  0：还有听众信息可以拉取。
        ///  1：已拉取完。 
        /// </summary>
        public int Hasnext { get; set; }

        /// <summary>
        /// 听众的详细信息列
        /// </summary>
        public List<Fan> Info { get; set; }      
    }

    /// <summary>
    /// 用户
    /// </summary>
    public class Fan
    {
        /// <summary>
        /// 听众的账户名。
        /// </summary>
        public string Name {get;set;}  
        /// <summary>
        /// 听众的唯一ID，与QQ号码一一对应。  
        /// </summary>
        public string Openid  {get;set;}
        /// <summary>
        ///  听众的昵称。
        /// </summary>
        public string Nick   {get;set;}
        /// <summary>
        /// 听众头像url。  
        /// </summary>
        public string Head {get;set;}
        /// <summary>
        /// 听众性别（0：表示未填写； 1：男； 2：女）。 
        /// </summary>
        public string Sex  {get;set;} 
        /// <summary>
        /// 听众所在地。 
        /// </summary>
        public string Location  {get;set;} 
        ///// <summary>
        ///// 听众最近发表的一条微博。
        ///// </summary>
        public List<Tweet> Tweet {get;set;}    
 
        /// <summary>
        ///  听众数。  
        /// </summary>
        public int Fansnum {get;set;}
        /// <summary>
        ///  收听的人数。  
        /// </summary>
        public int Idolnum {get;set;} 

        /// <summary>
        /// 是否为用户收听的人（0：不是； 1：是）。  
        /// </summary>
        public bool Isidol {get;set;}

        /// <summary>
        /// 听众是否为微博认证用户（0：不是； 1：是）。  
        /// </summary>
        public int Isvip  {get;set;}

        /// <summary>
        /// 标签信息列表
        /// </summary>
        public List<UserTag> Tag { get; set; }  

    }


    public class  Tweet
    {
        /// <summary>
        /// 微博的来源。 
        /// </summary>
        public string From  {get;set;} 
        /// <summary>
        /// 微博ID，用来唯一标识一条微博。  
        /// </summary>
        public UInt64 Id  {get;set;}

        /// <summary>
        /// 微博的内容。 
        /// </summary>
        public string Text { get; set; } 
        /// <summary>
        /// 发表微博的时间。
        /// </summary>
        public UInt64 Timestamp  {get;set;}
    }
}
