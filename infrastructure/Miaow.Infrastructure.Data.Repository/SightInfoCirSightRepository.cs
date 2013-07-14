using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Infrastructure.Data.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class SightInfoCirSightRepository :
        Miaow.Infrastructure.Data.RepositoryObject<Miaow.Infrastructure.Data.DataSys.Sys_SightInfoCirSight>,
        Miaow.Domain.Repository.ISightInfoCirSightRepository
    {
        public SightInfoCirSightRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
