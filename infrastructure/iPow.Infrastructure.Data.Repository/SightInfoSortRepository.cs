using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Data.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class SightInfoSortRepository :
        iPow.Infrastructure.Data.RepositoryObject<iPow.Infrastructure.Data.DataSys.Sys_SightInfoSort>,
        iPow.Domain.Repository.ISightInfoSortRepository
    {
        public SightInfoSortRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
