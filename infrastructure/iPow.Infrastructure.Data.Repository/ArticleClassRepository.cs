using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Data.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class ArticleClassRepository :
        iPow.Infrastructure.Data.RepositoryObject<iPow.Infrastructure.Data.DataSys.Sys_ArticleClass>,
        iPow.Domain.Repository.IArticleClassRepository
    {
        public ArticleClassRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
