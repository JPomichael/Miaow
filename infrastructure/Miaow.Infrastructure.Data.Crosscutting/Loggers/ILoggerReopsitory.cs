using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Infrastructure.Crosscutting.Loggers
{
    public interface ILoggerReopsitory :
        Miaow.Domain.Infrastructure.IRepository<Miaow.Infrastructure.Data.DataSys.sys_logs>
    {
    }
}
