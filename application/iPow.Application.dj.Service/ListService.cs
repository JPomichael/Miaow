using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using iPow.Application.dj.Dto;

namespace iPow.Application.dj.Service
{
    /// <summary>
    /// 
    /// </summary>
    public class ListService : IListService
    {
        /// <summary>
        /// 
        /// </summary>
        iPow.Domain.Repository.ISightInfoRepository sightInfoRepository;

        /// <summary>
        /// 
        /// </summary>
        iPow.Domain.Repository.ITourPlanRepository tourPlanRepository;

        /// <summary>
        /// 
        /// </summary>
        iPow.Domain.Repository.ITourPlanDetailRepository tourPlanDetailRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListService"/> class.
        /// </summary>
        /// <param name="sightInfo">The sight info.</param>
        /// <param name="tourPlan">The tour plan.</param>
        /// <param name="tourPlanDetail">The tour plan detail.</param>
        public ListService(iPow.Domain.Repository.ISightInfoRepository sightInfo,
             iPow.Domain.Repository.ITourPlanRepository tourPlan,
             iPow.Domain.Repository.ITourPlanDetailRepository tourPlanDetail
            )
        {
            if (sightInfo == null)
            {
                throw new ArgumentNullException("sightInfoRepository is null");
            }
            if (tourPlan == null)
            {
                throw new ArgumentNullException("tourPlanRepository is null");
            }
            if (tourPlanDetail == null)
            {
                throw new ArgumentNullException("tourPlanDetailRepository is null");
            }
            sightInfoRepository = sightInfo;
            tourPlanRepository = tourPlan;
            tourPlanDetailRepository = tourPlanDetail;
        }


        /// Gets the list type mid tour plan list.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="pageIndex">Size of the page.</param>
        /// <param name="take">The take.</param>
        /// <param name="total">The total.</param>
        /// <returns></returns>
        public IQueryable<ListTypeMidTourPlanDto> GetListTypeMidTourPlanListByTypeId(int id, int pi, int take, ref int total)
        {
            IQueryable<ListTypeMidTourPlanDto> data = null;
            var temp = tourPlanRepository.GetList(e => (e.IsDelete == 0 || e.IsDelete == null))
                  .Where(e => e.PlanClass == id);
            total = temp.Count();
            data = temp.OrderByDescending(e => e.VisitCount)
                .Select(e => new ListTypeMidTourPlanDto
             {
                 Id = e.PlanID,
                 PlanTitle = e.PlanTitle,
                 Days = e.Days,
                 TopReason = e.Destination,
                 PlanTotalMoney = tourPlanDetailRepository.GetList(c => c.PlanID == e.PlanID).Sum(d => d.CurrentPrice),
                 UserName = e.UserName,
                 ViCount = e.VisitCount,
                 ClassId = e.PlanClass,
                 AddTime = e.AddTime
             }).Skip(((pi - 1) < 0 ? 0 : (pi - 1)) * take).Take(take).AsQueryable();
            return data;
        }

        /// <summary>
        /// Gets the list type mid sight by tour plan id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public IQueryable<ListTypeMidSightDto> GetListTypeMidSightListByTourPlanId(int id)
        {
            var sightList = GetSightOrHotelIdList(id, "sight");
            IQueryable<ListTypeMidSightDto> data = null;
            data = sightInfoRepository.GetList(e => sightList.Contains(e.ParkID)).Select(e => new ListTypeMidSightDto
                     {
                         Id = e.ParkID,
                         Name = e.Title,
                         Py = e.PY
                     }).AsQueryable();
            return data;
        }

        /// <summary>
        /// Gets the sight or hotel id list.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public List<int?> GetSightOrHotelIdList(int id, string type)
        {
            var sightList = tourPlanDetailRepository.GetList(e => e.PlanID == id)
                .Where(e => e.DetailType == type)
                .Select(e => e.SightIDOrHotelID)
                .ToList();
            return sightList;
        }

        #region 得到线路的一个随机图片
        /// <summary>
        /// Gets the tour default pic by plan id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public List<string> GetTourDefaultPicByPlanId(int id)
        {
            List<int?> idList = GetSightOrHotelIdList(id, "sight");
            var r = new Random();
            List<string> picPath = new List<string>();
            if (idList.Count > 0)
            {
                int toSkip = r.Next(0, idList.Count);
                picPath = iPow.Infrastructure.Crosscutting.Comm.Service.UtilityService.GetSightDefaultPic((int)idList[toSkip]);
            }
            return picPath;
        }
        #endregion


        /// <summary>
        /// 得到线路分类的随机图片
        /// Gets the tour class default pic by class id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public List<string> GetTourClassDefaultPicByClassId(int id)
        {
            var temp = tourPlanRepository.GetList(e => (e.IsDelete == 0 || e.IsDelete == null))
               .Where(e => e.PlanClass == id).OrderByDescending(e => e.AddTime);
            int total = temp.Count();
            var randClassTotal = new Random();
            if (total > 0)
            {
                int randTour = randClassTotal.Next(0, total);
                int tourId = temp.Skip(randTour).Take(1).Select(e => e.PlanID).FirstOrDefault();
                return GetTourDefaultPicByPlanId(tourId);
            }
            else
            {
                return null;
            }
        }

        public IQueryable<ListTypeMidTourPlanDto> GetTourListByCity(string city, int pi, int take, ref int total)
        {
            IQueryable<ListTypeMidTourPlanDto> data = null;
            var temp = tourPlanRepository.GetList(e => (e.IsDelete == 0 || e.IsDelete == null))
                  .Where(e => e.Destination == city);
            total = temp.Count();
            data = temp.OrderByDescending(e => e.VisitCount)
                .Select(e => new ListTypeMidTourPlanDto
                {
                    Id = e.PlanID,
                    PlanTitle = e.PlanTitle,
                    Days = e.Days,
                    TopReason = e.Destination,
                    PlanTotalMoney = tourPlanDetailRepository.GetList(c => c.PlanID == e.PlanID).Sum(d => d.CurrentPrice),
                    UserName = e.UserName,
                    ViCount = e.VisitCount,
                    ClassId = e.PlanClass,
                    AddTime = e.AddTime
                }).Skip(((pi - 1) < 0 ? 0 : (pi - 1)) * take).Take(take).AsQueryable();
            return data;

        }

    }
}
