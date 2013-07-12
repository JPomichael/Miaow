using System;
using System.Linq;

using iPow.Application.jq.Dto;
using System.Collections.Generic;
using iPow.Application.jq.Service;
using iPow.Infrastructure.Crosscutting.EntityToDto;

namespace iPow.Application.jq.Service
{
    /// <summary>
    /// 
    /// </summary>
    public class PicInfoService : IPicInfoService
    {
        /// <summary>
        /// 
        /// </summary>
        private iPow.Domain.Repository.IPicInfoRepository picInfoRepository = null;

        /// <summary>
        /// 
        /// </summary>
        private iPow.Domain.Repository.IPicCommRepository picCommRepository = null;

        /// <summary>
        /// 
        /// </summary>
        private iPow.Domain.Repository.IPicClassRepository picClassRepository = null;

        /// <summary>
        /// 
        /// </summary>
        private iPow.Application.jq.Service.ISightInfoService sightInfoService = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="PicInfoService"/> class.
        /// </summary>
        /// <param name="picInfo">The pic info.</param>
        /// <param name="picComm">The pic comm.</param>
        /// <param name="picClass">The pic class.</param>
        public PicInfoService(iPow.Domain.Repository.IPicInfoRepository picInfo,
            iPow.Domain.Repository.IPicCommRepository picComm,
            iPow.Domain.Repository.IPicClassRepository picClass,
            iPow.Application.jq.Service.ISightInfoService sis)
        {
            if (picInfo == null)
            {
                throw new ArgumentNullException("picinforepository is null");
            }
            if (picComm == null)
            {
                throw new ArgumentNullException("piccommrepository is null");
            }
            if (picClass == null)
            {
                throw new ArgumentNullException("picclassrepository is null");
            }
            if (sis == null)
            {
                throw new ArgumentNullException("sightinfoservice is null");
            }
            picInfoRepository = picInfo;
            picCommRepository = picComm;
            picClassRepository = picClass;
            sightInfoService = sis;
        }

        /// <summary>
        /// Gets the sight pic by new.
        /// </summary>
        /// <param name="sid">The sid.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="take">The take.</param>
        /// <param name="total">The total.</param>
        /// <returns></returns>
        public IQueryable<iPow.Domain.Dto.Sys_PicInfoDto> GetSightPicByNew(int sid, int pageIndex, int take, ref int total)
        {
            var picList = picInfoRepository.GetList(e => e.ParkID == sid && e.IsDelete == 0)
             .OrderByDescending(e => e.AddTime);
            total = picList.Count();
            var res = picList
                .Skip(((pageIndex - 1) > 0 ? (pageIndex - 1) : 0) * take)
                .Take(take).AsQueryable();
            var data = res.ToDto().AsQueryable();
            return data;
        }


        /// <summary>
        /// Gets the sight pic by hot.
        /// </summary>
        /// <param name="sid">The sid.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="take">The take.</param>
        /// <param name="total">The total.</param>
        /// <returns></returns>
        public IQueryable<iPow.Domain.Dto.Sys_PicInfoDto> GetSightPicByHot(int sid, int pageIndex, int take, ref int total)
        {
            var picList = picInfoRepository.GetList(e => e.ParkID == sid)
                .Where(e => e.IsDelete == 0)
                .OrderByDescending(e => e.ViewCount);
            total = picList.Count();
            var res = picList
                .Skip(((pageIndex - 1) > 0 ? (pageIndex - 1) : 0) * take)
                .Take(take).AsQueryable();
            var data = res.ToDto().AsQueryable();
            return data;
        }

        /// <summary>
        /// Inits the pic info.
        /// </summary>
        /// <param name="picId">The pic id.</param>
        /// <returns></returns>
        public iPow.Domain.Dto.Sys_PicInfoDto GetPicSingleById(int? picId)
        {
            var pic = picInfoRepository.GetList(d => d.PicID == picId).FirstOrDefault();
            var data = pic.ToDto();
            return data;
        }

