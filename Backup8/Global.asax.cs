using System.Web.Mvc;
using System.Web.Routing;

namespace iPow.jz
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            #region 添加景区帖子
            routes.MapRoute(
                "AddTopic",
                "addTopic/addfromtopic",
                new
                {
                    controller = "Forum",
                    action = "AddFromTopic"
                });
            #endregion

            #region 添加家族圈
            routes.MapRoute(
                "AddCreate",
                "addcreate/create",
                new
                {
                    controller = "Forum",
                    action = "Create"
                });
            #endregion

            #region 根据作者名称和标题模糊查询景区帖子
            routes.MapRoute(
            "Seach", // 路由名称
            "seach/{seachName}/{type}/{pageIndex}", // 带有参数的 URL
              new
              {
                  controller = "Forum",
                  action = "SeachFroum",
                  seachName = UrlParameter.Optional,
                  type = UrlParameter.Optional,
                  pageIndex = UrlParameter.Optional
              });
            #endregion

            #region 查询景区路由
            routes.MapRoute(
                             "Catalog", // 路由名称
                              "catalog/{cid}/{t}/{pageIndex}", // 带有参数的 URL
                             new
                             {
                                 controller = "Forum",
                                 action = "CategoryList",
                                 cid = UrlParameter.Optional,
                                 t = UrlParameter.Optional,
                                 pageIndex = UrlParameter.Optional
                             });
            #endregion

            #region 查询景区详情帖子
            routes.MapRoute(
            "Topic", // 路由名称
            "topic/{tid}/{num}/{pageIndex}", // 带有参数的 URL
              new
              {
                  controller = "Forum",
                  action = "ListTopic",
                  tid = UrlParameter.Optional,
                  num = UrlParameter.Optional,
                  pageIndex = UrlParameter.Optional
              });
            #endregion

            #region 查询景区顶、飘过、砸
            routes.MapRoute(
            "Up", // 路由名称
            "up/{pid}/{type}", // 带有参数的 URL
              new
              {
                  controller = "Forum",
                  action = "DeUp",
                  pid = UrlParameter.Optional,
                  type = UrlParameter.Optional
              });
            #endregion

            routes.MapRoute(
            "Default", // 路由名称
            "{controller}/{action}/{id}", // 带有参数的 URL
                new
                {
                    controller = "Home",
                    action = "Index",
                    id = UrlParameter.Optional
                });

            routes.MapRoute(
              "Login", // 路由名称
              "login/{email}/{password}", // 带有参数的 URL
              new
              {
                  controller = "Home",
                  action = "Login",
                  email = UrlParameter.Optional,
                  password = UrlParameter.Optional
              } // 参数默认值
          );
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            //RouteDebug.RouteDebugger.RewriteRoutesForTesting(RouteTable.Routes);
        }
    }
}