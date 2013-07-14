using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Infrastructure.Data.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class ArticleClassRepository :
        Miaow.Infrastructure.Data.RepositoryObject<Miaow.Infrastructure.Data.DataSys.Sys_ArticleClass>,
        Miaow.Domain.Repository.IArticleClassRepository
    {
        public ArticleClassRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
