using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Infrastructure.Data.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class SightCommRepository :
        Miaow.Infrastructure.Data.RepositoryObject<Miaow.Infrastructure.Data.DataSys.Sys_SightComm>,
        Miaow.Domain.Repository.ISightCommRepository
    {
        public SightCommRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
