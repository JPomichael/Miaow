using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Data.Repository
{
    public class MvcControllerRepository :
          iPow.Infrastructure.Data.RepositoryObject<iPow.Infrastructure.Data.DataSys.Sys_MvcController>,
          iPow.Domain.Repository.IMvcControllerRepository
    {
        public MvcControllerRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
