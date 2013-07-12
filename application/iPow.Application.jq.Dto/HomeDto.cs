using System.Collections.Generic;

using iPow.Domain.Dto;
using Webdiyer.WebControls.Mvc;
using iPow.Infrastructure.Crosscutting.Comm.Dto;

namespace iPow.Application.jq.Dto
{
    /// <summary>
    /// 
    /// </summary>
    public class HomeDto
    {
        #region not mod

        /// <summary>
        /// Gets or sets the location.当前访问地址信息
        /// </summary>
        /// <value>The location.</value>
        public LocationInfoDto LocationSina { get; set; }

        /// <summary>
        /// Gets or sets the localtion city info.
        /// 根据新浪的数据进行本地城市数据查询
        /// </summary>
        /// <value>The localtion city info.</value>
        public Sys_CityInfoDto LocaltionCityInfo { get; set; }

        /// <summary>
        /// Gets or sets the current city info.
        /// 当用户点击城市时，进入一个城市的景区列表时
        /// 用于保存得到当前城市数据
        /// </summary>
        /// <value>The current city info.</value>
        public Sys_CityInfoDto CurrentCityInfo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private List<TopClassDto> topClass = null;

        /// <summary>
        /// Gets or sets the topclass.
        /// 这个地方应该是得到
        /// 访问省的景区分类及每个分类的数量
        /// </summary>
        /// <value>The topclass.</value>
        public List<TopClassDto> TopClass
        {
            get
            {
                return topClass;
            }
            set
            {
                topClass = value;
            }
        }

        /// <summary>
        /// Gets or sets the type of the current.
        /// 用于在点击景区分类时 保存当前的分类信息
        /// 景区的分类ClassID
        /// </summary>
        /// <value>The type of the current.</value>
        public int CurrentClassId
        {
            get
            {
                return this.currentClassId;
            }
            set
            {
                this.currentClassId = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private int currentClassId = 0;

        #endregion

        /// <summary>
        /// Gets or sets the sightinfo.
        /// 默认情况下，从当前的地址里面选景区
        /// 而，在传入了市的话，就从市先，传省的话，就从省选
        /// 还有就是用来显示景区信息
        /// </summary>
        /// <value>The sightinfo.</value>
        public PagedList<DefaultSightInfoDto> SightInfo { get; set; }

    }
}