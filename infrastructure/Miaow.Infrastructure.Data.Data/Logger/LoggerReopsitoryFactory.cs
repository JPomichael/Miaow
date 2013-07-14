using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Infrastructure.Data
{
    public class LoggerReopsitoryFactory :
          Miaow.Infrastructure.Crosscutting.Loggers.ILoggerReopsitoryFactory
    {
        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns></returns>
        public Crosscutting.Loggers.ILoggerReopsitory CreateLogger()
        {
            Miaow.Infrastructure.Data.IQueryableUnitOfWork uow =
                new MiaowObjectUnitOfWork();
            return new Miaow.Infrastructure.Data.LoggerReopsitory(uow);
        }
    }
}
