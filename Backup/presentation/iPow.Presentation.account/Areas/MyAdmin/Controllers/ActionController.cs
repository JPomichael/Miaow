using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Telerik.Web.Mvc;

namespace iPow.Presentation.account.Areas.MyAdmin
{
    [HandleError]
    public class ActionController : Controller
    {
        iPow.Infrastructure.Crosscutting.Authorize.IMvcActionService mvcActionService;

        iPow.Infrastructure.Crosscutting.Authorize.IMvcControllerClassService mvcControllerClassService;

        iPow.Infrastructure.Crosscutting.Authorize.IMvcControllerService mvcControllerService;

        public ActionController(iPow.Infrastructure.Crosscutting.NetFramework.IWorkContext work,
            iPow.Infrastructure.Crosscutting.Authorize.IMvcActionService mvcAction,
            iPow.Infrastructure.Crosscutting.Authorize.IMvcControllerClassService mvcControllerClass,
            iPow.Infrastructure.Crosscutting.Authorize.IMvcControllerService mvcController)
        {

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
            mvcActionService = mvcAction;
            mvcControllerClassService = mvcControllerClass;
            mvcControllerService = mvcController;
        }

        public ViewResult Index()
        {
            var AllAction = this.GetControllerActionDtoList();
            return View(AllAction);
        }

        [GridAction]
        public JsonResult AjaxIndex(string searchKey)
        {
            var data = mvcActionService.GetActionDtoList().AsEnumerable();
            if (!string.IsNullOrEmpty(searchKey))
            {
                data = data.Where(e => e.Name.Contains(searchKey));
            }
            var model = new GridModel<iPow.Domain.Dto.Sys_MvcControllerActionDto>
            {
                Data = data,
                Total = data.Count()
            };
            return new JsonResult { Data = model, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ViewResult Add()
        {
            //做为 DropDownList DataSource
            ViewBag.Actionmodel = mvcControllerService.GetList();
            var model = new Infrastructure.Crosscutting.Authorize.Dto.MvcControllerActionDto();
            return View(model);
        }

        [HttpPost]
        public ViewResult Edit(iPow.Infrastructure.Crosscutting.Authorize.Dto.MvcControllerActionDto MvcControllerAction, string State)
        {
            var AllAction = this.GetControllerActionDtoList();
            try
            {
                if (MvcControllerAction != null && MvcControllerAction.Id != 0)
                {
                    //根据Id得到当前
                    var model = mvcActionService.GetActionSingleById(MvcControllerAction.Id);
                    model.ControllerId = Convert.ToInt32(MvcControllerAction.ClassId);
                    model.Remark = MvcControllerAction.Remark;
                    model.State = Convert.ToBoolean(State);
                    model.SortNum = MvcControllerAction.SortNum;
                    //执行更新吧
                    mvcActionService.Modify(model, null);
                    var dto = model.ToDto();
                    var controllerName = mvcControllerService.GetControllerSingDto(Convert.ToInt32(MvcControllerAction.ClassId));
                    dto.ControllerName = controllerName.AssemblyFullName;
                    ModelState.AddModelError("", "恭喜,亲彻底Hold住了");

                    return View(dto);
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "亲不给力哦！");
            }
            return View(MvcControllerAction);
        }

        [GridAction]
        [HttpPost]
        public JsonResult Delete(int id)
        {
            //获得Model
            var model = mvcActionService.GetActionSingleById(id);
            mvcActionService.Delete(model, null);
            var dto = model.ToDto();
            //返回给Json
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
                res = mvcActionService.Delete(selectedList.ToIntList(),null);
            }
            return Json(new { success = res, message = message });
        }

        public ViewResult Edit(int id)
        {
            var model = mvcActionService.GetActionSingDto(id);//根据ID 获得当前ID数据
            return View(model);
        }

        [HttpPost]
        public ViewResult Add(iPow.Infrastructure.Crosscutting.Authorize.Dto.MvcControllerActionDto MvcControllerAction, string State)
        {
            ViewBag.Actionmodel = mvcControllerService.GetList();
            var MvcControllerName = mvcControllerService.GetControllerSingleById(Convert.ToInt32(MvcControllerAction.ClassId));
            if (MvcControllerAction.Name != null)
            {
                //根据Name查询
                // MvcControllerAction.ControllerName = MvcControllerName.Name;
                //判断Controller 是否存在当前所选Name  若没有则创建 有的话 阻止
                var isexist = mvcActionService.NameAndControllerNameHasAction(MvcControllerName.Id, MvcControllerAction.Name);
                if (isexist)  //该语法表示 已经存在
                {
                    ModelState.AddModelError("", "该控制器动作已经存在同一分类！");
                }
                else
                {
                    iPow.Infrastructure.Data.DataSys.Sys_MvcControllerAction addAction = new iPow.Infrastructure.Data.DataSys.Sys_MvcControllerAction();
                    addAction.ControllerId = Convert.ToInt32(MvcControllerAction.ClassId);
                    addAction.Name = MvcControllerAction.Name;
                    addAction.Remark = addAction.Name;
                    MvcControllerAction.AddTime = System.DateTime.Now;
                    addAction.AddTime = MvcControllerAction.AddTime;
                    addAction.IpAddress = iPow.Infrastructure.Crosscutting.Function.StringHelper.GetRealIP();
                    addAction.State = Convert.ToBoolean(State);
                    addAction.SortNum = MvcControllerAction.SortNum;
                    mvcActionService.Add(addAction, null);
                    if (addAction.Id > 0)
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
                ModelState.AddModelError("", "亲请使用楷体字用力填写");  //参数没有获取或者用户偷懒了
            }
            return View(MvcControllerAction);
        }

        [HttpGet]
        public JsonResult SearchAction(string term)
        {
            if (!string.IsNullOrEmpty(term))
            {
                var data = this.CurrentActionName().Where(e => e.Remark.Contains(term.Trim()))
                            .OrderBy(e => e.Id).Take(10)
                            .Select(e => e.Remark);
                return Json(data.ToList(), JsonRequestBehavior.AllowGet);
            }
            else
            {
                var data = this.CurrentActionName().OrderBy(e => e.Id).Take(10)
                            .Select(e => e.Remark);
                return Json(data.ToList(), JsonRequestBehavior.AllowGet);   //允许使用GET方式获取
            }
        }

        public JsonResult SearchActionName(string term)
        {
            var ControllerIdStr = Request["ControllerId"];
            var ControllerId = 0;
            int.TryParse(ControllerIdStr, out ControllerId);
            if (ControllerId > 0 && !string.IsNullOrEmpty(term))
            {
                var data = CurrentActionName().Where(e => e.ControllerId == ControllerId && e.Name.Contains(term)).Select(e => e.Name);
                return Json(data.ToList(), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }

        #region util

        protected IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_MvcControllerAction> CurrentActionName()
        {
            var data = mvcActionService.GetList().OrderByDescending(e => e.Id).AsEnumerable();
            var currentClassId = 0;
            if (currentClassId != 0)
            {
                data = data.Where(e => e.Id == currentClassId);
            }
            return data;
        }

        protected IEnumerable<iPow.Infrastructure.Crosscutting.Authorize.Dto.MvcControllerActionDto> GetControllerActionDtoList()
        {
            var AllControllerAction = mvcActionService.GetActionDtoList().OrderBy(e => e.ControllerName);
            return AllControllerAction;
        }

        #endregion
    }
}
