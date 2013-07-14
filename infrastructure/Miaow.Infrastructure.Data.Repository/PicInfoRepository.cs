using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Infrastructure.Data.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class PicInfoRepository :
        Miaow.Infrastructure.Data.RepositoryObject<Miaow.Infrastructure.Data.DataSys.Sys_PicInfo>,
        Miaow.Domain.Repository.IPicInfoRepository
    {
        public PicInfoRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
