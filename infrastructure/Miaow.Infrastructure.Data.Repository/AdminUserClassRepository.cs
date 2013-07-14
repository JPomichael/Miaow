using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Infrastructure.Data.Repository
{
    public class AdminUserClassRepository :
        Miaow.Infrastructure.Data.RepositoryObject<Miaow.Infrastructure.Data.DataSys.Sys_AdminUserClass>,
        Miaow.Domain.Repository.IAdminUserClassRepository
    {
        public AdminUserClassRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }

    }
}
