using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Data.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class DisCountInfoRepository :
        iPow.Infrastructure.Data.RepositoryObject<iPow.Infrastructure.Data.DataSys.Sys_DisCountInfo>,
        iPow.Domain.Repository.IDisCountInfoRepository
    {
        public DisCountInfoRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
