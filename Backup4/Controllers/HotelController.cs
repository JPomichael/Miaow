using System.Linq;
using System.Web;
using System.Web.Mvc;

using Webdiyer.WebControls.Mvc;

namespace iPow.jd.Controllers
{
    public class HotelController : ControllerBase
    {

        /// <summary>
        /// 
        /// </summary>
        public const int picPageSize = 9;

        /// <summary>
        /// 
        /// </summary>
        public const int commPageSize = 5;

        // GET: /Hotel/
        //[OutputCache(VaryByParam = "id")]
        /// <summary>
        /// Indexes the specified id.
        /// 酒店的基本信息
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index(int id)
        {
            Models.HotelDetailHead hd =   Bll.HotelDetail.GetHeadHotelDetailByIdentfiyId(id);

            if (hd != null)
            {
                ViewBag.hotelid = hd.HotelId;
                ViewBag.identfiyid = hd.IdentityId;
                try
                {
                    Bll.DbSys.Db.Sys_HotelPropertyInfo.Where(e => e.ID == id).FirstOrDefault().VisitCount += 1;
                    Bll.DbSys.Db.Sys_HotelPropertyInfo.Context.SaveChanges();
                }
                catch
                {

                }
            }
            return View(hd);
        }

        //[ChildActionOnly]
        //[OutputCache(Duration = 3600)]
        /// <summary>
        /// Hotels the room.
        /// 酒店房间信息
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public ActionResult HotelRoom(int id)
        {
            ViewBag.hotelid = id;
            return PartialView("HotelRoomPartial");
        }

        /// <summary>
        /// Hotels the DES.
        /// 酒店具体的一些描述
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        [HttpGet]
        //[OutputCache(Duration = 3600 ,VaryByParam="id")]
        public ActionResult HotelDes(int id)
        {
            Models.HotelDetailMidHotelInfo hi = Bll.HotelDetail.GetHotelDetailMidHotelInfoByIdentfiyId(id);
            return PartialView("HotelDesPartial", hi);
        }


        //下面的都没有做的

        #region 已经做了 完成于2011.7.12.16.06

        /// <summary>
        /// Hotels the comm.
        /// 首次加载酒店评论
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult HotelComm(int id)
        {
            int total = 0;
            IQueryable<iPow.DataSys.Sys_HotelComm> hc =Bll.HotelDetail.GetHotelCommPageListByHotelId(id, 1, 5, ref total);
            PagedList<iPow.DataSys.Sys_HotelComm> hcList = null;
            if (hc != null && hc.Count() > 0)
            {
                //ViewBag.id = id;
                //ViewBag.pagesize = commPageSize;
                //ViewBag.total = total;

                hcList = new PagedList<DataSys.Sys_HotelComm>(hc, 1, commPageSize, total);
            }
            ViewBag.hotelid = id;
            return PartialView("HotelCommPartial", hcList);
        }

