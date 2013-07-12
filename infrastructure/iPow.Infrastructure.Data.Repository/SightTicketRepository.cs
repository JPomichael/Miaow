using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Data.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class SightTicketRepository :
        iPow.Infrastructure.Data.RepositoryObject<iPow.Infrastructure.Data.DataSys.Sys_SightTicket>,
        iPow.Domain.Repository.ISightTicketRepository
    {
        public SightTicketRepository(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
