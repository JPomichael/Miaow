using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Infrastructure.Data.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class RolesRepository :
        Miaow.Infrastructure.Data.RepositoryObject<Miaow.Infrastructure.Data.DataSys.Sys_Roles>,
        Miaow.Domain.Repository.IRolesRepository
    {
        public RolesRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
