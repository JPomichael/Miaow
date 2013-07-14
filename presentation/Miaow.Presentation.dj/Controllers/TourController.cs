using System;
using System.Linq;
using System.Web.Mvc;

using Miaow.Application.dj.Dto;

namespace Miaow.Presentation.dj.Controllers
{
    public class TourController :
        Miaow.Infrastructure.Crosscutting.NetFramework.Controllers.MiaowBaseController
    {
        Miaow.Application.dj.Service.ITourPlanService tourPlanService;

        Miaow.Domain.Repository.ITourPlanRepository tourPlanRepository;

        public TourController(Miaow.Infrastructure.Crosscutting.NetFramework.IWorkContext work,
            Miaow.Application.dj.Service.ITourPlanService MiaowTourPlanService,
            Miaow.Domain.Repository.ITourPlanRepository tourPlan)
            : base(work)
        {
            if (MiaowTourPlanService == null)
            {
                throw new ArgumentNullException("tourPlanService is null");
            }
            if (tourPlan == null)
            {
                throw new ArgumentNullException("tourPlanRepository is null");
            }
            tourPlanService = MiaowTourPlanService;
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
