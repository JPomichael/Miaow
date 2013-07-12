using System;
using System.Web.Mvc;

namespace iPow.Presentation.jq.Controllers
{
    [HandleError]
    public class SightOtherController :
        iPow.Infrastructure.Crosscutting.NetFramework.Controllers.iPowBaseController
    {
        iPow.Application.jq.Service.ITicketService ticketService;

        iPow.Application.jq.Service.IPicInfoService picInfoService;

        iPow.Application.jq.Service.IArticleService articleService;

        public SightOtherController(iPow.Infrastructure.Crosscutting.NetFramework.IWorkContext work,
            iPow.Application.jq.Service.ITicketService ipowTicket,
            iPow.Application.jq.Service.IPicInfoService ipowPicInfo,
            iPow.Application.jq.Service.IArticleService ipowArticle)
            : base(work)
        {
            if (ipowTicket == null)
            {
                throw new ArgumentNullException("ticketService is null");
            }
            if (ipowPicInfo == null)
            {
                throw new ArgumentNullException("picInfoService is null");
            }
            if (ipowArticle == null)
            {
                throw new ArgumentNullException("articleService is null");
            }
            ticketService = ipowTicket;
            picInfoService = ipowPicInfo;
            articleService = ipowArticle;
        }
    
        [OutputCache(Duration = 60, VaryByParam = "sid")]
        public PartialViewResult Ticket(int? sid, string other, int? id)
        {
            var model = ticketService.GetDetailSightBaseInfoById((int)sid);
            return PartialView(model);
        }
     
        //[OutputCache(Duration = 60, VaryByParam = "sid")]
        public PartialViewResult Pic(int? sid, string other, string ord, int? id)
        {
            var model = ticketService.GetDetailSightBaseInfoById((int)sid);
            ViewBag.other = other;
            ViewBag.ord = ord;
            ViewBag.id = id;
            return PartialView(model);
        }
     
        //[OutputCache(Duration = 60, VaryByParam = "sid")]
        public PartialViewResult Video(int? sid, string other, string ord, int? id)
        {
            var model = ticketService.GetDetailSightBaseInfoById((int)sid);
            ViewBag.other = other;
            ViewBag.ord = ord;
            ViewBag.id = id;
            return PartialView(model);
        }
     
        //[OutputCache(Duration = 60, VaryByParam = "sid")]
        public PartialViewResult Article(int? sid, string other, string ord, int? id)
        {
            var model = ticketService.GetDetailSightBaseInfoById((int)sid);
            ViewBag.other = other;
            ViewBag.ord = ord;
            ViewBag.id = id;
            return PartialView(model);
        }
       
        [OutputCache(Duration = 60, VaryByParam = "sid")]
        public PartialViewResult Guide(int? sid, string other, int? id)
        {
            var model = ticketService.GetDetailSightBaseInfoById((int)sid);
            return PartialView("Guide", model);
        }

        public ActionResult PicDetail(int? sid, int? id)
        {
            var data = picInfoService.GetPicDetailModel(sid, id);
            return View(data);
        }
    
        public ActionResult ArticleDetail(int? sid, int? id)
        {
            var data = articleService.GetArticleDetailModel(sid, id);
            return View(data);
        }
    }
}
