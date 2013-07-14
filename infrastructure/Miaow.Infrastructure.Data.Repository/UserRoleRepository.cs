using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Infrastructure.Data.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class UserRoleRepository :
        Miaow.Infrastructure.Data.RepositoryObject<Miaow.Infrastructure.Data.DataSys.Sys_UserRoles>,
        Miaow.Domain.Repository.IUserRoleRepository
    {
        public UserRoleRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
