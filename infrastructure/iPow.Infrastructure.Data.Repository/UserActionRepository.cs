using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Data.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class UserActionRepository :
        iPow.Infrastructure.Data.RepositoryObject<iPow.Infrastructure.Data.DataSys.Sys_UserAction>,
        iPow.Domain.Repository.IUserActionRepository
    {
        public UserActionRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
