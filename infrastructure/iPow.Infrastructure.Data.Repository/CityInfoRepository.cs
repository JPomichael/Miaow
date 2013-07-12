using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Data.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class CityInfoRepository :
        iPow.Infrastructure.Data.RepositoryObject<iPow.Infrastructure.Data.DataSys.Sys_CityInfo>,
        iPow.Domain.Repository.ICityInfoRepository
    {
        public CityInfoRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
