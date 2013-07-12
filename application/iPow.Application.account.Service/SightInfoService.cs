using System;
using System.Collections.Generic;
using System.Linq;

using iPow.Domain.Dto;
using Webdiyer.WebControls.Mvc;
using iPow.Application.account.Dto;
using iPow.Infrastructure.Data.DataSys;
using iPow.Infrastructure.Crosscutting.EntityToDto;

namespace iPow.Application.account.Service
{
    public class SightInfoService : ISightInfoService
    {
        /// <summary>
        /// 
        /// </summary>
        iPow.Domain.Repository.ISightVouchItemRepository sightVouchItemRepository;

        /// <summary>
        /// 
        /// </summary>
        iPow.Domain.Repository.ISightTicketRepository sightTicketRepository;

        /// <summary>
        /// 
        /// </summary>
        iPow.Domain.Repository.ISightClassRepository sightClassRepository;

        /// <summary>
        /// 
        /// </summary>
        iPow.Domain.Repository.ISightInfoRepository sightInfoRepository;

        /// <summary>
        /// 
        /// </summary>
        iPow.Domain.Repository.IPicInfoRepository picInfoRepository;

        /// <summary>
        /// 
        /// </summary>
        iPow.Domain.Repository.ISightCommRepository sightCommRepository;

        /// <summary>
        /// 
        /// </summary>
        iPow.Domain.Repository.IHotelPropertyInfoRepository hotelPropertyInfoRepository;

        /// <summary>
        /// 
        /// </summary>
        iPow.Domain.Repository.ICityInfoRepository cityInfoRepository;

        /// <summary>
        /// 
        /// </summary>
        iPow.Application.jq.Service.IAddSortService addSortService;

        /// <summary>
        /// 
        /// </summary>
        iPow.Application.jq.Service.ITopClassService topClassService;

        /// <summary>
        /// 
        /// </summary>
        iPow.Infrastructure.Crosscutting.Comm.Service.ICityInfoService cityInfoService;

        /// <summary>
        /// 
        /// </summary>
        iPow.Domain.Repository.ISightInfoSortRepository sightInfoSortRepository;

        /// <summary>
        /// 
        /// </summary>
        iPow.Domain.Repository.ISightInfoCirHotelRepository sightInfoCirHotelRepository;

        /// <summary>
        /// 
        /// </summary>
        iPow.Domain.Repository.ISightInfoCirSightRepository sightInfoCirSightRepository;

        iPow.Domain.Repository.ITourPlanDetailRepository tourPlanDetailRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="SightInfoService"/> class.
        /// </summary>
        public SightInfoService(iPow.Domain.Repository.ISightVouchItemRepository sightVouch,
             iPow.Domain.Repository.ISightTicketRepository sightTicket,
             iPow.Domain.Repository.ISightClassRepository sightClass,
             iPow.Domain.Repository.ISightInfoRepository sightInfo,
             iPow.Domain.Repository.IPicInfoRepository picInfo,
             iPow.Domain.Repository.ISightCommRepository sightComm,
             iPow.Domain.Repository.IHotelPropertyInfoRepository hotelPropertyInfo,
             iPow.Domain.Repository.ICityInfoRepository cityInfo,
             iPow.Application.jq.Service.IAddSortService addSort,
             iPow.Application.jq.Service.ITopClassService topClass,
             iPow.Infrastructure.Crosscutting.Comm.Service.ICityInfoService ciService,
             iPow.Domain.Repository.ISightInfoSortRepository sightInfoSort,
             iPow.Domain.Repository.ISightInfoCirHotelRepository sightInfoCirHotel,
             iPow.Domain.Repository.ISightInfoCirSightRepository sightInfoCirSight,
             iPow.Domain.Repository.ITourPlanDetailRepository tourPlanDetail)
        {
            if (sightVouch == null)
            {
                throw new ArgumentNullException("sightvouchitem is null");
            }
            if (sightTicket == null)
            {
                throw new ArgumentNullException("sightticketrepository is null");
            }
            if (sightClass == null)
            {
                throw new ArgumentNullException("sightclassrepository is null");
            }
            if (sightInfo == null)
            {
                throw new ArgumentNullException("sightinforepository is null");
            }
            if (picInfo == null)
            {
                throw new ArgumentNullException("picinforepository is null");
            }
            if (sightComm == null)
            {
                throw new ArgumentNullException("sightCommRepository is null");
            }
            if (hotelPropertyInfo == null)
            {
                throw new ArgumentNullException("hotelpropertyinforepository is null");
            }
            if (cityInfo == null)
            {
                throw new ArgumentNullException("cityinforepository is null");
            }
            if (addSort == null)
            {
                throw new ArgumentNullException("addsortservice is null");
            }
            if (topClass == null)
            {
                throw new ArgumentNullException("topclassservice is null");
            }
            if (ciService == null)
            {
                throw new ArgumentNullException("cityinfoservice is null");
            }
            if (sightInfoSort == null)
            {
                throw new ArgumentNullException("sightInfoSortRepository is null");
            }
            if (sightInfoCirHotel == null)
            {
                throw new ArgumentNullException("sightInfoSortRepository is null");
            }
            if (sightInfoCirSight == null)
            {
                throw new ArgumentNullException("sightInfoSortRepository is null");
            }
            if (tourPlanDetail == null)
            {
                throw new ArgumentNullException("tourPlanDetailRepository in null");
            }
            sightVouchItemRepository = sightVouch;
            sightTicketRepository = sightTicket;
            sightClassRepository = sightClass;
            sightInfoRepository = sightInfo;
            picInfoRepository = picInfo;
            sightCommRepository = sightComm;
            hotelPropertyInfoRepository = hotelPropertyInfo;
            cityInfoRepository = cityInfo;
            addSortService = addSort;
            topClassService = topClass;
            cityInfoService = ciService;
            sightInfoSortRepository = sightInfoSort;
            sightInfoCirHotelRepository = sightInfoCirHotel;
            sightInfoCirSightRepository = sightInfoCirSight;
            tourPlanDetailRepository = tourPlanDetail;
        }


