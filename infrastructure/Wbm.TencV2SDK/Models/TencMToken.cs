using System;
namespace Wbm.TencV2SDK.Models
{
    /// <summary>
    /// 错误信息实体类
    /// </summary>
    [Serializable]
    public class TencMToken : TencMError
    {
        /// <summary>
        /// 访问令牌 
        /// </summary>
        public string access_token { set; get; }
        /// <summary>
        /// 过期时间
        /// </summary>
        public int expires_in { set; get; }
        /// <summary>
        /// 过期剩余时间
        /// </summary>
        public int remind_in { set; get; }
        /// <summary>
        /// 个人描述
        /// </summary>
        public string refresh_token { set; get; }
        /// <summary>
        /// 用户的ID，与QQ号码一一对应。
        /// </summary>
        public string openid { set; get; }
    }
}
/*
 * Author: xusion
 * Created: 2012.06.22
 * Support: http://wobumang.com
 */