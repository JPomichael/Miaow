using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;
using System.Web.Routing;

namespace iPow.Presentation.Union
{
    /// <summary>
    /// 
    /// </summary>
    public class iPowPreUnionRegistRoute
    {
        /// <summary>
        /// Registers the specified routes.
        /// </summary>
        /// <param name="routes">The routes.</param>
        public static void Register(RouteCollection routes)
        {
            routes.IgnoreRoute("ebook/agent.html");

            #region 酒店订单页
            routes.MapRoute("ebookquery","ebook/query/{phone}",
              new
              {
                  controller = "Ebook",
                  action = "Query",
                  phone = UrlParameter.Optional
              });

            routes.MapRoute("ebook","ebook/{id}/{rid}/{rpi}",
                new
                {
                    controller = "Ebook",
                    action = "Index",
                    id = UrlParameter.Optional,
                    rid = UrlParameter.Optional,
                    rpi = UrlParameter.Optional
                });

            #endregion

            #region 普通搜索分页
            routes.MapRoute("searchpagelist", "searchpagelist/{bide}/{key}/{cometime}/{leavetime}/{pi}",
             new
             {
                 controller = "Search",
                 action = "SearchPageList",
                 bide = UrlParameter.Optional,
                 key = UrlParameter.Optional,
                 cometime = UrlParameter.Optional,
                 leavetime = UrlParameter.Optional,
                 pi = UrlParameter.Optional
             });
            #endregion

            #region 筛选搜索分页和路由
            routes.MapRoute("SearchAll","searchall/{bide}/{key}/{cometime}/{leavetime}/{min}/{max}/{starts}/{mintomax}/{pi}",
             new
             {
                 controller = "Search",
                 action = "SearchAll",
                 bide = UrlParameter.Optional,
                 key = UrlParameter.Optional,
                 cometime = UrlParameter.Optional,
                 leavetime = UrlParameter.Optional,
                 min = UrlParameter.Optional,
                 max = UrlParameter.Optional,
                 start = UrlParameter.Optional,
                 mintomax = UrlParameter.Optional,
                 pi = UrlParameter.Optional
             });
            #endregion

            #region 酒店详细页

            #region 酒店详细页
            routes.MapRoute("hotel","hotel/{id}",
                new
                {
                    controller = "Hotel",
                    action = "Index",
                    id = UrlParameter.Optional
                });
            #endregion

            #region  酒店详细面 酒店信息
            routes.MapRoute("hoteldes","hoteldes/{id}",
                new
                {
                    controller = "Hotel",
                    action = "HotelDes",
                    id = UrlParameter.Optional
                });
            #endregion

            #region  酒店详细面 酒店房间价格
            routes.MapRoute("hotelroomprice","hotelroomprice/{id}",
                new
                {
                    controller = "Hotel",
                    action = "HotelRoom",
                    id = UrlParameter.Optional
                });
            #endregion

            #region  酒店详细面 酒店图片
            routes.MapRoute("hotelpic","hotelpic/{id}",
                new
                {
                    controller = "Hotel",
                    action = "HotelPic",
                    id = UrlParameter.Optional,
                });
            #endregion

            #region  酒店详细面 酒店图片分页
            routes.MapRoute("hotelpiclist","hotelpiclist/{id}/{pi}",
                new
                {
                    controller = "Hotel",
                    action = "HotelPicList",
                    id = UrlParameter.Optional,
                    pageIndex = UrlParameter.Optional
                });
            #endregion

            #region  酒店详细面 酒店评论
            routes.MapRoute("hotelcomm","hotelcomm/{id}",
                new
                {
                    controller = "Hotel",
                    action = "HotelComm",
                    id = UrlParameter.Optional,
                });
            #endregion

            #region  酒店详细面 酒店评论分页
            routes.MapRoute("hotelcommlist","hotelcommlist/{id}/{pi}",
                new
                {
                    controller = "Hotel",
                    action = "HotelCommList",
                    id = UrlParameter.Optional,
                    pi = UrlParameter.Optional
                });
            #endregion

            #region  酒店详细面 更新我住过
            routes.MapRoute("hotellivein","hotellivein/{id}",
                new
                {
                    controller = "Hotel",
                    action = "AddHotelLiveIn",
                    id = UrlParameter.Optional
                });
            #endregion

            #endregion

            #region 首页中间的热门酒店
            routes.MapRoute("LeftMidHotHotel","leftmidhothotel/{ids}/{min}/{max}",
                new
                {
                    controller = "LeftMidHotHotel",
                    action = "Index",
                    id = UrlParameter.Optional,
                    min = UrlParameter.Optional,
                    max = UrlParameter.Optional
                });
            #endregion
        }
    }
}