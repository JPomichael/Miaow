using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Infrastructure.Data.Repository
{
    public class MvcControllerClassRepository :
                Miaow.Infrastructure.Data.RepositoryObject<Miaow.Infrastructure.Data.DataSys.Sys_MvcControllerClass>,
           Miaow.Domain.Repository.IMvcControllerClassRepository
    {
        public MvcControllerClassRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }

}
