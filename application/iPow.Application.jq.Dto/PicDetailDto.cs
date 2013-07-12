using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using iPow.Domain.Dto;

namespace iPow.Application.jq.Dto
{
    /// <summary>
    /// 
    /// </summary>
    public class PicDetailDto
    {
        /// <summary>
        /// Gets or sets the type of the pic.
        /// 这个图片的类型哈
        /// </summary>
        /// <value>The type of the pic.</value>
        public Sys_PicClassDto PicType { get; set; }

        /// <summary>
        /// Gets or sets the info.
        /// 这张图片基本信息
        /// </summary>
        /// <value>The info.</value>
        public Sys_PicInfoDto PicInfo { get; set; }

        /// <summary>
        /// Gets or sets the sight info.
        /// 图片所属景区
        /// </summary>
        /// <value>The sight info.</value>
        public Sys_SightInfoDto SightInfo { get; set; }

        /// <summary>
        /// Gets or sets the sight class.
        /// 这个景区的类型
        /// </summary>
        /// <value>The sight class.</value>
        public Sys_SightClassDto SightClass { get; set; }

        /// <summary>
        /// Gets or sets the cir sight info.
        /// 当前景区的附近景区信息前10条
        /// </summary>
        /// <value>The cir sight info.</value>
        public List<Sys_SightInfoDto> CirSightInfoList { get; set; }

        //edited by yjihrp 2011.11.25.15.18
        //用的新版的酒店，逻辑写在页面上了
        ///// <summary>
        ///// Gets or sets the cir hotel info.
        ///// 当前景区附近的酒店信息前10条
        ///// </summary>
        ///// <value>The cir hotel info.</value>
        //public List<DataSys.Sys_HotelPropertyInfo> CirHotelInfoList { get; set; }
        //end edited by yjihrp 2011.11.25.15.18
    }
}