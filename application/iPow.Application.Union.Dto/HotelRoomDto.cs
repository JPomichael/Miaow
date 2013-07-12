using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iPow.Application.Union.Dto
{
    /// <summary>
    /// 
    /// </summary>
    public class HotelRoomDto
    {
        /// <summary>
        /// Gets or sets the hs.
        /// </summary>
        /// <value>The hs.</value>
        public int Hs { get; set; }

        /// <summary>
        /// Gets or sets the hotel id.
        /// </summary>
        /// <value>The hotel id.</value>
        public string HotelId { get; set; }

        /// <summary>
        /// Gets or sets the week list.
        /// </summary>
        /// <value>The week list.</value>
        public string WeekList { get; set; }

        /// <summary>
        /// Gets or sets the day list.
        /// </summary>
        /// <value>The day list.</value>
        public string DayList { get; set; }

        /// <summary>
        /// Gets or sets the elong ID.
        /// </summary>
        /// <value>The elong ID.</value>
        public string ElongID { get; set; }

        /// <summary>
        /// Gets or sets the way.
        /// </summary>
        /// <value>The way.</value>
        public string Way { get; set; }

        /// <summary>
        /// Gets or sets the room.
        /// </summary>
        /// <value>The room.</value>
        public List<RoomDetailModel> Room { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class RoomDetailModel
    {
        /// <summary>
        /// Gets or sets the hs.
        /// </summary>
        /// <value>The hs.</value>
        public string hs { get; set; }

        /// <summary>
        /// Gets or sets the hs_list.
        /// </summary>
        /// <value>The hs_list.</value>
        public string hs_list { get; set; }

        /// <summary>
        /// Gets or sets the room id.
        /// </summary>
        /// <value>The room id.</value>
        public string RoomId { get; set; }

        /// <summary>
        /// Gets or sets the name of the room.
        /// </summary>
        /// <value>The name of the room.</value>
        public string RoomName { get; set; }

        /// <summary>
        /// Gets or sets the type of the bed.
        /// </summary>
        /// <value>The type of the bed.</value>
        public string BedType { get; set; }

        /// <summary>
        /// Gets or sets the money.
        /// </summary>
        /// <value>The money.</value>
        public string Money { get; set; }

        /// <summary>
        /// Gets or sets the room type id.
        /// </summary>
        /// <value>The room type id.</value>
        public string RoomTypeId { get; set; }

        /// <summary>
        /// Gets or sets the rate plan id.
        /// </summary>
        /// <value>The rate plan id.</value>
        public string RatePlanId { get; set; }

        /// <summary>
        /// Gets or sets the name of the rate plan.
        /// </summary>
        /// <value>The name of the rate plan.</value>
        public string RatePlanName { get; set; }

        /// <summary>
        /// Gets or sets the net.
        /// </summary>
        /// <value>The net.</value>
        public string Net { get; set; }

        /// <summary>
        /// Gets or sets the type img.
        /// </summary>
        /// <value>The type img.</value>
        public string TypeImg { get; set; }

        /// <summary>
        /// Gets or sets the img.
        /// </summary>
        /// <value>The img.</value>
        public string Img { get; set; }

        /// <summary>
        /// Gets or sets the price list.
        /// </summary>
        /// <value>The price list.</value>
        public string PriceList { get; set; }

        /// <summary>
        /// Gets or sets the jun jia.
        /// </summary>
        /// <value>The jun jia.</value>
        public string JunJia { get; set; }

        /// <summary>
        /// Gets or sets the add bed.
        /// </summary>
        /// <value>The add bed.</value>
        public string AddBed { get; set; }

        /// <summary>
        /// Gets or sets the dan bao.
        /// </summary>
        /// <value>The dan bao.</value>
        public string DanBao { get; set; }

        /// <summary>
        /// Gets or sets the add value.
        /// </summary>
        /// <value>The add value.</value>
        public string AddValue { get; set; }

        /// <summary>
        /// Gets or sets the cu xiao.
        /// </summary>
        /// <value>The cu xiao.</value>
        public string CuXiao { get; set; }

        /// <summary>
        /// Gets or sets the area.
        /// </summary>
        /// <value>The area.</value>
        public string Area { get; set; }

        /// <summary>
        /// Gets or sets the room floor.
        /// </summary>
        /// <value>The room floor.</value>
        public string RoomFloor { get; set; }

        /// <summary>
        /// Gets or sets the desc.
        /// </summary>
        /// <value>The desc.</value>
        public string Desc { get; set; }

        /// <summary>
        /// Gets or sets the note.
        /// </summary>
        /// <value>The note.</value>
        public string Note { get; set; }

        /// <summary>
        /// Gets or sets the detail.
        /// </summary>
        /// <value>The detail.</value>
        public string Detail { get; set; }

        /// <summary>
        /// Gets or sets the extra money.
        /// </summary>
        /// <value>The extra money.</value>
        public string ExtraMoney { get; set; }

    }
}