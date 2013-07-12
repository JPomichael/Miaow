using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Data.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class SightInfoRepository :
        iPow.Infrastructure.Data.RepositoryObject<iPow.Infrastructure.Data.DataSys.Sys_SightInfo>,
        iPow.Domain.Repository.ISightInfoRepository
    {
        public SightInfoRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
