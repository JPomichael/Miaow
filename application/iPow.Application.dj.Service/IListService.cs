using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Application.dj.Service
{
    /// <summary>
    /// 
    /// </summary>
    public interface IListService
    {
        /// <summary>
        /// Gets the list type mid tour plan list by type id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="pi">Index of the page.</param>
        /// <param name="take">The take.</param>
        /// <param name="total">The total.</param>
        /// <returns></returns>
        IQueryable<Dto.ListTypeMidTourPlanDto> GetListTypeMidTourPlanListByTypeId(int id, int pi, int take, ref int total);

        /// <summary>
        /// Gets the list type mid sight list by tour plan id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        IQueryable<Dto.ListTypeMidSightDto> GetListTypeMidSightListByTourPlanId(int id);

        /// <summary>
        /// Gets the tour class default pic by class id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        List<string> GetTourClassDefaultPicByClassId(int id);

        /// <summary>
        /// Gets the sight or hotel id list.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        List<int?> GetSightOrHotelIdList(int id, string type);

        /// <summary>
        /// Gets the tour default pic by plan id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        List<string> GetTourDefaultPicByPlanId(int id);

        //  k此方法用于从index页面传来的参数 即City查询出该城市下所有拥有的景点   
        //  Date：2012/3/29
        IQueryable<Dto.ListTypeMidTourPlanDto> GetTourListByCity(string city, int pi, int take, ref int total);
    }

}
