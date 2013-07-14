using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Infrastructure.Data.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class SearchInfoRepository :
        Miaow.Infrastructure.Data.RepositoryObject<Miaow.Infrastructure.Data.DataSys.Sys_SearchInfo>,
        Miaow.Domain.Repository.ISearchInfoRepository
    {
        public SearchInfoRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
