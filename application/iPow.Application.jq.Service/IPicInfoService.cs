using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using iPow.Application.jq.Dto;

namespace iPow.Application.jq.Service
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPicInfoService
    {
        /// <summary>
        /// Gets the pic class by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        iPow.Domain.Dto.Sys_PicClassDto GetPicClassById(int? id);

        /// <summary>
        /// Gets the pic comm all list by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        IQueryable<iPow.Domain.Dto.Sys_PicCommDto> GetPicCommAllListById(int id);

        /// <summary>
        /// Gets the pic comm list by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="pi">Index of the page.</param>
        /// <param name="take">The take.</param>
        /// <param name="total">The total.</param>
        /// <returns></returns>
        IQueryable<iPow.Domain.Dto.Sys_PicCommDto> GetPicCommListById(int id, int pi, int take, ref int total);

        /// <summary>
        /// Gets the pic single by id.
        /// </summary>
        /// <param name="picId">The pic id.</param>
        /// <returns></returns>
        iPow.Domain.Dto.Sys_PicInfoDto GetPicSingleById(int? picId);

        /// <summary>
        /// Gets the sight pic by hot.
        /// </summary>
        /// <param name="sid">The sid.</param>
        /// <param name="pi">Index of the page.</param>
        /// <param name="take">The take.</param>
        /// <param name="total">The total.</param>
        /// <returns></returns>
        IQueryable<iPow.Domain.Dto.Sys_PicInfoDto> GetSightPicByHot(int sid, int pi, int take, ref int total);

        /// <summary>
        /// Gets the sight pic by new.
        /// </summary>
        /// <param name="sid">The sid.</param>
        /// <param name="pi">Index of the page.</param>
        /// <param name="take">The take.</param>
        /// <param name="total">The total.</param>
        /// <returns></returns>
        IQueryable<iPow.Domain.Dto.Sys_PicInfoDto> GetSightPicByNew(int sid, int pi, int take, ref int total);


        /// <summary>
        /// Gets the pic comm list model.
        /// </summary>
        /// <param name="picId">The pic id.</param>
        /// <param name="pi">The pi.</param>
        /// <param name="ps">The ps.</param>
        /// <returns></returns>
        PicCommListDto GetPicCommListModel(int picId, int pi, int ps);

        /// <summary>
        /// Gets the pic detail model.
        /// </summary>
        /// <param name="sightId">The sight id.</param>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        PicDetailDto GetPicDetailModel(int? sightId, int? id);
    }
}
