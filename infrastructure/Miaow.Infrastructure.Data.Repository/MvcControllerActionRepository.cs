using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Infrastructure.Data.Repository
{
    public class MvcControllerActionRepository :
                     Miaow.Infrastructure.Data.RepositoryObject<Miaow.Infrastructure.Data.DataSys.Sys_MvcControllerAction>,
         Miaow.Domain.Repository.IMvcControllerActionRepository
    {
        public MvcControllerActionRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }

}
