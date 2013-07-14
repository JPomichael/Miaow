using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Infrastructure.Data.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class SightInfoCirHotelRepository :
        Miaow.Infrastructure.Data.RepositoryObject<Miaow.Infrastructure.Data.DataSys.Sys_SightInfoCirHotel>,
        Miaow.Domain.Repository.ISightInfoCirHotelRepository
    {
        public SightInfoCirHotelRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
