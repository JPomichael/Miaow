using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using iPow.Domain.Dto;
using iPow.Infrastructure.Data.DataSys;
using iPow.Infrastructure.Crosscutting.EntityToDto;

namespace iPow.Application.account.Service
{
    public class TourPlanDetailService : ITourPlanDetailService
    {
        iPow.Domain.Repository.ITourPlanDetailRepository tourPlanDetailRepository;

        iPow.Domain.Repository.ISightInfoRepository sightInoRepository;

        public TourPlanDetailService(iPow.Domain.Repository.ITourPlanDetailRepository tourPlanDetail,
            iPow.Domain.Repository.ISightInfoRepository sightInfoRep)
        {
            if (tourPlanDetail == null)
            {
                throw new ArgumentNullException("tourPlanDetailRepository is null");
            }
            if (sightInfoRep == null)
            {
                throw new ArgumentNullException("sightInfoRepository is null");
            }
            tourPlanDetailRepository = tourPlanDetail;
            sightInoRepository = sightInfoRep;
        }

        /// <summary>
        /// 在线路中添加景点
        /// </summary>
        /// <param name="tour"></param>
        /// <returns></returns>
        public int AddTourPlanDetail(Sys_TourPlanDetail tour)
        {
            int count = 0;
            if (tour != null)
            {
                tourPlanDetailRepository.Add(tour);
                tourPlanDetailRepository.Uow.Commit();
                if (tour.PlanID > 0)
                {
                    count = 1;
                }
            }
            return count;
        }

        /// <summary>
        /// Check  Is Exist
        /// </summary>
        /// <param name="PlanID"></param>
        /// <param name="Remark"></param>
        /// <returns></returns>
        public bool CheckTourPlanDetailIsExist(int PlanID, int SightID, string Remark)
        {
            var res = tourPlanDetailRepository.GetList(e => e.SightIDOrHotelID == SightID && e.Remark == Remark).Where(e => e.PlanID == PlanID).Any();
            return res;
        }

        /// <summary>
        /// 验证 路线详情里是否已经存在该ID的景点
        /// </summary>
        /// <param name="parkID"></param>
        /// <param name="PlanID"></param>
        /// <returns></returns>
        public bool CheckAddSightByID(int parkID, int PlanID)
        {
            var res = tourPlanDetailRepository.GetList(e => e.SightIDOrHotelID == parkID).Where(e => e.PlanID == PlanID).Any();
            return res;
        }

        /// <summary>
        /// 删除该UserID 下的景点
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool UpdatesightById(int id)
        {
            bool count = false;
            var res = tourPlanDetailRepository.GetList(e => e.PlanID == id).First();
            tourPlanDetailRepository.Delete(res);
            tourPlanDetailRepository.Uow.Commit();
            count = true;
            return count;
        }

        /// <summary>
        /// 得到List<SIghtID>  
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<Dto.PartTourPlanDto> GetSightTitleByID(int id)
        {
            var res = tourPlanDetailRepository.GetList(e => e.PlanID == id)
                .Select(e => new Dto.PartTourPlanDto
                {
                    SightIDOrHotelID =e.SightIDOrHotelID,
                });
            return res;
        }

        /// <summary>
        /// 计算路线的总共费用
        /// </summary>
        /// <param name="planId"></param>
        /// <returns></returns>
        public IEnumerable<Dto.TourPlanDetailDto> GetTourPlanPrice(int planId)
        {
            var res = tourPlanDetailRepository.GetList(e => e.PlanID == planId)
                .Select(e => new Dto.TourPlanDetailDto
                {
                    CurrentPrice = Convert.ToInt32(e.CurrentPrice),
                });
            return res;
        }

        /// <summary>
        ///获得路线ID下 所有信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public IEnumerable<Dto.TourPlanDetailDto> GetTourPlanByID(int planId)
        {
            var res = tourPlanDetailRepository.GetList(e => e.PlanID == planId)
                .Select(e => new Dto.TourPlanDetailDto
                {
                    SightIDOrHotelID = e.SightIDOrHotelID,
                    PlanID = planId,
                });
            return res;
        } 

        /// <summary>
        ///获取线路详情  
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public IEnumerable<Dto.TourPlanDetailDto> GetTourPlanDetailByID(int Id)
        {
            var res = tourPlanDetailRepository.GetList(e => e.PlanID == Id).Where(e => e.IsDelete == 0 || e.IsDelete == null);
            return res.ToDto();
        }

        /// <summary>
        /// 查看线路是否存在景区
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool CheckTourPlanIsExistByID(int Id)
        {
            var res = tourPlanDetailRepository.GetList(e => e.PlanID == Id).Where(e => e.IsDelete == 0 || e.IsDelete == null || e.DetailType == "sight").Any();
            return res;
        }

    }
}

