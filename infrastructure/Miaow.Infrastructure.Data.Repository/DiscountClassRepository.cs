using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Infrastructure.Data.Repository
{
    public class DiscountClassRepository :
        Miaow.Infrastructure.Data.RepositoryObject<Miaow.Infrastructure.Data.DataSys.Sys_DiscountClass>,
        Miaow.Domain.Repository.IDiscountClassRepository
    {
        public DiscountClassRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
