using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Data.Entity;

namespace Miaow.Presentation.dj.Controllers
{
    public class HomeController :
        Miaow.Infrastructure.Crosscutting.NetFramework.Controllers.MiaowBaseController
    {
        int pageSize = 10;

        Miaow.Application.dj.Service.IHomeService homeService;

        Miaow.Application.dj.Service.ITourPlanService tourPlanService;

        public HomeController(Miaow.Infrastructure.Crosscutting.NetFramework.IWorkContext work,
            Miaow.Application.dj.Service.IHomeService MiaowHomeService,
            Miaow.Application.dj.Service.ITourPlanService MiaowTourPlanService) :
            base(work)
        {
            if (MiaowHomeService == null)
            {
                throw new ArgumentNullException("homeService is null");
            }
            if (MiaowTourPlanService == null)
            {
                throw new ArgumentNullException("tourPlanService is null");
            }
            homeService = MiaowHomeService;
            tourPlanService = MiaowTourPlanService;
        }

        public ViewResult Index(int? pageIndex)
        {
            var data = homeService.GetHomeModel (pageIndex ?? 1, pageSize);
            return View(data);
        }

        [HttpPost]
        [ActionName("toptourplancity")]
        public PartialViewResult GetTopTourPlanCity(string id)
        {
            var model = tourPlanService.GetTourPlanListByCity(id, 3);
            return PartialView("TopTourPlanPartial", model);
        }
    }
}
