using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Data.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class SightClassRepository :
        iPow.Infrastructure.Data.RepositoryObject<iPow.Infrastructure.Data.DataSys.Sys_SightClass>,
        iPow.Domain.Repository.ISightClassRepository
    {
        public SightClassRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
