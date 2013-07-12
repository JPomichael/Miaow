using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using iPow.Application.jq.Dto;
using iPow.Infrastructure.Crosscutting.EntityToDto;

namespace iPow.Application.jq.Service
{
    /// <summary>
    /// 
    /// </summary>
    public class ArticleService : iPow.Application.jq.Service.IArticleService
    {
        /// <summary>
        /// 
        /// </summary>
        private iPow.Domain.Repository.IArticleInfoRepository articleInfoRepository = null;

        /// <summary>
        /// 
        /// </summary>
        private iPow.Domain.Repository.ISightInfoRepository sightInfoRepository = null;

        /// <summary>
        /// 
        /// </summary>
        private iPow.Domain.Repository.IArticleCommRepository articleCommRepository = null;

        /// <summary>
        /// 
        /// </summary>
        private iPow.Domain.Repository.IArticleClassRepository articleClassRepository = null;

        /// <summary>
        /// 
        /// </summary>
        private iPow.Application.jq.Service.ISightInfoService sightInfoService = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ArticleService"/> class.
        /// </summary>
        /// <param name="articleInfo">The article info.</param>
        public ArticleService(iPow.Domain.Repository.IArticleInfoRepository articleInfo,
             iPow.Domain.Repository.ISightInfoRepository sightInfo,
            iPow.Domain.Repository.IArticleCommRepository articleComm,
            iPow.Domain.Repository.IArticleClassRepository articleClass,
            iPow.Application.jq.Service.ISightInfoService sis
            )
        {
            if (articleInfo == null)
            {
                throw new ArgumentNullException("articleInfoRepository is null");
            }
            if (sightInfo == null)
            {
                throw new ArgumentNullException("sightinforepository is null");
            }
            if (articleComm == null)
            {
                throw new ArgumentNullException("articleclassrepository is null");
            }
            if (articleClass == null)
            {
                throw new ArgumentNullException("articlecommrepository is null");
            }
            if (sis == null)
            {
                throw new ArgumentNullException("sightinfoservice is null");
            }
            articleInfoRepository = articleInfo;
            sightInfoRepository = sightInfo;
            articleCommRepository = articleComm;
            articleClassRepository = articleClass;
            sightInfoService = sis;
        }

        /// <summary>
        /// Gets the sight article by new.
        /// </summary>
        /// <param name="sid">The sid.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="take">The take.</param>
        /// <param name="total">The total.</param>
        /// <returns></returns>
        public IQueryable<iPow.Domain.Dto.Sys_ArticleInfoDto> GetSightArticleByNew(int sid, int pageIndex, int take, ref int total)
        {
            var temp = articleInfoRepository.GetList(e => e.SightID == sid).OrderByDescending(e => e.AddTime);
            total = temp.Count();
            var res = temp.Skip(((pageIndex - 1) > 0 ? (pageIndex - 1) : 0) * take).Take(take).AsQueryable();
            return res.ToDto().AsQueryable();
        }

        /// <summary>
        /// Gets the sight article by hot.
        /// </summary>
        /// <param name="sid">The sid.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="take">The take.</param>
        /// <param name="total">The total.</param>
        /// <returns></returns>
        public IQueryable<iPow.Domain.Dto.Sys_ArticleInfoDto> GetSightArticleByHot(int sid, int pageIndex, int take, ref int total)
        {
            var articleList = articleInfoRepository.GetList(e => e.SightID == sid).OrderByDescending(e => e.VisitCount);
            total = articleList.Count();
            var res = articleList.Skip(((pageIndex - 1) > 0 ? (pageIndex - 1) : 0) * take).Take(take).AsQueryable();
            return res.ToDto().AsQueryable();
        }

