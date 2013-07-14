using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Infrastructure.Data.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class PicCommRepository :
        Miaow.Infrastructure.Data.RepositoryObject<Miaow.Infrastructure.Data.DataSys.Sys_PicComm>,
        Miaow.Domain.Repository.IPicCommRepository
    {
        public PicCommRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
