using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Data.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class RolePermissionRepository :
        iPow.Infrastructure.Data.RepositoryObject<iPow.Infrastructure.Data.DataSys.Sys_RolePermissions>,
        iPow.Domain.Repository.IRolePermissionRepository
    {
        public RolePermissionRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
