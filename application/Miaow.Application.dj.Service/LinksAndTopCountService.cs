using System;
using System.Collections.Generic;
using System.Linq;

using Miaow.Infrastructure.Crosscutting.EntityToDto;

namespace Miaow.Application.dj.Service
{
    public class LinksAndTopCountService : ILinksAndTopCountService
    {
        /// <summary>
        /// 
        /// </summary>
        Miaow.Domain.Repository.ILinkInfoRepository linkInfoRepository;

        /// <summary>
        /// 
        /// </summary>
        Miaow.Domain.Repository.ISightInfoRepository sightInfoRepository;

        /// <summary>
        /// 
        /// </summary>
        Miaow.Domain.Repository.ITourPlanRepository tourPlanRepository;

        /// <summary>
        /// 
        /// </summary>
        Miaow.Domain.Repository.IHotelPropertyInfoRepository hotelPropertyInfoRepository;


        /// <summary>
        /// Initializes a new instance of the <see cref="LinksAndTopCountService"/> class.
        /// </summary>
        public LinksAndTopCountService(Miaow.Domain.Repository.ILinkInfoRepository linkInfo,
              Miaow.Domain.Repository.ISightInfoRepository sightInfo,
              Miaow.Domain.Repository.ITourPlanRepository tourPlan,
              Miaow.Domain.Repository.IHotelPropertyInfoRepository hotelPropertyInfo
            )
        {
            if (linkInfo == null)
            {
                throw new ArgumentNullException("linkInfoRepository is null");
            }
            if (sightInfo == null)
            {
                throw new ArgumentNullException("sightInfoRepository is null");
            }
            if (tourPlan == null)
            {
                throw new ArgumentNullException("tourPlanRepository is null");
            }
            if (hotelPropertyInfo == null)
            {
                throw new ArgumentNullException("hotelPropertyInfoRepository is null");
            }
            linkInfoRepository = linkInfo;
            sightInfoRepository = sightInfo;
            tourPlanRepository = tourPlan;
            hotelPropertyInfoRepository = hotelPropertyInfo;
        }

        /// <summary>
        /// Gets the text link list.
        /// </summary>
        /// <returns></returns>
        public List<Miaow.Domain.Dto.Sys_LinksInfoDto> GetTextLinkList()
        {
            var temp = (from e in linkInfoRepository.GetList()
                        where e.IsDelete == 0 &&
                       (e.LinksPath == "" ||
                        e.LinksPath == null ||
                        e.LinksName == null ||
                        e.LinksName == "") &&
                        e.ClassID == 3 &&
                        e.IsTop == 1
                        orderby e.AddTime descending
                        select e
            ).ToList();
            return temp.ToDto().ToList();
        }

        /// <summary>
        /// Gets the img link list.
        /// </summary>
        /// <returns></returns>
        public List<Miaow.Domain.Dto.Sys_LinksInfoDto> GetImgLinkList()
        {
            var temp = (from e in linkInfoRepository.GetList()
                        where e.IsDelete == 0 &&
                        e.LinksPath != "" &&
                        e.LinksPath != null &&
                        e.LinksName != null &&
                        e.LinksName != "" &&
                        e.ClassID == 3 &&
                        e.IsTop == 1
                        orderby e.AddTime descending
                        select e
                ).ToList();
            return temp.ToDto().ToList();
        }

        /// <summary>
        /// Gets the sight count.
        /// </summary>
        /// <returns></returns>
        public int GetSightCount()
        {
            return sightInfoRepository.GetList().Count();
        }

        /// <summary>
        /// Gets the tour info count.
        /// </summary>
        /// <returns></returns>
        public int GetTourInfoCount()
        {
            return tourPlanRepository.GetList().Count();
        }

        /// <summary>
        /// Gets the hotel info count.
        /// </summary>
        /// <returns></returns>
        public int GetHotelInfoCount()
        {
            return hotelPropertyInfoRepository.GetList().Count();
        }
    }
}