using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Infrastructure.Data.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class AdminUserExtensionRepository :
        Miaow.Infrastructure.Data.RepositoryObject<Miaow.Infrastructure.Data.DataSys.Sys_AdminUserExtension>,
        Miaow.Domain.Repository.IAdminUserExtensionRepository
    {
        public AdminUserExtensionRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
