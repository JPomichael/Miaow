using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Application.Union.Dto
{
    #region 首页

    /// <summary>
    /// 用了的
    /// 主要用于酒店的首页的热门景区
    /// </summary>
    public class HeadVouchSightInfoDto
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>The city.</value>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the py.
        /// </summary>
        /// <value>The py.</value>
        public string Py { get; set; }

        /// <summary>
        /// Gets or sets the province.
        /// </summary>
        /// <value>The province.</value>
        public string Province { get; set; }

        /// <summary>
        /// Gets or sets the lat.
        /// </summary>
        /// <value>The lat.</value>
        public double? Lat { get; set; }

        /// <summary>
        /// Gets or sets the lon.
        /// </summary>
        /// <value>The lon.</value>
        public double? Lon { get; set; }
    }

    #endregion

}
