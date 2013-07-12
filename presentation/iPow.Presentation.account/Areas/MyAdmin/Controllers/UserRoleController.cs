using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Web.Mvc;

namespace iPow.Presentation.account.Areas.MyAdmin
{
    [HandleError]
    public class UserRoleController :
        iPow.Infrastructure.Crosscutting.NetFramework.Controllers.iPowBaseController
    {
        iPow.Infrastructure.Crosscutting.Authorize.IUserRoleService userRoleService;

        iPow.Infrastructure.Crosscutting.Authorize.IUserService userService;

        iPow.Infrastructure.Crosscutting.Authorize.IRoleService roleService;

        public UserRoleController(iPow.Infrastructure.Crosscutting.NetFramework.IWorkContext work,
            iPow.Infrastructure.Crosscutting.Authorize.IUserRoleService userRole,
            iPow.Infrastructure.Crosscutting.Authorize.IUserService user,
            iPow.Infrastructure.Crosscutting.Authorize.IRoleService role)
            : base(work)
        {
            if (userRole == null)
            {
                throw new ArgumentNullException("userRoleService is null");
            }
            if (user == null)
            {
                throw new ArgumentNullException("userService is null");
            }
            if (role == null)
            {
                throw new ArgumentNullException("roleService is null");
            }
            userRoleService = userRole;
            userService = user;
            roleService = role;
        }

        //得到所有角色
        public ViewResult Index()
        {
            var dto = this.GetUserRoleDtoList();
            //根据UserId 查询出UserName 用于前台的显示
            return View(dto);
        }

        [GridAction]
        public JsonResult AjaxIndex(string searchKey)
        {
            var data = userRoleService.GetUserRoleDtoList().AsEnumerable();
            if (!string.IsNullOrEmpty(searchKey))
            {
                data = data.Where(e => e.UserName.Contains(searchKey));
            }
            data = data.OrderByDescending(e => e.Id).AsEnumerable();

            //iPow.Domain.Dto.Sys_UserRolesDto

            var model = new GridModel<iPow.Infrastructure.Crosscutting.Authorize.Dto.UserRoleDto>
            {
                Data = data,
                Total = data.Count()
            };
            return new JsonResult { Data = model, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        /// <summary>
        ///   Show Data  For Add New UserRole
        /// </summary>
        /// <returns></returns>
        public ViewResult AddUserRole()
        {
            //做为 DropDownList DataSource
            ViewBag.rolemodel = roleService.GetList();
            var model = new Infrastructure.Crosscutting.Authorize.Dto.UserRoleDto();
            return View(model);
        }

        /// <summary>
        /// Add New UserRole
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ViewResult AddUserRole(iPow.Infrastructure.Crosscutting.Authorize.Dto.UserRoleDto userRole)
        {
            ViewBag.rolemodel = roleService.GetList();
            if (userRole != null && userRole.RoleID > 0)
            {
                var user = userService.GetUserByName(userRole.UserName);
                if (user != null && user.id > 0)
                {
                    //判断User 是否存在当前所选Role  若没有则创建 有的话 阻止
                    var isexist = userRoleService.UserHasUserRole(user.id, userRole.RoleID);
                    if (isexist)  //该语法表示 已经存在
                    {
                        ModelState.AddModelError("", "该用户已经存在同一角色！");
                    }
                    else
                    {
                        var addUserRole = new iPow.Infrastructure.Data.DataSys.Sys_UserRoles();
                        addUserRole.RoleID = userRole.RoleID;
                        addUserRole.UserID = user.id;
                        userRoleService.Add(addUserRole,null);
                        ModelState.AddModelError("", "已成功为用户添加角色");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "" + "在系统中没有找到这个用户");
                }
            }
            else
            {
                ModelState.AddModelError("", "请使用正确地操作方式");
            }
            return View(userRole);
        }

        /// <summary>
        /// 删除用户角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [GridAction]
        [HttpPost]
        public JsonResult DeleteUserRole(int id)
        {
            //因为一个用户可能会有多个角色 所以根绝UserRoleID 查询出用户UserRole
            var model = userRoleService.GetUserRoleSingleById(id);
            //得到UserRole 然后干掉
            if (model != null && model.Id != 0)
            {
                userRoleService.Delete(model, null);
            }
            var dto = this.GetUserRoleDtoList();
            //返回给Json
            return Json(dto, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 选取获得ID 即可点击干掉
        /// </summary>
        /// <param name="del"></param>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpPost]
        public JsonResult DeleteMulUserRole(FormCollection del)
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
        ///  用于Edit 后的提交
        /// </summary>
        /// <param name="userRole"></param>
        /// <returns></returns>

        [HttpPost]
        public ViewResult EditUserRole(iPow.Infrastructure.Crosscutting.Authorize.Dto.UserRoleDto userRole)
        {
            try
            {
                if (userRole != null && userRole.Id > 0)
                {
                    //根据UserRoleId 即可得到UserRoleModel
                    var model = userRoleService.GetUserRoleSingleById(userRole.Id);
                    model.RoleID = userRole.RoleID;
                    model.Id = userRole.Id;
                    model.UserID = userRole.UserID;
                    userRoleService.Modify(model, null);
                    var dto = model.ToDto();
                    dto.UserName = userRole.UserName;
                    return View(dto);
                }
            }
            catch
            {
            }
            return View(userRole);
        }

        /// <summary>
        /// 用于Edit 初始化 Show Data 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ViewResult EditUserRole(int id)
        {
            var model = userRoleService.GetUserRoleSingDto(id);
            return View(model);
        }

        [HttpGet]
        public JsonResult SearchUserRole(string term)
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
                return Json(data.ToList(), JsonRequestBehavior.AllowGet);
            }
        }

        #region util

        protected iPow.Infrastructure.Data.DataSys.Sys_UserRoles SysSingleUserRole(int id)
        {
            var data = userRoleService.GetList().Where(e => e.Id == id).FirstOrDefault();
            return data;
        }

        protected IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_AdminUser> CurrentUserName()
        {
            var data = userService.GetList().OrderByDescending(e => e.logintimes).AsEnumerable();
            var currentUserId = 0;
            if (currentUserId != 0)
            {
                data = data.Where(e => e.id == currentUserId);
            }
            return data;
        }

        protected IEnumerable<iPow.Infrastructure.Crosscutting.Authorize.Dto.UserRoleDto> GetUserRoleDtoList()
        {
            var data = userRoleService.GetUserRoleDtoList().OrderByDescending(e => e.Id);
            return data.AsEnumerable();
        }

        #endregion
    }
}
