using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Webdiyer.WebControls.Mvc;

namespace iPow.Application.Union.Dto
{
    /// <summary>
    /// ui model
    /// </summary>
    public class SearchInfoDto
    {
        /// <summary>
        /// Gets or sets the hotel base info.
        /// </summary>
        /// <value>The hotel base info.</value>
        public PagedList<iPow.Application.Union.Dto.SearchHotelDetailDto> HotelBaseInfo { get; set; }

        /// <summary>
        /// Gets or sets the bide.
        /// </summary>
        /// <value>The bide.</value>
        public string Bide { get; set; }

        /// <summary>
        /// Gets or sets the come time.
        /// </summary>
        /// <value>The come time.</value>
        public DateTime? ComeTime { get; set; }

        /// <summary>
        /// Gets or sets the leave time.
        /// </summary>
        /// <value>The leave time.</value>
        public DateTime? LeaveTime { get; set; }

        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        /// <value>The key.</value>
        public string Key { get; set; }
    }


    /// <summary>
    /// bll model
    /// </summary>
    public class SearchHotelDto
    {
        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        /// <value>The total.</value>
        public int total { get; set; }

        /// <summary>
        /// Gets or sets the page.
        /// </summary>
        /// <value>The page.</value>
        public int page { get; set; }

        /// <summary>
        /// Gets or sets the hotel_list.
        /// </summary>
        /// <value>The hotel_list.</value>
        public List<SearchHotelDetailDto> hotel_list { get; set; }
    }

    /// <summary>
    /// bll model
    /// </summary>
    public class SearchHotelDetailDto
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
        public long id { get; set; }

        /// <summary>
        /// Gets or sets the rid.
        /// </summary>
        /// <value>The rid.</value>
        public int rid { get; set; }

        /// <summary>
        /// Gets or sets the hotelname.
        /// </summary>
        /// <value>The hotelname.</value>
        public string hotelname { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>The price.</value>
        public double price { get; set; }

        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        /// <value>The content.</value>
        public string content { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>The address.</value>
        public string address { get; set; }

        /// <summary>
        /// Gets or sets the xingji.
        /// </summary>
        /// <value>The xingji.</value>
        public int xingji { get; set; }

        /// <summary>
        /// Gets or sets the JDLX.
        /// </summary>
        /// <value>The JDLX.</value>
        public string jdlx { get; set; }

        /// <summary>
        /// Gets or sets the chain.
        /// </summary>
        /// <value>The chain.</value>
        public int chain { get; set; }

        /// <summary>
        /// Gets or sets the JDWZ.
        /// </summary>
        /// <value>The JDWZ.</value>
        public int jdwz { get; set; }

        /// <summary>
        /// Gets or sets the jdwz_name.
        /// </summary>
        /// <value>The jdwz_name.</value>
        public string jdwz_name { get; set; }

        /// <summary>
        /// Gets or sets the chian_name.
        /// </summary>
        /// <value>The chian_name.</value>
        public string chian_name { get; set; }

        /// <summary>
        /// Gets or sets the juli.
        /// </summary>
        /// <value>The juli.</value>
        public double juli { get; set; }

        /// <summary>
        /// Gets or sets the pic.
        /// </summary>
        /// <value>The pic.</value>
        public string pic { get; set; }

        /// <summary>
        /// Gets or sets the totaldd.
        /// </summary>
        /// <value>The totaldd.</value>
        public double totaldd { get; set; }

        /// <summary>
        /// Gets or sets the totaldp.
        /// </summary>
        /// <value>The totaldp.</value>
        public double totaldp { get; set; }

        /// <summary>
        /// Gets or sets the elong_sci.
        /// </summary>
        /// <value>The elong_sci.</value>
        public string elong_sci { get; set; }

        /// <summary>
        /// Gets or sets the cuxiao.
        /// </summary>
        /// <value>The cuxiao.</value>
        public string cuxiao { get; set; }

        /// <summary>
        /// Gets or sets the vedio.
        /// </summary>
        /// <value>The vedio.</value>
        public int vedio { get; set; }

        /// <summary>
        /// Gets or sets the ditie.
        /// </summary>
        /// <value>The ditie.</value>
        public string ditie { get; set; }

        /// <summary>
        /// Gets or sets the myd.
        /// </summary>
        /// <value>The myd.</value>
        public string myd { get; set; }

        /// <summary>
        /// Gets or sets the hp.
        /// </summary>
        /// <value>The hp.</value>
        public string hp { get; set; }

        /// <summary>
        /// Gets or sets the zp.
        /// </summary>
        /// <value>The zp.</value>
        public string zp { get; set; }

        /// <summary>
        /// Gets or sets the cp.
        /// </summary>
        /// <value>The cp.</value>
        public string cp { get; set; }

        /// <summary>
        /// Gets or sets the pos.
        /// </summary>
        /// <value>The pos.</value>
        public string pos { get; set; }

    }
}