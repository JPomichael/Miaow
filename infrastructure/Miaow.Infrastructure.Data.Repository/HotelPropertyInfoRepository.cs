using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Infrastructure.Data.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class HotelPropertyInfoRepository :
        Miaow.Infrastructure.Data.RepositoryObject<Miaow.Infrastructure.Data.DataSys.Sys_HotelPropertyInfo>,
        Miaow.Domain.Repository.IHotelPropertyInfoRepository
    {
        public HotelPropertyInfoRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
