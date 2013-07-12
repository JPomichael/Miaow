using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using iPow.Infrastructure.Data.DataSys;

namespace iPow.Application.Union.Dto
{
    //这个酒店周边的交通
    public class HotelTrafficDto
    {
        /// <summary>
        /// Gets or sets the hotel id.
        /// </summary>
        /// <value>The hotel id.</value>
        public int HotelId { get; set; }

        /// <summary>
        /// Gets or sets the hotel area code.
        /// </summary>
        /// <value>The hotel area code.</value>
        public string HotelAreaCode { get; set; }

        /// <summary>
        /// Gets or sets the sight info.
        /// </summary>
        /// <value>The sight info.</value>
        public List< iPow.Domain.Dto.Sys_SightInfoDto> SightInfo { get; set; }

        /// <summary>
        /// Gets or sets the hotel info.
        /// </summary>
        /// <value>The hotel info.</value>
        public List<iPow.Application.Union.Dto.HotelInfoDto> HotelInfo { get; set; }

        /// <summary>
        /// Gets or sets the sigle hotel info.
        /// </summary>
        /// <value>The sigle hotel info.</value>
        public iPow.Application.Union.Dto.HotelInfoDto SigleHotelInfo { get; set; }
    }
}