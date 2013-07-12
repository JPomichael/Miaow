using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Webdiyer.WebControls.Mvc;

namespace iPow.Application.dj.Service
{
    /// <summary>
    /// 
    /// </summary>
    public class HomeService : IHomeService
    {
        /// <summary>
        /// 
        /// </summary>
        iPow.Application.dj.Service.ITourPlanService tourPlanService = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeService"/> class.
        /// </summary>
        /// <param name="tpService">The tp service.</param>
        public HomeService(iPow.Application.dj.Service.ITourPlanService tpService)
        {
            if (tpService == null)
            {
                throw new ArgumentNullException("tourPlanService is null");
            }
            tourPlanService = tpService;
        }

        /// <summary>
        /// Gets the home model.
        /// </summary>
        /// <param name="pi">The pi.</param>
        /// <param name="take">The take.</param>
        /// <returns></returns>
        public Dto.HomeDto GetHomeModel(int? pi, int? take)
        {
            Dto.HomeDto data = new Dto.HomeDto();
            data.TopTourCitys = tourPlanService.GetTopTourPlanCity(10).ToList();
            #region TopTourPlans
            if (data.TopTourCitys.Count() > 0)
            {
                foreach (var item in data.TopTourCitys)
                {
                    data.TopTourPlans = tourPlanService.GetTourPlanListByCity(item.CityName, 3).ToPagedList(pi ?? 1, take ?? 10);
                    break;
                }
            }
            else
            {
                data.TopTourPlans = tourPlanService.GetTourPlanListByCity("上海", 3).ToPagedList(pi ?? 1, take ?? 10);
            }
            #endregion
            return data;
        }
    }
}