using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Infrastructure.Data.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class AdminUserIndividuationRepository :
        Miaow.Infrastructure.Data.RepositoryObject<Miaow.Infrastructure.Data.DataSys.Sys_AdminUserIndividuation>,
        Miaow.Domain.Repository.IAdminUserIndividuationRepository
    {
        public AdminUserIndividuationRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
