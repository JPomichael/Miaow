using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iPow.Domain.Dto;
using Webdiyer.WebControls.Mvc;

namespace iPow.Application.dj.Service
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITourPlanService
    {
        /// <summary>
        /// Gets the hot tour plan list.
        /// </summary>
        /// <param name="top">The top.</param>
        /// <returns></returns>
        IQueryable<iPow.Domain.Dto.Sys_TourPlanDto> GetHotTourPlanList(int top);

        /// <summary>
        /// Gets the top tour plan city.
        /// </summary>
        /// <param name="top">The top.</param>
        /// <returns></returns>
        IQueryable<Dto.TopTourCityDto> GetTopTourPlanCity(int top);

        /// <summary>
        /// Gets the tour class.
        /// </summary>
        /// <returns></returns>
        IQueryable<iPow.Domain.Dto.Sys_TourClassDto> GetTourClass();

        /// <summary>
        /// Gets the tour plan list by city.
        /// </summary>
        /// <param name="city">The city.</param>
        /// <param name="take">   take.</param>
        /// <returns></returns>
        IQueryable<Dto.TopTourPlanDto> GetTourPlanListByCity(string city, int take);

        //使用城市和分页展示旅游路线
        IQueryable<Dto.TopTourPlanDto> GetTourPlanListByCity(string city, int pi, int take, ref int total);

        /// <summary>
        /// Gets the hotel default pic by hotel id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        string GetHotelDefaultPicByHotelId(int id);

        /// <summary>
        /// Gets the map hotel info by tour id and day.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="day">The day.</param>
        /// <returns></returns>
        IQueryable<Dto.MapHotelInfoDto> GetMapHotelInfoByTourIdAndDay(int id, int day);

        /// <summary>
        /// Gets the map sight info by tour id and day.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="day">The day.</param>
        /// <returns></returns>
        IQueryable<Dto.MapSightInfoDto> GetMapSightInfoByTourIdAndDay(int id, int day);

        /// <summary>
        /// Gets the map union hotel info by tour id and day.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="day">The day.</param>
        /// <returns></returns>
        iPow.Application.Union.Dto.SearchHotelDto GetMapUnionHotelInfoByTourIdAndDay(int id, int day);

        Sys_TourPlanDto GetTourPlanByName(string Name);
        /// <summary>
        /// Gets the tour detail hotel by id and day.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="day">The day.</param>
        /// <returns></returns>
        IQueryable<Dto.TourDetailHotelDto> GetTourDetailHotelByIdAndDay(int id, int day);

        /// <summary>
        /// Gets the tour detail sight by id and day.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="day">The day.</param>
        /// <returns></returns>
        IQueryable<Dto.TourDetailSightDto> GetTourDetailSightByIdAndDay(int id, int day);

        /// <summary>
        /// Gets the tour detail top by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        Dto.TourDetailTopDto GetTourDetailTopById(int id);

        /// <summary>
        /// Gets the sight or hotel id list.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="type">The type.</param>
        /// <param name="day">The day.</param>
        /// <returns></returns>
        List<int?> GetSightOrHotelIdList(int id, string type, int day);

        /// <summary>
        /// User DIY Tourk
        /// </summary>
        /// <param name="tour"></param>
        iPow.Infrastructure.Data.DataSys.Sys_TourPlan AddTourPlan(iPow.Infrastructure.Data.DataSys.Sys_TourPlan tour);

        /// <summary>
        /// GetUserDIYByID
        /// </summary>
        /// <param name="planID"></param>
        /// <returns></returns>
        iPow.Infrastructure.Data.DataSys.Sys_TourPlan GetTourPlanByID(int planID);

        /// <summary>
        /// Check UserDIYIsExist
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="PlanTitle"></param>
        /// <returns></returns>
        bool CheckTourPlanIsExist(int userId, string PlanTitle);

        iPow.Infrastructure.Data.DataSys.Sys_TourPlan UpdateTourPlan(iPow.Infrastructure.Data.DataSys.Sys_TourPlan tour);

        PagedList<Sys_TourPlanDto> GetTourPlanListByUserId(int userId, int pi, int take);

        PagedList<Sys_TourPlanDto> GetTourPlanList(int pi, int take);

        /// <summary>
        /// 用来推荐热门线路
        /// </summary>
        /// <returns name="Top 10"></returns>
        IEnumerable<Sys_TourPlanDto> GetHotPlan();

    }
}
