using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iPow.Service.SSO.WebService.Controllers
{
    [HandleError]
    public class SinaController : Controller
    {
        Infrastructure.Crosscutting.Authorize.IUserService userService;

        Infrastructure.Crosscutting.Authorize.IUserExtensionService userExtensionService;

        public SinaController(Infrastructure.Crosscutting.Authorize.IUserService user,
            Infrastructure.Crosscutting.Authorize.IUserExtensionService userExtension)
        {
            if (user == null)
            {
                throw new ArgumentNullException("userService is null");
            }
            userService = user;
            userExtensionService = userExtension;
        }

        [HttpGet]
        public RedirectResult LogOn(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl))
            {
                returnUrl = "http://sso.ipow.cn";
                //returnUrl = "http://www.ipow.cn";
            }
            Session[Infrastructure.Crosscutting.Comm.Service.ConstService.SessionNameSinaReturnUrl] = returnUrl;
            Wbm.SinaV2API.oAuthSina oauth = Wbm.SinaV2API.SinaBase.oAuth();
            string link = oauth.GetAuthorization(); //获取用户认证地址
            return Redirect(link);
        }

        [HttpGet]
        public ActionResult CallBack(string code)
        {
            //如果能过授权
            if (!string.IsNullOrEmpty(code))
            {
                Wbm.SinaV2API.oAuthSina oauth = Wbm.SinaV2API.SinaBase.oAuth();
                try
                {
                    oauth.GetAccessToken(); //获取认证信息
                    if (!string.IsNullOrEmpty(oauth.AccessToken))
                    {
                        Wbm.SinaV2API.SinaBase.UpdateCache(oauth.AccessToken);//缓存认证信息

                        #region sina login

                        var sinaUser = Wbm.SinaV2API.SinaControllers.UserController.GetUser();

                        if (sinaUser != null)
                        {
                            string sinaId = sinaUser.id.ToString();
                            string sinaName = sinaUser.screen_name;
                            if (!string.IsNullOrEmpty(sinaId))
                            {
                                var sinaLoginModel = userService.GetUserBySina(sinaId);
                                //如果存在
                                if (sinaLoginModel != null && sinaLoginModel.id > 0)
                                {
                                    var currentUserDto = AutoMapper.Mapper.Map<iPow.Infrastructure.Data.DataSys.Sys_AdminUser,
                                        iPow.Service.SSO.Entity.User>(sinaLoginModel);
                                    currentUserDto.LoginDomain = "http://sso.ipow.cn";
                                    currentUserDto.LoginIpAddress = iPow.Infrastructure.Crosscutting.Function.StringHelper.GetRealIP();
                                    //添加到SsoUserList中
                                    //用户已登录
                                    return UserLoginedAndRedirect(currentUserDto);
                                }
                                //不存在
                                else
                                {
                                    #region 不存在

                                    iPow.Infrastructure.Data.DataSys.Sys_AdminUser user = new Infrastructure.Data.DataSys.Sys_AdminUser();
                                    iPow.Infrastructure.Data.DataSys.Sys_UserRoles userRole = new Infrastructure.Data.DataSys.Sys_UserRoles();
                                    iPow.Infrastructure.Data.DataSys.Sys_AdminUser perUser = new Infrastructure.Data.DataSys.Sys_AdminUser();
                                    userRole.RoleID = 8;

                                    user.UserType = "xl";
                                    user.username = sinaUser.screen_name;
                                    user.truename = sinaUser.screen_name;
                                    perUser.id = 1;
                                    userService.Add(user, userRole, perUser);
                                    if (user.id != 0)
                                    {
                                        //添加用户扩展信息
                                        var userExtension = new Infrastructure.Data.DataSys.Sys_AdminUserExtension();
                                        userExtension.AddTime = System.DateTime.Now;
                                        userExtension.QQId = "";
                                        userExtension.QQScreenName = "";
                                        userExtension.SinaId = sinaUser.id.ToString();
                                        userExtension.SinaScreenName = sinaUser.screen_name;
                                        userExtension.Sort = 0;
                                        userExtension.State = true;
                                        userExtension.UserId = user.id;
                                        userExtension.SinaAccessToken = oauth.AccessToken;
                                        userExtension.SinaAccessTokenSecret = "";
                                        userExtensionService.Add(userExtension, perUser);
                                        //end 添加用户扩展信息

                                        var currentRegisterUserDto = AutoMapper.Mapper.Map<iPow.Infrastructure.Data.DataSys.Sys_AdminUser, iPow.Service.SSO.Entity.User>(user);
                                        if (currentRegisterUserDto.id > 0)
                                        {
                                            //用户登录后返回的地址
                                            currentRegisterUserDto.LoginDomain = "http://sso.ipow.cn";
                                            currentRegisterUserDto.LoginIpAddress = iPow.Infrastructure.Crosscutting.Function.StringHelper.GetRealIP();
                                            //添加到SsoUserList中
                                            //用户已登录
                                            return UserLoginedAndRedirect(currentRegisterUserDto);
                                        }
                                        else
                                        {
                                            ViewBag.message = "亲爱的用户，您是第一次用新浪帐号登陆IPOW网站<br/>";
                                            ViewBag.message += "但登陆过程中出了点小毛病，<a href='/sina/logon/'>您愿意再试一次嘛</a>";
                                            return View();
                                        }
                                    }
                                    else
                                    {
                                        ViewBag.message = "亲爱的用户，您是第一次用新浪帐号登陆IPOW网站<br/>";
                                        ViewBag.message += "但登陆过程中出了点小毛病，<a href='/sina/logon/'>您愿意再试一次嘛</a>";
                                        return View();
                                    }
                                    #endregion
                                }
                            }
                            else
                            {
                                ViewBag.message = "貌似登陆过程中出现了点小问题，貌似你没有新浪ID哦，<a href='/sina/logon/'>再登陆一次吧<a>";
                                return View();
                            }
                        }
                        else
                        {
                            ViewBag.message = "登陆过程中，我们没有获取到新浪信息，你可以尝试<a href='/sina/logon/'>再登陆一次</a>";
                            return View();
                        }

                        #endregion
                    }
                    else
                    {
                        ViewBag.message = "在连接新浪失败了，<a href='/sina/logon/'>请再试试</a>";
                        return View();
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.message = "在连接新浪失败了，<a href='/sina/logon/'>请再试试</a>";
                    return View();
                }
            }
            else
            {
                ViewBag.message = "不正确的访问方式";
                return View();
            }
        }

        //添加到网络列表中
        [NonAction]
        protected RedirectResult UserLoginedAndRedirect(iPow.Service.SSO.Entity.User user)
        {
            #region user first login

            var tempOnlineUser = iPow.Service.SSO.WebService.OnLineUserService
                 .OnLineUserList.Where(e => e.username == user.username && e.id == user.id)
                 .FirstOrDefault();

            if (tempOnlineUser == null)
            {
                var onlineUser = new iPow.Service.SSO.Entity.OnlineUser()
                {
                    Activity = user.Activity,
                    DepartmentID = user.DepartmentID,
                    Email = user.Email,
                    EmployeeID = user.EmployeeID,
                    id = user.id,
                    lastloginip = user.lastloginip,
                    lastlogintime = user.lastlogintime,
                    LoginDomain = user.LoginDomain,
                    LoginIpAddress = user.LoginIpAddress,
                    LoginTime = System.DateTime.Now,
                    logintimes = user.logintimes,
                    password = user.password,
                    Phone = user.Phone,
                    roleid = user.roleid,
                    sex = user.sex,
                    style = user.style,
                    truename = user.truename,
                    UserGuid = user.UserGuid,
                    userid = user.userid,
                    username = user.username,
                    UserType = user.UserType
                };
                iPow.Service.SSO.WebService.OnLineUserService.OnLineUserList.Add(onlineUser);
            }
            #endregion

            //add session 这里的session用法，要和子站点统一，管理好时间
            iPow.Infrastructure.Crosscutting.Function.SessionHelper.Add(
                iPow.Infrastructure.Crosscutting.Comm.Service.ConstService.SessionNameCurrentUser,
               user, iPow.Infrastructure.Crosscutting.Comm.Service.ConstService.SessionExpires);
            //添加 Cookie 一边以其它业务网站能够访问
            iPow.Infrastructure.Crosscutting.Comm.Service.SsoService.SendSsoUserLoginedCookie();
            //添加日志记录

            #region buileder secutity token

            iPow.Service.SSO.Entity.SecurityToken securityToken = new Entity.SecurityToken()
            {
                CreateTime = System.DateTime.Now,
                TokenId = iPow.Infrastructure.Crosscutting.Comm.Service.SsoService.BuilderTokenId(),
                IsValid = false,
                User = user
            };
            iPow.Service.SSO.WebService.SecurityTokenService.SecurityTokenList.Add(securityToken);

            #endregion
            //返回
            var url = this.GetReturnUrl(securityToken.TokenId);
            return Redirect(url);
        }

        protected string GetReturnUrl(string tokenId)
        {
            var url = "http://testwww.ipow.cn";
            if (Session[Infrastructure.Crosscutting.Comm.Service.ConstService.SessionNameSinaReturnUrl] != null)
            {
                url = Session[Infrastructure.Crosscutting.Comm.Service.ConstService.SessionNameSinaReturnUrl].ToString();
                url = (string.Compare(url, "/sina/logon", false) == 0) ? "/" : url;
                url = (string.Compare(url, "/sina/callback", false) == 0) ? "/" : url;
                url = (string.Compare(url, "/sina/logon/", false) == 0) ? "/" : url;
                url = (string.Compare(url, "/sina/callback/", false) == 0) ? "/" : url;
            }

            #region checked url
            var newUri = new Uri(url);
            var newUrl = string.Empty;

            if (!string.IsNullOrEmpty(newUri.Query))
            {
                var para = Wbm.SinaV2API.Helpers.HttpUtil.GetQueryParameters(newUri.Query);
                var temp = new List<Wbm.SinaV2API.Helpers.QueryParameter>();
                foreach (var item in para)
                {
                    if (string.Compare(item.Name, "token", false) != 0)
                    {
                        temp.Add(item);
                    }
                }
                newUrl = newUri.Scheme + "://" + newUri.Host + newUri.AbsolutePath + "?" + Wbm.SinaV2API.Helpers.HttpUtil.GetQueryFromParas(temp);
            }
            else
            {
                newUrl = newUri.OriginalString;
            }

            #endregion

            string splitStr = newUrl.Contains("?") ? "&" : "?";
            string returnFormat = "{0}{1}" + iPow.Infrastructure.Crosscutting.Comm.Service.ConstService.UrlParaToken + "={2}";
            var redirectUrl = string.Format(returnFormat, newUrl, splitStr, tokenId);
            return redirectUrl;
        }
    }
}
