using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Infrastructure.Data.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class RolePermissionRepository :
        Miaow.Infrastructure.Data.RepositoryObject<Miaow.Infrastructure.Data.DataSys.Sys_RolePermissions>,
        Miaow.Domain.Repository.IRolePermissionRepository
    {
        public RolePermissionRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
