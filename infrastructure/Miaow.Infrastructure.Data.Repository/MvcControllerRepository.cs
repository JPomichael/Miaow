using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Infrastructure.Data.Repository
{
    public class MvcControllerRepository :
          Miaow.Infrastructure.Data.RepositoryObject<Miaow.Infrastructure.Data.DataSys.Sys_MvcController>,
          Miaow.Domain.Repository.IMvcControllerRepository
    {
        public MvcControllerRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
