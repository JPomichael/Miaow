using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Data
{
    public class LoggerReopsitory :
          iPow.Infrastructure.Data.RepositoryObject<iPow.Infrastructure.Data.DataSys.Sys_AdminUserLog>,
          iPow.Infrastructure.Crosscutting.Loggers.ILoggerReopsitory
    {
        public LoggerReopsitory(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
