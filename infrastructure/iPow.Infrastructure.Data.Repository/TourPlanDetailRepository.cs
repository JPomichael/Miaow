using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Data.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class TourPlanDetailRepository :
        iPow.Infrastructure.Data.RepositoryObject<iPow.Infrastructure.Data.DataSys.Sys_TourPlanDetail>,
        iPow.Domain.Repository.ITourPlanDetailRepository
    {
        public TourPlanDetailRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
