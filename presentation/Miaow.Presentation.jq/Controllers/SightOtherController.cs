using System;
using System.Web.Mvc;

namespace Miaow.Presentation.jq.Controllers
{
    [HandleError]
    public class SightOtherController :
        Miaow.Infrastructure.Crosscutting.NetFramework.Controllers.MiaowBaseController
    {
        Miaow.Application.jq.Service.ITicketService ticketService;

        Miaow.Application.jq.Service.IPicInfoService picInfoService;

        Miaow.Application.jq.Service.IArticleService articleService;

        public SightOtherController(Miaow.Infrastructure.Crosscutting.NetFramework.IWorkContext work,
            Miaow.Application.jq.Service.ITicketService MiaowTicket,
            Miaow.Application.jq.Service.IPicInfoService MiaowPicInfo,
            Miaow.Application.jq.Service.IArticleService MiaowArticle)
            : base(work)
        {
            if (MiaowTicket == null)
            {
                throw new ArgumentNullException("ticketService is null");
            }
            if (MiaowPicInfo == null)
            {
                throw new ArgumentNullException("picInfoService is null");
            }
            if (MiaowArticle == null)
            {
                throw new ArgumentNullException("articleService is null");
            }
            ticketService = MiaowTicket;
            picInfoService = MiaowPicInfo;
            articleService = MiaowArticle;
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
