using System;
using System.Collections.Generic;
using System.Linq;

using Miaow.Application.jq.Dto;

namespace Miaow.Application.jq.Service
{
    public class TopClassService : ITopClassService
    {
        /// <summary>
        /// 
        /// </summary>
        Miaow.Domain.Repository.ISightInfoRepository sightInfoRepository;

        /// <summary>
        /// 
        /// </summary>
        Miaow.Domain.Repository.ISightClassRepository sightClassRepository;

        Miaow.Domain.Repository.ISightInfoSortRepository sightInfoSortRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="TopClassService"/> class.
        /// </summary>
        /// <param name="sightInfo">The sight info.</param>
        /// <param name="sightClass">The sight class.</param>
        /// <param name="sightInfoSort">The sight info sort.</param>
        public TopClassService(Miaow.Domain.Repository.ISightInfoRepository sightInfo,
            Miaow.Domain.Repository.ISightClassRepository sightClass,
            Miaow.Domain.Repository.ISightInfoSortRepository sightInfoSort)
        {
            if (sightInfo == null)
            {
                throw new ArgumentNullException("sightinforepository is null");
            }
            if (sightClass == null)
            {
                throw new ArgumentNullException("sightclassrepository is null");
            }
            if (sightInfoSort == null)
            {
                throw new ArgumentNullException("sightInfoSortRepository is null");
            }
            sightInfoRepository = sightInfo;
            sightClassRepository = sightClass;
            sightInfoSortRepository = sightInfoSort;
        }

        /// <summary>
        /// Updates the top class.
        /// </summary>
        /// <param name="si">The si.</param>
        /// <returns></returns> 
        public List<TopClassDto> GetTopClassBySight(IEnumerable<Miaow.Infrastructure.Data.DataSys.Sys_SightInfo> si)
        {
            List<TopClassDto> tc = new List<TopClassDto>();

            //在这里，去更新TopClass
            tc = (from d in si
                  group d by d.ClassID into g
                  orderby g.Count() descending
                  select new TopClassDto
                  {
                      count = g.Count(),
                      name = (from s in sightClassRepository.GetList() where s.ClassID == g.Key select s).FirstOrDefault().ClassName,
                      Type = g.Key
                  }).ToList();
            return tc;
        }

        /// <summary>
        /// Updates the top class two.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="tar">The tar.</param>
        /// <returns></returns>
        public List<TopClassDto> UpdateTopClassTwo(List<TopClassDto> source, IEnumerable<TopClassDto> tar)
        {
            foreach (var item in tar)
            {
                for (int k = 0; k < source.Count; k++)
                {
                    if (item.Type == source[k].Type)
                    {
                        source[k].count += item.count;
                    }
                    else
                    { continue; }
                }
            }
            return source;
        }

        /// <summary>
        /// Adds the global to top class.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public List<TopClassDto> AddGlobalToTopClass(List<TopClassDto> source)
        {
            var globalSightIdList =  sightInfoSortRepository.GetList(e => e.Type == 3).Select(e=> e.SightId);
            var temp = (from e in sightInfoRepository.GetList()
                        where  globalSightIdList.Contains(e.ParkID) &&   e.IsDelete == 0
                        orderby e.ParkID descending
                        group e by e.ClassID into g
                        select new TopClassDto
                        {
                            count = g.Count(),
                            name = (from s in sightClassRepository.GetList() where s.ClassID == g.Key select s).FirstOrDefault().ClassName,
                            Type = g.Key
                        }).ToList();
            return UpdateTopClassTwo(source, temp);
        }
    }
}