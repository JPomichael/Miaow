using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Data.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class AdminUserRepository :
        iPow.Infrastructure.Data.RepositoryObject<iPow.Infrastructure.Data.DataSys.Sys_AdminUser>,
        iPow.Domain.Repository.IAdminUserRepository
    {
        public AdminUserRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
