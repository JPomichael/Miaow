using System;
using System.Linq;
using System.Web.Mvc;

using Webdiyer.WebControls.Mvc;

namespace iPow.dj.Controllers
{
    [HandleError]
    public class ListController :
        iPow.Infrastructure.Crosscutting.NetFramework.Controllers.iPowBaseController
    {
        const int pageSize = 4;

        iPow.Application.dj.Service.IListService listService;

        iPow.Application.dj.Service.IHomeService homeService;

        iPow.Application.dj.Service.ITourPlanService tourPlanService;

        public ListController(iPow.Infrastructure.Crosscutting.NetFramework.IWorkContext work,
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

        public ViewResult Index(int id, int pi)
        {
            int total = 0;
            var data = listService.GetListTypeMidTourPlanListByTypeId(id, pi, pageSize, ref total);
            PagedList<iPow.Application.dj.Dto.ListTypeMidTourPlanDto> model = new PagedList<iPow.Application.dj.Dto.ListTypeMidTourPlanDto>(data, pi, pageSize, total);
            ViewBag.id = id;
            return View(model);
        }
    }
}
