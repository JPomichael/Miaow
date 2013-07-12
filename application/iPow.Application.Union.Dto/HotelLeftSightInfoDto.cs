using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Application.Union.Dto
{
    /// <summary>
    /// 用于左边的
    /// </summary>
    public class HotelLeftSightInfoDto
    {

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the py.
        /// </summary>
        /// <value>The py.</value>
        public string Py { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>The city.</value>
        public string City { get; set; }

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
}
