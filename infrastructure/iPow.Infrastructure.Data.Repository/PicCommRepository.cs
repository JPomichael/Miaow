using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Data.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class PicCommRepository :
        iPow.Infrastructure.Data.RepositoryObject<iPow.Infrastructure.Data.DataSys.Sys_PicComm>,
        iPow.Domain.Repository.IPicCommRepository
    {
        public PicCommRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
