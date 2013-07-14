using System;
using System.Linq;
using System.Web;

namespace Miaow.Infrastructure.Crosscutting.NetFramework
{
    /// <summary>
    /// Working context for web application
    /// </summary>
    public class MiaowWebWorkContext : IWorkContext
    {
        /// <summary>
        /// 
        /// </summary>
        readonly HttpContextBase httpContext;

        /// <summary>
        /// 
        /// </summary>
        Miaow.Infrastructure.Data.DataSys.Sys_AdminUser cachedUser;

        /// <summary>
        /// 
        /// </summary>
        Miaow.Infrastructure.Data.DataSys.Sys_AdminUserExtension cachedUserExtension;

        /// <summary>
        /// 
        /// </summary>
        Miaow.Infrastructure.Crosscutting.Authorize.IUserService userService;

        Miaow.Infrastructure.Crosscutting.Authorize.IUserExtensionService userExtensionService;

        /// <summary>
        /// 
        /// </summary>
        Miaow.Infrastructure.Crosscutting.Comm.Service.ICityInfoService cityInfoService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MiaowWebWorkContext"/> class.
        /// </summary>
        /// <param name="MiaowHttpContext">The HTTP context.</param>
        /// <param name="MiaowUserService">The Miaow user service.</param>
        /// <param name="MiaowCityInfoService">The Miaow city info service.</param>
        public MiaowWebWorkContext(HttpContextBase MiaowHttpContext,
            Miaow.Infrastructure.Crosscutting.Authorize.IUserService MiaowUserService,
            Miaow.Infrastructure.Crosscutting.Comm.Service.ICityInfoService MiaowCityInfoService,
            Miaow.Infrastructure.Crosscutting.Authorize.IUserExtensionService userExtension)
        {
            if (MiaowHttpContext == null)
            {
                throw new ArgumentNullException("httpContext  is null");
            }
            if (MiaowUserService == null)
            {
                throw new ArgumentNullException("userService  is null");
            }
            if (MiaowCityInfoService == null)
            {
                throw new ArgumentNullException("cityInfoService  is null");
            }
            if (userExtension == null)
            {
                throw new ArgumentNullException("userExtensionService  is null");
            }
            httpContext = MiaowHttpContext;
            userService = MiaowUserService;
            cityInfoService = MiaowCityInfoService;
            userExtensionService = userExtension;
        }

