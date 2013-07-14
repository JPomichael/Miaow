using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Webdiyer.WebControls.Mvc;


namespace Miaow.Application.account.Service
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISightInfoService
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        PagedList<Miaow.Domain.Dto.Sys_SightInfoDto> GetAllSightByCity(string city, int pi, int take);

        Miaow.Domain.Dto.Sys_SightInfoDto GetSightByParkID(int ParkID);

        Miaow.Domain.Dto.Sys_SightInfoDto GetSightLonAndLatByName(string Name);

        Miaow.Domain.Dto.Sys_SightInfoDto GetSightByID(int id);

        Miaow.Domain.Dto.Sys_SightInfoDto GetSightByPlanID(int planId);

        #region 根据当前的SightID 获得周边的Sight And Hotal
        //方法已经定义好但是在Controllers还没有使用  
        //View 里的周边 Sight/Hotal 目前还是用的Google里的
        /// <summary>
        /// 获得周边景区ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        IEnumerable<Miaow.Application.account.Dto.PartSightInfoCirSightDto> GetCirSightIDByID(int Id);

        /// <summary>
        /// 获得周边酒店ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        IEnumerable<Miaow.Application.account.Dto.PartSightInfoCirHotelDto> GetCirHotalIDByID(int Id);
        #endregion

    }
}
