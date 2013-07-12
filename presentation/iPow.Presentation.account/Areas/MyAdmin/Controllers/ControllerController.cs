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
    public class ControllerController : Controller
    {
        iPow.Infrastructure.Crosscutting.Authorize.IMvcActionService mvcActionService;

        iPow.Infrastructure.Crosscutting.Authorize.IMvcControllerClassService mvcControllerClassService;

        iPow.Infrastructure.Crosscutting.Authorize.IMvcControllerService mvcControllerService;

        iPow.Infrastructure.Crosscutting.Authorize.IMvcRolePermissionService mvcRolePermissionService;

        public ControllerController(iPow.Infrastructure.Crosscutting.NetFramework.IWorkContext work,
            iPow.Infrastructure.Crosscutting.Authorize.IMvcActionService mvcAction,
            iPow.Infrastructure.Crosscutting.Authorize.IMvcControllerClassService mvcControllerClass,
            iPow.Infrastructure.Crosscutting.Authorize.IMvcControllerService mvcController,
            iPow.Infrastructure.Crosscutting.Authorize.IMvcRolePermissionService rolePermission)
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
            if (rolePermission == null)
            {
                throw new ArgumentNullException("rolePermissionService is null");
            }
            mvcActionService = mvcAction;
            mvcControllerClassService = mvcControllerClass;
            mvcControllerService = mvcController;
            mvcRolePermissionService = rolePermission;
        }

        /// <summary>
        /// Show Controller List
        /// </summary>
        /// <returns></returns>
        public ViewResult Index()
        {
            var model = this.GetControllerDtoList();
            return View(model);
        }

        [GridAction]
        public JsonResult AjaxIndex(string searchKey)
        {
            var data = mvcControllerService.GetControllerDtoList().AsEnumerable();
            if (!string.IsNullOrEmpty(searchKey))
            {
                data = data.Where(e => e.Name.Contains(searchKey));
            }
            var model = new GridModel<iPow.Domain.Dto.Sys_MvcControllerDto>
            {
                Data = data,
                Total = data.Count()
            };
            return new JsonResult { Data = model, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        /// <summary>
        ///   Show Data  For Add New Controller
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ViewResult Add()
        {
            //做为 DropDownList DataSource
            ViewBag.Controllermodel = mvcControllerClassService.GetList();
            var model = new Infrastructure.Crosscutting.Authorize.Dto.MvcControllerDto();
            return View(model);
        }

        /// <summary>
        /// Add New Controller
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ViewResult Add(iPow.Infrastructure.Crosscutting.Authorize.Dto.MvcControllerDto MvcController, string State)
        {
            //做为 DropDownList DataSource
            ViewBag.Controllermodel = mvcControllerClassService.GetList();
            if (MvcController != null)
            {
                var mvcclass = mvcControllerClassService.GetClassModelById(MvcController.ClassId);
                //MvcController.ClassName = mvcclass.Name;
                //根据Name查询
                var ControllerByName = mvcControllerService.GetList().Where(e => e.Name == MvcController.Name).FirstOrDefault();
                if (ControllerByName == null)
                {
                    //判断Controller 是否存在当前所选Role  若没有则创建 有的话 阻止
                    var isexist = mvcControllerService.ClassNameAndControllerNameHasController(MvcController.ClassId, MvcController.Name);
                    if (isexist)  //该语法表示 已经存在
                    {
                        ModelState.AddModelError("", "该该控制器已经存在同一分类！");
                    }
                    else
                    {
                        iPow.Infrastructure.Data.DataSys.Sys_MvcController addController = new iPow.Infrastructure.Data.DataSys.Sys_MvcController();
                        addController.ClassId = MvcController.ClassId;
                        addController.Name = MvcController.Name;
                        addController.AssemblyFullName = addController.Name;
                        addController.Remark = addController.Name;
                        MvcController.AddTime = System.DateTime.Now;
                        addController.AddTime = MvcController.AddTime;
                        addController.IpAddress = iPow.Infrastructure.Crosscutting.Function.StringHelper.GetRealIP();
                        addController.State = Convert.ToBoolean(State);
                        addController.SortNum = MvcController.SortNum;
                        mvcControllerService.Add(addController, null);
                        if (addController.Id > 0)
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
                    ModelState.AddModelError("", "添加控制器失败 ");
                }
            }
            else
            {
                ModelState.AddModelError("", "亲请使用楷体字用力填写");
            }
            return View(MvcController);
        }


        /// <summary>
        /// 用于Edit前的显示
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ViewResult Edit(int id)
        {
            //做为 DropDownList DataSource
            ViewBag.Controllermodel = mvcControllerClassService.GetList();
            var dto = mvcControllerService.GetControllerSingDto(id);
            return View(dto);
        }

        /// <summary>
        /// Edit Classs
        /// </summary>
        /// <param name="MvcController"></param>
        /// <returns></returns>
        [HttpPost]
        public ViewResult Edit(iPow.Infrastructure.Crosscutting.Authorize.Dto.MvcControllerDto MvcController, string State)
        {
            ViewBag.Controllermodel = mvcControllerClassService.GetList();
            try
            {
                if (MvcController != null && MvcController.Id > 0)
                {
                    //根据Id得到当前
                    var model = mvcControllerService.GetControllerSingleById(MvcController.Id);
                    model.ClassId = MvcController.ClassId;
                    model.Remark = MvcController.Remark;
                    model.State = Convert.ToBoolean(State);
                    model.SortNum = MvcController.SortNum;
                    //执行更新吧
                    mvcControllerService.Modify(model, null);
                    var dto = model.ToDto();
                    ModelState.AddModelError("", "恭喜,亲彻底Hold住了");
                    return View(dto);
                }
            }
            catch
            {
                ModelState.AddModelError("", "败笔！亲不给力哦~");
            }
            return View(MvcController);
        }

        [GridAction]
        [HttpPost]
        public JsonResult Delete(int id)
        {
            //获得Model
            var model = mvcControllerService.GetControllerSingleById(id);
            mvcControllerService.Delete(model, null);

            var data = this.GetControllerDtoList();
            //返回给Json
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteMul(FormCollection del)
        {
            var res = false;
            var message = "";
            var selectedList = del.GetValues("selectRow");
            if (selectedList != null && selectedList.Count() > 0)
            {
                res = mvcControllerService.Delete(selectedList.ToIntList(),null);
            }
            return Json(new { success = res, message = message });
        }


        /// <summary>
        /// 返回Json 用于页面
        /// </summary>
        /// <param name="term"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult SearchController(string term)
        {
            if (!string.IsNullOrEmpty(term))
            {
                var data = this.CurrentControllerName().Where(e => e.Remark.Contains(term.Trim()))
                            .OrderBy(e => e.Id).Take(10)
                            .Select(e => e.Remark);
                return Json(data.ToList(), JsonRequestBehavior.AllowGet);
            }
            else
            {
                var data = this.CurrentControllerName().OrderBy(e => e.Id).Take(10)
                            .Select(e => e.Remark);
                return Json(data.ToList(), JsonRequestBehavior.AllowGet);   //允许使用GET方式获取
            }
        }

        /// <summary>
        /// 用于显示 ControllerList的提取方法
        /// </summary>
        /// <returns></returns>
        protected IEnumerable<iPow.Infrastructure.Crosscutting.Authorize.Dto.MvcControllerDto> GetControllerDtoList()
        {
            var AllController = mvcControllerService.GetControllerDtoList().OrderBy(e => e.ClassName);
            return AllController;
        }

        protected IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_MvcController> CurrentControllerName()
        {
            var data = mvcControllerService.GetList().OrderByDescending(e => e.Id).AsEnumerable();
            var currentClassId = 0;
            if (currentClassId != 0)
            {
                data = data.Where(e => e.Id == currentClassId);
            }
            return data;
        }
    }
}
