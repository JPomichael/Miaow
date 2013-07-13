using System.Web.Mvc;

namespace iPow.Presentation.Union.Controllers
{
    [HandleError]
    public class HeadVouchDataController :
        iPow.Infrastructure.Crosscutting.NetFramework.Controllers.iPowBaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HeadVouchDataController"/> class.
        /// </summary>
        /// <param name="work">The work.</param>
        public HeadVouchDataController(iPow.Infrastructure.Crosscutting.NetFramework.IWorkContext work)
            : base(work)
        { }

        /// <summary>
        /// Gets the vouch data.
        /// </summary>
        /// <param name="city">The city.</param>
        /// <returns></returns>
        [HttpGet]
        [OutputCache(Duration = 3600)]
        public PartialViewResult GetVouchData(string city)
        {
            ViewBag.city = city;
            return PartialView("HeadVouchDataPartial");
        }
    }
}
