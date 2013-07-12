using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iPow.Application.Union.Dto
{
    [Serializable]
    public class HotelAroundHotelDto
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
        public long id { get; set; }

        /// <summary>
        /// Gets or sets the hotelname.
        /// </summary>
        /// <value>The hotelname.</value>
        public string hotelname { get; set; }

        /// <summary>
        /// Gets or sets the juli.
        /// </summary>
        /// <value>The juli.</value>
        public string juli { get; set; }

        /// <summary>
        /// Gets or sets the lowprice.
        /// </summary>
        /// <value>The lowprice.</value>
        public double lowprice { get; set; }

        /// <summary>
        /// Gets or sets the haoping.
        /// </summary>
        /// <value>The haoping.</value>
        public int haoping { get; set; }

        /// <summary>
        /// Gets or sets the zhongping.
        /// </summary>
        /// <value>The zhongping.</value>
        public int zhongping { get; set; }

        /// <summary>
        /// Gets or sets the chaping.
        /// </summary>
        /// <value>The chaping.</value>
        public int chaping { get; set; }

        /// <summary>
        /// Gets or sets the xingji.
        /// </summary>
        /// <value>The xingji.</value>
        public int xingji { get; set; }
    }
}