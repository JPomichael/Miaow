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
    public class UserClassController : Controller
    {
        iPow.Infrastructure.Crosscutting.Authorize.IAdminUserClassService userClassService;

        public UserClassController(iPow.Infrastructure.Crosscutting.NetFramework.IWorkContext work,
            iPow.Infrastructure.Crosscutting.Authorize.IAdminUserClassService userClass)
        {
            if (userClass == null)
            {
                throw new ArgumentNullException(" userClassService  is null");
            }
            userClassService = userClass;
        }

        public ViewResult Index()
        {
            var model = this.GetClassList();
            var dto = model.ToDto();
            return View(dto);
        }

        [GridAction]
        public JsonResult AjaxIndex(string searchKey)
        {
            var data = userClassService.GetList().AsEnumerable();
            if (!string.IsNullOrEmpty(searchKey))
            {
                data = data.Where(e => e.Name.Contains(searchKey));
            }
            var dto = data.ToDto();
            var model = new GridModel<iPow.Domain.Dto.Sys_AdminUserClassDto>
            {
                Data = dto,
                Total = data.Count()
            };
            return new JsonResult { Data = model, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ViewResult Add()
        {
            var model = new iPow.Domain.Dto.Sys_AdminUserClassDto();
            return View(model);
        }

        [HttpPost]
        public ViewResult Add(iPow.Domain.Dto.Sys_AdminUserClassDto dto)
        {
            if (dto != null)
            {
                var isexist = userClassService.NameHasClass(dto.Name);
                if (isexist)
                {
                    ModelState.AddModelError("", "亲 可不可以有点创意?");
                }
                else
                {
                    iPow.Infrastructure.Data.DataSys.Sys_AdminUserClass addUserClass = new Infrastructure.Data.DataSys.Sys_AdminUserClass();
                    iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser = new Infrastructure.Data.DataSys.Sys_AdminUser();
                    operUser.id = 1;
                    addUserClass.Name = dto.Name;
                    addUserClass.Remark = dto.Remark;
                    addUserClass.AddUserId = operUser.id;
                    addUserClass.IpAddress = iPow.Infrastructure.Crosscutting.Function.StringHelper.GetRealIP();
                    addUserClass.SortNum = dto.SortNum;
                    addUserClass.AddTime = System.DateTime.Now;
                    addUserClass.State = dto.State;
                    userClassService.Add(addUserClass, operUser);
                    if (addUserClass.Id > 0)
                    {
                        ModelState.AddModelError("", "分类添加成功！");
                    }
                    else
                    {
                        ModelState.AddModelError("", "失败啦！在来一次吧");
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "亲 人家不要你的信息啊 怎木办");
            }
            return View();
        }

        [GridAction]
        [HttpPost]
        public JsonResult Delete(int id)
        {
            var model = userClassService.GetList().Where(e => e.Id == id).First();
            userClassService.Delete(model, null);
            var dto = this.GetClassList();
            return Json(dto, JsonRequestBehavior.AllowGet);
        }


        [GridAction]
        [HttpPost]
        public JsonResult DeleteMul(FormCollection del)
        {
            var res = false;
            var message = "";
            var selectedList = del.GetValues("selectRow");
            if (selectedList != null && selectedList.Count() > 0)
            {
                res = userClassService.Delete(selectedList.ToIntList(),null);
            }
            return Json(new { success = res, message = message });
        }

        [HttpPost]
        public ViewResult Edit(iPow.Domain.Dto.Sys_AdminUserClassDto Class, string State)
        {
            try
            {
                if (Class != null && Class.Id > 0)
                {
                    iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser = new Infrastructure.Data.DataSys.Sys_AdminUser();
                    operUser.id = 1;
                    var model = userClassService.GetList().Where(e => e.Id == Class.Id).First();
                    model.Name = Class.Name;
                    model.Remark = Class.Remark;
                    model.SortNum = Class.SortNum;
                    model.State = Class.State;
                    model.AddUserId = operUser.id;
                    userClassService.Modify(model, operUser);
                    ModelState.AddModelError("", "分类修改成功");
                    var dto = model.ToDto();
                    return View(dto);
                }
                else
                {
                    ModelState.AddModelError("", "操作失败！");
                }
            }
            catch
            {
                ModelState.AddModelError("", "败笔！亲不给力哦~");
            }
            return View(Class);
        }


        [HttpGet]
        public ViewResult Edit(int id)
        {
            var model = userClassService.GetList().Where(e => e.Id == id).First();
            var dto = model.ToDto();
            return View(dto);
        }

        [HttpGet]
        public JsonResult SearchUserClass(string term)
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
                return Json(data.ToList(), JsonRequestBehavior.AllowGet);   //允许使用GET方式获取
            }
        }

        #region util
        
        protected IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_AdminUserClass> GetClassList()
        {
            var AllClass = userClassService.GetList();
            return AllClass;
        }

        protected IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_AdminUserClass> CurrentClassName()
        {
            var data = userClassService.GetList().OrderByDescending(e => e.Id).AsEnumerable();
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
