using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace iPow.Application.dj.Service
{
    public class SearchService : ISearchService
    {

        /// <summary>
        /// 
        /// </summary>
        iPow.Domain.Repository.IHotelPropertyInfoRepository hotelPropertyInfoRepository;

        /// <summary>
        /// 
        /// </summary>
        iPow.Domain.Repository.ITourPlanRepository tourPlanRepository;

        /// <summary>
        /// 
        /// </summary>
        iPow.Domain.Repository.ITourPlanDetailRepository tourPlanDetailRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchService"/> class.
        /// </summary>
        /// <param name="hotelPropertyInfo">The hotel property info.</param>
        /// <param name="tourPlan">The tour plan.</param>
        /// <param name="tourPlanDetail">The tour plan detail.</param>
        public SearchService(iPow.Domain.Repository.IHotelPropertyInfoRepository hotelPropertyInfo,
               iPow.Domain.Repository.ITourPlanRepository tourPlan,
               iPow.Domain.Repository.ITourPlanDetailRepository tourPlanDetail)
        {
            if (hotelPropertyInfo == null)
            {
                throw new ArgumentNullException("hotelpropertyinforepository is null");
            }
            if (tourPlan == null)
            {
                throw new ArgumentNullException("tourPlanRepository is null");
            }
            if (tourPlanDetail == null)
            {
                throw new ArgumentNullException("tourPlanDetailRepository is null");
            }
            hotelPropertyInfoRepository = hotelPropertyInfo;
            tourPlanRepository = tourPlan;
            tourPlanDetailRepository = tourPlanDetail;
        }


        /// <summary>
        /// Gets the search tour model.
        /// </summary>
        /// <param name="search">The search.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="take">The take.</param>
        /// <param name="total">The total.</param>
        /// <returns></returns>
        public IQueryable<Dto.SearchTourDto> GetSearchTourModel(Dto.SearchInfoDto search, int pageIndex, int take, ref int total)
        {
            IQueryable<Dto.SearchTourDto> data = null;
            var temp = tourPlanRepository.GetList(e => e.Days <= search.Days && e.Days > ((search.Days - 2) > 0 ? (search.Days - 2) : 0))
                .Where(e => e.IsDelete == 0)
                .Where(e => e.PlanTitle.Contains(search.Bide) ||
                    e.Destination.Contains(search.Bide) ||
                    e.Remark.Contains(search.Bide)
                )
                .OrderByDescending(e => e.Days);
            total = temp.Count();
            data = temp.Select(e => new Dto.SearchTourDto
                {
                    ViCount = e.VisitCount,
                    Id = e.PlanID,
                    PlanTitle = e.PlanTitle,
                    Days = e.Days,
                    TopReason = e.Destination,
                    PlanTotalMoney = tourPlanDetailRepository.GetList(c => c.PlanID == e.PlanID).Sum(d => d.CurrentPrice),
                    UserName = e.UserName,
                    ClassId = e.PlanClass,
                    AddTime = e.AddTime
                }).OrderByDescending(e => e.ViCount)
                .Skip(((pageIndex - 1) < 0 ? 0 : (pageIndex - 1)) * take)
                .Take(take).AsQueryable();
            return data;
        }

        /// <summary>
        /// Gets the search tour model advanced.
        /// </summary>
        /// <param name="search">The search.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="min">The min.</param>
        /// <param name="max">The max.</param>
        /// <param name="day">The day.</param>
        /// <param name="type">The type.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="take">The take.</param>
        /// <param name="total">The total.</param>
        /// <returns></returns>
        public IQueryable<Dto.SearchTourDto> GetSearchTourModelAdvanced(string search,
            string sort, int min, int max, int day, List<string> type,
            int pageIndex, int take, ref int total)
        {
            IQueryable<Dto.SearchTourDto> data = null;
            var temp = tourPlanRepository.GetList(e => e.IsDelete == 0)
                //search
              .Where(e => e.PlanTitle.Contains(search) ||
                  e.Destination.Contains(search) ||
                  e.Remark.Contains(search))
              .Select(e => new Dto.SearchTourDto
                {
                    ViCount = e.VisitCount,
                    Id = e.PlanID,
                    PlanTitle = e.PlanTitle,
                    Days = e.Days,
                    TopReason = e.Destination,
                    PlanTotalMoney = tourPlanDetailRepository.GetList(c => c.PlanID == e.PlanID).Sum(d => d.CurrentPrice),
                    UserName = e.UserName,
                    ClassId = e.PlanClass,
                    AddTime = e.AddTime
                });
            //day
            if (day != 0)
            {
                temp = temp.Where(e => e.Days <= day);
            }
            //type
            if (type.Count > 0)
            {
                temp = temp.Where(e =>
                    tourPlanDetailRepository.GetList(t =>
                    hotelPropertyInfoRepository.GetList(q => tourPlanDetailRepository.GetList(d => d.DetailType == "hotel")
                    .Select(d => d.SightIDOrHotelID).Distinct().Contains(q.HotelID))
                    .Where(w => type.Contains(w.HotelClass))
                    .Select(r => r.HotelID)
                    .Contains(t.SightIDOrHotelID))
                    .Select(y => y.PlanID)
                    .Distinct().Contains(e.Id)
                    );
            }

            //min and max
            //0-200 
            //200-400
            //400-600
            if (min >= 0 && max > 0)
            {
                temp = temp.Where(e => (e.PlanTotalMoney == null ? 0.0 : (int)e.PlanTotalMoney) >= min
                    && e.PlanTotalMoney <= max);
            }
            //600-
            else if (max <= 0)
            {
                temp = temp.Where(e => (e.PlanTotalMoney == null ? 0.0 : e.PlanTotalMoney) >= min);
            }
            else
            {

            }

            //total
            total = temp.Count();

            //sort
            if (sort.ToLower().CompareTo("priceasc") == 0)
            {
                temp = temp.OrderBy(e => e.PlanTotalMoney);
            }
            else if (sort.ToLower().CompareTo("pricedesc") == 0)
            {
                temp = temp.OrderByDescending(e => e.PlanTotalMoney);
            }
            else if (sort.ToLower().CompareTo("daysasc") == 0)
            {
                temp = temp.OrderBy(e => e.Days);
            }
            else if (sort.ToLower().CompareTo("daysdesc") == 0)
            {
                temp = temp.OrderByDescending(e => e.Days);
            }
            else
            {
                temp = temp.OrderByDescending(e => e.ViCount);
            }
            //pi
            data = temp.Skip(((pageIndex - 1) < 0 ? 0 : (pageIndex - 1)) * take)
               .Take(take).AsQueryable();
            return data;
        }

    }
}
