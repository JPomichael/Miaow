using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Data
{
    public class LoggerReopsitoryFactory :
          iPow.Infrastructure.Crosscutting.Loggers.ILoggerReopsitoryFactory
    {
        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns></returns>
        public Crosscutting.Loggers.ILoggerReopsitory CreateLogger()
        {
            iPow.Infrastructure.Data.IQueryableUnitOfWork uow =
                new iPowObjectUnitOfWork();
            return new iPow.Infrastructure.Data.LoggerReopsitory(uow);
        }
    }
}
