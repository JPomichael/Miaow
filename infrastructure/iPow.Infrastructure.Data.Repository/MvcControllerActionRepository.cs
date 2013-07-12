using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Data.Repository
{
    public class MvcControllerActionRepository :
                     iPow.Infrastructure.Data.RepositoryObject<iPow.Infrastructure.Data.DataSys.Sys_MvcControllerAction>,
         iPow.Domain.Repository.IMvcControllerActionRepository
    {
        public MvcControllerActionRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }

}
