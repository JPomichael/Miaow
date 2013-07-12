using System;
using System.Linq;
using System.Web.Mvc;

namespace iPow.Presentation.jq.Controllers
{
    [HandleError]
    public class ArticleController :
        iPow.Infrastructure.Crosscutting.NetFramework.Controllers.iPowBaseController
    {
        public const int pageSize = 5;

        iPow.Application.jq.Service.IArticleService articleService;

        iPow.Domain.Repository.IArticleCommRepository articleCommRepository;

        public ArticleController(iPow.Infrastructure.Crosscutting.NetFramework.IWorkContext work,
            iPow.Application.jq.Service.IArticleService article,
            iPow.Domain.Repository.IArticleCommRepository articleComm)
            : base(work)
        {
            if (article == null)
            {
                throw new ArgumentNullException("articleService is null");
            }
            if (articleComm == null)
            {
                throw new ArgumentNullException("articleCommRepository is null");
            }
            articleService = article;
            articleCommRepository = articleComm;
        }


        /// <summary>
        /// Adds the article comm.
        /// </summary>
        /// <param name="artId">The art id.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddArticleComm(FormCollection f)
        {
            try
            {
                iPow.Infrastructure.Data.DataSys.Sys_ArticleComm comm = new iPow.Infrastructure.Data.DataSys.Sys_ArticleComm();
                comm.AddTime = System.DateTime.Now;
                comm.UserName = f["txtUserName"].ToString();
                comm.UserID = 0;
                //comm.CommID = Bll.Db.db.Sys_PicComm.Max(e => e.CommID) + 1;
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
                string picId = f["txtArtId"].ToString();
                int id = 0;
                int.TryParse(picId, out id);
                comm.ArticleID = id;
                articleCommRepository.Add(comm);
                iPow.Infrastructure.Data.DataSys.Sys_ArticleInfo info = articleService.GetSysArticleSingleById(comm.ArticleID);
                if (info != null)
                {
                    info.CommFlag += 1;
                }
                articleCommRepository.Uow.Commit();
                var data = articleService.GetArticleCommListById(comm.ArticleID, 1, pageSize);
                return PartialView("ArticleCommListPartial", data);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public PartialViewResult ArticleCommPage(int art, int pi)
        {
            var data = articleService.GetArticleCommListById(art, pi, pageSize);
            return PartialView("ArticleCommListPartial", data);
        }
    }
}
