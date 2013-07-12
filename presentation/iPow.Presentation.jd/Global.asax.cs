using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace iPow.jd
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    /// <summary>
    /// 
    /// </summary>
    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("elmah.axd");
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            #region 普通搜索分页
            routes.MapRoute(
             "searchpagelist", // 路由名称
             "searchpagelist/{bide}/{key}/{cometime}/{leavetime}/{pi}", // 带有参数的 URL
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
            routes.MapRoute(
             "SearchAll", // 路由名称
             "searchall/{bide}/{key}/{cometime}/{leavetime}/{min}/{max}/{starts}/{mintomax}/{pi}", // 带有参数的 URL
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
            routes.MapRoute(
                "hotel",
                "hotel/{id}",
                new
                {
                    controller = "Hotel",
                    action = "Index",
                    id = UrlParameter.Optional
                });
            #endregion

            #region  酒店详细面 酒店信息
            routes.MapRoute(
                "hoteldes",
                "hoteldes/{id}",
                new
                {
                    controller = "Hotel",
                    action = "HotelDes",
                    id = UrlParameter.Optional
                });
            #endregion

            #region  酒店详细面 酒店房间价格
            routes.MapRoute(
                "hotelroomprice",
                "hotelroomprice/{id}",
                new
                {
                    controller = "Hotel",
                    action = "HotelRoom",
                    id = UrlParameter.Optional
                });
            #endregion

            #region  酒店详细面 酒店图片
            routes.MapRoute(
                "hotelpic",
                "hotelpic/{id}",
                new
                {
                    controller = "Hotel",
                    action = "HotelPic",
                    id = UrlParameter.Optional,
                });
            #endregion

            #region  酒店详细面 酒店图片分页
            routes.MapRoute(
                "hotelpiclist",
                "hotelpiclist/{id}/{pi}",
                new
                {
                    controller = "Hotel",
                    action = "HotelPicList",
                    id = UrlParameter.Optional,
                    pageIndex = UrlParameter.Optional
                });
            #endregion

            #region  酒店详细面 酒店评论
            routes.MapRoute(
                "hotelcomm",
                "hotelcomm/{id}",
                new
                {
                    controller = "Hotel",
                    action = "HotelComm",
                    id = UrlParameter.Optional,
                });
            #endregion

            #region  酒店详细面 酒店评论分页
            routes.MapRoute(
                "hotelcommlist",
                "hotelcommlist/{id}/{pi}",
                new
                {
                    controller = "Hotel",
                    action = "HotelCommList",
                    id = UrlParameter.Optional,
                    pi = UrlParameter.Optional
                });
            #endregion

            #region  酒店详细面 更新我住过
            routes.MapRoute(
                "hotellivein",
                "hotellivein/{id}",
                new
                {
                    controller = "Hotel",
                    action = "AddHotelLiveIn",
                    id = UrlParameter.Optional
                });
            #endregion

            #endregion

            #region 首页中间的热门酒店
            routes.MapRoute(
                "LeftMidHotHotel",
                "leftmidhothotel/{ids}/{min}/{max}",
                new
                {
                    controller = "LeftMidHotHotel",
                    action = "Index",
                    id = UrlParameter.Optional,
                    min = UrlParameter.Optional,
                    max = UrlParameter.Optional
                });
            #endregion

            routes.MapRoute(
                "Default", // 路由名称
                "{controller}/{action}/{id}", // 带有参数的 URL
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // 参数默认值
            );

        }

        /// <summary>
        /// Application_s the start.
        /// </summary>
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            // RouteDebug.RouteDebugger.RewriteRoutesForTesting(RouteTable.Routes);
        }

        /// <summary>
        /// Handles the Error event of the Application control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Application_Error(object sender, EventArgs e)
        {
            if (!HttpContext.Current.IsCustomErrorEnabled)
            {
                return;
            }
            var exception = Server.GetLastError();
            var httpException = new HttpException(null, exception);
            var routeData = new RouteData();
            routeData.Values.Add("controller", "Error");
            routeData.Values.Add("action", "Index");
            routeData.Values.Add("httpException", httpException);
            Server.ClearError();
            var errorController = ControllerBuilder.Current.GetControllerFactory().CreateController(
                new RequestContext(new HttpContextWrapper(Context), routeData), "Error");
            errorController.Execute(new RequestContext(new HttpContextWrapper(Context), routeData));
        }
    }
}