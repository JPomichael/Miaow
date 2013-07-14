using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Domain.Repository
{
    public interface IMvcControllerRepository :
                iPow.Domain.Infrastructure.IRepository<iPow.Infrastructure.Data.DataSys.Sys_MvcController>
    {
    }
}
