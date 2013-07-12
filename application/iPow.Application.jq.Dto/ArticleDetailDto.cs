using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using iPow.Domain.Dto;

namespace iPow.Application.jq.Dto
{
    public class ArticleDetailDto
    {
        /// <summary>
        /// Gets or sets the type of the pic.
        /// 这个游记攻略的类型哈
        /// </summary>
        /// <value>The type of the pic.</value>
        public Sys_ArticleClassDto ArticleType { get; set; }

        /// <summary>
        /// Gets or sets the info.
        /// 这张游记攻略基本信息
        /// </summary>
        /// <value>The info.</value>
        public Sys_ArticleInfoDto ArticleInfo { get; set; }

        /// <summary>
        /// Gets or sets the sight info.
        /// 游记攻略所属景区
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

        //新版的酒店，数据写在页面上，所以不要这个字段了
        //edit by yjihrp 2011.11.25.15.28
        ///// <summary>
        ///// Gets or sets the cir hotel info.
        ///// 当前景区附近的酒店信息前10条
        ///// </summary>
        ///// <value>The cir hotel info.</value>
        //public List<DataSys.Sys_HotelPropertyInfo> CirHotelInfoList { get; set; }
        //end edit by yjihrp 2011.11.25.15.28
    }
}