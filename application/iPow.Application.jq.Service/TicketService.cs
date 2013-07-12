using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using iPow.Application.jq.Dto;

namespace iPow.Application.jq.Service
{
    /// <summary>
    /// 
    /// </summary>
    public class TicketService : ITicketService
    {
        /// <summary>
        /// 
        /// </summary>
        private iPow.Domain.Repository.ISightInfoRepository sightInfoRepository = null;

        /// <summary>
        /// 
        /// </summary>
        private iPow.Domain.Repository.ISightClassRepository sightClassRepository = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="TopClassService"/> class.
        /// </summary>
        /// <param name="sightInfo">The sight info.</param>
        /// <param name="sightClass">The sight class.</param>
        public TicketService(iPow.Domain.Repository.ISightInfoRepository sightInfo,
            iPow.Domain.Repository.ISightClassRepository sightClass)
        {
            if (sightInfo == null)
            {
                throw new ArgumentNullException("sightinforepository is null");
            }
            if (sightClass == null)
            {
                throw new ArgumentNullException("sightclassrepository is null");
            }
            sightInfoRepository = sightInfo;
            sightClassRepository = sightClass;
        }

        /// <summary>
        /// Gets the detail base info by id.
        /// </summary>
        /// <param name="sid">The sid.</param>
        /// <returns></returns>
        public DetailSightBaseDto GetDetailSightBaseInfoById(int sid)
        {
            DetailSightBaseDto data = sightInfoRepository.GetList(e => e.ParkID == sid)
                .Select(e => new DetailSightBaseDto
                {
                    GoCount = e.GoCount,
                    ParkID = e.ParkID,
                    Py = e.PY,
                    Ticket = e.Ticket,
                    Title = e.Title,
                    Type = sightClassRepository.GetList(d => d.ClassID == e.ClassID).FirstOrDefault().ClassName,
                    WantCount = e.WantCount,
                    ParkMap = e.ParkMap
                }).FirstOrDefault();
            return data;
        }
    }
}
