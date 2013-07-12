using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wbm.TencV2SDK.Entitys
{
    /// <summary>
    /// APPKey实体
    /// </summary>
    public class AppEntity
    {
        /// <summary>
        /// 名字，只是做判断使用，但不能重复
        /// </summary>
        public string AppName { set; get; }

        /// <summary>
        /// App Key
        /// </summary>
        public string AppKey { set; get; }

        /// <summary>
        /// App Secret
        /// </summary>
        public string AppSecret { set; get; }

        /// <summary>
        /// Redirect Uri
        /// </summary>
        public string RedirectUri { set; get; }
         /// <summary>
        /// Scope
        /// </summary>
        public string Scope { set; get; }
   }
}
/*
 * Author: xusion
 * Created: 2012.06.22
 * Support: http://wobumang.com
 */