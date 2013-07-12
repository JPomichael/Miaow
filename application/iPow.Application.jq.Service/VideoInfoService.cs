using System;
using System.Collections.Generic;
using System.Linq;

using iPow.Infrastructure.Crosscutting.EntityToDto;

namespace iPow.Application.jq.Service
{
    /// <summary>
    /// 
    /// </summary>
    public class VideoInfoService : IVideoInfoService
    {
        /// <summary>
        /// 
        /// </summary>
        private iPow.Domain.Repository.IVideoInfoRepository videoInfoRepository = null;
        /// <summary>
        /// 
        /// </summary>
        private iPow.Domain.Repository.IVideoCommRepository videoCommRepository = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="VideoInfoService"/> class.
        /// </summary>
        /// <param name="videoInfo">The video info.</param>
        /// <param name="videoComm">The video comm.</param>
        public VideoInfoService(iPow.Domain.Repository.IVideoInfoRepository videoInfo,
            iPow.Domain.Repository.IVideoCommRepository videoComm)
        {
            if (videoInfo == null)
            {
                throw new ArgumentNullException("videoinforepository is null");
            }
            if (videoComm == null)
            {
                throw new ArgumentNullException("videocommrepository is null");
            }
            videoInfoRepository = videoInfo;
            videoCommRepository = videoComm;
        }

        /// <summary>
        /// Gets the sight video list by hot.
        /// </summary>
        /// <param name="sigId">The sig id.</param>
        /// <returns></returns>
        public IQueryable<iPow.Domain.Dto.Sys_VideoInfoDto> GetSightVideoListByHot(int sigId, int pi, int take, ref int total)
        {
            var videoList = videoInfoRepository.GetList(e => e.SightID == sigId && e.IsDelete == 0)
                .OrderByDescending(e => e.PlayCount);
            total = videoList.Count();
            var res = videoList
                .Skip(((pi - 1) > 0 ? (pi - 1) : 0) * take)
                .Take(take).AsQueryable();
            var dto = res.ToDto();
            return dto.AsQueryable();
        }

        /// <summary>
        /// Gets the sight video list by new.
        /// </summary>
        /// <param name="sigId">The sig id.</param>
        /// <returns></returns>
        public IQueryable<iPow.Domain.Dto.Sys_VideoInfoDto> GetSightVideoListByNew(int sigId, int pi, int take, ref int total)
        {
            var videoList = videoInfoRepository.GetList()
                      .Where(e => e.SightID == sigId && e.IsDelete == 0)
                      .OrderByDescending(e => e.AddTime);
            total = videoList.Count();
            var data = videoList
                .Skip(((pi - 1) > 0 ? (pi - 1) : 0) * take)
                .Take(take).AsQueryable();
            var dto = data.ToDto().AsQueryable();
            return dto;
        }

        /// <summary>
        /// Gets the sight video list by score.
        /// </summary>
        /// <param name="sigId">The sig id.</param>
        /// <param name="pi">Index of the page.</param>
        /// <param name="take">The take.</param>
        /// <returns></returns>
        public IQueryable<iPow.Domain.Dto.Sys_VideoInfoDto> GetSightVideoListByScore(int sigId, int pi, int take)
        {
            var data = videoInfoRepository.GetList()
                .Where(e => e.SightID == sigId && e.IsDelete == 0)
                .OrderByDescending(e => e.Score)
                .Skip(((pi - 1) > 0 ? (pi - 1) : 0) * take)
                .Take(take).AsQueryable();
            var dto = data.ToDto().AsQueryable();
            return dto;
        }

        /// <summary>
        /// Gets the video comm all list.
        /// </summary>
        /// <param name="videoId">The video id.</param>
        /// <returns></returns>
        public List<iPow.Domain.Dto.Sys_VideoCommDto> GetVideoCommAllList(int videoId)
        {
            var res = (from e in videoCommRepository.GetList()
                       where e.VideoID == videoId
                       orderby e.AddTime
                       select e).ToList();
            var dto = res.ToDto().ToList();
            return dto;
        }

        /// <summary>
        /// Inits the sight video info.
        /// 随机选取一个视频来给一个景区
        /// </summary>
        /// <param name="sight">The sight.</param>
        public iPow.Domain.Dto.Sys_VideoInfoDto GetVideoRandSingleBySight(int sightId)
        {
            iPow.Infrastructure.Data.DataSys.Sys_VideoInfo vi = null;
            var rand = new Random();
            var temp = (from e in videoInfoRepository.GetList()
                        where e.SightID == sightId && e.IsDelete == 0
                        select e).Count();
            if (temp > 0)
            {
                var toSkip = rand.Next(0, temp);
                vi = (from e in videoInfoRepository.GetList()
                      where e.SightID == sightId && e.IsDelete == 0
                      orderby e.AddTime descending
                      select e).Skip(toSkip).Take(1).FirstOrDefault();
            }
            var dto = vi.ToDto();
            return dto;
        }
    }
}
