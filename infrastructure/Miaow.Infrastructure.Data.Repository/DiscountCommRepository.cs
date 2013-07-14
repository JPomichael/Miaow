using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Infrastructure.Data.Repository
{
    public class DiscountCommRepository :
              Miaow.Infrastructure.Data.RepositoryObject<Miaow.Infrastructure.Data.DataSys.Sys_DiscountComm>,
     Miaow.Domain.Repository.IDiscountCommRepository
    {
        public DiscountCommRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
