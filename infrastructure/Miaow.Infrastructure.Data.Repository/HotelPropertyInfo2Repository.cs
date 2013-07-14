using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Infrastructure.Data.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class HotelPropertyInfo2Repository :
        Miaow.Infrastructure.Data.RepositoryObject<Miaow.Infrastructure.Data.DataSys.Sys_HotelPropertyInfo2>,
        Miaow.Domain.Repository.IHotelPropertyInfo2Repository
    {
        public HotelPropertyInfo2Repository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
