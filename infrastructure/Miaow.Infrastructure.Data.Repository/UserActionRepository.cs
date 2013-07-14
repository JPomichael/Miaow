using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Infrastructure.Data.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class UserActionRepository :
        Miaow.Infrastructure.Data.RepositoryObject<Miaow.Infrastructure.Data.DataSys.Sys_UserAction>,
        Miaow.Domain.Repository.IUserActionRepository
    {
        public UserActionRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
