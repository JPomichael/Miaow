using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Data.Repository
{
    public class MvcControllerClassRepository :
                iPow.Infrastructure.Data.RepositoryObject<iPow.Infrastructure.Data.DataSys.Sys_MvcControllerClass>,
           iPow.Domain.Repository.IMvcControllerClassRepository
    {
        public MvcControllerClassRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }

}
