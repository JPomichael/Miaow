﻿using System;
using System.Collections.Generic;
using System.Linq;

using Miaow.Domain.Dto;
using Webdiyer.WebControls.Mvc;
using Miaow.Application.account.Dto;
using Miaow.Infrastructure.Data.DataSys;
using Miaow.Infrastructure.Crosscutting.EntityToDto;

namespace Miaow.Application.account.Service
{
    public class SightInfoService : ISightInfoService
    {
        /// <summary>
        /// 
        /// </summary>
        Miaow.Domain.Repository.ISightVouchItemRepository sightVouchItemRepository;

        /// <summary>
        /// 
        /// </summary>
        Miaow.Domain.Repository.ISightTicketRepository sightTicketRepository;

        /// <summary>
        /// 
        /// </summary>
        Miaow.Domain.Repository.ISightClassRepository sightClassRepository;

        /// <summary>
        /// 
        /// </summary>
        Miaow.Domain.Repository.ISightInfoRepository sightInfoRepository;

        /// <summary>
        /// 
        /// </summary>
        Miaow.Domain.Repository.IPicInfoRepository picInfoRepository;

        /// <summary>
        /// 
        /// </summary>
        Miaow.Domain.Repository.ISightCommRepository sightCommRepository;

        /// <summary>
        /// 
        /// </summary>
        Miaow.Domain.Repository.IHotelPropertyInfoRepository hotelPropertyInfoRepository;

        /// <summary>
        /// 
        /// </summary>
        Miaow.Domain.Repository.ICityInfoRepository cityInfoRepository;

        /// <summary>
        /// 
        /// </summary>
        Miaow.Application.jq.Service.IAddSortService addSortService;

        /// <summary>
        /// 
        /// </summary>
        Miaow.Application.jq.Service.ITopClassService topClassService;

        /// <summary>
        /// 
        /// </summary>
        Miaow.Infrastructure.Crosscutting.Comm.Service.ICityInfoService cityInfoService;

        /// <summary>
        /// 
        /// </summary>
        Miaow.Domain.Repository.ISightInfoSortRepository sightInfoSortRepository;

        /// <summary>
        /// 
        /// </summary>
        Miaow.Domain.Repository.ISightInfoCirHotelRepository sightInfoCirHotelRepository;

        /// <summary>
        /// 
        /// </summary>
        Miaow.Domain.Repository.ISightInfoCirSightRepository sightInfoCirSightRepository;

        Miaow.Domain.Repository.ITourPlanDetailRepository tourPlanDetailRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="SightInfoService"/> class.
        /// </summary>
        public SightInfoService(Miaow.Domain.Repository.ISightVouchItemRepository sightVouch,
             Miaow.Domain.Repository.ISightTicketRepository sightTicket,
             Miaow.Domain.Repository.ISightClassRepository sightClass,
             Miaow.Domain.Repository.ISightInfoRepository sightInfo,
             Miaow.Domain.Repository.IPicInfoRepository picInfo,
             Miaow.Domain.Repository.ISightCommRepository sightComm,
             Miaow.Domain.Repository.IHotelPropertyInfoRepository hotelPropertyInfo,
             Miaow.Domain.Repository.ICityInfoRepository cityInfo,
             Miaow.Application.jq.Service.IAddSortService addSort,
             Miaow.Application.jq.Service.ITopClassService topClass,
             Miaow.Infrastructure.Crosscutting.Comm.Service.ICityInfoService ciService,
             Miaow.Domain.Repository.ISightInfoSortRepository sightInfoSort,
             Miaow.Domain.Repository.ISightInfoCirHotelRepository sightInfoCirHotel,
             Miaow.Domain.Repository.ISightInfoCirSightRepository sightInfoCirSight,
             Miaow.Domain.Repository.ITourPlanDetailRepository tourPlanDetail)
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
        public PagedList<Miaow.Domain.Dto.Sys_SightInfoDto> GetAllSightByCity(string city, int pi, int take)
        {
            var res = sightInfoRepository.GetList(d => d.City == city)
                .OrderByDescending(e => e.ViCount).AsEnumerable();
            int total = res.Count();
            //if (res.Count() < 15)
            //    pi = pi - 1;
            //pi = (pi - 1) > 0 ? (pi - 1) : 0;
            res = res.Skip(((pi - 1) > 0 ? (pi - 1) : 0) * take).Take(take).AsEnumerable();
            var temp = new Webdiyer.WebControls.Mvc.PagedList<Miaow.Domain.Dto.Sys_SightInfoDto>(res.ToDto(), pi, take, total);
            return temp;
        }

        /// <summary>
        /// 用于点击块儿 添加景点 不是真的添加 只是用于视觉表面上的
        /// </summary>
        /// <param name="ParkID"></param>
        /// <returns></returns>
        public Miaow.Domain.Dto.Sys_SightInfoDto GetSightByParkID(int ParkID)
        {
            var res = sightInfoRepository.GetList(e => e.ParkID == ParkID).First();
            return res.ToDto();
        }

        /// <summary>
        /// 用于点击景点 即可获得经纬来在地图上Show
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public Miaow.Domain.Dto.Sys_SightInfoDto GetSightLonAndLatByName(string Name)
        {
            var res = sightInfoRepository.GetList(e => e.Title == Name).First();
            return res.ToDto();
        }

        public Miaow.Domain.Dto.Sys_SightInfoDto GetSightByID(int id)
        {
            var res = sightInfoRepository.GetList(e => e.ParkID == id).First();
            return res.ToDto();
        }

        public Miaow.Domain.Dto.Sys_SightInfoDto GetSightByPlanID(int planId)
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




