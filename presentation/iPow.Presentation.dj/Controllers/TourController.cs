using System;
using System.Linq;
using System.Web.Mvc;

using iPow.Application.dj.Dto;

namespace iPow.Presentation.dj.Controllers
{
    public class TourController :
        iPow.Infrastructure.Crosscutting.NetFramework.Controllers.iPowBaseController
    {
        iPow.Application.dj.Service.ITourPlanService tourPlanService;

        iPow.Domain.Repository.ITourPlanRepository tourPlanRepository;

        public TourController(iPow.Infrastructure.Crosscutting.NetFramework.IWorkContext work,
            iPow.Application.dj.Service.ITourPlanService ipowTourPlanService,
            iPow.Domain.Repository.ITourPlanRepository tourPlan)
            : base(work)
        {
            if (ipowTourPlanService == null)
            {
                throw new ArgumentNullException("tourPlanService is null");
            }
            if (tourPlan == null)
            {
                throw new ArgumentNullException("tourPlanRepository is null");
            }
            tourPlanService = ipowTourPlanService;
            tourPlanRepository = tourPlan;
        }

        public ActionResult Index(int id)
        {
            var model = tourPlanService.GetTourDetailTopById(id);
            try
            {
                tourPlanRepository.GetList(d => d.PlanID == id).FirstOrDefault().VisitCount++;
                tourPlanRepository.Uow.Commit();
            }
            catch
            {
                throw new ArgumentNullException("plan is null");
            }
            return View(model);
        }
    }
}
