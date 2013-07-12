using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Webdiyer.WebControls.Mvc;

namespace iPow.Application.dj.Dto
{
    /// <summary>
    /// 
    /// </summary>
    public class HomeDto
    {
        /// <summary>
        /// Gets or sets the tour plans.
        /// </summary>
        /// <value>The tour plans.</value>
        public PagedList<TopTourPlanDto> TopTourPlans { get; set; }

        /// <summary>
        /// Gets or sets the top tour citys.
        /// </summary>
        /// <value>The top tour citys.</value>
        public List<TopTourCityDto> TopTourCitys { get; set; }
    }

    #region  首页

    /// <summary>
    /// 一个城市的推荐路线
    /// </summary>
    public class TopTourPlanDto
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// 路线名
        /// </summary>
        /// <value>The title.</value>
        public string PlanTitle { get; set; }

        /// <summary>
        /// Gets or sets the total money.
        /// 全程价格
        /// </summary>
        /// <value>The total money.</value>
        public double? PlanTotalMoney { get; set; }

        /// <summary>
        /// Gets or sets the days.
        /// 全程天数
        /// </summary>
        /// <value>The days.</value>
        public int? Days { get; set; }

        /// <summary>
        /// Gets or sets the reason.
        /// 推荐理由
        /// </summary>
        /// <value>The reason.</value>
        public string TopReason { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// 用户名
        /// </summary>
        /// <value>The name of the user.</value>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the vi count.
        /// 路线访问量
        /// </summary>
        /// <value>The vi count.</value>
        public int? ViCount { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// 线路分类ID号
        /// </summary>
        /// <value>The type.</value>
        public int? ClassId { get; set; }
    }

    /// <summary>
    /// 推荐城市列表
    /// </summary>
    public class TopTourCityDto
    {
        /// <summary>
        /// Gets or sets the id.
        /// 自增Id号
        /// </summary>
        /// <value>The id.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the city.
        /// 城市名
        /// </summary>
        /// <value>The name of the city.</value>
        public string CityName { get; set; }
    }

    /// <summary>
    /// 首页中的热门酒店
    /// </summary>
    public class HotelInfoDto
    {
        /// <summary>
        /// Gets or sets the name.
        /// 酒店名
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the id.
        /// 酒店自增ID号
        /// </summary>
        /// <value>The id.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the hotel id.
        /// 酒店ID号
        /// </summary>
        /// <value>The hotel id.</value>
        public int? HotelId { get; set; }

        /// <summary>
        /// Gets or sets the min price.
        /// 酒店最低价
        /// </summary>
        /// <value>The min price.</value>
        public string MinPrice { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// 地址
        /// </summary>
        /// <value>The address.</value>
        public string Address { get; set; }

    }
    #endregion

    #region 分类列表页

    /// <summary>
    /// 分类列表
    /// </summary>
    public class ListTypeMidTourPlanDto : TopTourPlanDto
    {

        /// <summary>
        /// Gets or sets the add time.
        /// </summary>
        /// <value>The add time.</value>
        public DateTime? AddTime { get; set; }

        /// <summary>
        /// Gets or sets the sight list.
        /// </summary>
        /// <value>The sight list.</value>
        //  public IQueryable<ListTypeMidSight> SightList { get; set; }

    }

    /// <summary>
    /// 分类列表用到的途径景点
    /// </summary>
    public class ListTypeMidSightDto
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the py.
        /// </summary>
        /// <value>The py.</value>
        public string Py { get; set; }
    }

    #endregion

    #region 路线详细页

    /// <summary>
    /// 路线详细页头部
    /// </summary>
    public class TourDetailTopDto
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// 路线名
        /// </summary>
        /// <value>The title.</value>
        public string PlanTitle { get; set; }

        /// <summary>
        /// Gets or sets the total money.
        /// 全程价格
        /// </summary>
        /// <value>The total money.</value>
        public double? PlanTotalMoney { get; set; }

        /// <summary>
        /// Gets or sets the days.
        /// 全程天数
        /// </summary>
        /// <value>The days.</value>
        public int? Days { get; set; }
    }

    #region Content

    /// <summary>
    /// 
    /// </summary>
    public class TourDetailBaseDto
    {
        /// <summary>
        /// Gets or sets the plan id.
        /// </summary>
        /// <value>The plan id.</value>
        public int PlanId { get; set; }

