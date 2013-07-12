using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Data.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class HotelPicRepository :
        iPow.Infrastructure.Data.RepositoryObject<iPow.Infrastructure.Data.DataSys.Sys_HotelPic>,
        iPow.Domain.Repository.IHotelPicRepository
    {
        public HotelPicRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
