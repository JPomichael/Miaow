using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Infrastructure.Data.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class TourPlanRepository :
        Miaow.Infrastructure.Data.RepositoryObject<Miaow.Infrastructure.Data.DataSys.Sys_TourPlan>,
        Miaow.Domain.Repository.ITourPlanRepository
    {
        public TourPlanRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
