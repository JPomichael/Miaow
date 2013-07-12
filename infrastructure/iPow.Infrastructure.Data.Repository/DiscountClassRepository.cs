using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Data.Repository
{
    public class DiscountClassRepository :
        iPow.Infrastructure.Data.RepositoryObject<iPow.Infrastructure.Data.DataSys.Sys_DiscountClass>,
        iPow.Domain.Repository.IDiscountClassRepository
    {
        public DiscountClassRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
