using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Infrastructure.Data.Repository
{
    public class MvcControllerRolePermissionRepository :
        Miaow.Infrastructure.Data.RepositoryObject<Miaow.Infrastructure.Data.DataSys.Sys_MvcControllerRolePermission>,
        Miaow.Domain.Repository.IMvcControllerRolePermissionRepository
    {
        public MvcControllerRolePermissionRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
