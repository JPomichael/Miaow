using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace iPow.Application.jq.Service
{
    /// <summary>
    /// 
    /// </summary>
    public interface IVideoInfoService
    {
        /// <summary>
        /// Gets the sight video list by hot.
        /// </summary>
        /// <param name="sigId">The sig id.</param>
        /// <param name="pi">Index of the page.</param>
        /// <param name="take">The take.</param>
        /// <param name="total">The total.</param>
        /// <returns></returns>
        IQueryable< iPow.Domain.Dto.Sys_VideoInfoDto> GetSightVideoListByHot(int sigId, int pi, int take, ref int total);

        /// <summary>
        /// Gets the sight video list by new.
        /// </summary>
        /// <param name="sigId">The sig id.</param>
        /// <param name="pi">Index of the page.</param>
        /// <param name="take">The take.</param>
        /// <param name="total">The total.</param>
        /// <returns></returns>
        IQueryable<iPow.Domain.Dto.Sys_VideoInfoDto> GetSightVideoListByNew(int sigId, int pi, int take, ref int total);

        /// <summary>
        /// Gets the sight video list by score.
        /// </summary>
        /// <param name="sigId">The sig id.</param>
        /// <param name="pi">Index of the page.</param>
        /// <param name="take">The take.</param>
        /// <returns></returns>
        IQueryable<iPow.Domain.Dto.Sys_VideoInfoDto> GetSightVideoListByScore(int sigId, int pi, int take);

        /// <summary>
        /// Gets the video comm all list.
        /// </summary>
        /// <param name="videoId">The video id.</param>
        /// <returns></returns>
        List<iPow.Domain.Dto.Sys_VideoCommDto> GetVideoCommAllList(int videoId);

        /// <summary>
        /// Gets the video rand single by sight.
        /// </summary>
        /// <param name="sightId">The sight id.</param>
        /// <returns></returns>
        iPow.Domain.Dto.Sys_VideoInfoDto GetVideoRandSingleBySight(int sightId);
    }
}
