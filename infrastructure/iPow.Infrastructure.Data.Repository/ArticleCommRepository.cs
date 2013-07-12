using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Data.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class ArticleCommRepository :
        iPow.Infrastructure.Data.RepositoryObject<iPow.Infrastructure.Data.DataSys.Sys_ArticleComm>,
        iPow.Domain.Repository.IArticleCommRepository
    {
        public ArticleCommRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
