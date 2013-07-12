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
    public class ControllerClassController : Controller
    {
        iPow.Infrastructure.Crosscutting.Authorize.IMvcControllerClassService mvcControllerClassService;

        public ControllerClassController(iPow.Infrastructure.Crosscutting.NetFramework.IWorkContext work,
            iPow.Infrastructure.Crosscutting.Authorize.IMvcControllerClassService mvcControllerClass)
        {
            if (mvcControllerClass == null)
            {
                throw new ArgumentNullException("actionService is null");
            }
            mvcControllerClassService = mvcControllerClass;
        }

        /// <summary>
        /// 查询出所有的分来列表
        /// </summary>
        /// <returns></returns>
        public ViewResult Index()
        {
            var AllClasss = this.GetClassList();
            var dto = AllClasss.ToDto();
            return View(dto);
        }

        [GridAction]
        public JsonResult AjaxIndex(string searchKey)
        {
            var data = mvcControllerClassService.GetList().AsEnumerable();
            if (!string.IsNullOrEmpty(searchKey))
            {
                data = data.Where(e => e.Name.Contains(searchKey));
            }
            var dto = data.ToDto();
            var model = new GridModel<iPow.Domain.Dto.Sys_MvcControllerClassDto>
            {
                Data = dto,
                Total = data.Count()
            };
            return new JsonResult { Data = model, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        /// <summary>
        /// AddClass 做初始化
        /// </summary>
        /// <returns></returns>
        public ViewResult Add()
        {
            var model = new Domain.Dto.Sys_MvcControllerClassDto();
            return View(model);
        }

        /// <summary>
        /// AddClass  
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public ViewResult Add(iPow.Domain.Dto.Sys_MvcControllerClassDto dto, string State)
        {
            if (dto != null)
            {
                var isexist = mvcControllerClassService.NameAndRemarkHasClass(dto.Name, dto.Remark);
                if (isexist)  //该语法表示 已经存在
                {
                    ModelState.AddModelError("", "该控制器动作已经存在同一分类！");
                }
                else
                {
                    dto.AddTime = System.DateTime.Now; //添加的当前时间
                    dto.SortNum = 0;
                    iPow.Infrastructure.Data.DataSys.Sys_MvcControllerClass addClass = new Infrastructure.Data.DataSys.Sys_MvcControllerClass();
                    addClass.Name = dto.Name;
                    addClass.Remark = dto.Remark;
                    addClass.AddTime = dto.AddTime;
                    addClass.State = Convert.ToBoolean(State);
                    addClass.SortNum = dto.SortNum;
                    addClass.IpAddress = iPow.Infrastructure.Crosscutting.Function.StringHelper.GetRealIP();
                    mvcControllerClassService.Add(addClass,null);
                    if (addClass.Id > 0)
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
                ModelState.AddModelError("", "败笔！亲不给力哦~");
            }
            return View(dto);
        }

        [GridAction]
        [HttpPost]
        public JsonResult DeleteClass(int id)
        {
            //获得Model
            var model = mvcControllerClassService.GetClassModelById(id);
            mvcControllerClassService.Delete(model, null);
            var dto = this.GetClassList();
            //返回给Json
            return Json(dto, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteMulClass(FormCollection del)
        {
            var res = false;
            var message = "";
            var selectedList = del.GetValues("selectRow");
            if (selectedList != null && selectedList.Count() > 0)
            {
                res = mvcControllerClassService.Delete(selectedList.ToIntList(),null);
            }
            return Json(new { success = res, message = message });
        }


        /// <summary>
        /// 用于Edit前的显示
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ViewResult Edit(int id)
        {
            var model = mvcControllerClassService.GetClassModelById(id);
            var dto = model.ToDto();
            return View(dto);
        }

        /// <summary>
        /// Edit Classs
        /// </summary>
        /// <param name="Class"></param>
        /// <returns></returns>
        [HttpPost]
        public ViewResult Edit(iPow.Domain.Dto.Sys_MvcControllerClassDto Class, string State)
        {
            try
            {
                if (Class != null && Class.Id > 0)
                {
                    //根据Id得到当前
                    var model = mvcControllerClassService.GetClassModelById(Class.Id);
                    model.Name = Class.Name;
                    model.Remark = Class.Remark;
                    model.State = Convert.ToBoolean(State);
                    model.SortNum = Class.SortNum;
                    //执行更新吧
                    mvcControllerClassService.Modify(model, null);
                    var dto = model.ToDto();
                    ModelState.AddModelError("", "恭喜,亲彻底Hold住了");
                    return View(dto);
                }
            }
            catch
            {
                ModelState.AddModelError("", "败笔！亲不给力哦~");
            }
            return View(Class);
        }

        /// <summary>
        /// 返回Json 用于页面
        /// </summary>
        /// <param name="term"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult SearchClass(string term)
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

        protected IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_MvcControllerClass> CurrentClassName()
        {
            var data = mvcControllerClassService.GetList().OrderByDescending(e => e.Id).AsEnumerable();
            var currentClassId = 0;
            if (currentClassId != 0)
            {
                data = data.Where(e => e.Id == currentClassId);
            }
            return data;
        }

        /// <summary>
        /// 用于显示ClassList的提取方法
        /// </summary>
        /// <returns></returns>
        protected IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_MvcControllerClass> GetClassList()
        {
            var AllClass = mvcControllerClassService.GetList();
            return AllClass;
        }

        #endregion
    }
}
