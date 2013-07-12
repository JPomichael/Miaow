using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Telerik.Web.Mvc;
using iPow.Infrastructure.Crosscutting.EntityToDto;

namespace iPow.Presentation.account.Areas.MyAdmin
{
    [HandleError]
    public class UserController :
        iPow.Infrastructure.Crosscutting.NetFramework.Controllers.iPowBaseController
    {
        iPow.Infrastructure.Crosscutting.Authorize.IUserService userService;

        public UserController(iPow.Infrastructure.Crosscutting.NetFramework.IWorkContext work,
            iPow.Infrastructure.Crosscutting.Authorize.IUserService userRole)
            : base(work)
        {
            if (userRole == null)
            {
                throw new ArgumentNullException("userService is null");
            }
            userService = userRole;
        }

        //查询出所有User
        public ViewResult Index()
        {
            var AllUser = this.GetList();
            //转换成Dto
            var dto = AllUser.ToDto();
            dto = dto.OrderByDescending(e => e.id).AsEnumerable();
            return View(dto);
        }

        [GridAction]
        public JsonResult AjaxIndex(string searchKey)
        {
            var data = this.GetList().AsEnumerable();
            if (!string.IsNullOrEmpty(searchKey))
            {
                data = data.Where(e => e.username.Contains(searchKey));
            }
            var dto = data.ToDto();
            dto = dto.OrderByDescending(e => e.id).AsEnumerable();
            var model = new GridModel<iPow.Domain.Dto.Sys_AdminUserDto>
            {
                Data = dto,
                Total = data.Count()
            };
            return new JsonResult { Data = model, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        //为AddUser 做初始化
        public ActionResult AddUser()
        {
            iPow.Domain.Dto.Sys_AdminUserDto user = new Domain.Dto.Sys_AdminUserDto();
            return View(user);
        }

        //AddUser
        [HttpPost]
        public ActionResult AddUser(iPow.Domain.Dto.Sys_AdminUserDto user, string UserType)
        {
            //验证y用户数据是否为空
            if (user != null)
            {
                //查询name and email是否存在
                var checkuser = userService.UserHasUser(user.username, user.Email);
                if (checkuser)
                {
                    //表示已经存在
                    ModelState.AddModelError("", "亲 可以不用别人的昵称不？ ");
                }
                else
                {
                    iPow.Infrastructure.Data.DataSys.Sys_AdminUser addUser = new Infrastructure.Data.DataSys.Sys_AdminUser();
                    iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser = new Infrastructure.Data.DataSys.Sys_AdminUser();
                    iPow.Infrastructure.Data.DataSys.Sys_UserRoles userRole = new Infrastructure.Data.DataSys.Sys_UserRoles();
                    addUser.username = user.username;
                    addUser.password = iPow.Infrastructure.Crosscutting.Function.StringHelper.Tomd5(user.password);
                    addUser.truename = user.truename;
                    addUser.sex = user.sex; //根据用户选择去判断
                    addUser.Phone = user.Phone;
                    addUser.UserType = user.UserType;
                    addUser.Email = user.Email;
                    operUser.id = 1;
                    userRole.RoleID = Convert.ToInt32(GetUserType(UserType, userRole));
                    //判断是否添加成功
                    userService.Add(addUser, userRole, operUser);
                    if (addUser.id > 0)
                    {
                        ModelState.AddModelError("", "恭喜,亲彻底Hold住了");
                    }
                    else
                    {
                        ModelState.AddModelError("", "败笔！亲不给力哦~");
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "不要偷懒哦！请使用楷体用力填写~");
            }
            return View(user);
        }

        [GridAction]
        [HttpPost]
        public JsonResult DeleteUser(int id)
        {
            //获得Model
            var model = userService.GetUserById(id);
            userService.DeleteTrue(model, null);

            var data = this.GetList().AsEnumerable();
            var dto = data.ToDto();
            dto = dto.OrderByDescending(e => e.id).AsEnumerable();

            //返回给Json
            return Json(dto, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteMulUser(FormCollection del)
        {
            var res = false;
            var message = "";
            var selectedList = del.GetValues("selectRow");
            if (selectedList != null && selectedList.Count() > 0)
            {
                res = userService.Delete(selectedList.ToIntList(),null);
            }
            return Json(new { success = res, message = message });
        }

        /// <summary>
        /// 用于Edit前的显示
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ViewResult EditUser(int id)
        {
            var model = userService.GetUserById(id);
            var dto = model.ToDto();
            return View(dto);
        }

        [HttpPost]
        public ViewResult EditUser(iPow.Domain.Dto.Sys_AdminUserDto user)
        {
            try
            {
                if (user != null && user.id > 0)
                {
                    //根据Id得到当前UserRole
                    var model = userService.GetUserById(user.id);
                    //var model = this.SysSingleUser(user.id);
                    model.username = user.username;
                    model.truename = user.truename;
                    model.sex = user.sex;
                    model.Phone = user.Phone;
                    model.Email = user.Email;
                    iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser = new Infrastructure.Data.DataSys.Sys_AdminUser();
                    operUser.id = model.id;
                    //执行更新吧
                    userService.Modify(model, operUser);
                    var dto = model.ToDto();
                    ModelState.AddModelError("", "添加成功哦亲");
                    return View(dto);
                }
                else
                {
                    ModelState.AddModelError("", "败笔！还得努力啊亲");
                }
            }
            catch
            {
            }
            return View(user);
        }

        /// <summary>
        /// 返回Json 用于页面
        /// </summary>
        /// <param name="term"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult SearchUser(string term)
        {
            if (!string.IsNullOrEmpty(term))
            {
                var data = this.CurrentUserName().Where(e => e.username.Contains(term.Trim()))
                            .OrderBy(e => e.id).Take(10)
                            .Select(e => e.username);
                return Json(data.ToList(), JsonRequestBehavior.AllowGet);
            }
            else
            {
                var data = this.CurrentUserName().OrderBy(e => e.id).Take(10)
                            .Select(e => e.username);
                return Json(data.ToList(), JsonRequestBehavior.AllowGet);   //允许使用GET方式获取
            }
        }


        #region util

        protected IQueryable<iPow.Infrastructure.Data.DataSys.Sys_AdminUser> GetList()
        {
            var data = userService.GetList().OrderByDescending(e => e.id);
            return data.AsQueryable();
        }

        //根据用户注册选择的UserType类型判断 UserRole
        [NonAction]
        protected string GetUserType(string userSelected, iPow.Infrastructure.Data.DataSys.Sys_UserRoles userRole)
        {
            if (userSelected == null)
            {
                throw new ArgumentNullException("usertype is null");
            }
            else
            {
                switch (userSelected)
                {
                    case "ca":
                        userRole.RoleID = 1;
                        break;
                    case "xg":
                        userRole.RoleID = 2;
                        break;
                    case "pg":
                        userRole.RoleID = 3;
                        break;
                    case "jq":
                        userRole.RoleID = 4;
                        break;
                    case "jd":
                        userRole.RoleID = 5;
                        break;
                    case "sj":
                        userRole.RoleID = 6;
                        break;
                    case "lxs":
                        userRole.RoleID = 7;
                        break;
                    case "xl":
                        userRole.RoleID = 8;
                        break;
                    case "tx":
                        userRole.RoleID = 9;
                        break;
                }
            }
            return Convert.ToString(userRole.RoleID);
        }

        protected IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_AdminUser> CurrentUserName()
        {
            var data = this.GetList().OrderByDescending(e => e.logintimes).AsEnumerable();
            var currentUserId = 0;
            if (currentUserId != 0)
            {
                data = data.Where(e => e.id == currentUserId);
            }
            return data;
        }

        #endregion
    }
}
