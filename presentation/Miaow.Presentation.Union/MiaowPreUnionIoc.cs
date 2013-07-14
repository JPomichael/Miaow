using System.Web;

using Autofac;
using System.Reflection;
using Autofac.Integration.Mvc;
using Miaow.Infrastructure.Crosscutting.NetFramework;
using Miaow.Infrastructure.Crosscutting.NetFramework.Fakes;

namespace Miaow.Presentation.Union
{
    public class MiaowPreUnionIoc
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
            builder.RegisterType<Miaow.Infrastructure.Data.Repository.SightInfoSortRepository>()
            .As<Miaow.Domain.Repository.ISightInfoSortRepository>().InstancePerHttpRequest();
            //end added by yjihrp 2012.3.6

            //added by 张军朋 2012/4/10
            builder.RegisterType<Miaow.Infrastructure.Data.Repository.RolesRepository>()
            .As<Miaow.Domain.Repository.IRolesRepository>().InstancePerHttpRequest();
            //end 

            //add by yjihrp 2012.4.12.17.2
            builder.RegisterType<Miaow.Infrastructure.Data.Repository.MvcControllerActionRepository>()
            .As<Miaow.Domain.Repository.IMvcControllerActionRepository>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Infrastructure.Data.Repository.MvcControllerClassRepository>()
            .As<Miaow.Domain.Repository.IMvcControllerClassRepository>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Infrastructure.Data.Repository.MvcControllerRepository>()
            .As<Miaow.Domain.Repository.IMvcControllerRepository>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Infrastructure.Data.Repository.MvcControllerRolePermissionRepository>()
            .As<Miaow.Domain.Repository.IMvcControllerRolePermissionRepository>().InstancePerHttpRequest();
            //end add by yjihrp 2012.4.12.17.2