        /// <summary>
        /// Gets or sets the detail id.
        /// </summary>
        /// <value>The detail id.</value>
        public int DetailId { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class TourDetailSightDto : TourDetailBaseDto
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
        public int SightId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the py.
        /// </summary>
        /// <value>The py.</value>
        public string Py { get; set; }

        /// <summary>
        /// Gets or sets the show hours.
        /// </summary>
        /// <value>The show hours.</value>
        public string ShowHours { get; set; }

        /// <summary>
        /// Gets or sets the op to time.
        /// </summary>
        /// <value>The op to time.</value>
        public string OpToTime { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>The address.</value>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the ticket.
        /// </summary>
        /// <value>The ticket.</value>
        public int? Ticket { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the lat.
        /// </summary>
        /// <value>The lat.</value>
        public double? Lat { get; set; }

        /// <summary>
        /// Gets or sets the long.
        /// </summary>
        /// <value>The long.</value>
        public double? Long { get; set; }

    }

    /// <summary>
    /// 
    /// </summary>
    public class TourDetailHotelDto : TourDetailBaseDto
    {
        /// <summary>
        /// Gets or sets the hotel id.
        /// </summary>
        /// <value>The hotel id.</value>
        public int? HotelId { get; set; }

        /// <summary>
        /// Gets or sets the identity id.
        /// </summary>
        /// <value>The identity id.</value>
        public int IdentityId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the min price.
        /// </summary>
        /// <value>The min price.</value>
        public double? MinPrice { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>The address.</value>
        public string Address { get; set; }

    }

    public class TourDetailTrafficDto : TourDetailBaseDto
    {

    }
    #endregion


    /// <summary>
    /// 
    /// </summary>
    public class MapSightInfoDto
    {

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
        public int SightId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the py.
        /// </summary>
        /// <value>The py.</value>
        public string Py { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>The address.</value>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the ticket.
        /// </summary>
        /// <value>The ticket.</value>
        public int? Ticket { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the lat.
        /// </summary>
        /// <value>The lat.</value>
        public double? Lat { get; set; }

        /// <summary>
        /// Gets or sets the long.
        /// </summary>
        /// <value>The long.</value>
        public double? Long { get; set; }

        /// <summary>
        /// Gets or sets the img count.
        /// </summary>
        /// <value>The img count.</value>
        public int ImgCount { get; set; }

        /// <summary>
        /// Gets or sets the comm count.
        /// </summary>
        /// <value>The comm count.</value>
        public int CommCount { get; set; }

    }

    /// <summary>
    /// 
    /// </summary>
    public class MapHotelInfoDto
    {
        /// <summary>
        /// Gets or sets the identity id.
        /// </summary>
        /// <value>The identity id.</value>
        public int IdentityId { get; set; }

        /// <summary>
        /// Gets or sets the hotel id.
        /// </summary>
        /// <value>The hotel id.</value>
        public int? HotelId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the lat.
        /// </summary>
        /// <value>The lat.</value>
        public string Lat { get; set; }

        /// <summary>
        /// Gets or sets the long.
        /// </summary>
        /// <value>The long.</value>
        public string Long { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>The address.</value>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the comm count.
        /// </summary>
        /// <value>The comm count.</value>
        public int CommCount { get; set; }

        /// <summary>
        /// Gets or sets the pic count.
        /// </summary>
        /// <value>The pic count.</value>
        public int PicCount { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the min price.
        /// </summary>
        /// <value>The min price.</value>
        public double? MinPrice { get; set; }

    }

    #endregion

    #region 搜索

    /// <summary>
    /// 
    /// </summary>
    public class SearchInfoDto
    {
        /// <summary>
        /// Gets or sets the days.
        /// </summary>
        /// <value>The days.</value>
        public int Days { get; set; }

        /// <summary>
        /// Gets or sets the money.
        /// </summary>
        /// <value>The money.</value>
        public int Money { get; set; }

        /// <summary>
        /// Gets or sets the bide.
        /// </summary>
        /// <value>The bide.</value>
        public string Bide { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public string Type { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class SearchTourDto : ListTypeMidTourPlanDto
    {
        //public int? ViCount { get; set; }
    }

    #endregion
}
