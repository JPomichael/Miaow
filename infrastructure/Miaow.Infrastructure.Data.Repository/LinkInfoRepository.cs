using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Infrastructure.Data.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class LinkInfoRepository :
        Miaow.Infrastructure.Data.RepositoryObject<Miaow.Infrastructure.Data.DataSys.Sys_LinksInfo>,
        Miaow.Domain.Repository.ILinkInfoRepository
    {
        public LinkInfoRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
