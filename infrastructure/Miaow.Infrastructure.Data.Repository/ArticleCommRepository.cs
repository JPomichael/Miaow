using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Infrastructure.Data.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class ArticleCommRepository :
        Miaow.Infrastructure.Data.RepositoryObject<Miaow.Infrastructure.Data.DataSys.Sys_ArticleComm>,
        Miaow.Domain.Repository.IArticleCommRepository
    {
        public ArticleCommRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
