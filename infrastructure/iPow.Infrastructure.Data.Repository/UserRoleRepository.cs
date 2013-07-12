using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Data.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class UserRoleRepository :
        iPow.Infrastructure.Data.RepositoryObject<iPow.Infrastructure.Data.DataSys.Sys_UserRoles>,
        iPow.Domain.Repository.IUserRoleRepository
    {
        public UserRoleRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
