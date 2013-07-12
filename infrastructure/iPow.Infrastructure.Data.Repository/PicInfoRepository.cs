using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Data.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class PicInfoRepository :
        iPow.Infrastructure.Data.RepositoryObject<iPow.Infrastructure.Data.DataSys.Sys_PicInfo>,
        iPow.Domain.Repository.IPicInfoRepository
    {
        public PicInfoRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
