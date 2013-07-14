using System;
using System.Linq;
using System.Web.Mvc;

using Webdiyer.WebControls.Mvc;

namespace Miaow.Presentation.dj.Controllers
{
    [HandleError]
    public class ListController :
        Miaow.Infrastructure.Crosscutting.NetFramework.Controllers.MiaowBaseController
    {
        const int pageSize = 4;

        Miaow.Application.dj.Service.IListService listService;

        Miaow.Application.dj.Service.IHomeService homeService;

        Miaow.Application.dj.Service.ITourPlanService tourPlanService;

        public ListController(Miaow.Infrastructure.Crosscutting.NetFramework.IWorkContext work,
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

        public ViewResult Index(int id, int pi)
        {
            int total = 0;
            var data = listService.GetListTypeMidTourPlanListByTypeId(id, pi, pageSize, ref total);
            PagedList<Miaow.Application.dj.Dto.ListTypeMidTourPlanDto> model = new PagedList<Miaow.Application.dj.Dto.ListTypeMidTourPlanDto>(data, pi, pageSize, total);
            ViewBag.id = id;
            return View(model);
        }
    }
}
