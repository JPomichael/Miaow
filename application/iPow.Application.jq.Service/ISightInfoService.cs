using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Webdiyer.WebControls.Mvc;
using iPow.Application.jq.Dto;
using iPow.Infrastructure.Crosscutting.Comm.Dto;

namespace iPow.Application.jq.Service
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISightInfoService
    {
        /// <summary>
        /// Gets the cir hotel list by sight.
        /// </summary>
        /// <param name="sight">The sight.</param>
        /// <param name="take">The take.</param>
        /// <returns></returns>
        List<iPow.Domain.Dto.Sys_HotelPropertyInfoDto> GetCirHotelListBySight(iPow.Domain.Dto.Sys_SightInfoDto sight, int take);

        /// <summary>
        /// Gets the cir sight list by sight.
        /// </summary>
        /// <param name="sight">The sight.</param>
        /// <param name="take">The take.</param>
        /// <returns></returns>
        List<iPow.Domain.Dto.Sys_SightInfoDto> GetCirSightListBySight(iPow.Domain.Dto.Sys_SightInfoDto sight, int take);

        /// <summary>
        /// Gets the sight class by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        iPow.Domain.Dto.Sys_SightClassDto GetSightClassById(int id);

        /// <summary>
        /// Gets the sight comm list.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="pi">Index of the page.</param>
        /// <param name="take">The take.</param>
        /// <param name="total">The total.</param>
        /// <returns></returns>
        IQueryable<iPow.Domain.Dto.Sys_SightCommDto> GetSightCommList(int id, int pi, int take, ref int total);

        /// <summary>
        /// Gets the sight comm page list by sid.
        /// </summary>
        /// <param name="sightId">The sight id.</param>
        /// <param name="pi">Index of the page.</param>
        /// <param name="take">Default size of the page.</param>
        /// <returns></returns>
        PagedList<iPow.Domain.Dto.Sys_SightCommDto> GetSightCommPageListBySid(int sightId, int? pi, int? take);

        /// <summary>
        /// Gets the sight default pic.
        /// </summary>
        /// <param name="si">The si.</param>
        /// <returns></returns>
        List<iPow.Domain.Dto.Sys_PicInfoDto> GetSightDefaultPic(PagedList<DefaultSightInfoDto> si);

        /// <summary>
        /// Gets the sight list by province or city.
        /// </summary>
        /// <param name="li">The li.</param>
        /// <param name="currentClassId">The current class id.</param>
        /// <param name="province">The province.</param>
        /// <param name="city">The city.</param>
        /// <param name="type">The type.</param>
        /// <param name="pi">Index of the page.</param>
        /// <param name="take">Size of the page.</param>
        /// <param name="total">The total.</param>
        /// <param name="sortCount">The sort count.</param>
        /// <param name="topList">The top list.</param>
        /// <returns></returns>
        List<DefaultSightInfoDto> GetSightListByProvinceOrCity(LocationInfoDto li, ref  int currentClassId, string province,
            string city, int? type, int? pi, int? take, ref int total,
            ref int sortCount, ref List<Dto.TopClassDto> topList);

        /// <summary>
        /// Gets the sight list by ticket.
        /// </summary>
        /// <param name="prov">The prov.</param>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <param name="pi">Index of the page.</param>
        /// <param name="take">Size of the page.</param>
        /// <param name="total">The total.</param>
        /// <param name="sortCount">The sort count.</param>
        /// <param name="topList">The top list.</param>
        /// <returns></returns>
        List<DefaultSightInfoDto> GetSightListByTicket(string prov, int? start, int? end,
          int pi, int take, ref int total, ref int sortCount,
            ref  List<Dto.TopClassDto> topList);

        /// <summary>
        /// Gets the sight pic count.
        /// </summary>
        /// <param name="si">The si.</param>
        /// <returns></returns>
        Dictionary<int, int> GetSightPicCount(PagedList<DefaultSightInfoDto> si);

        /// <summary>
        /// Gets the sight vouch item.
        /// </summary>
        /// <param name="sid">The sid.</param>
        /// <returns></returns>
        IQueryable<iPow.Domain.Dto.Sys_SightVouchItemDto> GetSightVouchItem(int sid);

        /// <summary>
        /// Toes the page list.
        /// </summary>
        /// <param name="info">The info.</param>
        /// <param name="pi">Index of the page.</param>
        /// <param name="take">The take.</param>
        /// <returns></returns>
        List<DefaultSightInfoDto> ToPageList(IEnumerable<DefaultSightInfoDto> info, int pi, int take);

        /// <summary>
        /// Toes the page list.
        /// </summary>
        /// <param name="info">The info.</param>
        /// <param name="pi">Index of the page.</param>
        /// <param name="take">The take.</param>
        /// <param name="total">The total.</param>
        /// <returns></returns>
        PagedList<DefaultSightInfoDto> ToPageList(IEnumerable<DefaultSightInfoDto> info, int pi, int take, int total);

        /// <summary>
        /// Gets the sight ticket info.
        /// </summary>
        /// <param name="sid">The sid.</param>
        /// <returns></returns>
        IQueryable<iPow.Domain.Dto.Sys_SightTicketDto> GetSightTicketInfo(int sid);

        /// <summary>
        /// Gets the sight single by id.
        /// </summary>
        /// <param name="sightId">The sight id.</param>
        /// <returns></returns>
        iPow.Domain.Dto.Sys_SightInfoDto GetSightSingleById(int? sightId);

        /// <summary>
        /// Gets the sys sight single by id.
        /// </summary>
        /// <param name="sightId">The sight id.</param>
        /// <returns></returns>
        iPow.Infrastructure.Data.DataSys.Sys_SightInfo GetSysSightSingleById(int? sightId);

        /// <summary>
        /// Gets the sight detail model.
        /// </summary>
        /// <param name="sid">The sid.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <returns></returns>
        SightDetailDto GetSightDetailModel(int? sid, int? pageIndex);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        IQueryable<iPow.Domain.Dto.Sys_SightInfoDto> GetSightSingleByCity(string city);
    }
}
