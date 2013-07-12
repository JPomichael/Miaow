using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iPow.Application.Union.Dto
{
    /// <summary>
    /// 
    /// </summary>
    public class UnionConfigDto
    {
        /*初始化主要参数*/
        /// <summary>
        /// //如果是在二级目录，请填写"/名称/，并修改httpd.ini的伪静态规则"
        /// </summary>
        /// <value>A.</value>
        public string a { get; set; }

        /// <summary>
        /// Gets or sets the web path.
        /// </summary>
        /// <value>The web path.</value>
        public string WebPath { get; set; }

        /// <summary>
        /// Gets or sets the name of the web.
        /// </summary>
        /// <value>The name of the web.</value>
        public string WebName { get; set; }

        /// <summary>
        /// //接口地址,此处不需要修改
        /// </summary>
        /// <value>The base URL.</value>
        public string BaseUrl { get; set; }

        /// <summary>
        /// //是否支持伪静态
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is static page; otherwise, <c>false</c>.
        /// </value>
        public bool IsStaticPage { get; set; }

        /// <summary>
        /// //此处不需要修改
        /// </summary>
        /// <value>The type of the ding dan.</value>
        public string DingDanType { get; set; }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        /// <value>The version.</value>
        public string Version { get; set; }

        /// <summary>
        /// //缓存时间10天，都是一些基本不怎么改变的数据
        /// </summary>
        /// <value>The cache day.</value>
        public string CacheDay { get; set; }

        /// <summary>
        /// //[推广ID] 请到http://union.128uu.com/user/apimain.aspx页面获取，必填
        /// </summary>
        /// <value>The agent id.</value>
        public string AgentId { get; set; }

        /// <summary>
        /// //[接口KEY] 请到http://union.128uu.com/user/apimain.aspx页面获取，必填
        /// </summary>
        /// <value>The agent md.</value>
        public string AgentMd { get; set; }
    }
}
