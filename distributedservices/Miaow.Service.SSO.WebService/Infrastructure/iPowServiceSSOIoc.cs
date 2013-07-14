using System.Web;

using Autofac;
using System.Reflection;
using Autofac.Integration.Mvc;
using Miaow.Infrastructure.Crosscutting.NetFramework;
using Miaow.Infrastructure.Crosscutting.NetFramework.Fakes;

namespace Miaow.Service.SSO.WebService
{
    /// <summary>
    /// 
    /// </summary>
    public class MiaowServiceSSOIoc
    {
        /// <summary>
        /// Registers the specified builder.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public static void Register(ContainerBuilder builder)
        {
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            RegisterHttpContext(builder);
            //repository
            RegisterRepository(builder);
            //comm service
            RegisterCommService(builder);
            RegisterOther(builder);
            RegisterAuthorize(builder);
        }

        /// <summary>
        /// Registers the other.
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected static void RegisterOther(ContainerBuilder builder)
        {
            //uow
            builder.RegisterType<Miaow.Infrastructure.Data.MiaowObjectUnitOfWork>()
            .As<Miaow.Infrastructure.Data.IQueryableUnitOfWork>().InstancePerHttpRequest();
            //work context
            builder.RegisterType<MiaowWebWorkContext>().As<IWorkContext>().InstancePerHttpRequest();
        }

        /// <summary>
        /// Registers the HTTP context.
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected static void RegisterHttpContext(ContainerBuilder builder)
        {
            //这个里面再写入各个层的入注就行了，
            #region register httpcontext
            //register FakeHttpContext when HttpContext is not available
            builder.Register(c => HttpContext.Current != null ? (new HttpContextWrapper(HttpContext.Current) as HttpContextBase) : (new FakeHttpContext("~/") as HttpContextBase))
                .As<HttpContextBase>()
                .InstancePerHttpRequest();
            builder.Register(c => c.Resolve<HttpContextBase>().Request)
                .As<HttpRequestBase>()
                .InstancePerHttpRequest();
            builder.Register(c => c.Resolve<HttpContextBase>().Response)
                .As<HttpResponseBase>()
                .InstancePerHttpRequest();
            builder.Register(c => c.Resolve<HttpContextBase>().Server)
                .As<HttpServerUtilityBase>()
                .InstancePerHttpRequest();
            builder.Register(c => c.Resolve<HttpContextBase>().Session)
                .As<HttpSessionStateBase>()
                .InstancePerHttpRequest();
            #endregion
        }

        /// <summary>
        /// Registers the repository.
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected static void RegisterRepository(Autofac.ContainerBuilder builder)
        {
            builder.RegisterType<Miaow.Infrastructure.Data.Repository.AdminUserExtensionRepository>()
            .As<Miaow.Domain.Repository.IAdminUserExtensionRepository>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Infrastructure.Data.Repository.AdminUserIndividuationRepository>()
            .As<Miaow.Domain.Repository.IAdminUserIndividuationRepository>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Infrastructure.Data.Repository.AdminUserRepository>()
            .As<Miaow.Domain.Repository.IAdminUserRepository>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Infrastructure.Data.Repository.ArticleClassRepository>()
            .As<Miaow.Domain.Repository.IArticleClassRepository>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Infrastructure.Data.Repository.ArticleCommRepository>()
            .As<Miaow.Domain.Repository.IArticleCommRepository>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Infrastructure.Data.Repository.ArticleInfoRepository>()
            .As<Miaow.Domain.Repository.IArticleInfoRepository>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Infrastructure.Data.Repository.CityAreaCodeRepository>()
            .As<Miaow.Domain.Repository.ICityAreaCodeRepository>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Infrastructure.Data.Repository.CityInfoRepository>()
            .As<Miaow.Domain.Repository.ICityInfoRepository>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Infrastructure.Data.Repository.DisCountInfoRepository>()
            .As<Miaow.Domain.Repository.IDisCountInfoRepository>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Infrastructure.Data.Repository.HotelCommRepository>()
            .As<Miaow.Domain.Repository.IHotelCommRepository>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Infrastructure.Data.Repository.HotelPicRepository>()
            .As<Miaow.Domain.Repository.IHotelPicRepository>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Infrastructure.Data.Repository.HotelPropertyInfo2Repository>()
            .As<Miaow.Domain.Repository.IHotelPropertyInfo2Repository>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Infrastructure.Data.Repository.HotelPropertyInfoRepository>()
            .As<Miaow.Domain.Repository.IHotelPropertyInfoRepository>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Infrastructure.Data.Repository.LinkInfoRepository>()
            .As<Miaow.Domain.Repository.ILinkInfoRepository>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Infrastructure.Data.Repository.PicClassRepository>()
            .As<Miaow.Domain.Repository.IPicClassRepository>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Infrastructure.Data.Repository.PicCommRepository>()
            .As<Miaow.Domain.Repository.IPicCommRepository>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Infrastructure.Data.Repository.PicInfoRepository>()
            .As<Miaow.Domain.Repository.IPicInfoRepository>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Infrastructure.Data.Repository.RolePermissionRepository>()
            .As<Miaow.Domain.Repository.IRolePermissionRepository>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Infrastructure.Data.Repository.SearchInfoRepository>()
            .As<Miaow.Domain.Repository.ISearchInfoRepository>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Infrastructure.Data.Repository.SightClassRepository>()
            .As<Miaow.Domain.Repository.ISightClassRepository>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Infrastructure.Data.Repository.SightCommRepository>()
            .As<Miaow.Domain.Repository.ISightCommRepository>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Infrastructure.Data.Repository.SightInfoRepository>()
            .As<Miaow.Domain.Repository.ISightInfoRepository>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Infrastructure.Data.Repository.SightTicketRepository>()
            .As<Miaow.Domain.Repository.ISightTicketRepository>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Infrastructure.Data.Repository.SightVouchItemRepository>()
            .As<Miaow.Domain.Repository.ISightVouchItemRepository>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Infrastructure.Data.Repository.TourClassRepository>()
            .As<Miaow.Domain.Repository.ITourClassRepository>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Infrastructure.Data.Repository.TourPlanDetailRepository>()
            .As<Miaow.Domain.Repository.ITourPlanDetailRepository>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Infrastructure.Data.Repository.TourPlanRepository>()
            .As<Miaow.Domain.Repository.ITourPlanRepository>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Infrastructure.Data.Repository.UserActionRepository>()
            .As<Miaow.Domain.Repository.IUserActionRepository>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Infrastructure.Data.Repository.UserRoleRepository>()
            .As<Miaow.Domain.Repository.IUserRoleRepository>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Infrastructure.Data.Repository.VideoClassRepository>()
            .As<Miaow.Domain.Repository.IVideoClassRepository>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Infrastructure.Data.Repository.VideoCommRepository>()
            .As<Miaow.Domain.Repository.IVideoCommRepository>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Infrastructure.Data.Repository.VideoInfoRepository>()
            .As<Miaow.Domain.Repository.IVideoInfoRepository>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Infrastructure.Data.Repository.SightInfoCirHotelRepository>()
            .As<Miaow.Domain.Repository.ISightInfoCirHotelRepository>().InstancePerHttpRequest();

            //added by yjihrp 2012.3.6
            builder.RegisterType<Miaow.Infrastructure.Data.Repository.SightInfoCirSightRepository>()
            .As<Miaow.Domain.Repository.ISightInfoCirSightRepository>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Infrastructure.Data.Repository.SightInfoCirHotelRepository>()
            .As<Miaow.Domain.Repository.ISightInfoCirHotelRepository>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Infrastructure.Data.Repository.SightInfoSortRepository>()
            .As<Miaow.Domain.Repository.ISightInfoSortRepository>().InstancePerHttpRequest();
            //end added by yjihrp 2012.3.6


            //add  张军朋 2012/4/1
            builder.RegisterType<Miaow.Infrastructure.Data.Repository.MvcControllerRepository>()
                .As<Miaow.Domain.Repository.IMvcControllerRepository>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Infrastructure.Data.Repository.MvcControllerClassRepository>()
                .As<Miaow.Domain.Repository.IMvcControllerClassRepository>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Infrastructure.Data.Repository.MvcControllerActionRepository>()
                .As<Miaow.Domain.Repository.IMvcControllerActionRepository>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Infrastructure.Data.Repository.MvcControllerRolePermissionRepository>()
                .As<Miaow.Domain.Repository.IMvcControllerRolePermissionRepository>().InstancePerHttpRequest();
            //end  张军朋 2012/4/1

        }

