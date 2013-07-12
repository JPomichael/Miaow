using System.Collections.Generic;
using System.Linq;

using Webdiyer.WebControls.Mvc;
using iPow.Application.jq.Dto;

namespace iPow.Application.jq.Service
{
    /// <summary>
    /// 
    /// </summary>
    public class PageService : IPageService
    {
        /// <summary>
        /// Toes the page list.
        /// </summary>
        /// <param name="si">The si.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns></returns>
        public PagedList<DefaultSightInfoDto> ToPages(List<DefaultSightInfoDto> si, int? pageIndex, int? pageSize, int total)
        {
            //生成分页
            var sightInfo = new PagedList<DefaultSightInfoDto>(si, pageIndex ?? 1, pageSize ?? 10, total);
            return sightInfo;
        }
    }
}