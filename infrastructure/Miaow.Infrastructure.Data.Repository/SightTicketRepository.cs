using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Infrastructure.Data.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class SightTicketRepository :
        Miaow.Infrastructure.Data.RepositoryObject<Miaow.Infrastructure.Data.DataSys.Sys_SightTicket>,
        Miaow.Domain.Repository.ISightTicketRepository
    {
        public SightTicketRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