        /// <summary>
        /// Inits the sight info article.
        /// 添加这个当前地方所有景区的前10条
        /// 推荐的前10条
        /// </summary>
        /// <param name="province">The province.</param>
        /// <param name="take">The take.</param>
        /// <returns></returns>
        public IQueryable<DefaultRightArticleListDto> GetSightArticleDefaultPageByProv(string province, int take)
        {
            IQueryable<DefaultRightArticleListDto> sa = null;
            //选到当前省的所有景区再去得到文章信息
            var currentProvinceSightInfoIds = sightInfoRepository.GetList(e => e.Province == province)
               .OrderBy(e => e.ViCount).Select(e => e.ParkID);

            sa = iPow.Infrastructure.Crosscutting.Comm.Service.UtilityService.db.
                 Sys_ArticleInfo.Where(e => e.IsDelete == 0)
                   .Where(e => currentProvinceSightInfoIds.Contains((int)e.SightID))
                   .OrderByDescending(e => e.VisitCount)
                   .Select(e => new DefaultRightArticleListDto
                   {
                       AddTime = e.AddTime,
                       Id = e.ArticleID,
                       Title = e.Title,
                       Sid = e.SightID
                   })
                   .Take(take)
                   .AsQueryable();

            //不知道为什么下面的代码很慢
            //sa = articleInfoRepository.GetList(e => e.IsDelete == 0)
            //      .Where(e => currentProvinceSightInfoIds.Contains((int)e.SightID))
            //      .OrderByDescending(e => e.VisitCount)
            //      .Take(take)
            //      .Select(e => new DefaultRightArticleListModel
            //      {
            //          AddTime = e.AddTime,
            //          Id = e.ArticleID,
            //          Title = e.Title,
            //          Sid = e.SightID
            //      })
            //      .AsQueryable();
            //var temp = articleInfoRepository.GetList(d => d.IsDelete == 0)
            //    .Where(d => currentProvinceSightInfoIds.Contains((int)d.SightID))
            //    .OrderByDescending(d => d.VisitCount)
            //    .Take(take)
            //     .Select(e => new DefaultRightArticleListModel
            //     {
            //         AddTime = e.AddTime,
            //         Id = e.ArticleID,
            //         Title = e.Title,
            //         Sid = e.SightID
            //     })
            //    .ToList();
            return sa;
        }

        /// <summary>
        /// Gets the comm list.
        /// </summary>
        /// <param name="artId">The art id.</param>
        /// <returns></returns>
        public IQueryable<iPow.Domain.Dto.Sys_ArticleCommDto> GetArticleCommListByArtId(int? artId, int pageIndex, int take, ref int total)
        {
            IQueryable<iPow.Infrastructure.Data.DataSys.Sys_ArticleComm> ac = null;
            var temp = articleCommRepository.GetList(e => e.ArticleID == artId).OrderByDescending(e => e.AddTime);
            total = temp.Count();
            ac = temp.Skip(((pageIndex - 1) > 0 ? (pageIndex - 1) : 0) * take).Take(take).AsQueryable();
            return ac.ToDto().AsQueryable();
        }

        /// <summary>
        /// Gets the article comm single by id.
        /// </summary>
        /// <param name="commId">The comm id.</param>
        /// <returns></returns>
        public iPow.Domain.Dto.Sys_ArticleCommDto GetArticleCommSingleById(int commId)
        {
            var ac = articleCommRepository.GetList(d => d.CommID == commId).FirstOrDefault();
            return ac.ToDto();
        }

        /// <summary>
        /// Gets the article info by id.
        /// </summary>
        /// <param name="artId">The art id.</param>
        /// <returns></returns>
        public iPow.Domain.Dto.Sys_ArticleInfoDto GetArticleSingleById(int? artId)
        {
            var ai = articleInfoRepository.GetList(d => d.ArticleID == artId).FirstOrDefault();
            return ai.ToDto();
        }

        /// <summary>
        /// Inits the pic class.
        /// 这个游记攻略的类型
        /// </summary>
        /// <param name="info">The sys_ pic info.</param>
        public iPow.Domain.Dto.Sys_ArticleClassDto GetArticleClassById(int id)
        {
            var at = articleClassRepository.GetList(d => d.ClassID == id).FirstOrDefault();
            return at.ToDto();
        }