        /// <summary>
        /// Hotels the comm list.
        /// 酒店评论分页
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="pi">The pi.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult HotelCommList(int id, int? pi)
        {
            int total = 0;
            int pageIdex = pi == null ? 1 : (int)pi;
            IQueryable<iPow.DataSys.Sys_HotelComm> hc = Bll.HotelDetail.GetHotelCommPageListByHotelId(id, pageIdex, 5, ref total);
            PagedList<iPow.DataSys.Sys_HotelComm> hcList = null;
            if (hc != null && hc.Count() > 0)
            {
                //ViewBag.id = id;
                //ViewBag.pagesize = commPageSize;
                //ViewBag.total = total;
                hcList = new PagedList<DataSys.Sys_HotelComm>(hc, pageIdex, commPageSize, total);
            }
            ViewBag.hotelid = id;
            return PartialView("HotelCommListPartial", hcList);
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
                    iPow.DataSys.Sys_HotelComm hc = new DataSys.Sys_HotelComm();

                    #region init

                    hc.AddTime = System.DateTime.Now;
                    hc.CommID = Bll.DbSys.Db.Sys_HotelComm.Max(e => e.CommID) + 1;
                    if (f["Content"] != null)
                    {
                        hc.Content = f["Content"];
                    }
                    if (f["HotelID"] != null)
                    {
                        hc.HotelID = int.Parse(f["HotelID"].ToString());
                    }
                    hc.Ip = iPow.function.StringHelper.GetRealIP();
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

                   Bll.DbSys.Db.AddToSys_HotelComm(hc);
                    if (Bll.DbSys.Db.Sys_HotelComm.Context.SaveChanges() > 0)
                    {
                        var hotelInfo = Bll.DbSys.Db.Sys_HotelPropertyInfo.Where(e => e.ID == hc.HotelID).FirstOrDefault() ;
                        hotelInfo.CommCount += 1;
                        Bll.DbSys.Db.Sys_HotelPropertyInfo.Context.SaveChanges();

                        int total = 0;
                        IQueryable<iPow.DataSys.Sys_HotelComm> hcs = Bll.HotelDetail.GetHotelCommPageListByHotelId(hc.HotelID, 1, 5, ref total);
                        PagedList<iPow.DataSys.Sys_HotelComm> hcList = null;
                        if (hcs != null && hcs.Count() > 0)
                        {
                            hcList = new PagedList<DataSys.Sys_HotelComm>(hcs, 1, commPageSize, total);
                        }
                        ViewBag.hotelid = hc.HotelID;
                        return PartialView("HotelCommListPartial", hcList);
                    }
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
        public ActionResult HotelPic(int id)
        {
            IQueryable<iPow.DataSys.Sys_HotelPic> hp = null;
            PagedList<iPow.DataSys.Sys_HotelPic> hpList = null;
            int total = 0;
            hp = Bll.HotelDetail.GetHotelPicPageListByHotelId(id, 1, picPageSize, ref total);
            if (hp != null && hp.Count() > 0)
            {
                hpList = new PagedList<iPow.DataSys.Sys_HotelPic>(hp, 1, picPageSize, total);
            }
            return PartialView("HotelPicPartial", hpList);
        }

        /// <summary>
        /// Hotels the pic list.
        /// 酒店图片分页
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="pi">Index of the page.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult HotelPicList(int id, int? pi)
        {
            //不用写单独的东西出来了，直接用数据库里面的就是了 ，数据量也不大
            //随机9张
            //可能会改进那种分页的那种
            IQueryable<iPow.DataSys.Sys_HotelPic> hp = null;
            PagedList<iPow.DataSys.Sys_HotelPic> hpList = null;
            int pageIndex = (pi == null ? 1 : (int)pi);
            int total = 0;
            hp = Bll.HotelDetail.GetHotelPicPageListByHotelId(id, pageIndex, picPageSize, ref total);
            if (hp != null && hp.Count() > 0)
            {
                hpList = new PagedList<iPow.DataSys.Sys_HotelPic>(hp, pageIndex, picPageSize, total);
            }
            return PartialView("HotelPicListPartial", hpList);
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
                iPow.DataSys.Sys_HotelPropertyInfo hi = Bll.DbSys.Db.Sys_HotelPropertyInfo.Where(e => e.ID == id).FirstOrDefault();
                if (hi != null)
                {
                    hi.LiveInCount += 1;
                    temp = hi.LiveInCount;
                }
             Bll.DbSys.Db.Sys_HotelPropertyInfo.Context.SaveChanges();
                tar = true;
            }
            catch
            {

            }
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
        public ActionResult HotelTraffic(int id)
        {
            ViewBag.hotelid = id;
            Models.HotelTraffic ht =Bll.HotelDetail.GetHotelTrafficByHotelId(id);
            return PartialView("HotelTrafficPartial", ht);
        }
    }

   
}
