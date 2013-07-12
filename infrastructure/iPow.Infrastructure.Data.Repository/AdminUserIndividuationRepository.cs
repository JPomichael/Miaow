using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Data.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class AdminUserIndividuationRepository :
        iPow.Infrastructure.Data.RepositoryObject<iPow.Infrastructure.Data.DataSys.Sys_AdminUserIndividuation>,
        iPow.Domain.Repository.IAdminUserIndividuationRepository
    {
        public AdminUserIndividuationRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
