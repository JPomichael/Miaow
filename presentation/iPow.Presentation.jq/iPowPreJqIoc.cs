using System.Web;

using Autofac;
using System.Reflection;
using Autofac.Integration.Mvc;
using iPow.Infrastructure.Crosscutting.NetFramework;
using iPow.Infrastructure.Crosscutting.NetFramework.Fakes;

namespace iPow.Presentation.jq
{
    /// <summary>
    /// 
    /// </summary>
    public class iPowPreJqIoc
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
            //这个项目没有引用这些
            //RegisterApplicationDjService(builder);
            RegisterApplicationJqService(builder);
            RegisterServiceUnionService(builder);
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
            builder.RegisterType<iPow.Infrastructure.Data.iPowObjectUnitOfWork>()
            .As<iPow.Infrastructure.Data.IQueryableUnitOfWork>().InstancePerHttpRequest();

            //work context
            builder.RegisterType<iPowWebWorkContext>().As<IWorkContext>().InstancePerHttpRequest();
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
            builder.RegisterType<iPow.Infrastructure.Data.Repository.AdminUserExtensionRepository>()
            .As<iPow.Domain.Repository.IAdminUserExtensionRepository>().InstancePerHttpRequest();
            builder.RegisterType<iPow.Infrastructure.Data.Repository.AdminUserIndividuationRepository>()
            .As<iPow.Domain.Repository.IAdminUserIndividuationRepository>().InstancePerHttpRequest();
            builder.RegisterType<iPow.Infrastructure.Data.Repository.AdminUserRepository>()
            .As<iPow.Domain.Repository.IAdminUserRepository>().InstancePerHttpRequest();
            builder.RegisterType<iPow.Infrastructure.Data.Repository.ArticleClassRepository>()
            .As<iPow.Domain.Repository.IArticleClassRepository>().InstancePerHttpRequest();
            builder.RegisterType<iPow.Infrastructure.Data.Repository.ArticleCommRepository>()
            .As<iPow.Domain.Repository.IArticleCommRepository>().InstancePerHttpRequest();
            builder.RegisterType<iPow.Infrastructure.Data.Repository.ArticleInfoRepository>()
            .As<iPow.Domain.Repository.IArticleInfoRepository>().InstancePerHttpRequest();
            builder.RegisterType<iPow.Infrastructure.Data.Repository.CityAreaCodeRepository>()
            .As<iPow.Domain.Repository.ICityAreaCodeRepository>().InstancePerHttpRequest();
            builder.RegisterType<iPow.Infrastructure.Data.Repository.CityInfoRepository>()
            .As<iPow.Domain.Repository.ICityInfoRepository>().InstancePerHttpRequest();
            builder.RegisterType<iPow.Infrastructure.Data.Repository.DisCountInfoRepository>()
            .As<iPow.Domain.Repository.IDisCountInfoRepository>().InstancePerHttpRequest();
            builder.RegisterType<iPow.Infrastructure.Data.Repository.HotelCommRepository>()
            .As<iPow.Domain.Repository.IHotelCommRepository>().InstancePerHttpRequest();
            builder.RegisterType<iPow.Infrastructure.Data.Repository.HotelPicRepository>()
            .As<iPow.Domain.Repository.IHotelPicRepository>().InstancePerHttpRequest();
            builder.RegisterType<iPow.Infrastructure.Data.Repository.HotelPropertyInfo2Repository>()
            .As<iPow.Domain.Repository.IHotelPropertyInfo2Repository>().InstancePerHttpRequest();
            builder.RegisterType<iPow.Infrastructure.Data.Repository.HotelPropertyInfoRepository>()
            .As<iPow.Domain.Repository.IHotelPropertyInfoRepository>().InstancePerHttpRequest();
            builder.RegisterType<iPow.Infrastructure.Data.Repository.LinkInfoRepository>()
            .As<iPow.Domain.Repository.ILinkInfoRepository>().InstancePerHttpRequest();
            builder.RegisterType<iPow.Infrastructure.Data.Repository.PicClassRepository>()
            .As<iPow.Domain.Repository.IPicClassRepository>().InstancePerHttpRequest();
            builder.RegisterType<iPow.Infrastructure.Data.Repository.PicCommRepository>()
            .As<iPow.Domain.Repository.IPicCommRepository>().InstancePerHttpRequest();
            builder.RegisterType<iPow.Infrastructure.Data.Repository.PicInfoRepository>()
            .As<iPow.Domain.Repository.IPicInfoRepository>().InstancePerHttpRequest();
            builder.RegisterType<iPow.Infrastructure.Data.Repository.RolePermissionRepository>()
            .As<iPow.Domain.Repository.IRolePermissionRepository>().InstancePerHttpRequest();
            builder.RegisterType<iPow.Infrastructure.Data.Repository.SearchInfoRepository>()
            .As<iPow.Domain.Repository.ISearchInfoRepository>().InstancePerHttpRequest();
            builder.RegisterType<iPow.Infrastructure.Data.Repository.SightClassRepository>()
            .As<iPow.Domain.Repository.ISightClassRepository>().InstancePerHttpRequest();
            builder.RegisterType<iPow.Infrastructure.Data.Repository.SightCommRepository>()
            .As<iPow.Domain.Repository.ISightCommRepository>().InstancePerHttpRequest();
            builder.RegisterType<iPow.Infrastructure.Data.Repository.SightInfoRepository>()
            .As<iPow.Domain.Repository.ISightInfoRepository>().InstancePerHttpRequest();
            builder.RegisterType<iPow.Infrastructure.Data.Repository.SightTicketRepository>()
            .As<iPow.Domain.Repository.ISightTicketRepository>().InstancePerHttpRequest();
            builder.RegisterType<iPow.Infrastructure.Data.Repository.SightVouchItemRepository>()
            .As<iPow.Domain.Repository.ISightVouchItemRepository>().InstancePerHttpRequest();
            builder.RegisterType<iPow.Infrastructure.Data.Repository.TourClassRepository>()
            .As<iPow.Domain.Repository.ITourClassRepository>().InstancePerHttpRequest();
            builder.RegisterType<iPow.Infrastructure.Data.Repository.TourPlanDetailRepository>()
            .As<iPow.Domain.Repository.ITourPlanDetailRepository>().InstancePerHttpRequest();
            builder.RegisterType<iPow.Infrastructure.Data.Repository.TourPlanRepository>()
            .As<iPow.Domain.Repository.ITourPlanRepository>().InstancePerHttpRequest();
            builder.RegisterType<iPow.Infrastructure.Data.Repository.UserActionRepository>()
            .As<iPow.Domain.Repository.IUserActionRepository>().InstancePerHttpRequest();
            builder.RegisterType<iPow.Infrastructure.Data.Repository.UserRoleRepository>()
            .As<iPow.Domain.Repository.IUserRoleRepository>().InstancePerHttpRequest();
            builder.RegisterType<iPow.Infrastructure.Data.Repository.VideoClassRepository>()
            .As<iPow.Domain.Repository.IVideoClassRepository>().InstancePerHttpRequest();
            builder.RegisterType<iPow.Infrastructure.Data.Repository.VideoCommRepository>()
            .As<iPow.Domain.Repository.IVideoCommRepository>().InstancePerHttpRequest();
            builder.RegisterType<iPow.Infrastructure.Data.Repository.VideoInfoRepository>()
            .As<iPow.Domain.Repository.IVideoInfoRepository>().InstancePerHttpRequest();

