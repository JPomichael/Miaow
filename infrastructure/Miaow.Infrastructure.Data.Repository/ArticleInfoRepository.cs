using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Infrastructure.Data.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class ArticleInfoRepository :
        Miaow.Infrastructure.Data.RepositoryObject<Miaow.Infrastructure.Data.DataSys.Sys_ArticleInfo>,
        Miaow.Domain.Repository.IArticleInfoRepository
    {
        public ArticleInfoRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
