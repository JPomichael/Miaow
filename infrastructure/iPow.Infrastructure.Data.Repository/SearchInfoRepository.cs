using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Data.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class SearchInfoRepository :
        iPow.Infrastructure.Data.RepositoryObject<iPow.Infrastructure.Data.DataSys.Sys_SearchInfo>,
        iPow.Domain.Repository.ISearchInfoRepository
    {
        public SearchInfoRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