            //added by yjihrp 2012.3.6
            builder.RegisterType<iPow.Infrastructure.Data.Repository.SightInfoCirSightRepository>()
            .As<iPow.Domain.Repository.ISightInfoCirSightRepository>().InstancePerHttpRequest();
            builder.RegisterType<iPow.Infrastructure.Data.Repository.SightInfoSortRepository>()
            .As<iPow.Domain.Repository.ISightInfoSortRepository>().InstancePerHttpRequest();
            builder.RegisterType<iPow.Infrastructure.Data.Repository.SightInfoCirHotelRepository>()
            .As<iPow.Domain.Repository.ISightInfoCirHotelRepository>().InstancePerHttpRequest();

            //end added by yjihrp 2012.3.6

        }

        /// <summary>
        /// Registers the comm service.
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected static void RegisterCommService(Autofac.ContainerBuilder builder)
        {
            //comm service
            builder.RegisterType<iPow.Infrastructure.Crosscutting.Comm.Service.CityInfoService>()
            .As<iPow.Infrastructure.Crosscutting.Comm.Service.ICityInfoService>().InstancePerHttpRequest();
            builder.RegisterType<iPow.Infrastructure.Crosscutting.Comm.Service.DiscountService>()
            .As<iPow.Infrastructure.Crosscutting.Comm.Service.IDiscountService>().InstancePerHttpRequest();
            builder.RegisterType<iPow.Infrastructure.Crosscutting.Comm.Service.LocationService>()
            .As<iPow.Infrastructure.Crosscutting.Comm.Service.ILocationService>().InstancePerHttpRequest();
            builder.RegisterType<iPow.Infrastructure.Crosscutting.Comm.Service.SightInfoSearchService>()
            .As<iPow.Infrastructure.Crosscutting.Comm.Service.ISightInfoSearchService>().InstancePerHttpRequest();
        }

        /// <summary>
        /// Registers the dj service.
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected static void RegisterApplicationDjService(Autofac.ContainerBuilder builder)
        {
            //builder.RegisterType<iPow.Application.dj.Services.TourPlanService>()
            //.As<iPow.Application.dj.Services.ITourPlanService>();
            //builder.RegisterType<iPow.Application.dj.Services.HomeService>()
            //    .As<iPow.Application.dj.Services.IHomeService>();
            //builder.RegisterType<iPow.Application.dj.Services.HotelInfoService>()
            //    .As<iPow.Application.dj.Services.IHotelInfoService>();
            //builder.RegisterType<iPow.Application.dj.Services.HotKeyWordsService>()
            //    .As<iPow.Application.dj.Services.IHotKeyWordsService>();
            //builder.RegisterType<iPow.Application.dj.Services.LinksAndTopCountService>()
            //    .As<iPow.Application.dj.Services.ILinksAndTopCountService>();
            //builder.RegisterType<iPow.Application.dj.Services.ListService>()
            //    .As<iPow.Application.dj.Services.IListService>();
            //builder.RegisterType<iPow.Application.dj.Services.SearchService>()
            //    .As<iPow.Application.dj.Services.ISearchService>();
        }

        /// <summary>
        /// Registers the jq service.
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected static void RegisterApplicationJqService(Autofac.ContainerBuilder builder)
        {
            builder.RegisterType<iPow.Application.jq.Service.AddSortService>()
            .As<iPow.Application.jq.Service.IAddSortService>();
            builder.RegisterType<iPow.Application.jq.Service.ArticleService>()
            .As<iPow.Application.jq.Service.IArticleService>();
            builder.RegisterType<iPow.Application.jq.Service.HomeService>()
            .As<iPow.Application.jq.Service.IHomeService>();
            builder.RegisterType<iPow.Application.jq.Service.PageService>()
            .As<iPow.Application.jq.Service.IPageService>();
            builder.RegisterType<iPow.Application.jq.Service.PicInfoService>()
            .As<iPow.Application.jq.Service.IPicInfoService>();
            builder.RegisterType<iPow.Application.jq.Service.SearchService>()
            .As<iPow.Application.jq.Service.ISearchService>();
            builder.RegisterType<iPow.Application.jq.Service.SightInfoService>()
            .As<iPow.Application.jq.Service.ISightInfoService>();
            builder.RegisterType<iPow.Application.jq.Service.SinaInfoService>()
            .As<iPow.Application.jq.Service.ISinaInfoService>();
            builder.RegisterType<iPow.Application.jq.Service.TicketService>()
            .As<iPow.Application.jq.Service.ITicketService>();
            builder.RegisterType<iPow.Application.jq.Service.TopClassService>()
            .As<iPow.Application.jq.Service.ITopClassService>();
            builder.RegisterType<iPow.Application.jq.Service.VideoInfoService>()
            .As<iPow.Application.jq.Service.IVideoInfoService>();

            //add 2012-4-28  JPomichael
            builder.RegisterType<iPow.Application.jq.Service.SightInfoSortService>()
            .As<iPow.Application.jq.Service.ISightInfoSortService>();
            //end

        }

        /// <summary>
        /// Registers the jq service.
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected static void RegisterServiceUnionService(Autofac.ContainerBuilder builder)
        {
            builder.RegisterType<iPow.Service.Union.CitySettingDefault>()
            .As<iPow.Service.Union.CitySettingBase>();
            builder.RegisterType<iPow.Service.Union.UnionCityService>()
            .As<iPow.Service.Union.IUnionCityService>();
            builder.RegisterType<iPow.Service.Union.Service.CityService>()
            .As<iPow.Service.Union.Service.ICityService>();
            builder.RegisterType<iPow.Service.Union.Service.HeadVouchDataService>()
            .As<iPow.Service.Union.Service.IHeadVouchDataService>();
            builder.RegisterType<iPow.Service.Union.Service.HotelAroundHotelService>()
           .As<iPow.Service.Union.Service.IHotelAroundHotelService>();
            builder.RegisterType<iPow.Service.Union.Service.HotelCommService>()
            .As<iPow.Service.Union.Service.IHotelCommService>();
            builder.RegisterType<iPow.Service.Union.Service.HotelCommSysService>()
            .As<iPow.Service.Union.Service.IHotelCommSysService>();
            builder.RegisterType<iPow.Service.Union.Service.HotelEbookService>()
            .As<iPow.Service.Union.Service.IHotelEbookService>();
            builder.RegisterType<iPow.Service.Union.Service.HotelInfoService>()
            .As<iPow.Service.Union.Service.IHotelInfoService>();
            builder.RegisterType<iPow.Service.Union.Service.HotelLeftMidService>()
            .As<iPow.Service.Union.Service.IHotelLeftMidService>();
            builder.RegisterType<iPow.Service.Union.Service.HotelPicService>()
            .As<iPow.Service.Union.Service.IHotelPicService>();
            builder.RegisterType<iPow.Service.Union.Service.HotelRoomService>()
            .As<iPow.Service.Union.Service.IHotelRoomService>();

            builder.RegisterType<iPow.Service.Union.Service.HotelSearchService>()
            .As<iPow.Service.Union.Service.IHotelSearchService>();
            builder.RegisterType<iPow.Service.Union.Service.HotelTrafficService>()
            .As<iPow.Service.Union.Service.IHotelTrafficService>();
            builder.RegisterType<iPow.Service.Union.Service.HotelTypeService>()
            .As<iPow.Service.Union.Service.IHotelTypeService>();
            builder.RegisterType<iPow.Service.Union.Service.TodayLowPriceService>()
            .As<iPow.Service.Union.Service.ITodayLowPriceService>();
        }

        protected static void RegisterAuthorize(Autofac.ContainerBuilder builder)
        {
            builder.RegisterType<iPow.Infrastructure.Crosscutting.Authorize.MvcActionService>()
                .As<iPow.Infrastructure.Crosscutting.Authorize.IMvcActionService>().InstancePerHttpRequest();
            builder.RegisterType<iPow.Infrastructure.Crosscutting.Authorize.MvcControllerClassService>()
                .As<iPow.Infrastructure.Crosscutting.Authorize.IMvcControllerClassService>().InstancePerHttpRequest();
            builder.RegisterType<iPow.Infrastructure.Crosscutting.Authorize.MvcControllerService>()
                .As<iPow.Infrastructure.Crosscutting.Authorize.IMvcControllerService>().InstancePerHttpRequest();
            builder.RegisterType<iPow.Infrastructure.Crosscutting.Authorize.MvcRolePermissionService>()
                .As<iPow.Infrastructure.Crosscutting.Authorize.IMvcRolePermissionService>().InstancePerHttpRequest();
            builder.RegisterType<iPow.Infrastructure.Crosscutting.Authorize.RoleService>()
                .As<iPow.Infrastructure.Crosscutting.Authorize.IRoleService>().InstancePerHttpRequest();
            builder.RegisterType<iPow.Infrastructure.Crosscutting.Authorize.UserRoleService>()
                .As<iPow.Infrastructure.Crosscutting.Authorize.IUserRoleService>().InstancePerHttpRequest();
            builder.RegisterType<iPow.Infrastructure.Crosscutting.Authorize.UserService>()
                .As<iPow.Infrastructure.Crosscutting.Authorize.IUserService>().InstancePerHttpRequest();
            //Add JPomichael 2012、4、17 
            builder.RegisterType<iPow.Infrastructure.Crosscutting.Authorize.UserExtensionService>()
              .As<iPow.Infrastructure.Crosscutting.Authorize.IUserExtensionService>().InstancePerHttpRequest();

            //added by yjihrp 2012.4.12
            builder.RegisterType<iPow.Infrastructure.Crosscutting.Authorize.AssemblyControllerService>();
            //end added by yjihrp 2012.4.12

            //add by jpomichael 2014/4/19
            builder.RegisterType<iPow.Infrastructure.Crosscutting.Authorize.AdminUserClassService>()
                .As<iPow.Infrastructure.Crosscutting.Authorize.IAdminUserClassService>().InstancePerHttpRequest();
            builder.RegisterType<iPow.Infrastructure.Crosscutting.Authorize.MvcControllerActionClassService>()
                .As<iPow.Infrastructure.Crosscutting.Authorize.IMvcControllerActionClassService>().InstancePerHttpRequest();
            //end


        }
    }
}