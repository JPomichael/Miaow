using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using RouteDebug;
using Autofac.Integration.Mvc;
using Autofac;

namespace iPow.Presentation.jq
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
            routes.IgnoreRoute("elmah.axd");
            routes.IgnoreRoute("{resource}.jpg/{*pathInfo}");
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            iPowPreJqRegistRoute.Register(routes);

            routes.MapRoute(
                "Default", // 路由名称
                "{controller}/{action}/{id}", // 带有参数的 URL
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // 参数默认值
            );
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            //入注器声明准备工作
            var builder = new ContainerBuilder();
            //注册类型
            iPow.Presentation.jq.iPowPreJqIoc.Register(builder);
            builder.RegisterFilterProvider();
            //end 注册类型
            var container = builder.Build();
            //声明入注器
            var dependency = new AutofacDependencyResolver(container);

            iPowPreJqEngine.Current.Container = container;
            //告知mvc入注器为autofac
            DependencyResolver.SetResolver(dependency);

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_End()
        {

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
            var error = Server.GetLastError();
            var httpException = new HttpException(null, error);
            var errorControllerName = error.TargetSite.DeclaringType.FullName;
            var errorActionName = error.TargetSite.Name;
            Server.ClearError();
            var routeData = new RouteData();
            routeData.Values.Add("controller", "Error");
            routeData.Values.Add("action", "Index");
            routeData.Values.Add("httpException", httpException);
            routeData.Values.Add("controllerName", errorControllerName);
            routeData.Values.Add("actionName", errorActionName);
            var errorController = ControllerBuilder.Current.GetControllerFactory().CreateController(
                new RequestContext(new HttpContextWrapper(Context), routeData), "Error");
            errorController.Execute(new RequestContext(new HttpContextWrapper(Context), routeData));
        }
    }
}