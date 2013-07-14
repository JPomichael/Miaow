using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Infrastructure.Data
{
    public class LoggerReopsitory :
          Miaow.Infrastructure.Data.RepositoryObject<Miaow.Infrastructure.Data.DataSys.sys_logs>,
          Miaow.Infrastructure.Crosscutting.Loggers.ILoggerReopsitory
    {
        public LoggerReopsitory(IQueryableUnitOfWork uow)
            : base(uow)
        { }
    }
}
