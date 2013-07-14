using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Infrastructure.Data.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class SightVouchItemRepository :
        Miaow.Infrastructure.Data.RepositoryObject<Miaow.Infrastructure.Data.DataSys.Sys_SightVouchItem>,
        Miaow.Domain.Repository.ISightVouchItemRepository
    {
        public SightVouchItemRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
