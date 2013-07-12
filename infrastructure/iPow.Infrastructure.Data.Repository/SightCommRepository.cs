using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Data.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class SightCommRepository :
        iPow.Infrastructure.Data.RepositoryObject<iPow.Infrastructure.Data.DataSys.Sys_SightComm>,
        iPow.Domain.Repository.ISightCommRepository
    {
        public SightCommRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
