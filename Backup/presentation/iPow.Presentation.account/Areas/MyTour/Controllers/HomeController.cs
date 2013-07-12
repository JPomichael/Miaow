using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iPow.Infrastructure.Data.DataSys;
using iPow.Domain.Dto;
using System.Collections;

using Webdiyer.WebControls.Mvc;
using iPow.Infrastructure.Crosscutting.EntityToDto;

namespace iPow.Presentation.account.Areas.MyTour
{
    [HandleError]
    public class HomeController :
        iPow.Infrastructure.Crosscutting.NetFramework.Controllers.MyTourControllerBase
    {
        const int pageSize = 15; //每页显示的数量

        iPow.Application.jq.Service.IHomeService homeService;

        iPow.Application.dj.Service.ITourPlanService tourPlanService;

        iPow.Application.account.Service.ITourPlanDetailService tourPlanDetailService;

        iPow.Application.account.Service.ISightInfoService SightInfo;

        iPow.Infrastructure.Crosscutting.Comm.Service.ICityInfoService cityInfoService;

        iPow.Application.account.Service.ICityInfoMoreService cityInfoMoreService;

        iPow.Application.account.Service.IHotelPropertyInfoService hotelPrpertyInfoService;

        public HomeController(iPow.Application.jq.Service.IHomeService ipowHome,
            iPow.Application.dj.Service.ITourPlanService tour,
            iPow.Application.account.Service.ISightInfoService Sight,
            iPow.Infrastructure.Crosscutting.Comm.Service.ICityInfoService city,
            iPow.Application.account.Service.ITourPlanDetailService tourPlan,
            iPow.Application.account.Service.ICityInfoMoreService cityInfoMore,
            iPow.Application.account.Service.IHotelPropertyInfoService hotelPrpertyInfo
            )
        {
            if (hotelPrpertyInfo == null)
            {
                throw new ArgumentNullException("hotelPrpertyInfoService");
            }
            if (ipowHome == null)
            {
                throw new ArgumentNullException("homeService is null");
            }
            if (tour == null)
            {
                throw new ArgumentNullException("tourPlanService is null");
            }
            if (Sight == null)
            {
                throw new ArgumentNullException("SightInfoService is null");
            }
            if (city == null)
            {
                throw new ArgumentNullException("cityInfoService in null ");
            }
            if (tourPlan == null)
            {
                throw new ArgumentNullException("TourPlanDetailService");
            }
            if (cityInfoMore == null)
            {
                throw new ArgumentNullException("cityInfoMoreService");
            }
            tourPlanService = tour;
            homeService = ipowHome;
            SightInfo = Sight;
            cityInfoService = city;
            tourPlanDetailService = tourPlan;
            cityInfoMoreService = cityInfoMore;
            hotelPrpertyInfoService = hotelPrpertyInfo;
        }

        public ViewResult Index(bool? modal, bool? scrolling, bool? animation, bool? resizable, bool? movable)
        {
            ViewData["modal"] = modal ?? false;
            ViewData["scrolling"] = scrolling ?? true;
            ViewData["resizable"] = resizable ?? true;
            ViewData["movable"] = movable ?? true;
            return View();
        }

        /// <summary>
        /// 这里显示所有的线路 By UserID 
        /// 并以分页
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ViewResult PlanList(int userId, int? Id)
        {
            Application.account.Dto.TourPlanDto dto = new Application.account.Dto.TourPlanDto();
            if (userId != 0 || userId != null)
            {
                int take = pageSize;
                var pi = Id == null ? 1 : (int)Id;
                dto.TourPlanList = tourPlanService.GetTourPlanListByUserId(userId, pi, take);
            }
            if (userId != 0)
            {
                int take = pageSize;
                var pi = Id == null ? 1 : (int)Id;
                dto.TourPlanList = tourPlanService.GetTourPlanListByUserId(userId, pi, take);
            }
            return View(dto);
        }

        /// <summary>
        /// Show 所有的线路
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ViewResult AllPlan(int? Id)
        {
            List<iPow.Domain.Dto.Sys_SightInfoDto> LSID = new List<Sys_SightInfoDto>();
            Application.account.Dto.TourPlanDto dto = new Application.account.Dto.TourPlanDto();
            int take = pageSize;
            var pi = (Id.HasValue && Id.Value > 0) ? (int)Id : 1;
            dto.TourPlanList = tourPlanService.GetTourPlanList(pi, take);

            #region MyRegion
            //foreach (var item in dto.TourPlanList)
            //{
            //    //验证是否为空路线
            //    var res = tourPlanDetailService.CheckTourPlanIsExistByID(item.PlanID);
            //    if (res != false)
            //    {
            //        var tourPlanDetail = tourPlanDetailService.GetTourPlanDetailByID(item.PlanID); //线路详情
            //        foreach (var tourplan in tourPlanDetail)
            //        {
            //            if (tourplan.SightIDOrHotelID != 0)
            //            {
            //                iPow.Domain.Dto.Sys_SightInfoDto SID = new Sys_SightInfoDto();
            //                var sight = SightInfo.GetSightByParkID(tourplan.SightIDOrHotelID);
            //                SID.ParkID = sight.ParkID;
            //                SID.Title = sight.Title;
            //                LSID.Add(SID);
            //            }
            //        }
            //    }
            //} 
            #endregion

            return View(dto);
        }

        /// <summary>
        /// 一 Add()
        /// 二 Show ClickSight()
        /// </summary>
        /// <param name="tour"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CreatePlan(FormCollection tour)
        {
            var tp = new Sys_TourPlan();
            var tt = new Infrastructure.Data.DataSys.Sys_TourPlan();
            string AddTime = string.Empty;
            string Days = string.Empty;
            string PlanTitle = string.Empty;
            string City = string.Empty;
            if (tour != null)
            {
                if (tour["AddTime"] != null)
                {
                    tt.AddTime = Convert.ToDateTime(tour["AddTime"]);
                }
                if (tour["Days"] != null)
                {
                    tt.Days = Convert.ToInt32(tour["Days"]);
                }
                if (tour["City"] != null && tour["City"] != "输入目的地" && tour["City"] != "null")
                {
                    tt.Destination = tour["City"].ToString();
                }
                if (tour["PlanTitle"] != null && tour["PlanTitle"] != "输入行程名称" && tour["PlanTitle"] != "null")
                {
                    tt.PlanTitle = tour["PlanTitle"].ToString();
                    tt.Remark = tour["PlanTitle"].ToString();
                }

                tt.IsDelete = 0;
                tt.IsTop = 0;
                tt.PlanClass = null;
                tt.TempDataCreateHtml = null;
                tt.TopReason = "";
                tt.TopTime = null;
                tt.UserId = 1;
                tt.UserName = "Test";
                tt.VisitCount = 0;
                // checkTourPlanDetailIsExist() 是否用tourName 来验证单一
                tp = tourPlanService.AddTourPlan(tt);
                if (tt.PlanID < 0)
                { }
            }
            else
            { }
            return RedirectToAction("plan", new { id = 1, PlanID = tp.PlanID });
        }

        /// <summary>
        ///创建成功后页面    plus  Pager
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Plan(int PlanID, int? id, bool? modal, bool? scrolling, bool? animation, bool? resizable, bool? movable)
        {
            var res = tourPlanService.GetTourPlanByID(PlanID);
            var data = res.ToDto();
            var sightInfoService = iPow.Presentation.account.iPowPreAccountEngine.Current.Resolve<
                iPow.Application.account.Service.ISightInfoService>();
            Application.account.Dto.TourPlanDto dto = new Application.account.Dto.TourPlanDto();
            dto.CurrentCityInfo = cityInfoService.GetCityInfoSingleByName(res.Destination);
            var pi = id == null ? 1 : (int)id;
            int take = pageSize;
            dto.SightInfo = sightInfoService.GetAllSightByCity(dto.CurrentCityInfo.city, pi, take);
            dto.TourPlan = data;
            var result = tourPlanDetailService.GetTourPlanByID(PlanID);
            if (result != null)
            {
                List<iPow.Domain.Dto.Sys_SightInfoDto> LSIF = new List<Sys_SightInfoDto>();
                foreach (var item in result)
                {
                    iPow.Domain.Dto.Sys_SightInfoDto SIF = new Sys_SightInfoDto();
                    SIF = sightInfoService.GetSightByPlanID(item.SightIDOrHotelID.HasValue ? (int)item.SightIDOrHotelID : 0);
                    LSIF.Add(SIF);
                }
                dto.sightInfoDto = LSIF;
            }
            ViewData["modal"] = modal ?? false;
            ViewData["scrolling"] = scrolling ?? true;
            ViewData["resizable"] = resizable ?? true;
            ViewData["movable"] = movable ?? true;
            return View(dto);
        }

        //根据ID去删除数据
        [HttpGet]
        public string DeleteSightDIY(int id)
        {
            string point = "0";
            bool res = tourPlanDetailService.UpdatesightById(id);
            if (res == false)
            {
                point = "0";
            }
            else
            {
                //success
                point = "1";
            }
            return point;
        }

        [HttpPost]
        public ActionResult Edit(FormCollection tour)
        {
            var tp = new Sys_TourPlan();
            var tt = new Infrastructure.Data.DataSys.Sys_TourPlan();
            string AddTime = string.Empty;
            string Days = string.Empty;
            string PlanTitle = string.Empty;
            string City = string.Empty;
            string id = string.Empty;
            if (tour != null)
            {

                #region 赋值一
                if (tour["AddTime"] != null)
                {
                    tt.AddTime = Convert.ToDateTime(tour["AddTime"]);
                }
                if (tour["Days"] != null)
                {
                    tt.Days = Convert.ToInt32(tour["Days"]);
                }
                if (tour["City"] != null)
                {
                    tt.Destination = tour["City"].ToString();
                }
                if (tour["PlanTitle"] != null)
                {
                    tt.PlanTitle = tour["PlanTitle"].ToString();
                    tt.Remark = tour["PlanTitle"].ToString();
                }
                if (tour["id"] != null)
                {
                    tt.PlanID = Convert.ToInt32(tour["id"]);
                }
                tt.IsDelete = 0;
                tt.IsTop = 0;
                tt.TopReason = "";

                #endregion

                var model = tourPlanService.GetTourPlanByID(tt.PlanID);

                #region 赋值二
                model.PlanID = tt.PlanID;
                model.AddTime = tt.AddTime;
                model.Days = tt.Days;
                model.Destination = tt.Destination;
                model.IsDelete = 0;
                model.IsTop = 0;
                model.PlanClass = null;
                model.PlanTitle = tt.PlanTitle;
                model.Remark = tt.PlanTitle;
                model.TempDataCreateHtml = null;
                model.TopReason = "";
                model.TopTime = null;
                model.UserId = 1;    //这里  默认为1 
                model.UserName = "Test";   //测试研发阶段
                model.VisitCount = 0;
                #endregion

                tp = tourPlanService.UpdateTourPlan(model);
            }
            return RedirectToAction("plan", new { id = 1, PlanID = tp.PlanID });
        }

        [HttpGet]
        public JsonResult ClickAddSight(int ParkID, int PlanID, int Days)
        {
            //GetToutByName
            //Sys_TourPlanDto TourPlan = tourPlanService.GetTourPlanByName(Name);  
            var data = SightInfo.GetSightByParkID(ParkID);
            Sys_TourPlanDetail tpd = new Sys_TourPlanDetail();
            tpd.SightIDOrHotelID = data.ParkID;
            tpd.CurrentPrice = data.Ticket;
            tpd.Remark = data.Title;
            tpd.VisitCount = data.VouchCount;
            tpd.AddTime = DateTime.Now;
            tpd.DayID = Days;
            tpd.DetailType = "sight";
            tpd.PlanID = PlanID;
            var IsExist = tourPlanDetailService.CheckTourPlanDetailIsExist(Convert.ToInt32(tpd.PlanID), Convert.ToInt32(tpd.SightIDOrHotelID), tpd.Remark);
            if (IsExist)
            {
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            else
            {
                int count = tourPlanDetailService.AddTourPlanDetail(tpd);
                if (count < 0)
                {
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    //success
                }
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public string CheckAddSightByID(int parkID, int PlanID)
        {
            string point = "0";
            bool res = tourPlanDetailService.CheckAddSightByID(parkID, PlanID);
            if (res == false)
            {
                return point;
            }
            else
            {
                //success
                point = "1";
            }
            return point;
        }

        [HttpGet]
        public JsonResult GetSightLonAndLat(int Id)
        {
            var data = SightInfo.GetSightByParkID(Id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetSightDestinationLonAndLat(string Destination)
        {
            var data = cityInfoMoreService.GetSightDestinationLonAndLat(Destination);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        //校验目的地是否存在
        [HttpGet]
        public string GetDestinationIsEtist(string City)
        {
            string point = "0";
            if (City != null || City != "")
            {
                bool res = cityInfoService.CityIsExistByName(City);
                if (res == false)
                {
                    point = "0";
                }
                else
                {
                    //success
                    point = "1";
                }
            }
            return point;
        }

        [HttpGet]
        public JsonResult GetUserDIYTourByID(int Id)
        {
            List<iPow.Domain.Dto.Sys_SightInfoDto> LSID = new List<Sys_SightInfoDto>();
            var res = tourPlanDetailService.GetSightTitleByID(Id);
            foreach (var item in res)
            {
                iPow.Domain.Dto.Sys_SightInfoDto SID = new iPow.Domain.Dto.Sys_SightInfoDto();
                SID = SightInfo.GetSightByID(item.SightIDOrHotelID.HasValue ? (int)item.SightIDOrHotelID : 0);
                SID.ParkID = item.SightIDOrHotelID.HasValue ? (int)item.SightIDOrHotelID : 0;
                LSID.Add(SID);
            }
            var count = LSID.Count();
            var data = new { List = LSID, Count = count };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        #region 获得周边景区和酒店  By SightID

        /// <summary>
        /// 根据SightID 获得周边的SightInfo
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetCirSightInfoByID(int Id)
        {
            List<iPow.Domain.Dto.Sys_SightInfoDto> LSID = new List<Sys_SightInfoDto>();
            var res = SightInfo.GetCirSightIDByID(Id);
            foreach (var item in res)
            {
                iPow.Domain.Dto.Sys_SightInfoDto SID = new iPow.Domain.Dto.Sys_SightInfoDto();
                SID = SightInfo.GetSightByID(item.CirId.HasValue ? (int)item.CirId : 0);
                LSID.Add(SID);
            }
            var count = LSID.Count();
            var data = new { List = LSID, Count = count };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 根据SightID 获得周边HotalInfo
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetHotelInfoByID(int Id)
        {
            List<iPow.Domain.Dto.Sys_HotelPropertyInfoDto> LHID = new List<Sys_HotelPropertyInfoDto>();
            var res = SightInfo.GetCirHotalIDByID(Id);
            foreach (var item in res)
            {
                iPow.Domain.Dto.Sys_HotelPropertyInfoDto HID = new Sys_HotelPropertyInfoDto();
                HID = hotelPrpertyInfoService.GetHotelInfoByID(item.HotelId.HasValue ? (int)item.HotelId : 0);
                LHID.Add(HID);
            }
            var count = LHID.Count();
            var data = new { List = LHID, Count = count };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        #endregion

        [HttpGet]
        public JsonResult GetUserTourByID(int Id)
        {
            var data = tourPlanService.GetTourPlanByID(Id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult SearchCity(string term)
        {
            if (!string.IsNullOrEmpty(term))
            {
                var data = this.CurrentCityName().Where(e => e.province.Contains(term.Trim()) || e.ProvincePy.Contains(term.Trim()) || e.city.Contains(term.Trim()) || e.pinyin.Contains(term.Trim()))
                            .OrderBy(e => e.id).Take(10)
                            .Select(e => e.city);
                return Json(data.ToList(), JsonRequestBehavior.AllowGet);
            }
            else
            {
                var data = this.CurrentCityName().OrderBy(e => e.id).Take(10)
                            .Select(e => e.city);
                return Json(data.ToList(), JsonRequestBehavior.AllowGet);
            }
        }

        #region util

        protected Sys_SightInfoDto GetSightByID(int Id)
        {
            Sys_SightInfoDto data = SightInfo.GetSightByParkID(Id);
            return data;
        }

        protected IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_CityInfo> CurrentCityName()
        {
            var data = cityInfoService.GetList().OrderByDescending(e => e.id).AsEnumerable();
            var currentCityId = 0;
            if (currentCityId != 0)
            {
                data = data.Where(e => e.id == currentCityId);
            }
            return data;
        }

        #endregion
    }
}

