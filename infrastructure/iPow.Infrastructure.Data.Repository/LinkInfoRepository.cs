using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Data.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class LinkInfoRepository :
        iPow.Infrastructure.Data.RepositoryObject<iPow.Infrastructure.Data.DataSys.Sys_LinksInfo>,
        iPow.Domain.Repository.ILinkInfoRepository
    {
        public LinkInfoRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
