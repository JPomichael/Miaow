using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Webdiyer.WebControls.Mvc;
using iPow.Application.dj.Dto;

namespace iPow.Presentation.dj.Controllers
{
    [HandleError]
    public class CatalogController :
        iPow.Infrastructure.Crosscutting.NetFramework.Controllers.iPowBaseController
    {
        //单页显示4个
        const int pageSize = 4;

        iPow.Application.dj.Service.IListService listService;

        iPow.Application.dj.Service.IHomeService homeService;

        iPow.Application.dj.Service.ITourPlanService tourPlanService;

        public CatalogController(iPow.Infrastructure.Crosscutting.NetFramework.IWorkContext work,
        iPow.Application.dj.Service.IListService ipowListService,
            iPow.Application.dj.Service.IHomeService ipowHomeService,
            iPow.Application.dj.Service.ITourPlanService ipowTourPlanService)
            : base(work)
        {
            if (ipowHomeService == null)
            {
                throw new ArgumentNullException("homeService is null");
            }
            if (ipowTourPlanService == null)
            {
                throw new ArgumentNullException("tourPlanService is null");
            }
            if (ipowListService == null)
            {
                throw new ArgumentNullException("listService is null");
            }
            homeService = ipowHomeService;
            tourPlanService = ipowTourPlanService;
            listService = ipowListService;
        }

        public ViewResult Index(int? id)
        {
            var data = homeService.GetHomeModel(id ?? 1, pageSize);
            return View(data);
        }

        public ViewResult Tour(int id, int pi)
        {
            IQueryable<iPow.Application.dj.Dto.ListTypeMidTourPlanDto> data = null;
            int total = 0;
            data = listService.GetListTypeMidTourPlanListByTypeId(id, pi, pageSize, ref total);

            PagedList<iPow.Application.dj.Dto.ListTypeMidTourPlanDto> model =
                new PagedList<iPow.Application.dj.Dto.ListTypeMidTourPlanDto>
                    (data, pi, pageSize, total);

            ViewBag.id = id;
            return View(model);
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
