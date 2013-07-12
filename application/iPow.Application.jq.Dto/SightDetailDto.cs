using System.Collections.Generic;

using iPow.Domain.Dto;

namespace iPow.Application.jq.Dto
{
    /// <summary>
    /// 
    /// </summary>
    public class SightDetailDto
    {
        /// <summary>
        /// Gets or sets the sight info.
        /// 当前景区信息属性
        /// </summary>
        /// <value>The sight info.</value>
        public Sys_SightInfoDto  SightInfo { get; set; }

        /// <summary>
        /// Gets or sets the cir sight info.
        /// 当前景区的附近景区信息前10条
        /// </summary>
        /// <value>The cir sight info.</value>
        public List<Sys_SightInfoDto> CirSightInfoList { get; set; }



        ///// <summary>
        ///// Gets or sets the cir hotel info.做到页面上，比较容易发改，都做到页面上
        ///// 当前景区附近的酒店信息前10条
        ///// </summary>
        ///// <value>The cir hotel info.</value>
        //public iPow.Union.Models.SearchHotelModel CirHotelInfoList { get; set; }


        //edited by yjihrp 2011.11.24.15.54
        ///// <summary>
        ///// Gets or sets the cir hotel info.
        ///// 当前景区附近的酒店信息前10条
        ///// </summary>
        ///// <value>The cir hotel info.</value>
        //public List<Sys_HotelPropertyInfo> CirHotelInfoList { get; set; }
        //end edited by yjihrp 2011.11.24.15.54

        /// <summary>
        /// Gets or sets the current city info.
        /// 当用户点击城市时，进入一个城市的景区列表时
        /// 用于保存得到当前城市数据
        /// </summary>
        /// <value>The current city info.</value>
        public Sys_CityInfoDto CurrentSightCityInfo { get; set; }

        /// <summary>
        /// Gets or sets the sight class.
        /// 当前景区的分类信息
        /// </summary>
        /// <value>The sight class.</value>
        public Sys_SightClassDto SightClass { get; set; }
    }
}