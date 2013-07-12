using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Data.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class VideoCommRepository :
        iPow.Infrastructure.Data.RepositoryObject<iPow.Infrastructure.Data.DataSys.Sys_VideoComm>,
        iPow.Domain.Repository.IVideoCommRepository
    {
        public VideoCommRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
