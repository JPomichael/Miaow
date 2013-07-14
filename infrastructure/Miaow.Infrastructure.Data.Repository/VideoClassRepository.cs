using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Infrastructure.Data.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class VideoClassRepository :
        Miaow.Infrastructure.Data.RepositoryObject<Miaow.Infrastructure.Data.DataSys.Sys_VideoClass>,
        Miaow.Domain.Repository.IVideoClassRepository
    {
        public VideoClassRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
