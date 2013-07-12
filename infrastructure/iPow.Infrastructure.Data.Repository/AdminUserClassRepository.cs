using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Data.Repository
{
    public class AdminUserClassRepository :
        iPow.Infrastructure.Data.RepositoryObject<iPow.Infrastructure.Data.DataSys.Sys_AdminUserClass>,
        iPow.Domain.Repository.IAdminUserClassRepository
    {
        public AdminUserClassRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }

    }
}
