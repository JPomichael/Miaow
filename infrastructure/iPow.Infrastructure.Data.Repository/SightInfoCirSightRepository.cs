using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Data.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class SightInfoCirSightRepository :
        iPow.Infrastructure.Data.RepositoryObject<iPow.Infrastructure.Data.DataSys.Sys_SightInfoCirSight>,
        iPow.Domain.Repository.ISightInfoCirSightRepository
    {
        public SightInfoCirSightRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
