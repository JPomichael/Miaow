using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Data.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class RolesRepository :
        iPow.Infrastructure.Data.RepositoryObject<iPow.Infrastructure.Data.DataSys.Sys_Roles>,
        iPow.Domain.Repository.IRolesRepository
    {
        public RolesRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
