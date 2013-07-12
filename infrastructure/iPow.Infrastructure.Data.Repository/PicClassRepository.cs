using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Data.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class PicClassRepository :
        iPow.Infrastructure.Data.RepositoryObject<iPow.Infrastructure.Data.DataSys.Sys_PicClass>,
        iPow.Domain.Repository.IPicClassRepository
    {
        public PicClassRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
