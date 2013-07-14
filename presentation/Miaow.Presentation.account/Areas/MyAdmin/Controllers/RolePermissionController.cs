using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Miaow.Presentation.account.Areas.MyAdmin
{
    [HandleError]
    public class RolePermissionController : Controller
    {
        Miaow.Infrastructure.Crosscutting.Authorize.IRoleService roleService;

        Miaow.Infrastructure.Crosscutting.Authorize.IMvcActionService mvcActionService;

        Miaow.Infrastructure.Crosscutting.Authorize.IMvcControllerClassService mvcControllerClassService;

        Miaow.Infrastructure.Crosscutting.Authorize.IMvcControllerService mvcControllerService;

        Miaow.Infrastructure.Crosscutting.Authorize.IMvcRolePermissionService mvcRolePermissionService;

        public RolePermissionController(Miaow.Infrastructure.Crosscutting.NetFramework.IWorkContext work,
            Miaow.Infrastructure.Crosscutting.Authorize.IRoleService role,
            Miaow.Infrastructure.Crosscutting.Authorize.IMvcActionService mvcAction,
            Miaow.Infrastructure.Crosscutting.Authorize.IMvcControllerClassService mvcControllerClass,
            Miaow.Infrastructure.Crosscutting.Authorize.IMvcControllerService mvcController,
            Miaow.Infrastructure.Crosscutting.Authorize.IMvcRolePermissionService rolePermission)
        {
            if (role == null)
            {
                throw new ArgumentNullException("roleService is null");
            }
            if (mvcAction == null)
            {
                throw new ArgumentNullException("actionService is null");
            }
            if (mvcControllerClass == null)
            {
                throw new ArgumentNullException("actionService is null");
            }
            if (mvcController == null)
            {
                throw new ArgumentNullException("mvcControllerService is null");
            }
            if (rolePermission == null)
            {
                throw new ArgumentNullException("rolePermissionService is null");
            }
            roleService = role;
            mvcActionService = mvcAction;
            mvcControllerClassService = mvcControllerClass;
            mvcControllerService = mvcController;
            mvcRolePermissionService = rolePermission;
        }

        [HttpGet]
        public ViewResult Index(int id)
        {
            var model = this.GetRolePermissionDto(id);
            return View(model);
        }

        [HttpPost]
        public JsonResult Add(int id, int roleId, int actionId)
        {
            var hasRoleId = roleService.GetList().Where(e => e.RoleID == roleId).Any();
            if (hasRoleId)
            {
                var existActionId = mvcRolePermissionService.GetList().Where(e => e.RoleId == roleId && e.ActionId == actionId).Any();
                if (!existActionId)
                {
                    var hasActionModel = mvcActionService.GetList().Where(e => e.Id == actionId).FirstOrDefault();
                    if (hasActionModel != null && hasActionModel.Id > 0)
                    {
                        var addPermissionModel = new Miaow.Infrastructure.Data.DataSys.Sys_MvcControllerRolePermission();
                        addPermissionModel.ActionId = actionId;
                        addPermissionModel.AddTime = System.DateTime.Now;
                        addPermissionModel.IpAddress = Miaow.Infrastructure.Crosscutting.Function.StringHelper.GetRealIP();
                        addPermissionModel.Name = hasActionModel.Name;
                        addPermissionModel.Remark = hasActionModel.Remark;
                        addPermissionModel.RoleId = roleId;
                        addPermissionModel.SortNum = 0;
                        addPermissionModel.State = true;
                        mvcRolePermissionService.Add(addPermissionModel, null);
                        return Json(new { success = true, message = "添加权限成功", data = "" });
                    }
                    else
                    {
                        return Json(new { success = false, message = "没有你提交的权限", data = "" });
                    }
                }
                else
                {
                    return Json(new { success = false, message = "此角色已经有这个权限了", data = "" });
                }
            }
            else
            {
                return Json(new { success = false, message = "此角色不存在", data = "" });
            }
        }

        [HttpPost]
        public JsonResult Delete(int id, int roleId, int actionId)
        {
            var hasRoleId = roleService.GetList().Where(e => e.RoleID == roleId).Any();
            if (hasRoleId)
            {
                var hasActionModel = mvcActionService.GetList().Where(e => e.Id == actionId).FirstOrDefault();
                if (hasActionModel != null && hasActionModel.Id > 0)
                {
                    var del = mvcRolePermissionService.GetList().Where(e => e.RoleId == roleId && e.ActionId == actionId).FirstOrDefault();
                    if (del != null)
                    {
                        mvcRolePermissionService.Delete(del, null);
                        return Json(new { success = true, message = "删除权限成功", data = "" });
                    }
                    else
                    {
                        return Json(new { success = false, message = "未找到要删除的权限，此权限可能已经被删除", data = "" });
                    }
                }
                else
                {
                    return Json(new { success = false, message = "未找到要删除的权限，此权限可能已经被删除", data = "" });
                }
            }
            else
            {
                return Json(new { success = false, message = "此角色没有这个权限", data = "" });
            }
        }

        protected Miaow.Infrastructure.Crosscutting.Authorize.Dto.RolePermissionDto
            GetRolePermissionDto(int roleId)
        {
            var data = roleService.Get(roleId);
            var model = new Miaow.Infrastructure.Crosscutting.Authorize.Dto.RolePermissionDto();
            model.Id = data.Id;
            model.RoleID = data.RoleID;
            model.Description = data.Description;
            var permissionActionIdList = mvcRolePermissionService.GetRolePermissionByRoleId(model.Id).Select(e => e.ActionId);

            var permission = permissionActionIdList.ToList();

            var actionList = mvcActionService.GetList(permissionActionIdList)
                .Select(e => new Miaow.Infrastructure.Crosscutting.Authorize.Dto.MvcActionDto()
                {
                    ActionId = e.Id,
                    ActionName = e.Name,
                    ActionRemark = e.Remark,
                    ControllerId = e.ControllerId
                });

            var temp = actionList.ToList();

            foreach (var item in temp)
            {
                item.ControllerClassId = mvcControllerClassService.GetList().Where(d => d.Id == item.ControllerId).Select(d => d.Id).FirstOrDefault();
                item.ControllerClassName = mvcControllerClassService.GetList().Where(d => d.Id == item.ControllerId).Select(d => d.Name).FirstOrDefault();
                item.ControllerName = mvcControllerService.GetList().Where(d => d.Id == item.ControllerId).Select(d => d.Name).FirstOrDefault();
                item.ControllerRemark = mvcControllerService.GetList().Where(d => d.Id == item.ControllerId).Select(d => d.Remark).FirstOrDefault();
            }
            model.PermissionList = temp;
            return model;
        }
    }
}
