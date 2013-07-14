using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Infrastructure.Data.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class CityInfoRepository :
        Miaow.Infrastructure.Data.RepositoryObject<Miaow.Infrastructure.Data.DataSys.Sys_CityInfo>,
        Miaow.Domain.Repository.ICityInfoRepository
    {
        public CityInfoRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
