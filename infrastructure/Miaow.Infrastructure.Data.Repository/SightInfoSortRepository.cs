using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Infrastructure.Data.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class SightInfoSortRepository :
        Miaow.Infrastructure.Data.RepositoryObject<Miaow.Infrastructure.Data.DataSys.Sys_SightInfoSort>,
        Miaow.Domain.Repository.ISightInfoSortRepository
    {
        public SightInfoSortRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
