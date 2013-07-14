using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Infrastructure.Data.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class TourPlanDetailRepository :
        Miaow.Infrastructure.Data.RepositoryObject<Miaow.Infrastructure.Data.DataSys.Sys_TourPlanDetail>,
        Miaow.Domain.Repository.ITourPlanDetailRepository
    {
        public TourPlanDetailRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
