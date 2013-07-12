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
    public class TourController :
        iPow.Infrastructure.Crosscutting.NetFramework.Controllers.iPowBaseController
    {
        iPow.Domain.Repository.ITourClassRepository tourClassRepository;

        iPow.Domain.Repository.ITourPlanDetailRepository tourPlanDetailRepository;

        iPow.Domain.Repository.ITourPlanRepository tourPlanRepository;

        public TourController(iPow.Infrastructure.Crosscutting.NetFramework.IWorkContext work,
            iPow.Domain.Repository.ITourClassRepository tourClass,
            iPow.Domain.Repository.ITourPlanDetailRepository tourPlanDetail,
            iPow.Domain.Repository.ITourPlanRepository tourPlan)
            : base(work)
        {
            if (tourClass == null)
            {
                throw new ArgumentNullException("tourClassRepository is null");
            }
            if (tourPlanDetail == null)
            {
                throw new ArgumentNullException("tourPlanDetailRepository is null");
            }
            if (tourPlan == null)
            {
                throw new ArgumentNullException("tourPlanRepository is null");
            }
            tourClassRepository = tourClass;
            tourPlanDetailRepository = tourPlanDetail;
            tourPlanRepository = tourPlan;
        }

        #region tour plan

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        public ViewResult Index()
        {
            var data = this.CurrentUserTourPlan();
            var dto = data.ToDto();
            return View(dto);
        }

        /// <summary>
        /// Ajaxes the index.
        /// </summary>
        /// <returns></returns>
        [GridAction]
        public JsonResult AjaxIndex(string searchKey)
        {
            var data = this.CurrentUserTourPlan();
            if (!string.IsNullOrEmpty(searchKey))
            {
                data = data.Where(e => e.PlanTitle != null && e.PlanTitle.Contains(searchKey));
            }
            var dto = data.ToDto().OrderByDescending(e => e.AddTime);
            var model = new GridModel<iPow.Domain.Dto.Sys_TourPlanDto>
            {
                Data = dto,
                Total = dto.Count()
            };
            return new JsonResult { Data = model, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        /// <summary>
        /// Searches the tour plan.
        /// </summary>
        /// <param name="term">The text.</param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult SearchTourPlan(string term)
        {
            if (!string.IsNullOrEmpty(term))
            {
                var data = this.CurrentUserTourPlan().Where(e => e.PlanTitle != null && e.PlanTitle.Contains(term.Trim()))
                            .OrderBy(e => e.PlanID).Take(10)
                            .Select(e => e.PlanTitle);
                return Json(data.ToList(), JsonRequestBehavior.AllowGet);
            }
            else
            {
                var data = this.CurrentUserTourPlan().Where(e => e.PlanTitle != null).OrderBy(e => e.PlanID).Take(10)
                            .Select(e => e.PlanTitle);
                return Json(data.ToList(), JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// Deletes the plan.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        [GridAction]
        [HttpPost]
        public JsonResult DeletePlan(int id)
        {
            var model = this.CurrentUserTourPlan().Where(e => e.PlanID == id).FirstOrDefault();
            if (model != null && model.PlanID > 0)
            {
                tourPlanRepository.Delete(model);
                tourPlanRepository.Uow.Commit();
            }
            var data = this.CurrentUserTourPlan();
            var dto = data.ToDto();
            return Json(dto, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Deletes the mul plan.
        /// </summary>
        /// <param name="del">The del.</param>
        /// <returns></returns>

        [HttpPost]
        public ActionResult DeleteMulPlan(FormCollection del)
        {
            var selectedList = del.GetValues("selectRow");
            if (selectedList != null && selectedList.Count() > 0)
            {
                foreach (var item in selectedList)
                {
                    var intDel = 0;
                    int.TryParse(item.ToString(), out intDel);
                    if (intDel != 0)
                    {
                        var temp = this.SysSingleTourPlan(intDel);
                        tourPlanRepository.Delete(temp);
                    }
                }
                tourPlanRepository.Uow.Commit();
            }
            return new EmptyResult();
        }

        /// <summary>
        /// Edits the plan.
        /// </summary>
        /// <param name="tour">The tour.</param>
        /// <returns></returns>
        [GridAction]
        [HttpPost]
        public JsonResult EditPlan(iPow.Domain.Dto.Sys_TourPlanDto tour)
        {
            try
            {
                if (tour != null && tour.PlanID > 0)
                {
                    var model = this.SysSingleTourPlan(tour.PlanID);
                    model.PlanTitle = tour.PlanTitle;
                    model.PlanClass = tour.PlanClass;
                    model.Days = tour.Days;
                    model.Destination = tour.Destination;
                    model.Remark = tour.Remark;
                    tourPlanRepository.Uow.Commit();
                }
            }
            catch
            {
            }
            var dto = this.CurrentUserTourPlan().ToDto().OrderByDescending(e => e.AddTime);
            var data = new GridModel<iPow.Domain.Dto.Sys_TourPlanDto>
            {
                Data = dto,
                Total = dto.Count()
            };
            return new JsonResult { Data = data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        /// <summary>
        /// Creates the plan.
        /// </summary>
        /// <param name="tour">The tour.</param>
        /// <returns></returns>
        [GridAction]
        [HttpPost]
        public ViewResult CreatePlan(iPow.Domain.Dto.Sys_TourPlanDto tour)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(tour);
                }
                else
                {
                    var data = new iPow.Infrastructure.Data.DataSys.Sys_TourPlan();
                    data.AddTime = System.DateTime.Now;
                    data.Days = tour.Days;
                    data.Destination = tour.Destination;
                    data.IsDelete = 0;
                    data.IsTop = 0;
                    data.PlanClass = tour.PlanClass;
                    data.PlanTitle = tour.PlanTitle;
                    data.Remark = tour.Remark;
                    data.TempDataCreateHtml = tour.TempDataCreateHtml;
                    data.TopReason = "";
                    data.TopTime = null;
                    data.UserId = tour.UserId;
                    data.UserName = tour.UserName;
                    data.VisitCount = 0;
                    tourPlanRepository.Add(data);
                    tourPlanRepository.Uow.Commit();
                }

                

                return View(new GridModel(this.CurrentUserTourPlan()));
            }
            catch
            {
                return View(tour);
            }
        }

        #endregion

        #region util

        private IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_TourPlan> CurrentUserTourPlan()
        {
            var data = tourPlanRepository.GetList().OrderByDescending(e => e.AddTime).AsEnumerable();
            var currentUserId = 0;
            if (currentUserId != 0)
            {
                //data = data.Where(e => e.UserId == currentUserId);
            }
            return data;
        }

        private iPow.Infrastructure.Data.DataSys.Sys_TourPlan SysSingleTourPlan(int id)
        {
            var data = tourPlanRepository.GetList(e => e.PlanID == id).FirstOrDefault();
            return data;
        }

        #endregion
    }
}
