using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Data.Repository
{
    public class MvcControllerRolePermissionRepository :
        iPow.Infrastructure.Data.RepositoryObject<iPow.Infrastructure.Data.DataSys.Sys_MvcControllerRolePermission>,
        iPow.Domain.Repository.IMvcControllerRolePermissionRepository
    {
        public MvcControllerRolePermissionRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
