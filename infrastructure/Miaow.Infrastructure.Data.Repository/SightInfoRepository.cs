using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Infrastructure.Data.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class SightInfoRepository :
        Miaow.Infrastructure.Data.RepositoryObject<Miaow.Infrastructure.Data.DataSys.Sys_SightInfo>,
        Miaow.Domain.Repository.ISightInfoRepository
    {
        public SightInfoRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
