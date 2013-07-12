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
    public class ActionClassController : Controller
    {
        iPow.Infrastructure.Crosscutting.Authorize.IMvcControllerActionClassService actionClassService;

        public ActionClassController(iPow.Infrastructure.Crosscutting.NetFramework.IWorkContext work,
            iPow.Infrastructure.Crosscutting.Authorize.IMvcControllerActionClassService actionClass)
        {
            if (actionClass == null)
            {
                throw new ArgumentNullException("actionClassService is null");
            }
            actionClassService = actionClass;
        }

        public ViewResult Index()
        {
            var model = actionClassService.GetList();
            var dto = model.ToDto();
            return View(dto);
        }

        [GridAction]
        public JsonResult AjaxIndex(string searchKey)
        {
            var data = actionClassService.GetList().AsEnumerable();
            if (!string.IsNullOrEmpty(searchKey))
            {
                data = data.Where(e => e.Name.Contains(searchKey));
            }
            var dto = data.ToDto();
            var model = new GridModel<iPow.Domain.Dto.Sys_MvcControllerActionClassDto>
            {
                Data = dto,
                Total = data.Count()
            };
            return new JsonResult { Data = model, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ViewResult Add()
        {
            var model = new iPow.Domain.Dto.Sys_MvcControllerActionClassDto();
            return View(model);
        }

        [HttpPost]
        public ViewResult Add(iPow.Domain.Dto.Sys_MvcControllerActionClassDto dto)
        {
            if (dto != null)
            {
                var isexist = actionClassService.NameHasClass(dto.Name);
                if (isexist)
                {
                    ModelState.AddModelError("", "此分类已经存在，请重试");
                }
                else
                {
                    iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser = new Infrastructure.Data.DataSys.Sys_AdminUser();
                    iPow.Infrastructure.Data.DataSys.Sys_MvcControllerActionClass addActionClass =
                        new Infrastructure.Data.DataSys.Sys_MvcControllerActionClass();
                    operUser.id = 1;
                    addActionClass.Name = dto.Name;
                    addActionClass.Remark = dto.Remark;
                    addActionClass.IpAddress = iPow.Infrastructure.Crosscutting.Function.StringHelper.GetRealIP();
                    addActionClass.SortNum = dto.SortNum;
                    addActionClass.AddTime = System.DateTime.Now;
                    addActionClass.State = dto.State;
                    actionClassService.Add(addActionClass, operUser);
                    if (addActionClass.Id != 0)
                    {
                        ModelState.AddModelError("", "分类添加成功");
                    }
                    else
                    {
                        ModelState.AddModelError("", "分类添加失败!");
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "请用楷体字用力填写！");
            }
            return View(dto);
        }

        [GridAction]
        [HttpPost]
        public JsonResult Delete(int id)
        {
            var model = actionClassService.GetList().Where(e => e.Id == id).First();
            actionClassService.Delete(model, null);
            var dto = actionClassService.GetList();
            return Json(dto, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteMul(FormCollection del)
        {
            var res = false;
            var message = "";
            var selectedList = del.GetValues("selectRow");
            if (selectedList != null && selectedList.Count() > 0)
            {
                res = actionClassService.Delete(selectedList.ToIntList(), null);
            }
            return Json(new { success = res, message = message });
        }

        public ViewResult Edit(int id)
        {
            var model = actionClassService.GetList().Where(e => e.Id == id).First();
            var dto = model.ToDto();
            return View(dto);
        }

        [HttpPost]
        public ViewResult Edit(iPow.Domain.Dto.Sys_MvcControllerActionClassDto dto)
        {
            if (dto != null && dto.Id > 0)
            {
                iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser = new Infrastructure.Data.DataSys.Sys_AdminUser();
                var model = actionClassService.GetList().Where(e => e.Id == dto.Id).First();
                operUser.id = 1;
                model.Name = dto.Name;
                model.Remark = dto.Remark;
                model.IpAddress = iPow.Infrastructure.Crosscutting.Function.StringHelper.GetRealIP();
                model.SortNum = dto.SortNum;
                model.AddTime = System.DateTime.Now;
                model.State = dto.State;
                actionClassService.Modify(model, null);
                ModelState.AddModelError("", "分类修改成功");
            }
            else
            {
                ModelState.AddModelError("", "分类修改失败!");
            }
            return View(dto);
        }

        [HttpGet]
        public JsonResult SearchActionClass(string term)
        {
            if (!string.IsNullOrEmpty(term))
            {
                var data = this.CurrentClassName().Where(e => e.Name.Contains(term.Trim()))
                            .OrderBy(e => e.Id).Take(10)
                            .Select(e => e.Name);
                return Json(data.ToList(), JsonRequestBehavior.AllowGet);
            }
            else
            {
                var data = this.CurrentClassName().OrderBy(e => e.Id).Take(10)
                            .Select(e => e.Name);
                return Json(data.ToList(), JsonRequestBehavior.AllowGet);
            }
        }

        #region util

        protected IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_MvcControllerActionClass> CurrentClassName()
        {
            var data = actionClassService.GetList().OrderByDescending(e => e.Id).AsEnumerable();
            var currentClassId = 0;
            if (currentClassId != 0)
            {
                data = data.Where(e => e.Id == currentClassId);
            }
            return data;
        }

        #endregion
    }
}
