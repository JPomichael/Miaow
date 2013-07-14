using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Infrastructure.Data.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class VideoCommRepository :
        Miaow.Infrastructure.Data.RepositoryObject<Miaow.Infrastructure.Data.DataSys.Sys_VideoComm>,
        Miaow.Domain.Repository.IVideoCommRepository
    {
        public VideoCommRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
