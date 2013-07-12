using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using Autofac;
using Autofac.Integration.Mvc;

namespace iPow.Presentation.dj
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{resource}.html/{*pathInfo}");
            iPowPreDjRegisteRoute.Register(routes);
            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            //入注器声明准备工作
            var builder = new ContainerBuilder();
            //注册类型
            iPow.Presentation.dj.iPowPreDjIoc.Register(builder);
            builder.RegisterFilterProvider();
            //end 注册类型
            var container = builder.Build();
            //声明入注器
            var dependency = new AutofacDependencyResolver(container);
            iPowPreDjEngine.Current.Container = container;
            //告知mvc入注器为autofac
            DependencyResolver.SetResolver(dependency);

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_End()
        {

        }

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