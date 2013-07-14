using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Crosscutting.OAuth.QQ.Models
{
    /// <summary>
    /// 验证登录的用户是否为某个认证空间的粉丝
    /// </summary>
    public  class CheckPageResult: QzoneBase
    {
        /// <summary>
        /// 1 表示登录的用户是该认证空间的粉丝；
        /// 0 表示登录的用户没有关注该认证空间。
        /// </summary>
        public int Isfans { get; set; }
    }
}
