using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iPow.Infrastructure.Data.DataSys;

namespace iPow.Application.account.Service
{
    public interface ITourPlanDetailService
    {
        /// <summary>
        /// 线路里添加景点
        /// </summary>
        /// <returns></returns>
        int AddTourPlanDetail(Sys_TourPlanDetail tour);

        /// <summary>
        /// Check IsExist
        /// </summary>
        /// <param name="PlanID"></param>
        /// <param name="Remark"></param>
        /// <returns></returns>
        bool CheckTourPlanDetailIsExist(int PlanID, int SightID, string Remark);

        /// <summary>
        /// 保持线路单一不重复
        /// </summary>
        /// <param name="parkID"></param>
        /// <param name="PlanID"></param>
        /// <returns></returns>
        bool CheckAddSightByID(int parkID, int PlanID);

        /// <summary>
        ///UserDIY delete sight 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool UpdatesightById(int id);

        /// <summary>
        /// 获取景点名称 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IEnumerable<Dto.PartTourPlanDto> GetSightTitleByID(int id);

        /// <summary>
        /// 计算路线的总共费用
        /// </summary>
        /// <param name="planId"></param>
        /// <returns></returns>
        IEnumerable<Dto.TourPlanDetailDto> GetTourPlanPrice(int planId);

        /// <summary>
        ///获得路线ID下 所有信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        IEnumerable<Dto.TourPlanDetailDto> GetTourPlanByID(int planId);

        /// <summary>
        /// 获取线路详情 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        IEnumerable<Dto.TourPlanDetailDto> GetTourPlanDetailByID(int Id);

        /// <summary>
        /// 线路里有木有景点
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        bool CheckTourPlanIsExistByID(int Id);
    }
}
