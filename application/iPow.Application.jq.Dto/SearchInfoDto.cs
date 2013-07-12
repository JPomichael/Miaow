using System.Collections.Generic;
using System.Linq;

using Webdiyer.WebControls.Mvc;

namespace iPow.Application.jq.Dto
{
    /// <summary>
    /// 
    /// </summary>
    public class SearchInfoDto
    {
        /// <summary>
        /// Gets or sets the sight info list.
        /// </summary>
        /// <value>The sight info list.</value>
        public PagedList<DefaultSightInfoDto> SightInfoList { get; set; }
    }
}