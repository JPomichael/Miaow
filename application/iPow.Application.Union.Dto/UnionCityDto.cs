using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iPow.Application.Union.Dto
{
    [Serializable]
    public class UnionCityDto
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string name { get; set; }

        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        /// <value>The total.</value>
        public int? total { get; set; }

        /// <summary>
        /// Gets or sets the citypy.
        /// </summary>
        /// <value>The citypy.</value>
        public string citypy { get; set; }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
        public int? id { get; set; }

        /// <summary>
        /// Gets or sets the pid.
        /// </summary>
        /// <value>The pid.</value>
        public int? pid { get; set; }

        /// <summary>
        /// Gets or sets the p_name.
        /// </summary>
        /// <value>The p_name.</value>
        public string p_name { get; set; }
    }
}