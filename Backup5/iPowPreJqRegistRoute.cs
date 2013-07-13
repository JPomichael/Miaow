using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;
using System.Web.Routing;

namespace iPow.Presentation.jq
{
    /// <summary>
    /// 
    /// </summary>
    public class iPowPreJqRegistRoute
    {
        /// <summary>
        /// Registers the specified routes.
        /// </summary>
        /// <param name="routes">The routes.</param>
        public static void Register(RouteCollection routes)
        {

            #region 用户

            routes.MapRoute(
           "SightLogOut", // 路由名称
           "logout/index", // 带有参数的 URL
               new
               {
                   controller = "Account",
                   action = "LogOff",
               });

            #endregion

            #region 景区搜索

            routes.MapRoute(
            "SightSearch", // 路由名称
            "search/index", // 带有参数的 URL
                new
                {
                    controller = "Search",
                    action = "Index",

                });

            routes.MapRoute(
            "SightSearchPage", // 路由名称
            "search/index/{search}/{id}", // 带有参数的 URL
                new
                {
                    controller = "Search",
                    action = "IndexPage",
                    search = UrlParameter.Optional,
                    id = UrlParameter.Optional
                });

            routes.MapRoute(
            "SearchTip", // 路由名称
            "search/tip", // 带有参数的 URL
            new
            {
                controller = "Search",
                action = "GetSearchTip"
            });


            #endregion

            #region 景区详细   pic tic vid art  gui


            #region 图片

            #region 给景区一张图片评论翻页路由
            routes.MapRoute(
            "SightPicCommPage", // 路由名称
            "sight/piccommpage/{picid}/{pi}", // 带有参数的 URL
            new
            {
                controller = "Pic",
                action = "PicCommPage",
                picid = UrlParameter.Optional,
                pi = UrlParameter.Optional
            } // 参数默认值
            );
            #endregion

            #region 给景区一张图片添加评论路由

            routes.MapRoute(
    "SightPicAddComm", // 路由名称
    "sight/picaddcomm", // 带有参数的 URL
    new
    {
        controller = "Pic",
        action = "AddPicComm"
    } // 参数默认值
    );
            #endregion

            #region 景区一张图片详细路由

            routes.MapRoute(
    "SightPicDetail", // 路由名称
    "sight/picdetail/{sid}/{id}", // 带有参数的 URL
    new
    {
        controller = "SightOther",
        action = "PicDetail",
        sid = UrlParameter.Optional,
        id = UrlParameter.Optional
    } // 参数默认值
    );
            #endregion

            #region 景区详细页面 图片路由

            routes.MapRoute(
            "SightPic", // 路由名称
            "sight/pic/{sid}/{other}/{ord}/{id}", // 带有参数的 URL
            new
            {
                controller = "SightOther",
                action = "Pic",
                sid = UrlParameter.Optional,
                other = UrlParameter.Optional,
                ord = UrlParameter.Optional,
                id = UrlParameter.Optional
            } // 参数默认值
            );
            #endregion
            #endregion

            #region 添加景区评论

            routes.MapRoute(
    "SightAddComm", // 路由名称
    "sight/addsightcomm", // 带有参数的 URL
    new
    {
        controller = "SightDetail",
        action = "AddSightComm"
    } // 参数默认值
    );

            routes.MapRoute(
    "SightComm", // 路由名称
    "sight/sightcomm/{sid}/{pi}", // 带有参数的 URL
    new
    {
        controller = "SightDetail",
        action = "CommList",
        sid = UrlParameter.Optional,
        pi = UrlParameter.Optional
    } // 参数默认值
    );

            #endregion

            #region 门票路由

            routes.MapRoute(
    "SightTic", // 路由名称
    "sight/ticket/{sid}/{other}", // 带有参数的 URL
    new
    {
        controller = "SightOther",
        action = "Ticket",
        sid = UrlParameter.Optional,
        other = UrlParameter.Optional
    } // 参数默认值
    );
            #endregion

            #region 导游图路由

            routes.MapRoute(
"SightGui", // 路由名称
"sight/guide/{sid}/{other}", // 带有参数的 URL
new
{
    controller = "SightOther",
    action = "Guide",
    sid = UrlParameter.Optional,
    other = UrlParameter.Optional
} // 参数默认值
);
            #endregion

            #region 游记攻略文章

            #region 游记攻略评论分页路由

            routes.MapRoute(
            "SightArticleCommPage", // 路由名称
            "sight/articlecommpage/{art}/{pi}", // 带有参数的 URL
            new
            {
                controller = "Article",
                action = "ArticleCommPage",
                art = UrlParameter.Optional,
                pi = UrlParameter.Optional

            } // 参数默认值
            );

            #endregion


            #region 给景区游记攻略添加评论路由

            routes.MapRoute(
            "SightArticleAddComm", // 路由名称
            "sight/articleaddcomm", // 带有参数的 URL
            new
            {
                controller = "Article",
                action = "AddArticleComm"
            } // 参数默认值
            );
            #endregion

            #region 游记攻略详细路由

            routes.MapRoute(
    "SightArticleDetail", // 路由名称
    "sight/articledetail/{sid}/{id}", // 带有参数的 URL
    new
    {
        controller = "SightOther",
        action = "ArticleDetail",
        sid = UrlParameter.Optional,
        id = UrlParameter.Optional
    } // 参数默认值
    );
            #endregion

            #region 游记攻略路由

            routes.MapRoute(
"SightArt", // 路由名称
"sight/article/{sid}/{other}/{ord}/{id}", // 带有参数的 URL
new
{
    controller = "SightOther",
    action = "Article",
    sid = UrlParameter.Optional,
    other = UrlParameter.Optional,
    ord = UrlParameter.Optional,
    id = UrlParameter.Optional
} // 参数默认值
);
            #endregion

            #endregion

            #region 视频路由

            routes.MapRoute(
"SightVid", // 路由名称
"sight/video/{sid}/{other}/{ord}/{id}", // 带有参数的 URL
new
{
    controller = "SightOther",
    action = "Video",
    sid = UrlParameter.Optional,
    other = UrlParameter.Optional,
    ord = UrlParameter.Optional,
    id = UrlParameter.Optional
} // 参数默认值
);
            #endregion

            #region 用于更新我想去
            routes.MapRoute(
              "WantGo", // 路由名称
              "wantgo/{sid}/{id}", // 带有参数的 URL
              new
              {
                  controller = "SightDetail",
                  action = "WantGo",
                  sid = UrlParameter.Optional,
                  id = UrlParameter.Optional
              } // 参数默认值
              );
            #endregion

            #region 用于更新我去过
            routes.MapRoute(
              "GoCount", // 路由名称
              "gocount/{sid}/{id}", // 带有参数的 URL
              new
              {
                  controller = "SightDetail",
                  action = "GoCount",
                  sid = UrlParameter.Optional,
                  id = UrlParameter.Optional
              } // 参数默认值
              );
            #endregion

            #region 用于更新我顶
            routes.MapRoute(
              "WoDing", // 路由名称
              "woding/{sid}/{id}", // 带有参数的 URL
              new
              {
                  controller = "SightDetail",
                  action = "WoDing",
                  sid = UrlParameter.Optional,
                  id = UrlParameter.Optional
              } // 参数默认值
              );
            #endregion

            #region 景区详细中的基本信息路由

            routes.MapRoute(
 "SightDetail", // 路由名称
 "sight/{sight}/{sid}/{id}", // 带有参数的 URL
 new
 {
     controller = "SightDetail",
     action = "Index",
     sight = UrlParameter.Optional,
     sid = UrlParameter.Optional,
     id = UrlParameter.Optional
 } // 参数默认值
 );
            #endregion

            #endregion

            // usefull 首页不能和省路由换顺序哦

            #region 首页

            #region  按城市分类路由

            routes.MapRoute(
                "City", // 路由名称
                "{city}/{id}", // 带有参数的 URL
                new
                {
                    controller = "Home",
                    action = "Index",
                    city = UrlParameter.Optional,
                    id = UrlParameter.Optional
                } // 参数默认值
                );
            #endregion

            #region 景区类型路由
            routes.MapRoute(
                "Type", // 路由名称
                "{city}/{cla}/{id}", // 带有参数的 URL
                new
                {
                    controller = "Home",
                    action = "Type",
                    cla = UrlParameter.Optional,
                    city = UrlParameter.Optional,
                    id = UrlParameter.Optional
                } // 参数默认值
                );
            #endregion

            #endregion

            #region //点击省的路由
            //不要改变这两个路由的顺序哈
            #region 一般省用到的

            routes.MapRoute(
               "Prov", // 路由名称
               "{prov}/{city}/{cla}/{id}", // 带有参数的 URL
               new
               {
                   controller = "Home",
                   action = "Province",
                   prov = UrlParameter.Optional,
                   city = UrlParameter.Optional,
                   cla = UrlParameter.Optional,
                   id = UrlParameter.Optional
               } // 参数默认值
           );
            #endregion

            #region 省页面，点击 50 100 500
            routes.MapRoute(
               "ProvSelect", // 路由名称
               "{prov}/{cla}/{start}/{end}/{id}", // 带有参数的 URL
               new
               {
                   controller = "Home",
                   action = "SelectProvinceByTicket",
                   prov = UrlParameter.Optional,
                   cla = UrlParameter.Optional,
                   start = UrlParameter.Optional,
                   end = UrlParameter.Optional,
                   id = UrlParameter.Optional
               } // 参数默认值
           );
            #endregion

            #endregion
        }
    }
}