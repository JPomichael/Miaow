using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Infrastructure.Data.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class PicClassRepository :
        Miaow.Infrastructure.Data.RepositoryObject<Miaow.Infrastructure.Data.DataSys.Sys_PicClass>,
        Miaow.Domain.Repository.IPicClassRepository
    {
        public PicClassRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
