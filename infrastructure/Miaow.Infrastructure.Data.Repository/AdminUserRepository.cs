using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Infrastructure.Data.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class AdminUserRepository :
        Miaow.Infrastructure.Data.RepositoryObject<Miaow.Infrastructure.Data.DataSys.Sys_AdminUser>,
        Miaow.Domain.Repository.IAdminUserRepository
    {
        public AdminUserRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
