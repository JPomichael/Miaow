using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Data.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class ArticleInfoRepository :
        iPow.Infrastructure.Data.RepositoryObject<iPow.Infrastructure.Data.DataSys.Sys_ArticleInfo>,
        iPow.Domain.Repository.IArticleInfoRepository
    {
        public ArticleInfoRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