        /// <summary>
        /// Get or set value indicating whether we're in admin area
        /// </summary>
        /// <value></value>
        public bool IsAdmin
        {
            get
            {
                if (CurrentUser != null && CurrentUser.roleid == 1)
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// Gets or sets the current Data.DataSys.Sys_AdminUser
        /// </summary>
        /// <value></value>
        public Data.DataSys.Sys_AdminUser CurrentUser
        {
            get
            {
                return GetCurrentUser();
            }
            set
            {
                SetCurrentUserCookie(value.UserGuid);
                SetCurrentUserSession(value);
                cachedUser = value;
            }
        }

        /// <summary>
        /// Gets or sets the current user extension.
        /// </summary>
        /// <value>The current user extension.</value>
        public Data.DataSys.Sys_AdminUserExtension CurrentUserExtension
        {
            get
            {
                return GetCurrentUserExtension();
            }
            set
            {
                cachedUserExtension = value;
            }
        }

        /// <summary>
        /// Gets the current user.
        /// </summary>
        /// <returns></returns>
        protected Miaow.Infrastructure.Data.DataSys.Sys_AdminUser GetCurrentUser()
        {
            if (cachedUser != null)
            {
                return cachedUser;
            }
            else
            {
                Data.DataSys.Sys_AdminUser adminUser = null;
                if (httpContext != null)
                {
                    //cookie
                    adminUser = GetUserByCookie();
                    if (adminUser == null)
                    {
                        adminUser = GetUserBySession();
                        if (adminUser != null)
                        {
                            cachedUser = adminUser;
                        }
                        else
                        {
                            //check whether request is made by a search engine
                            //in this case return built-in Data.DataSys.Sys_AdminUser record for search engines 
                            //or comment the following two lines of code in order to disable this functionality
                            if (Miaow.Infrastructure.Crosscutting.Function.StringHelper.IsSearchEngine(httpContext.Request))
                            {
                                //搜索引擎用户
                                adminUser = userService.GetUserById(Miaow.Infrastructure.Crosscutting.Comm.Service.ConstService.UserSearchEngineUserId);
                            }
                        }
                    }
                    else
                    {
                        cachedUser = adminUser;
                    }
                }
            }
            return cachedUser;
        }

        /// <summary>
        /// Sys_s the admin user extension.
        /// </summary>
        /// <returns></returns>
        protected Miaow.Infrastructure.Data.DataSys.Sys_AdminUserExtension GetCurrentUserExtension()
        {
            if (CurrentUser == null)
            {
                return null;
            }
            else
            {
                cachedUserExtension = userExtensionService.Get(CurrentUser.id);
            }
            return cachedUserExtension;
        }

        /// <summary>
        /// Gets the user by cookie value.
        /// 这个地方没有用function库
        /// </summary>
        /// <returns></returns>
        protected Miaow.Infrastructure.Data.DataSys.Sys_AdminUser GetUserByCookie()
        {
            Miaow.Infrastructure.Data.DataSys.Sys_AdminUser user = null;
            var userCookie = httpContext.Request.Cookies[Miaow.Infrastructure.Crosscutting.Comm.Service.ConstService.CookieNameCurrentUser];
            if (userCookie != null)
            {
                user = userService.GetUserByUserGuid(userCookie.Value);
            }
            return user;
        }

        /// <summary>
        /// Gets the user by session.
        /// </summary>
        /// <returns></returns>
        protected Miaow.Infrastructure.Data.DataSys.Sys_AdminUser GetUserBySession()
        {
            Miaow.Infrastructure.Data.DataSys.Sys_AdminUser user = null;

            user = Miaow.Infrastructure.Crosscutting.Function.SessionHelper.GetObjectValue(
                Miaow.Infrastructure.Crosscutting.Comm.Service.ConstService.SessionNameCurrentUser) as
                Miaow.Infrastructure.Data.DataSys.Sys_AdminUser;

            return user;
        }

        /// <summary>
        /// Sets the current user cookie.
        /// </summary>
        /// <param name="val">The val.</param>
        protected void SetCurrentUserCookie(string val)
        {
            Miaow.Infrastructure.Crosscutting.Function.CookieHelper.Add(
                Miaow.Infrastructure.Crosscutting.Comm.Service.ConstService.CookieNameCurrentUser,
                val, Miaow.Infrastructure.Crosscutting.Comm.Service.ConstService.CookieExpires);
        }

        /// <summary>
        /// Sets the current user session.
        /// </summary>
        /// <param name="user">The user.</param>
        protected void SetCurrentUserSession(Miaow.Infrastructure.Data.DataSys.Sys_AdminUser user)
        {
            Miaow.Infrastructure.Crosscutting.Function.SessionHelper.Add(
                Miaow.Infrastructure.Crosscutting.Comm.Service.ConstService.SessionNameCurrentUser,
                user, Miaow.Infrastructure.Crosscutting.Comm.Service.ConstService.SessionExpires);
        }

        /// <summary>
        /// Gets the selected city info by cookie.
        /// </summary>
        /// <returns></returns>
        protected Miaow.Domain.Dto.Sys_CityInfoDto GetSelectedCityInfoByCookie()
        {
            Miaow.Domain.Dto.Sys_CityInfoDto cityInfo = null;
            var selected = Miaow.Infrastructure.Crosscutting.Function.CookieHelper.Get(
                Miaow.Infrastructure.Crosscutting.Comm.Service.ConstService
                .CookieNameCurrentSelectedCityInfo);
            if (selected != null && string.IsNullOrEmpty(selected))
            {
                var selectCity = selected.Split('-');
                if (selectCity.Count() == 2)
                {
                    cityInfo = cityInfoService.GetCityInfoSingleByName(selectCity[0], selectCity[1]);
                }
            }
            return cityInfo;
        }

        /// <summary>
        /// Gets the city info by cookie.
        /// </summary>
        /// <returns></returns>
        protected Miaow.Domain.Dto.Sys_CityInfoDto GetCityInfoByCookie()
        {
            Miaow.Domain.Dto.Sys_CityInfoDto cityInfo = null;
            var selected = Miaow.Infrastructure.Crosscutting.Function.CookieHelper.Get(
                Miaow.Infrastructure.Crosscutting.Comm.Service.ConstService
                .CookieNameCurrentCityInfo);
            if (selected != null && string.IsNullOrEmpty(selected))
            {
                var selectCity = selected.Split('-');
                if (selectCity.Count() == 2)
                {
                    cityInfo = cityInfoService.GetCityInfoSingleByName(selectCity[0], selectCity[1]);
                }
            }
            return cityInfo;
        }

        /// <summary>
        /// Gets or sets the select city info.
        /// </summary>
        /// <value>The select city info.</value>
        public Miaow.Domain.Dto.Sys_CityInfoDto SelectedCityInfo
        {
            get
            {
                return GetSelectedCityInfoByCookie();
            }
            set
            {
                var city = string.Empty;
                if (value != null)
                {
                    city = value.province + "-" + value.pinyin;
                }
                Miaow.Infrastructure.Crosscutting.Function.CookieHelper.Add(
                    Miaow.Infrastructure.Crosscutting.Comm.Service.ConstService.CookieNameCurrentSelectedCityInfo,
                    city, Miaow.Infrastructure.Crosscutting.Comm.Service.ConstService.CookieExpires);
            }
        }

        /// <summary>
        /// Gets or sets the current city info.
        /// </summary>
        /// <value>The current city info.</value>
        public Miaow.Domain.Dto.Sys_CityInfoDto CurrentCityInfo
        {
            get
            {
                return GetCityInfoByCookie();
            }
            set
            {
                var city = string.Empty;
                if (value != null)
                {
                    city = value.province + "-" + value.pinyin;
                }
                Miaow.Infrastructure.Crosscutting.Function.CookieHelper.Add(
                    Miaow.Infrastructure.Crosscutting.Comm.Service.ConstService.CookieNameCurrentCityInfo,
                    city, Miaow.Infrastructure.Crosscutting.Comm.Service.ConstService.CookieExpires);
            }
        }
    }
}
