using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Data.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class HotelPropertyInfoRepository :
        iPow.Infrastructure.Data.RepositoryObject<iPow.Infrastructure.Data.DataSys.Sys_HotelPropertyInfo>,
        iPow.Domain.Repository.IHotelPropertyInfoRepository
    {
        public HotelPropertyInfoRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
