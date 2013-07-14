using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Infrastructure.Data.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class CityAreaCodeRepository :
        Miaow.Infrastructure.Data.RepositoryObject<Miaow.Infrastructure.Data.DataSys.CityAreaCode>,
        Miaow.Domain.Repository.ICityAreaCodeRepository
    {
        public CityAreaCodeRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
