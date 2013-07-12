using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac.Integration.Mvc;

namespace iPow.Service.SSO.WebService
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{resource}.svc/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();


            //ioc
            var builder = new Autofac.ContainerBuilder();
            iPowServiceSSOIoc.Register(builder);
            var container = builder.Build();
            iPow.Service.SSO.WebService.iPowServiceSSOEngine.Current.Container = container;
            //声明入注器
            var dependency = new AutofacDependencyResolver(container);
            //告知mvc入注器为autofac
            DependencyResolver.SetResolver(dependency);


            //entity map
            iPowServiceSSOEntityMap.Map();


            Wbm.SinaV2API.SinaBase.RegisterKey("app_1");

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