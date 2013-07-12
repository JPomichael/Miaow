using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Data.Repository
{
    public class MvcControllerActionClassRepository :
         iPow.Infrastructure.Data.RepositoryObject<iPow.Infrastructure.Data.DataSys.Sys_MvcControllerActionClass>,
         iPow.Domain.Repository.IMvcControllerActionClassRepository
    {
        public MvcControllerActionClassRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }

    }
}



