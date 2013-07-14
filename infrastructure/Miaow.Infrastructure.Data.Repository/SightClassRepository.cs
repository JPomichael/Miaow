using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Infrastructure.Data.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class SightClassRepository :
        Miaow.Infrastructure.Data.RepositoryObject<Miaow.Infrastructure.Data.DataSys.Sys_SightClass>,
        Miaow.Domain.Repository.ISightClassRepository
    {
        public SightClassRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
