using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Miaow.Infrastructure.Crosscutting.NetFramework.Attributes;

namespace Miaow.Presentation.jq.Controllers
{
    [HandleError]
    public class SightDetailController :
        Miaow.Infrastructure.Crosscutting.NetFramework.Controllers.MiaowBaseController
    {
        //这个是用于评论的哈，只显示5条
        const int pageSizeForCommList = 5;

        Miaow.Application.jq.Service.ISightInfoService sightInfoService;

        Miaow.Domain.Repository.ISightCommRepository sightCommRepository;

        public SightDetailController(Miaow.Infrastructure.Crosscutting.NetFramework.IWorkContext work,
            Miaow.Application.jq.Service.ISightInfoService MiaowSightInfo,
            Miaow.Domain.Repository.ISightCommRepository sightComm)
            : base(work)
        {
            if (MiaowSightInfo == null)
            {
                throw new ArgumentNullException("sightInfoServiceis null");
            }
            if (sightComm == null)
            {
                throw new ArgumentNullException("sightCommRepository null");
            }
            sightInfoService = MiaowSightInfo;
            sightCommRepository = sightComm;
        }

        //[OutputCache(Duration = 60, VaryByParam = "sid")]
        public ViewResult Index(string sight, int? sid, int? id)
        {
            ViewBag.parkid = sid;
            var data = sightInfoService.GetSightDetailModel(sid, id ?? 1);
            return View(data);
        }

        [HttpGet]
        public PartialViewResult CommList(int sid, int pi)
        {
            int total = 0;
            var data = sightInfoService.GetSightCommList(sid, pi, pageSizeForCommList, ref total);
            Webdiyer.WebControls.Mvc.PagedList<Miaow.Domain.Dto.Sys_SightCommDto> model =
                new Webdiyer.WebControls.Mvc.PagedList<Miaow.Domain.Dto.Sys_SightCommDto>(data, pi, 5, total);
            ViewBag.parkid = sid;
            return PartialView(model);
        }

        public ActionResult AddSightComm(FormCollection f)
        {
            try
            {
                Miaow.Infrastructure.Data.DataSys.Sys_SightComm comm = new Infrastructure.Data.DataSys.Sys_SightComm();
                comm.AddTime = System.DateTime.Now;
                comm.UserName = f["txtUserName"].ToString();
                comm.UserID = 0;
                //comm.CommID = Bll.Db.db.Sys_SightComm.Max(e => e.CommID) + 1;
                comm.Content = f["txtContent"].ToString();
                int fen = 0;
                if (f["score"] != null)
                {
                    int.TryParse(f["score"].ToString(), out  fen);
                }
                comm.Fen = fen;
                comm.Ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]; ;
                if (comm.Ip.CompareTo("::1") == 0)
                {
                    comm.Ip = "127.0.0.1";
                }
                comm.ParentID = 0;
                string sightId = f["txtSightId"].ToString();
                int id = 0;
                int.TryParse(sightId, out id);
                comm.SightID = id;
                string sightPy = f["txtSightPy"].ToString();
                sightCommRepository.Add(comm);


                //这个地方，只是给景区的一个评论字段加一，其实，可以不要这个字段的，
                //Sys_SightInfo sightInfo = sightInfoService.GetSightSingleById(comm.SightID);
                //if (sightInfo != null)
                //{
                //    sightInfo.CommCount += 1;
                //}

                sightCommRepository.Uow.Commit();
                int total = 0;
                var data = sightInfoService.GetSightCommList(comm.SightID, 1, pageSizeForCommList, ref total);
                Webdiyer.WebControls.Mvc.PagedList<Miaow.Domain.Dto.Sys_SightCommDto> model =
                    new Webdiyer.WebControls.Mvc.PagedList<Miaow.Domain.Dto.Sys_SightCommDto>(data, 1, 5, total);
                ViewBag.parkid = comm.SightID;
                return PartialView("CommList", model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [NoCache]
        public JsonResult WantGo(int sid, int? id)
        {
            Miaow.Infrastructure.Data.DataSys.Sys_SightInfo s = sightInfoService.GetSysSightSingleById(sid);
            int count = 0;
            bool tar = true;
            if (s != null)
            {
                s.WantCount += 1;
                count = (int)s.WantCount;
                try
                {
                    sightCommRepository.Uow.Commit();
                }
                catch
                {
                    tar = false;
                    count = 0;
                }
            }
            else
            {
                tar = false;
            }
            return this.Json(new { success = tar.ToString(), count = count }, JsonRequestBehavior.AllowGet);
        }

        [NoCache]
        public JsonResult GoCount(int sid, int? id)
        {
            Miaow.Infrastructure.Data.DataSys.Sys_SightInfo info = sightInfoService.GetSysSightSingleById(sid);
            bool tar = true;
            int count = 0;
            if (info != null)
            {
                info.GoCount += 1;
                count = (int)info.GoCount;
                try
                {
                    sightCommRepository.Uow.Commit();
                }
                catch
                {
                    tar = false;
                    count = 0;
                }
            }
            else
            {
                tar = false;
            }
            return this.Json(new { success = tar.ToString(), count = count }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Woes the ding.
        /// </summary>
        /// <param name="sid">The sid.</param>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        [NoCache]
        public JsonResult WoDing(int sid, int? id)
        {
            Miaow.Infrastructure.Data.DataSys.Sys_SightInfo info = sightInfoService.GetSysSightSingleById(sid);
            bool tar = true;
            int count = 0;
            if (info != null)
            {
                info.WantCount += 1;
                count = (int)info.WantCount;
                try
                {
                    sightCommRepository.Uow.Commit();
                }
                catch
                {
                    tar = false;
                    count = 0;
                }
            }
            else
            {
                tar = false;
            }
            return this.Json(new { success = tar.ToString(), count = count }, JsonRequestBehavior.AllowGet);
        }
    }

}
