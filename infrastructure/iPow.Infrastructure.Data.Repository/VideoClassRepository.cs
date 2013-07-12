using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Data.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class VideoClassRepository :
        iPow.Infrastructure.Data.RepositoryObject<iPow.Infrastructure.Data.DataSys.Sys_VideoClass>,
        iPow.Domain.Repository.IVideoClassRepository
    {
        public VideoClassRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
