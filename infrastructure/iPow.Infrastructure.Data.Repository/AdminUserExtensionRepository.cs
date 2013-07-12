using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Data.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class AdminUserExtensionRepository :
        iPow.Infrastructure.Data.RepositoryObject<iPow.Infrastructure.Data.DataSys.Sys_AdminUserExtension>,
        iPow.Domain.Repository.IAdminUserExtensionRepository
    {
        public AdminUserExtensionRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
