using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Data.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class SightVouchItemRepository :
        iPow.Infrastructure.Data.RepositoryObject<iPow.Infrastructure.Data.DataSys.Sys_SightVouchItem>,
        iPow.Domain.Repository.ISightVouchItemRepository
    {
        public SightVouchItemRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
