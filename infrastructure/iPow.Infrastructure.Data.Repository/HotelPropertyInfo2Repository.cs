using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Data.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class HotelPropertyInfo2Repository :
        iPow.Infrastructure.Data.RepositoryObject<iPow.Infrastructure.Data.DataSys.Sys_HotelPropertyInfo2>,
        iPow.Domain.Repository.IHotelPropertyInfo2Repository
    {
        public HotelPropertyInfo2Repository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
