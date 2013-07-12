using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Webdiyer.WebControls.Mvc;
using iPow.Application.jq.Dto;

namespace iPow.Application.jq.Service
{
    /// <summary>
    /// 
    /// </summary>
    public class SearchService : ISearchService
    {
        /// <summary>
        /// 
        /// </summary>
        private iPow.Application.jq.Service.IAddSortService addSortService = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchService"/> class.
        /// </summary>
        /// <param name="addService">The add service.</param>
        public SearchService(iPow.Application.jq.Service.IAddSortService addService)
        {
            if (addService == null)
            {
                throw new ArgumentNullException("addsortservice is null");
            }
            addSortService = addService;
        }

        /// <summary>
        /// Inits the sight info.
        /// </summary>
        /// <param name="str">The STR.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns></returns>
        public SearchInfoDto GetSearchModel(string str, int? pageIndex, int? pageSize)
        {
            SearchInfoDto data = new SearchInfoDto();
            iPow.Infrastructure.Crosscutting.Comm.Service.SightInfoSearchService sightInfoService = new Infrastructure.Crosscutting.Comm.Service.SightInfoSearchService();
            var sortCity = sightInfoService.GetSearchModel(str);
            data.SightInfoList = AddSortSightInfoByGlobal(sortCity.ToList(), (int)pageIndex, (int)pageSize)
                .AsQueryable().ToPagedList(pageIndex ?? 1, pageSize ?? 10);
            return data;
        }

        /// <summary>
        /// Adds the sort sight info.
        /// 用于添加强制排名景区的 这个是全局性的，最大优先
        /// </summary>
        /// <param name="sourceInfo">The sight.</param>
        /// <param name="pi">Index of the page.</param>
        /// <param name="take">Size of the page.</param>
        /// <returns></returns>
        public List<DefaultSightInfoDto> AddSortSightInfoByGlobal(List<iPow.Infrastructure.Data.DataSys.Sys_SightInfo> sourceInfo, int pi, int take)
        {
            if (sourceInfo == null)
            {
                sourceInfo = new List<iPow.Infrastructure.Data.DataSys.Sys_SightInfo>();
            }
            var data = addSortService.SelectSightInfo(sourceInfo).ToList();
            addSortService.AddSortSightInfoByGlobal(data, pi, take);
            return data;
        }
    }
}
