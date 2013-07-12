using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Data.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class CityAreaCodeRepository :
        iPow.Infrastructure.Data.RepositoryObject<iPow.Infrastructure.Data.DataSys.CityAreaCode>,
        iPow.Domain.Repository.ICityAreaCodeRepository
    {
        public CityAreaCodeRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
