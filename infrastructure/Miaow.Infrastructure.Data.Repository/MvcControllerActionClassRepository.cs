using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Infrastructure.Data.Repository
{
    public class MvcControllerActionClassRepository :
         Miaow.Infrastructure.Data.RepositoryObject<Miaow.Infrastructure.Data.DataSys.Sys_MvcControllerActionClass>,
         Miaow.Domain.Repository.IMvcControllerActionClassRepository
    {
        public MvcControllerActionClassRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }

    }
}



