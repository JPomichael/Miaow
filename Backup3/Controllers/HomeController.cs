using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Data.Entity;

namespace iPow.Presentation.dj.Controllers
{
    public class HomeController :
        iPow.Infrastructure.Crosscutting.NetFramework.Controllers.iPowBaseController
    {
        int pageSize = 10;

        iPow.Application.dj.Service.IHomeService homeService;

        iPow.Application.dj.Service.ITourPlanService tourPlanService;

        public HomeController(iPow.Infrastructure.Crosscutting.NetFramework.IWorkContext work,
            iPow.Application.dj.Service.IHomeService ipowHomeService,
            iPow.Application.dj.Service.ITourPlanService ipowTourPlanService) :
            base(work)
        {
            if (ipowHomeService == null)
            {
                throw new ArgumentNullException("homeService is null");
            }
            if (ipowTourPlanService == null)
            {
                throw new ArgumentNullException("tourPlanService is null");
            }
            homeService = ipowHomeService;
            tourPlanService = ipowTourPlanService;
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
