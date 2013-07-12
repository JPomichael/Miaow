using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Webdiyer.WebControls.Mvc;
using iPow.Application.jq.Dto;

namespace iPow.Application.jq.Service
{
    public interface IPageService
    {
        /// <summary>
        /// Toes the pages.
        /// </summary>
        /// <param name="si">The si.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="total">The total.</param>
        /// <returns></returns>
        PagedList<DefaultSightInfoDto> ToPages(List<DefaultSightInfoDto> si, int? pageIndex, int? pageSize, int total);
    }
}