            //add by jpomichael 2014/4/19
            builder.RegisterType<Miaow.Infrastructure.Data.Repository.AdminUserClassRepository>()
                .As<Miaow.Domain.Repository.IAdminUserClassRepository>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Infrastructure.Data.Repository.MvcControllerActionClassRepository>()
                .As<Miaow.Domain.Repository.IMvcControllerActionClassRepository>().InstancePerHttpRequest();
            //end



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
        }

        /// <summary>
        /// Registers the dj service.
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected static void RegisterApplicationDjService(Autofac.ContainerBuilder builder)
        {
            //builder.RegisterType<Miaow.Application.dj.Services.TourPlanService>()
            //.As<Miaow.Application.dj.Services.ITourPlanService>();
            //builder.RegisterType<Miaow.Application.dj.Services.HomeService>()
            //    .As<Miaow.Application.dj.Services.IHomeService>();
            //builder.RegisterType<Miaow.Application.dj.Services.HotelInfoService>()
            //    .As<Miaow.Application.dj.Services.IHotelInfoService>();
            //builder.RegisterType<Miaow.Application.dj.Services.HotKeyWordsService>()
            //    .As<Miaow.Application.dj.Services.IHotKeyWordsService>();
            //builder.RegisterType<Miaow.Application.dj.Services.LinksAndTopCountService>()
            //    .As<Miaow.Application.dj.Services.ILinksAndTopCountService>();
            //builder.RegisterType<Miaow.Application.dj.Services.ListService>()
            //    .As<Miaow.Application.dj.Services.IListService>();
            //builder.RegisterType<Miaow.Application.dj.Services.SearchService>()
            //    .As<Miaow.Application.dj.Services.ISearchService>();
        }

        /// <summary>
        /// Registers the jq service.
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected static void RegisterApplicationJqService(Autofac.ContainerBuilder builder)
        {
            builder.RegisterType<Miaow.Application.jq.Service.AddSortService>()
            .As<Miaow.Application.jq.Service.IAddSortService>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Application.jq.Service.ArticleService>()
            .As<Miaow.Application.jq.Service.IArticleService>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Application.jq.Service.HomeService>()
            .As<Miaow.Application.jq.Service.IHomeService>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Application.jq.Service.PageService>()
            .As<Miaow.Application.jq.Service.IPageService>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Application.jq.Service.PicInfoService>()
            .As<Miaow.Application.jq.Service.IPicInfoService>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Application.jq.Service.SearchService>()
            .As<Miaow.Application.jq.Service.ISearchService>().InstancePerHttpRequest(); ;
            builder.RegisterType<Miaow.Application.jq.Service.SightInfoService>()
            .As<Miaow.Application.jq.Service.ISightInfoService>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Application.jq.Service.SinaInfoService>()
            .As<Miaow.Application.jq.Service.ISinaInfoService>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Application.jq.Service.TicketService>()
            .As<Miaow.Application.jq.Service.ITicketService>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Application.jq.Service.TopClassService>()
            .As<Miaow.Application.jq.Service.ITopClassService>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Application.jq.Service.VideoInfoService>()
            .As<Miaow.Application.jq.Service.IVideoInfoService>().InstancePerHttpRequest();

        }

        /// <summary>
        /// Registers the jq service.
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected static void RegisterServiceUnionService(Autofac.ContainerBuilder builder)
        {
            builder.RegisterType<Miaow.Service.Union.CitySettingDefault>()
            .As<Miaow.Service.Union.CitySettingBase>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Service.Union.UnionCityService>()
            .As<Miaow.Service.Union.IUnionCityService>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Service.Union.Service.CityService>()
            .As<Miaow.Service.Union.Service.ICityService>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Service.Union.Service.HeadVouchDataService>()
            .As<Miaow.Service.Union.Service.IHeadVouchDataService>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Service.Union.Service.HotelAroundHotelService>()
           .As<Miaow.Service.Union.Service.IHotelAroundHotelService>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Service.Union.Service.HotelCommService>()
            .As<Miaow.Service.Union.Service.IHotelCommService>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Service.Union.Service.HotelCommSysService>()
            .As<Miaow.Service.Union.Service.IHotelCommSysService>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Service.Union.Service.HotelEbookService>()
            .As<Miaow.Service.Union.Service.IHotelEbookService>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Service.Union.Service.HotelInfoService>()
            .As<Miaow.Service.Union.Service.IHotelInfoService>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Service.Union.Service.HotelLeftMidService>()
            .As<Miaow.Service.Union.Service.IHotelLeftMidService>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Service.Union.Service.HotelPicService>()
            .As<Miaow.Service.Union.Service.IHotelPicService>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Service.Union.Service.HotelRoomService>()
            .As<Miaow.Service.Union.Service.IHotelRoomService>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Service.Union.Service.HotelSearchService>()
            .As<Miaow.Service.Union.Service.IHotelSearchService>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Service.Union.Service.HotelTrafficService>()
            .As<Miaow.Service.Union.Service.IHotelTrafficService>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Service.Union.Service.HotelTypeService>()
            .As<Miaow.Service.Union.Service.IHotelTypeService>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Service.Union.Service.TodayLowPriceService>()
            .As<Miaow.Service.Union.Service.ITodayLowPriceService>().InstancePerHttpRequest();
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

            //add JPomichael 2012.4.17
            builder.RegisterType<Miaow.Infrastructure.Crosscutting.Authorize.UserExtensionService>()
              .As<Miaow.Infrastructure.Crosscutting.Authorize.IUserExtensionService>().InstancePerHttpRequest();
            //end add JPomichael 2012.4.17

            //added by yjihrp 2012.4.12
            builder.RegisterType<Miaow.Infrastructure.Crosscutting.Authorize.AssemblyControllerService>();
            //end added by yjihrp 2012.4.12

            //add by jpomichael 2014/4/19
            builder.RegisterType<Miaow.Infrastructure.Crosscutting.Authorize.AdminUserClassService>()
                .As<Miaow.Infrastructure.Crosscutting.Authorize.IAdminUserClassService>().InstancePerHttpRequest();
            builder.RegisterType<Miaow.Infrastructure.Crosscutting.Authorize.MvcControllerActionClassService>()
                .As<Miaow.Infrastructure.Crosscutting.Authorize.IMvcControllerActionClassService>().InstancePerHttpRequest();
            //end add by jpomichael 2014/4/19
        }
    }
}