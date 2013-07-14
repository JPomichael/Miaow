using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Infrastructure.Data.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class VideoInfoRepository :
        Miaow.Infrastructure.Data.RepositoryObject<Miaow.Infrastructure.Data.DataSys.Sys_VideoInfo>,
        Miaow.Domain.Repository.IVideoInfoRepository
    {
        public VideoInfoRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
