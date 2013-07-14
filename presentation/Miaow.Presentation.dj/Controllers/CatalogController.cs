using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Webdiyer.WebControls.Mvc;
using Miaow.Application.dj.Dto;

namespace Miaow.Presentation.dj.Controllers
{
    [HandleError]
    public class CatalogController :
        Miaow.Infrastructure.Crosscutting.NetFramework.Controllers.MiaowBaseController
    {
        //单页显示4个
        const int pageSize = 4;

        Miaow.Application.dj.Service.IListService listService;

        Miaow.Application.dj.Service.IHomeService homeService;

        Miaow.Application.dj.Service.ITourPlanService tourPlanService;

        public CatalogController(Miaow.Infrastructure.Crosscutting.NetFramework.IWorkContext work,
        Miaow.Application.dj.Service.IListService MiaowListService,
            Miaow.Application.dj.Service.IHomeService MiaowHomeService,
            Miaow.Application.dj.Service.ITourPlanService MiaowTourPlanService)
            : base(work)
        {
            if (MiaowHomeService == null)
            {
                throw new ArgumentNullException("homeService is null");
            }
            if (MiaowTourPlanService == null)
            {
                throw new ArgumentNullException("tourPlanService is null");
            }
            if (MiaowListService == null)
            {
                throw new ArgumentNullException("listService is null");
            }
            homeService = MiaowHomeService;
            tourPlanService = MiaowTourPlanService;
            listService = MiaowListService;
        }

        public ViewResult Index(int? id)
        {
            var data = homeService.GetHomeModel(id ?? 1, pageSize);
            return View(data);
        }

        public ViewResult Tour(int id, int pi)
        {
            IQueryable<Miaow.Application.dj.Dto.ListTypeMidTourPlanDto> data = null;
            int total = 0;
            data = listService.GetListTypeMidTourPlanListByTypeId(id, pi, pageSize, ref total);

            PagedList<Miaow.Application.dj.Dto.ListTypeMidTourPlanDto> model =
                new PagedList<Miaow.Application.dj.Dto.ListTypeMidTourPlanDto>
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