        /// <summary>
        /// Inits the comm list.
        /// </summary>
        /// <param name="id">The pic id.</param>
        /// <param name="pi">Index of the page.</param>
        /// <param name="take">The take.</param>
        /// <param name="total">The total.</param>
        /// <returns></returns>
        public IQueryable<iPow.Domain.Dto.Sys_PicCommDto> GetPicCommListById(int id, int pi, int take, ref int total)
        {
            IQueryable<iPow.Infrastructure.Data.DataSys.Sys_PicComm> pc = null;
            var temp = picCommRepository.GetList(e => e.PicID == id).OrderByDescending(e => e.AddTime);
            total = temp.Count();
            pc = temp.Skip(((pi - 1) > 0 ? (pi - 1) : 0) * take).Take(take).AsQueryable();
            return pc.ToDto().AsQueryable();
        }

        /// <summary>
        /// Gets the pic class by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public iPow.Domain.Dto.Sys_PicClassDto GetPicClassById(int? id)
        {
            var pc = picClassRepository.GetList(d => d.ClassID == id).FirstOrDefault();
            return pc.ToDto();
        }

        /// <summary>
        /// Inits the pic comm.
        /// 图片的所有评论
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public IQueryable<iPow.Domain.Dto.Sys_PicCommDto> GetPicCommAllListById(int id)
        {
            IQueryable<iPow.Infrastructure.Data.DataSys.Sys_PicComm> pc = picCommRepository.GetList(e => e.PicID == id)
                .OrderByDescending(e => e.AddTime).AsQueryable();
            return pc.ToDto().AsQueryable();
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="GetPicCommListModel"/> class.
        /// </summary>
        /// <param name="picId">The pic id.</param>
        /// <param name="pi">The pi.</param>
        /// <param name="ps">The ps.</param>
        /// <returns></returns>
        public PicCommListDto GetPicCommListModel(int picId, int pi, int ps)
        {
            PicCommListDto data = new PicCommListDto();
            data.PicId = picId;
            int total = 0;
            var comm = GetPicCommListById(picId, pi, ps, ref total);
            data.CommList = new Webdiyer.WebControls.Mvc.PagedList<iPow.Domain.Dto.Sys_PicCommDto>(comm, pi, ps, total);
            return data;
        }


        /// <summary>
        /// Gets the pic detail model.
        /// </summary>
        /// <param name="sightId">The sight id.</param>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public PicDetailDto GetPicDetailModel(int? sightId, int? id)
        {
            var data = new PicDetailDto();
            data.PicInfo = GetPicSingleById(id);
            if (data.PicInfo != null)
            {
                data.PicInfo.ViewCount += 1;
                try
                {
                    picInfoRepository.Uow.Commit();
                }
                catch
                {
                }
                data.PicType = GetPicClassById(data.PicInfo.ClassID);
                data.SightInfo = sightInfoService.GetSightSingleById(sightId);
                if (data.SightInfo != null)
                {
                    data.SightClass = sightInfoService.GetSightClassById(data.SightInfo.ClassID);

                    #region hotel cir
                    //edited by yjihrp 2011.11.25.15.18 用的新版的酒店，逻辑写在页面上了
                    //var cir = data.SightInfo.CirHotelID;
                    //if (cir != null)
                    //{
                    //    cir = (cir.Length > 1 && (cir.LastIndexOf(',') == 0)) ? cir.Substring(0, cir.Length - 1) : cir;
                    //    string[] cirStrArray = cir.Split(',');
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
                    //end edited by yjihrp 2011.11.25.15.18
                    #endregion

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
                            { cirList.Add(temp); }
                        }
                        data.CirSightInfoList = sightInfoService.GetCirSightListBySight(data.SightInfo, 9);
                    }
                    if (data.CirSightInfoList == null)
                    {
                        data.CirSightInfoList = new List<iPow.Domain.Dto.Sys_SightInfoDto>();
                    }
                    data.CirSightInfoList.Insert(0, data.SightInfo);
                    #endregion
                }
            }
            return data;
        }
    }
}