        // add by JPomichael
        /// <summary>
        /// 根据City 查询该城市下的景点  + Pageing
        /// </summary>
        /// <param name="sid"></param>
        /// <returns></returns>
        public PagedList<iPow.Domain.Dto.Sys_SightInfoDto> GetAllSightByCity(string city, int pi, int take)
        {
            var res = sightInfoRepository.GetList(d => d.City == city)
                .OrderByDescending(e => e.ViCount).AsEnumerable();
            int total = res.Count();
            //if (res.Count() < 15)
            //    pi = pi - 1;
            //pi = (pi - 1) > 0 ? (pi - 1) : 0;
            res = res.Skip(((pi - 1) > 0 ? (pi - 1) : 0) * take).Take(take).AsEnumerable();
            var temp = new Webdiyer.WebControls.Mvc.PagedList<iPow.Domain.Dto.Sys_SightInfoDto>(res.ToDto(), pi, take, total);
            return temp;
        }

        /// <summary>
        /// 用于点击块儿 添加景点 不是真的添加 只是用于视觉表面上的
        /// </summary>
        /// <param name="ParkID"></param>
        /// <returns></returns>
        public iPow.Domain.Dto.Sys_SightInfoDto GetSightByParkID(int ParkID)
        {
            var res = sightInfoRepository.GetList(e => e.ParkID == ParkID).First();
            return res.ToDto();
        }

        /// <summary>
        /// 用于点击景点 即可获得经纬来在地图上Show
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public iPow.Domain.Dto.Sys_SightInfoDto GetSightLonAndLatByName(string Name)
        {
            var res = sightInfoRepository.GetList(e => e.Title == Name).First();
            return res.ToDto();
        }

        public iPow.Domain.Dto.Sys_SightInfoDto GetSightByID(int id)
        {
            var res = sightInfoRepository.GetList(e => e.ParkID == id).First();
            return res.ToDto();
        }

        public iPow.Domain.Dto.Sys_SightInfoDto GetSightByPlanID(int planId)
        {
            var res = sightInfoRepository.GetList(e => e.ParkID == planId).First();
            return res.ToDto();
        }

        #region 获得周边景点和酒店

        /// <summary>
        /// 获得周边景区ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public IEnumerable<PartSightInfoCirSightDto> GetCirSightIDByID(int Id)
        {
            var res = sightInfoCirSightRepository.GetList(e => e.SightId == Id).Where(e =>e.State==true)
                .Select(e => new PartSightInfoCirSightDto { CirId = e.CirId });
            return res;
        }

        /// <summary>
        /// 获得周边酒店ID
        /// 目前以为 酒店的数据库信息不全 所以前台搁置为空
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public IEnumerable<PartSightInfoCirHotelDto> GetCirHotalIDByID(int Id)
        {
            var res = sightInfoCirHotelRepository.GetList(e => e.SightId == Id).Where(e => e.State ==true)
                .Select(e => new PartSightInfoCirHotelDto { HotelId = e.HotelId });
            return res;
        }

        #endregion
    }
}




