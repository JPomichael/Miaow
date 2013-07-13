using System;
using System.Linq;
using System.Web.Mvc;

namespace iPow.Presentation.jq.Controllers
{
    [HandleError]
    public class PicController :
        iPow.Infrastructure.Crosscutting.NetFramework.Controllers.iPowBaseController
    {
        const int pageSize = 5;

        iPow.Application.jq.Service.IPicInfoService picInfoService;

        iPow.Domain.Repository.IPicCommRepository picCommRepository;

        public PicController(iPow.Infrastructure.Crosscutting.NetFramework.IWorkContext work,
            iPow.Application.jq.Service.IPicInfoService ipowPicInfo,
            iPow.Domain.Repository.IPicCommRepository picComm)
            : base(work)
        {
            if (ipowPicInfo == null)
            {
                throw new ArgumentNullException("picInfoService is null");
            }
            if (picComm == null)
            {
                throw new ArgumentNullException("picInfoRepository is null");
            }
            picInfoService = ipowPicInfo;
            picCommRepository = picComm;
        }

        public PartialViewResult PicCommPage(int picid, int pi)
        {
            var model = picInfoService.GetPicCommListModel(picid, pi, pageSize);
            return PartialView("PicCommListPartial", model);
        }

        public ActionResult AddPicComm(FormCollection f)
        {
            try
            {
                iPow.Infrastructure.Data.DataSys.Sys_PicComm comm = new Infrastructure.Data.DataSys.Sys_PicComm();
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
                string picId = f["txtPicId"].ToString();
                int id = 0;
                int.TryParse(picId, out id);
                comm.PicID = id;
                picCommRepository.Add(comm);

                var picInfo = picInfoService.GetPicSingleById(comm.PicID);
                if (picInfo != null)
                {
                    picInfo.CommCount += 1;
                }

                picCommRepository.Uow.Commit();
                var data = picInfoService.GetPicCommListModel(comm.PicID, 1, pageSize);
                return PartialView("PicCommListPartial", data);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
