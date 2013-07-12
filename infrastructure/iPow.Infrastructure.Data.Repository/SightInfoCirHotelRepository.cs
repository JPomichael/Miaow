using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Data.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class SightInfoCirHotelRepository :
        iPow.Infrastructure.Data.RepositoryObject<iPow.Infrastructure.Data.DataSys.Sys_SightInfoCirHotel>,
        iPow.Domain.Repository.ISightInfoCirHotelRepository
    {
        public SightInfoCirHotelRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