        /// <summary>
        /// Registers the comm service.
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected static void RegisterCommService(Autofac.ContainerBuilder builder)
        {
            //comm service
            builder.RegisterType<Miaow.Infrastructure.Crosscutting.Comm.Service.CityInfoService>()
            .As<Miaow.Infrastructure.Crosscutting.Comm.Service.ICityInfoService>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Infrastructure.Crosscutting.Comm.Service.DiscountService>()
            .As<Miaow.Infrastructure.Crosscutting.Comm.Service.IDiscountService>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Infrastructure.Crosscutting.Comm.Service.LocationService>()
            .As<Miaow.Infrastructure.Crosscutting.Comm.Service.ILocationService>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Infrastructure.Crosscutting.Comm.Service.SightInfoSearchService>()
            .As<Miaow.Infrastructure.Crosscutting.Comm.Service.ISightInfoSearchService>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Infrastructure.Crosscutting.Comm.Service.FormsAuthService>()
            .As<Miaow.Infrastructure.Crosscutting.Comm.Service.IFormsAuthService>().InstancePerHttpRequest();
        }

        protected static void RegisterAuthorize(Autofac.ContainerBuilder builder)
        {
            builder.RegisterType<Miaow.Infrastructure.Crosscutting.Authorize.MvcActionService>()
                .As<Miaow.Infrastructure.Crosscutting.Authorize.IMvcActionService>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Infrastructure.Crosscutting.Authorize.MvcControllerClassService>()
                .As<Miaow.Infrastructure.Crosscutting.Authorize.IMvcControllerClassService>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Infrastructure.Crosscutting.Authorize.MvcControllerService>()
                .As<Miaow.Infrastructure.Crosscutting.Authorize.IMvcControllerService>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Infrastructure.Crosscutting.Authorize.MvcRolePermissionService>()
                .As<Miaow.Infrastructure.Crosscutting.Authorize.IMvcRolePermissionService>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Infrastructure.Crosscutting.Authorize.RoleService>()
                .As<Miaow.Infrastructure.Crosscutting.Authorize.IRoleService>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Infrastructure.Crosscutting.Authorize.UserRoleService>()
                .As<Miaow.Infrastructure.Crosscutting.Authorize.IUserRoleService>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Infrastructure.Crosscutting.Authorize.UserService>()
                .As<Miaow.Infrastructure.Crosscutting.Authorize.IUserService>().InstancePerHttpRequest();
            //Add JPomichael 2012、4、17 
            builder.RegisterType<Miaow.Infrastructure.Crosscutting.Authorize.UserExtensionService>()
              .As<Miaow.Infrastructure.Crosscutting.Authorize.IUserExtensionService>().InstancePerHttpRequest();

            //added by yjihrp 2012.4.12
            builder.RegisterType<Miaow.Infrastructure.Crosscutting.Authorize.AssemblyControllerService>();
            //end added by yjihrp 2012.4.12
        }
    }
}