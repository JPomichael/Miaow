using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Crosscutting.Loggers
{
    public interface ILoggerReopsitory :
        iPow.Domain.Infrastructure.IRepository<iPow.Infrastructure.Data.DataSys.Sys_AdminUserLog>
    {
    }
}
