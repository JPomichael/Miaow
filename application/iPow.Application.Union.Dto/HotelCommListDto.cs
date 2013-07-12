using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iPow.Application.Union.Dto
{
    /// <summary>
    /// 
    /// </summary>
    public class HotelCommListDto
    {
        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        /// <value>The total.</value>
        public int total { get; set; }

        /// <summary>
        /// Gets or sets the totalpage.
        /// </summary>
        /// <value>The totalpage.</value>
        public int totalpage { get; set; }

        /// <summary>
        /// Gets or sets the pg.
        /// </summary>
        /// <value>The pg.</value>
        public int pg { get; set; }

        /// <summary>
        /// Gets or sets the dianping_list.
        /// </summary>
        /// <value>The dianping_list.</value>
        public List<HotelCommDto> dianping_list { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class HotelCommDto
    {
        /// <summary>
        /// Gets or sets the roomname.
        /// </summary>
        /// <value>The roomname.</value>
        public string roomname { get; set; }

        /// <summary>
        /// Gets or sets the uptime.
        /// </summary>
        /// <value>The uptime.</value>
        public string uptime { get; set; }

        /// <summary>
        /// Gets or sets the pingjia.
        /// </summary>
        /// <value>The pingjia.</value>
        public string pingjia { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>
        public string username { get; set; }

        /// <summary>
        /// Gets or sets the yxiang.
        /// </summary>
        /// <value>The yxiang.</value>
        public string yxiang { get; set; }

        /// <summary>
        /// Gets or sets the lx.
        /// </summary>
        /// <value>The lx.</value>
        public string lx { get; set; }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
        public string id { get; set; }

        /// <summary>
        /// Gets or sets the money.
        /// </summary>
        /// <value>The money.</value>
        public string money { get; set; }

        /// <summary>
        /// Gets or sets the img.
        /// </summary>
        /// <value>The img.</value>
        public string img { get; set; }

        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        /// <value>The content.</value>
        public string content { get; set; }

    }
}