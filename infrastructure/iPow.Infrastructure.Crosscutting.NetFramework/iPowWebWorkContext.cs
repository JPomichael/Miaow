using System;
using System.Linq;
using System.Web;

namespace iPow.Infrastructure.Crosscutting.NetFramework
{
    /// <summary>
    /// Working context for web application
    /// </summary>
    public class iPowWebWorkContext : IWorkContext
    {
        /// <summary>
        /// 
        /// </summary>
        readonly HttpContextBase httpContext;

        /// <summary>
        /// 
        /// </summary>
        iPow.Infrastructure.Data.DataSys.Sys_AdminUser cachedUser;

        /// <summary>
        /// 
        /// </summary>
        iPow.Infrastructure.Data.DataSys.Sys_AdminUserExtension cachedUserExtension;

        /// <summary>
        /// 
        /// </summary>
        iPow.Infrastructure.Crosscutting.Authorize.IUserService userService;

        iPow.Infrastructure.Crosscutting.Authorize.IUserExtensionService userExtensionService;

        /// <summary>
        /// 
        /// </summary>
        iPow.Infrastructure.Crosscutting.Comm.Service.ICityInfoService cityInfoService;

        /// <summary>
        /// Initializes a new instance of the <see cref="iPowWebWorkContext"/> class.
        /// </summary>
        /// <param name="ipowHttpContext">The HTTP context.</param>
        /// <param name="ipowUserService">The ipow user service.</param>
        /// <param name="ipowCityInfoService">The ipow city info service.</param>
        public iPowWebWorkContext(HttpContextBase ipowHttpContext,
            iPow.Infrastructure.Crosscutting.Authorize.IUserService ipowUserService,
            iPow.Infrastructure.Crosscutting.Comm.Service.ICityInfoService ipowCityInfoService,
            iPow.Infrastructure.Crosscutting.Authorize.IUserExtensionService userExtension)
        {
            if (ipowHttpContext == null)
            {
                throw new ArgumentNullException("httpContext  is null");
            }
            if (ipowUserService == null)
            {
                throw new ArgumentNullException("userService  is null");
            }
            if (ipowCityInfoService == null)
            {
                throw new ArgumentNullException("cityInfoService  is null");
            }
            if (userExtension == null)
            {
                throw new ArgumentNullException("userExtensionService  is null");
            }
            httpContext = ipowHttpContext;
            userService = ipowUserService;
            cityInfoService = ipowCityInfoService;
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
        protected iPow.Infrastructure.Data.DataSys.Sys_AdminUser GetCurrentUser()
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
                            if (iPow.Infrastructure.Crosscutting.Function.StringHelper.IsSearchEngine(httpContext.Request))
                            {
                                //搜索引擎用户
                                adminUser = userService.GetUserById(iPow.Infrastructure.Crosscutting.Comm.Service.ConstService.UserSearchEngineUserId);
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
        protected iPow.Infrastructure.Data.DataSys.Sys_AdminUserExtension GetCurrentUserExtension()
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
        protected iPow.Infrastructure.Data.DataSys.Sys_AdminUser GetUserByCookie()
        {
            iPow.Infrastructure.Data.DataSys.Sys_AdminUser user = null;
            var userCookie = httpContext.Request.Cookies[iPow.Infrastructure.Crosscutting.Comm.Service.ConstService.CookieNameCurrentUser];
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
        protected iPow.Infrastructure.Data.DataSys.Sys_AdminUser GetUserBySession()
        {
            iPow.Infrastructure.Data.DataSys.Sys_AdminUser user = null;

            user = iPow.Infrastructure.Crosscutting.Function.SessionHelper.GetObjectValue(
                iPow.Infrastructure.Crosscutting.Comm.Service.ConstService.SessionNameCurrentUser) as
                iPow.Infrastructure.Data.DataSys.Sys_AdminUser;

            return user;
        }

        /// <summary>
        /// Sets the current user cookie.
        /// </summary>
        /// <param name="val">The val.</param>
        protected void SetCurrentUserCookie(string val)
        {
            iPow.Infrastructure.Crosscutting.Function.CookieHelper.Add(
                iPow.Infrastructure.Crosscutting.Comm.Service.ConstService.CookieNameCurrentUser,
                val, iPow.Infrastructure.Crosscutting.Comm.Service.ConstService.CookieExpires);
        }

        /// <summary>
        /// Sets the current user session.
        /// </summary>
        /// <param name="user">The user.</param>
        protected void SetCurrentUserSession(iPow.Infrastructure.Data.DataSys.Sys_AdminUser user)
        {
            iPow.Infrastructure.Crosscutting.Function.SessionHelper.Add(
                iPow.Infrastructure.Crosscutting.Comm.Service.ConstService.SessionNameCurrentUser,
                user, iPow.Infrastructure.Crosscutting.Comm.Service.ConstService.SessionExpires);
        }

        /// <summary>
        /// Gets the selected city info by cookie.
        /// </summary>
        /// <returns></returns>
        protected iPow.Domain.Dto.Sys_CityInfoDto GetSelectedCityInfoByCookie()
        {
            iPow.Domain.Dto.Sys_CityInfoDto cityInfo = null;
            var selected = iPow.Infrastructure.Crosscutting.Function.CookieHelper.Get(
                iPow.Infrastructure.Crosscutting.Comm.Service.ConstService
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
        protected iPow.Domain.Dto.Sys_CityInfoDto GetCityInfoByCookie()
        {
            iPow.Domain.Dto.Sys_CityInfoDto cityInfo = null;
            var selected = iPow.Infrastructure.Crosscutting.Function.CookieHelper.Get(
                iPow.Infrastructure.Crosscutting.Comm.Service.ConstService
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
        public iPow.Domain.Dto.Sys_CityInfoDto SelectedCityInfo
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
                iPow.Infrastructure.Crosscutting.Function.CookieHelper.Add(
                    iPow.Infrastructure.Crosscutting.Comm.Service.ConstService.CookieNameCurrentSelectedCityInfo,
                    city, iPow.Infrastructure.Crosscutting.Comm.Service.ConstService.CookieExpires);
            }
        }

        /// <summary>
        /// Gets or sets the current city info.
        /// </summary>
        /// <value>The current city info.</value>
        public iPow.Domain.Dto.Sys_CityInfoDto CurrentCityInfo
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
                iPow.Infrastructure.Crosscutting.Function.CookieHelper.Add(
                    iPow.Infrastructure.Crosscutting.Comm.Service.ConstService.CookieNameCurrentCityInfo,
                    city, iPow.Infrastructure.Crosscutting.Comm.Service.ConstService.CookieExpires);
            }
        }
    }
}
