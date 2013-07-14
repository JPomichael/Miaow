using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Crosscutting.OAuth.QQ.Models
{
    /// <summary>
    /// QQ空间的个人资料
    /// </summary>
    public class User : QzoneBase
    {
        /// <summary>
        /// 昵称 
        /// </summary>
        public string Nickname { get; set; }

        /// <summary>
        /// 头像URL
        /// </summary>
        public string Figureurl { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// 标识用户是否为黄钻用户（0：非黄钻用户； 1：黄钻用户） 
        /// </summary>
        public int Vip { get; set; }

        /// <summary>
        ///  黄钻等级。如果不是黄钻用户，则返回0 
        /// </summary>
        public int Level { get; set; }

    }
}
