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
    public class TourDetailController :
        iPow.Infrastructure.Crosscutting.NetFramework.Controllers.iPowBaseController
    {
        iPow.Domain.Repository.ITourClassRepository tourClassRepository;

        iPow.Domain.Repository.ITourPlanDetailRepository tourPlanDetailRepository;

        iPow.Domain.Repository.ITourPlanRepository tourPlanRepository;

        iPow.Domain.Repository.ISightInfoRepository sightInfoRepository;

        iPow.Domain.Repository.IHotelPropertyInfoRepository hotelPropertyInfoRepository;

        public TourDetailController(iPow.Infrastructure.Crosscutting.NetFramework.IWorkContext work,
            iPow.Domain.Repository.ITourClassRepository tourClass,
            iPow.Domain.Repository.ITourPlanDetailRepository tourPlanDetail,
            iPow.Domain.Repository.ITourPlanRepository tourPlan,
            iPow.Domain.Repository.ISightInfoRepository sightInfo,
            iPow.Domain.Repository.IHotelPropertyInfoRepository hotelPropertyInfo)
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
            if (sightInfo == null)
            {
                throw new ArgumentNullException("sightInfoRepository is null");
            }
            if (hotelPropertyInfo == null)
            {
                throw new ArgumentNullException("hotelPropertyInfoRepository is null");
            }
            tourClassRepository = tourClass;
            tourPlanDetailRepository = tourPlanDetail;
            tourPlanRepository = tourPlan;
            sightInfoRepository = sightInfo;
            hotelPropertyInfoRepository = hotelPropertyInfo;
        }

        /// <summary>
        /// Indexes the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public ViewResult Index(int? id)
        {
            ViewBag.id = id;
            if (id.HasValue)
            {
                var data = this.SysSingleTourPlan((int)id);
                if (data != null)
                {

                    var planDto = data.ToDto();
                    Models.UiTourPlanDetailDto model = new Models.UiTourPlanDetailDto();
                    model.Parent = planDto;
                    var detailList = CurrentUserTourPlanDetail().Where(e => e.PlanID == planDto.PlanID);
                    var detailDto = detailList.ToDto();
                    InitDetailPlan(detailDto);
                    model.DetailList = detailDto.ToList();
                    return View(model);
                }
            }
            return View();
        }

        /// <summary>
        /// Ajaxes the index.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        [GridAction]
        public JsonResult AjaxTourDetailPlanIndex(string id)
        {
            var data = this.CurrentUserTourPlanDetail();
            //我要搜索 用到 找到搜索的父Id
            var parentIdStr = Request["parentId"];
            var parentId = 0;
            if (parentIdStr != null)
            {
                int.TryParse(parentIdStr, out parentId);
            }
            if (parentId > 0)
            {
                data = data.Where(e => e.PlanID == parentId);
            }

            var dto = data.ToDto();
            InitDetailPlan(dto);
            //id是搜索里文本框的内容
            if (!string.IsNullOrEmpty(id))
            {
                dto = dto.Where(e => e.TargetName.Contains(id));
            }
            var model = new { Data = dto.ToList(), Total = dto.Count() };
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Deletes the detail plan.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        [GridAction]
        [HttpPost]
        public ActionResult DeleteTourDetailPlan(int id)
        {
            int? planId = 0;
            if (id > 0)
            {
                var temp = tourPlanDetailRepository.GetList(e => e.PlanDetailID == id).FirstOrDefault();
                if (temp != null && temp.PlanDetailID > 0)
                {
                    planId = temp.PlanID;
                    //tourPlanDetailRepository.Delete(temp);
                    tourPlanDetailRepository.Uow.Commit();
                }
            }
            if (planId.HasValue)
            {
                var modelList = CurrentUserTourPlanDetail().Where(e => e.PlanID == planId);
                var dto = modelList.ToDto();
                InitDetailPlan(dto);
                var model = new { Data = dto.ToList(), Total = dto.Count() };
                return Json(model, JsonRequestBehavior.AllowGet);
            }
            return View();
        }

        /// <summary>
        /// Deletes the mul detail plan.
        /// </summary>
        /// <param name="del">The del.</param>
        /// <returns></returns>
        [GridAction]
        [HttpPost]
        public ActionResult DeleteMulTourDetailPlan(FormCollection del)
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
                        var temp = this.SysSingleTourDetailPlan(intDel);
                        tourPlanDetailRepository.Delete(temp);
                    }
                }
                tourPlanDetailRepository.Uow.Commit();
            }
            return new EmptyResult();
        }

        /// <summary>
        /// Searches the tour detail.
        /// </summary>
        /// <param name="term">The term.</param>
        /// <returns></returns>
        public JsonResult SearchTourDetail(string term)
        {
            var parendIdStr = Request["parentId"];
            var parentId = 0;
            int.TryParse(parendIdStr, out parentId);
            if (parentId > 0 && !string.IsNullOrEmpty(term))
            {
                var data = CurrentUserTourPlanDetail().Where(e => e.PlanID == parentId);
                var dto = data.ToDto();
                InitDetailPlan(dto);
                term = term.Trim();
                var res = dto.Where(e => e.TargetName.Contains(term)).Select(e => e.TargetName).ToList();
                return Json(res, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// Ajaxes the tip.
        /// </summary>
        /// <param name="term">The term.</param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult AjaxTip(string term)
        {
            var typeStr = Request["targetType"];
            var type = string.Empty;
            if (typeStr != null)
            {
                type = typeStr.ToString();
                if (string.Compare(type, "sight", false) == 0)
                {
                    var res = this.GetSightTip(term, 10);
                    return Json(res.ToList(), JsonRequestBehavior.AllowGet);
                }
                else if (string.Compare(type, "hotel", false) == 0)
                {
                    var res = this.GetHotelTip(term, 10);
                    return Json(res.ToList(), JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var res = this.GetSightTip(term, 10);
                    return Json(res.ToList(), JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                var res = this.GetSightTip(term, 10);
                return Json(res.ToList(), JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// Ajaxes the name of the check target.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult AjaxCheckTargetName(string id)
        {
            var res = false;
            var targetTypeStr = Request["targetType"];
            if (targetTypeStr != null && !string.IsNullOrEmpty(id))
            {
                var targetType = targetTypeStr.ToString();
                id = id.Trim();
                if (string.Compare(targetType, "sight", false) == 0)
                {
                    res = sightInfoRepository.GetList().Where(e => e.Title == id).Any();
                }
                else if (string.Compare(targetType, "hotel", false) == 0)
                {
                    res = hotelPropertyInfoRepository.GetList().Where(e => e.HotelName == id).Any();
                }
                else
                {
                    res = true;
                }
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// Edits the tour detail plan.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        [GridAction]
        [HttpPost]
        public ActionResult EditTourDetailPlan(iPow.Presentation.account.Models.TourPlanDetailDto data)
        {
            if (data != null)
            {
                var model = tourPlanDetailRepository.GetList(e => e.PlanDetailID == data.PlanDetailID).FirstOrDefault();
                if (model != null && model.PlanDetailID > 0)
                {
                    model.DayID = data.DayID;
                    model.CurrentPrice = data.CurrentPrice;
                    model.Remark = data.Remark;
                    tourPlanDetailRepository.Uow.Commit();

                    var temp = CurrentUserTourPlanDetail().Where(e => e.PlanID == model.PlanID);
                    var dto = temp.ToDto();
                    InitDetailPlan(dto);
                    var res = new { Data = dto.ToList(), Total = dto.Count() };
                    return Json(res, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return new EmptyResult();
                }
            }
            else
            {
                return new EmptyResult();
            }
        }

        /// <summary>
        /// Creates the tour detail plan.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ViewResult Create(string id)
        {
            ViewBag.id = id;
            var model = new iPow.Presentation.account.Models.TourPlanDetailDto();
            return View(model);
        }

        [HttpPost]
        public ViewResult Create(int id, iPow.Presentation.account.Models.TourPlanDetailDto data)
        {
            if (data != null && ModelState.IsValid && id > 0)
            {
                var model = new iPow.Infrastructure.Data.DataSys.Sys_TourPlanDetail();
                model.AddTime = System.DateTime.Now;
                model.CurrentPrice = data.CurrentPrice;
                model.DayID = data.DayID;
                model.IsDelete = 0;
                model.Remark = data.Remark;
                model.VisitCount = 0;

                model.PlanID = id;
                //model.PlanDetailID 
                model.DetailType = data.DetailTypeName;//sight hotel other
                //data.TargetName 景区或酒店名字
                var sightOrHotelId = 0;
                if (string.Compare(data.DetailTypeName, "sight", false) == 0)
                {
                    var temp = sightInfoRepository.GetList(e => e.Title == data.TargetName).FirstOrDefault();
                    if (temp != null)
                    {
                        sightOrHotelId = temp.ParkID;
                    }
                }
                else if (string.Compare(data.DetailTypeName, "hotel", false) == 0)
                {
                    var temp = hotelPropertyInfoRepository.GetList(e => e.HotelName == data.TargetName).FirstOrDefault();
                    if (temp != null)
                    {
                        sightOrHotelId = (int)temp.HotelID;
                    }
                }
                else { }
                model.SightIDOrHotelID = sightOrHotelId;
                tourPlanDetailRepository.Add(model);
                tourPlanDetailRepository.Uow.Commit();
            }
            else
            {
                base.AddModelStateError();
            }
            return View(data);
        }

        #region util

        protected IEnumerable<string> GetHotelTip(string term, int take)
        {
            var tip = hotelPropertyInfoRepository.GetList().OrderByDescending(e => e.HotelID).AsEnumerable();
            if (!string.IsNullOrEmpty(term))
            {
                tip = tip.Where(e => e.HotelName.Contains(term));
            }
            var res = tip.Take(take).Select(e => e.HotelName);
            return res;
        }

        protected IEnumerable<string> GetSightTip(string term, int take)
        {
            var tip = sightInfoRepository.GetList().OrderByDescending(e => e.AddTime).AsEnumerable();
            if (!string.IsNullOrEmpty(term))
            {
                tip = tip.Where(e => e.Title.Contains(term));
            }
            var res = tip.Take(take).Select(e => e.Title);
            return res;
        }

        protected void InitDetailPlan(IEnumerable<Models.TourPlanDetailDto> detailDto)
        {
            foreach (var item in detailDto)
            {
                if (string.Compare(item.DetailType, "sight", false) == 0)
                {
                    var sight = sightInfoRepository.GetList(e => e.ParkID == item.SightIDOrHotelID).FirstOrDefault();
                    if (sight != null)
                    {
                        item.TargetName = sight.Title;
                        item.TargetUrl = "http://jq.ipow.cn/sight/" + sight.PY + sight.ParkID + "/1";
                        item.DetailTypeName = "景区";
                    }
                }
                else if (string.Compare(item.DetailType, "hotel", false) == 0)
                {
                    var hotel = hotelPropertyInfoRepository.GetList(e => e.HotelID == item.SightIDOrHotelID).FirstOrDefault();
                    if (hotel != null)
                    {
                        item.TargetName = hotel.HotelName;
                        item.TargetUrl = "http://hotel.ipow.cn/hotel/" + hotel.HotelID;
                        item.DetailTypeName = "酒店";
                    }
                }
            }
        }

        protected IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_TourPlanDetail> CurrentUserTourPlanDetail()
        {
            var data = tourPlanDetailRepository.GetList().OrderByDescending(e => e.AddTime).AsEnumerable();
            var currentUserId = 0;
            if (currentUserId != 0)
            {
                //data = data.Where(e => e.UserId == currentUserId);
            }
            return data;
        }

        protected iPow.Infrastructure.Data.DataSys.Sys_TourPlanDetail SysSingleTourDetailPlan(int id)
        {
            var data = tourPlanDetailRepository.GetList(e => e.PlanID == id).FirstOrDefault();
            return data;
        }

        protected iPow.Infrastructure.Data.DataSys.Sys_TourPlan SysSingleTourPlan(int id)
        {
            var data = tourPlanRepository.GetList(e => e.PlanID == id).FirstOrDefault();
            return data;
        }

        #endregion
    }
}