        /// <summary>
        /// Inits the comm list.
        /// 初始化文章列表
        /// </summary>
        /// <param name="artId">The pic id.</param>
        /// <param name="pi">The pi.</param>
        /// <param name="ps">The ps.</param>
        /// <returns></returns>
        public ArticleCommListDto GetArticleCommListById(int? artId, int pi, int ps)
        {
            ArticleCommListDto data = new ArticleCommListDto();
            data.ArticleId = (int)(artId == null ? 0 : artId);
            int total = 0;
            var comm = GetArticleCommListByArtId(artId, pi, ps, ref total);
            data.CommList = new Webdiyer.WebControls.Mvc.PagedList<iPow.Domain.Dto.Sys_ArticleCommDto>(comm, pi, ps, total);
            return data;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PicModel"/> class.
        /// 景区Id号，和游记攻略Id号
        /// </summary>
        /// <param name="sightId">The sight id.</param>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public ArticleDetailDto GetArticleDetailModel(int? sightId, int? id)
        {
            ArticleDetailDto data = new ArticleDetailDto();
            data.ArticleInfo = GetArticleSingleById(id);
            if (data.ArticleInfo != null)
            {
                data.ArticleInfo.VisitCount += 1;
                try
                {
                    articleInfoRepository.Uow.Commit();
                }
                catch
                {
                }
                data.ArticleType = GetArticleClassById(data.ArticleInfo.ClassID);
                var sightDto = sightInfoService.GetSightSingleById(sightId);

                //var sightDto = AutoMapper.Mapper.Map<iPow.Infrastructure.Data.DataSys.Sys_SightInfo
                //    ,iPow.Domain.Dto.Sys_SightInfoDto>(sight);

                data.SightInfo = sightDto;
                if (data.SightInfo != null)
                {
                    data.SightClass = sightInfoService.GetSightClassById(data.SightInfo.ClassID);

                    #region sight cir

                    var sightCir = data.SightInfo.CirParkID;
                    if (sightCir != null)
                    {
                        sightCir = (sightCir.Length > 1 && (sightCir.LastIndexOf(',') == 0)) ? sightCir.Substring(0, sightCir.Length - 1) : sightCir;
                        string[] cirStrArray = sightCir.Split(',');
                        List<int> cirList = new List<int>();
                        for (int i = 0; i < cirStrArray.Length; i++)
                        {
                            int temp = 0;
                            int.TryParse(cirStrArray[i], out temp);
                            if (temp != 0)
                            {
                                cirList.Add(temp);
                            }
                        }
                        data.CirSightInfoList = sightInfoService.GetCirSightListBySight(data.SightInfo, 9);
                    }
                    if (data.CirSightInfoList == null)
                    {
                        data.CirSightInfoList = new List<iPow.Domain.Dto.Sys_SightInfoDto>();
                    }
                    data.CirSightInfoList.Insert(0, data.SightInfo);
                    #endregion

                    #region hotel cir

                    //新版的酒店，数据写在页面上，所以不要这个字段了
                    //edited by yjihrp 2011.11.25.14.54
                    //var hotelCir = data.SightInfo.CirHotelID;
                    //if (hotelCir != null)
                    //{
                    //    hotelCir = (hotelCir.Length > 1 && (hotelCir.LastIndexOf(',') == 0)) ? hotelCir.Substring(0, hotelCir.Length - 1) : hotelCir;
                    //    string[] cirStrArray = hotelCir.Split(',');
                    //    List<int?> cirList = new List<int?>();
                    //    for (int i = 0; i < cirStrArray.Length; i++)
                    //    {
                    //        int temp = 0;
                    //        int.TryParse(cirStrArray[i], out temp);
                    //        if (temp != 0)
                    //        { cirList.Add(temp); }
                    //    }
                    //    data.CirHotelInfoList = Bll.SightInfo.GetCirHotelListBySight(data.SightInfo, 10);
                    //}
                    //end edited by yjihrp 2011.11.25.14.54
                    #endregion
                }
            }
            return data;
        }

        /// <summary>
        /// Contents the split.
        /// 游记攻略 分割
        /// </summary>
        /// <param name="content">The content.</param>
        /// <returns></returns>
        public List<string> ContentSplit(string content)
        {
            List<string> contentList = new List<string>();
            int pageSize = 1000;
            string copy = content + "";
            string add = string.Empty;
            int count = (copy.Length % pageSize) == 0 ? copy.Length / pageSize : copy.Length / pageSize + 1;
            for (int i = 0; i < count; i++)
            {
                if (i == count - 1)
                {
                    add = copy.Substring(i * pageSize, copy.Length - i * pageSize);
                    contentList.Add(add);
                    break;
                }
                add = copy.Substring(i * pageSize, pageSize);
                contentList.Add(add);
            }
            return contentList;
        }

        /// <summary>
        /// Gets the sys article single by id.
        /// </summary>
        /// <param name="artId">The art id.</param>
        /// <returns></returns>
        public Infrastructure.Data.DataSys.Sys_ArticleInfo GetSysArticleSingleById(int? artId)
        {
            var ai = articleInfoRepository.GetList(d => d.ArticleID == artId).FirstOrDefault();
            return ai;
        }
    }
}
