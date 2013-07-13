using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using Webdiyer.WebControls.Mvc;
using iPow.Application.Union.Dto;
using iPow.Infrastructure.Crosscutting.NetFramework.Attributes;

namespace iPow.Presentation.Union.Controllers
{
    [HandleError]
    public class HotelController :
        iPow.Infrastructure.Crosscutting.NetFramework.Controllers.iPowBaseController
    {
        /// <summary>
        /// 
        /// </summary>
        public const int picPageSize = 9;

        /// <summary>
        /// 
        /// </summary>
        public const int commPageSize = 5;

        /// <summary>
        /// 
        /// </summary>
        iPow.Service.Union.Service.IHotelInfoService hotelInfoService;

        /// <summary>
        /// 
        /// </summary>
        iPow.Service.Union.Service.IHotelRoomService hotelRoomService;

        /// <summary>
        /// 
        /// </summary>
        iPow.Service.Union.Service.IHotelCommService hotelCommService;

        /// <summary>
        /// 
        /// </summary>
        iPow.Service.Union.Service.IHotelPicService hotelPicService;

        /// <summary>
        /// 
        /// </summary>
        iPow.Service.Union.Service.IHotelTrafficService hotelTrafficService;

        /// <summary>
        /// 
        /// </summary>
        iPow.Domain.Repository.IHotelCommRepository hotelCommRepository;

        /// <summary>
        /// 
        /// </summary>
        iPow.Domain.Repository.IHotelPropertyInfoRepository hotelPropertyInfoRepository;

        /// <summary>
        /// 
        /// </summary>
        iPow.Service.Union.Service.IHotelCommSysService hotelCommSysService;

        /// <summary>
        /// Initializes a new instance of the <see cref="HotelController"/> class.
        /// </summary>
        /// <param name="work">The work.</param>
        /// <param name="ipowHotelInfo">The ipow hotel info.</param>
        /// <param name="ipowHotelRoom">The ipow hotel room.</param>
        /// <param name="ipowHotelComm">The ipow hotel comm.</param>
        /// <param name="ipowHotelPic">The ipow hotel pic.</param>
        /// <param name="ipowHotelTraffic">The ipow hotel traffic.</param>
        public HotelController(iPow.Infrastructure.Crosscutting.NetFramework.IWorkContext work,
            iPow.Service.Union.Service.IHotelInfoService ipowHotelInfo,
            iPow.Service.Union.Service.IHotelRoomService ipowHotelRoom,
            iPow.Service.Union.Service.IHotelCommService ipowHotelComm,
            iPow.Service.Union.Service.IHotelPicService ipowHotelPic,
            iPow.Service.Union.Service.IHotelTrafficService ipowHotelTraffic,
            iPow.Domain.Repository.IHotelCommRepository hotelComm,
            iPow.Domain.Repository.IHotelPropertyInfoRepository hotelPropertyInfo,
            iPow.Service.Union.Service.IHotelCommSysService ipowHotelCommSys)
            : base(work)
        {
            if (ipowHotelInfo == null)
            {
                throw new ArgumentNullException("hotelInfoService is null");
            }
            if (ipowHotelRoom == null)
            {
                throw new ArgumentNullException("hotelRoomService is null");
            }
            if (ipowHotelComm == null)
            {
                throw new ArgumentNullException("hotelCommService is null");
            }
            if (ipowHotelPic == null)
            {
                throw new ArgumentNullException("hotelPicService is null");
            }
            if (ipowHotelTraffic == null)
            {
                throw new ArgumentNullException("hotelTrafficService is null");
            }
            if (hotelComm == null)
            {
                throw new ArgumentNullException("hotelCommRepository is null");
            }
            if (hotelPropertyInfo == null)
            {
                throw new ArgumentNullException("hotelPropertyInfoRepository is null");
            }
            if (ipowHotelCommSys == null)
            {
                throw new ArgumentNullException("hotelCommSysService is null");
            }
            hotelInfoService = ipowHotelInfo;
            hotelRoomService = ipowHotelRoom;
            hotelCommService = ipowHotelComm;
            hotelPicService = ipowHotelPic;
            hotelTrafficService = ipowHotelTraffic;
            hotelCommRepository = hotelComm;
            hotelPropertyInfoRepository = hotelPropertyInfo;
            hotelCommSysService = ipowHotelCommSys;
        }

        /// <summary>
        /// Indexes the specified id.
        /// 酒店的基本信息
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        //[HttpGet]
        //[OutputCache(VaryByParam = "id")]
        public ViewResult Index(int id)
        {
            var model = hotelInfoService.GetHotelInfoById(id.ToString());
            ViewBag.hotelid = id;
            return View(model);
        }

        /// <summary>
        /// Hotels the room.
        /// 酒店房间信息
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        //[ChildActionOnly]
        //[OutputCache(Duration = 3600)]
        public PartialViewResult HotelRoom(int id)
        {
            var data = hotelRoomService.GetHotelRoomById(id.ToString());
            return PartialView("HotelRoomPartial", data);
        }

        /// <summary>
        /// Hotels the DES.
        /// 酒店具体的一些描述
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        [HttpGet]
        //[OutputCache(Duration = 3600 ,VaryByParam="id")]
        public PartialViewResult HotelDes(int id)
        {
            var model = hotelInfoService.GetHotelInfoById(id.ToString());
            return PartialView("HotelDesPartial", model);
        }

        #region 已经做了 完成于2011.7.12.16.06

        /// <summary>
        /// Hotels the comm.
        /// 首次加载酒店评论
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        [HttpGet]
        public PartialViewResult HotelComm(int id)
        {
            PagedList<iPow.Application.Union.Dto.HotelCommDto> data = null;
            var hotelInfo = hotelInfoService.GetHotelInfoById(id.ToString());
            if (hotelInfo != null)
            {
                var temp = hotelCommService.GetHotelCommById(hotelInfo.id.ToString(), hotelInfo.cid.ToString());
                data = new PagedList<iPow.Application.Union.Dto.HotelCommDto>(temp.dianping_list, 1, 10, temp.total);
            }
            ViewBag.id = id;
            ViewBag.hotelid = id;
            return PartialView("HotelCommPartial", data);
        }

        /// <summary>
        /// Hotels the comm list.
        /// 酒店评论分页
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="pi">The pi.</param>
        /// <returns></returns>
        [HttpGet]
        public PartialViewResult HotelCommList(int id, int? pi)
        {
            int pageIdex = pi == null ? 1 : (int)pi;
            PagedList<iPow.Application.Union.Dto.HotelCommDto> data = null;
            var hotelInfo = hotelInfoService.GetHotelInfoById(id.ToString());
            if (hotelInfo != null)
            {
                var temp = hotelCommService.GetHotelCommById(hotelInfo.id.ToString(), hotelInfo.cid.ToString(), pageIdex.ToString());
                data = new PagedList<iPow.Application.Union.Dto.HotelCommDto>(temp.dianping_list, pageIdex, 10, temp.total);
            }
            ViewBag.id = id;
            ViewBag.hotelid = id;
            return PartialView("HotelCommListPartial", data);
        }

        /// <summary>
        /// Adds the hotel comm.
        /// 添加酒店评论
        /// </summary>
        /// <param name="f">The f.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddHotelComm(FormCollection f)
        {
            if (f != null)
            {
                try
                {
                    iPow.Infrastructure.Data.DataSys.Sys_HotelComm hc = new Infrastructure.Data.DataSys.Sys_HotelComm();
                    #region init

                    hc.AddTime = System.DateTime.Now;
                    //hc.CommID = Bll.DbSys.Db.Sys_HotelComm.Max(e => e.CommID) + 1;
                    if (f["Content"] != null)
                    {
                        hc.Content = f["Content"];
                    }
                    if (f["HotelID"] != null)
                    {
                        hc.HotelID = int.Parse(f["HotelID"].ToString());
                    }
                    hc.Ip = iPow.Infrastructure.Crosscutting.Function.StringHelper.GetRealIP();
                    if (hc.Ip == "::1")
                    {
                        hc.Ip = "127.0.0.1";
                    }
                    if (f["Sroce"] != null)
                    {
                        hc.Point = int.Parse(f["Sroce"].ToString());
                    }
                    hc.UserID = 0;
                    if (f["UserName"] != null)
                    {
                        hc.UserName = f["UserName"].ToString();
                    }
                    #endregion
                    hotelCommRepository.Add(hc);
                    hotelCommRepository.Uow.Commit();
                    var hotelInfo = hotelPropertyInfoRepository.GetList(e => e.ID == hc.HotelID).FirstOrDefault();
                    hotelInfo.CommCount += 1;
                    hotelPropertyInfoRepository.Uow.Commit();
                    int total = 0;
                    List<iPow.Domain.Dto.Sys_HotelCommDto> hcs = hotelCommSysService.GetHotelCommPageListByHotelId(hc.HotelID, 1, 5, ref total);
                    PagedList<iPow.Domain.Dto.Sys_HotelCommDto> hcList = null;
                    if (hcs != null && hcs.Count() > 0)
                    {
                        hcList = new PagedList<iPow.Domain.Dto.Sys_HotelCommDto>(hcs, 1, commPageSize, total);
                    }
                    ViewBag.hotelid = hc.HotelID;
                    return PartialView("HotelCommListPartial", hcList);
                }
                catch
                {
                    return Json("", JsonRequestBehavior.AllowGet);
                }
            }
            return Json("", JsonRequestBehavior.AllowGet);
        }
        #endregion

        /// <summary>
        /// Hotels the pic.
        /// 酒店图片
        /// 首次加载
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        [HttpGet]
        public PartialViewResult HotelPic(int id)
        {
            PagedList<iPow.Application.Union.Dto.HotelPicDto> data = null;
            data = hotelPicService.GetHotelPicById(id.ToString(), 1, 9);
            return PartialView("HotelPicPartial", data);
        }

        /// <summary>
        /// Hotels the pic list.
        /// 酒店图片分页
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="pi">Index of the page.</param>
        /// <returns></returns>
        [HttpGet]
        public PartialViewResult HotelPicList(int id, int? pi)
        {
            PagedList<iPow.Application.Union.Dto.HotelPicDto> data = null;
            data = hotelPicService.GetHotelPicById(id.ToString(), pi == null ? (int)0 : (int)pi, 9);
            return PartialView("HotelPicListPartial", data);
        }

        //2011.7.10.17.42完成
        /// <summary>
        /// Adds the hotel live in.
        /// 酒店的我住过
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        [HttpGet]
        [NoCache]
        public JsonResult AddHotelLiveIn(int id)
        {
            bool tar = false;
            int? temp = 0;
            try
            {
                iPow.Infrastructure.Data.DataSys.Sys_HotelPropertyInfo hi = hotelPropertyInfoRepository.GetList(e => e.ID == id).FirstOrDefault();
                if (hi != null)
                {
                    hi.LiveInCount += 1;
                    temp = hi.LiveInCount;
                }
                hotelPropertyInfoRepository.Uow.Commit();
                tar = true;
            }
            catch
            { }
            return Json(new { success = tar, livein = temp }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Hotels the traffic.
        /// 交通
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        //[HttpGet]
        [ChildActionOnly]
        public PartialViewResult HotelTraffic(int id)
        {
            iPow.Application.Union.Dto.HotelTrafficDto data = hotelTrafficService.GetHotelTrafficById(id.ToString());
            return PartialView("HotelTrafficPartial", data);
        }
    }
}
