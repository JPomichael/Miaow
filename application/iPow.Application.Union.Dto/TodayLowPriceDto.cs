using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iPow.Application.Union.Dto
{
    [Serializable]
    public class TodayLowPriceDto
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
        public int id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string name { get; set; }

        /// <summary>
        /// Gets or sets the xingji.
        /// </summary>
        /// <value>The xingji.</value>
        public string xingji { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>The price.</value>
        public double price { get; set; }

        /// <summary>
        /// Gets or sets the pic.
        /// </summary>
        /// <value>The pic.</value>
        public string pic { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>The address.</value>
        public string address { get; set; }

        /// <summary>
        /// Gets or sets the cid.
        /// </summary>
        /// <value>The cid.</value>
        public int cid { get; set; }
    }
}