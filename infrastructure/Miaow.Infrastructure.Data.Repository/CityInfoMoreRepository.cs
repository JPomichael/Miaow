using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Infrastructure.Data.Repository
{
    public class CityInfoMoreRepository :
        Miaow.Infrastructure.Data.RepositoryObject<Miaow.Infrastructure.Data.DataSys.Sys_CityInfoMore>,
        Miaow.Domain.Repository.ICityInfoMoreRepository
    {
        public CityInfoMoreRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
