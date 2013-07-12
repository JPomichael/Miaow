using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Data.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class HotelCommRepository :
        iPow.Infrastructure.Data.RepositoryObject<iPow.Infrastructure.Data.DataSys.Sys_HotelComm>,
        iPow.Domain.Repository.IHotelCommRepository
    {
        public HotelCommRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
