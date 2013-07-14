using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Infrastructure.Data.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class HotelPicRepository :
        Miaow.Infrastructure.Data.RepositoryObject<Miaow.Infrastructure.Data.DataSys.Sys_HotelPic>,
        Miaow.Domain.Repository.IHotelPicRepository
    {
        public HotelPicRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
