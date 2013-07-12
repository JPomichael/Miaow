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
    public class RoleController :
        iPow.Infrastructure.Crosscutting.NetFramework.Controllers.iPowBaseController
    {
        iPow.Infrastructure.Crosscutting.Authorize.IRoleService roleService;

        public RoleController(iPow.Infrastructure.Crosscutting.NetFramework.IWorkContext work,
            iPow.Infrastructure.Crosscutting.Authorize.IRoleService role)
            : base(work)
        {
            if (role == null)
            {
                throw new ArgumentNullException("roleService is null");
            }
            roleService = role;
        }

        public ViewResult Index()
        {
            var data = this.GetStateTrueList();
            var dto = data.ToDto();
            return View(dto);
        }

        [GridAction]
        public JsonResult AjaxIndex(string searchKey)
        {
            var data = this.GetStateTrueList();
            if (!string.IsNullOrEmpty(searchKey))
            {
                data = data.Where(e => e.Description.Contains(searchKey));
            }
            var dto = data.ToDto();
            var model = new GridModel<iPow.Domain.Dto.Sys_RolesDto>
            {
                Data = dto,
                Total = data.Count()
            };
            return new JsonResult { Data = model, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [GridAction]
        [HttpPost]
        public JsonResult Delete(int id)
        {
            var model = this.GetStateTrueList().Where(e => e.Id == id).FirstOrDefault();
            if (model != null && model.Id > 0)
            {
                roleService.DeleteTrue(model, null);
            }
            var data = this.GetStateTrueList();
            var dto = data.ToDto();
            return Json(dto, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult MulDelete(FormCollection del)
        {
            var res = false;
            var message = "";
            var selectedList = del.GetValues("selectRow");
            if (selectedList != null && selectedList.Count() > 0)
            {
                res = roleService.DeleteTrue(selectedList.ToIntList(), null);
            }
            return Json(new { success = res, message = message });
        }

        [GridAction]
        [HttpPost]
        public JsonResult Add(Domain.Dto.Sys_RolesDto role)
        {
            if (!string.IsNullOrEmpty(role.Description))
            {
                var model = new iPow.Infrastructure.Data.DataSys.Sys_Roles();
                model.Description = role.Description;
                model.RoleID = roleService.GetNewRoleId();
                roleService.Add(model,null);
            }
            var data = this.GetStateTrueList();
            var dto = data.ToDto();
            return Json(dto, JsonRequestBehavior.AllowGet);
        }

        [GridAction]
        [HttpPost]
        public JsonResult Edit(Domain.Dto.Sys_RolesDto role)
        {
            if (role != null && !string.IsNullOrEmpty(role.Description))
            {
                var model = roleService.Get(role.Id);
                model.Description = role.Description;
                try
                {
                    roleService.Modify(model, null);
                }
                catch
                {
                }
            }
            var data = this.GetStateTrueList();
            var dto = data.ToDto();
            return Json(dto, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult SearchRole(string term)
        {
            if (!string.IsNullOrEmpty(term))
            {
                var data = this.GetStateTrueList().Where(e => e.Description.Contains(term.Trim()))
                            .OrderBy(e => e.Id).Take(10)
                            .Select(e => e.Description);
                return Json(data.ToList(), JsonRequestBehavior.AllowGet);
            }
            else
            {
                var data = this.GetStateTrueList().OrderBy(e => e.Description).Take(10)
                            .Select(e => e.Description);
                return Json(data.ToList(), JsonRequestBehavior.AllowGet);
            }
        }

        protected IQueryable<iPow.Infrastructure.Data.DataSys.Sys_Roles> GetStateTrueList()
        {
            var data = roleService.GetList().OrderByDescending(e => e.Id);
            return data;
        }
    }
}
