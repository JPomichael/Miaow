using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Data.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class TourClassRepository :
        iPow.Infrastructure.Data.RepositoryObject<iPow.Infrastructure.Data.DataSys.Sys_TourClass>,
        iPow.Domain.Repository.ITourClassRepository
    {
        public TourClassRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
