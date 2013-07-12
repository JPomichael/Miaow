using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Data.Repository
{
    public class CityInfoMoreRepository :
        iPow.Infrastructure.Data.RepositoryObject<iPow.Infrastructure.Data.DataSys.Sys_CityInfoMore>,
        iPow.Domain.Repository.ICityInfoMoreRepository
    {
        public CityInfoMoreRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
