using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Data.Repository
{
    public class DiscountCommRepository :
              iPow.Infrastructure.Data.RepositoryObject<iPow.Infrastructure.Data.DataSys.Sys_DiscountComm>,
     iPow.Domain.Repository.IDiscountCommRepository
    {
        public DiscountCommRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
