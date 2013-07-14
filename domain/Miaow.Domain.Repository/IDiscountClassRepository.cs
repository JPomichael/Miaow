using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Domain.Repository
{
  public  interface IDiscountClassRepository:
         iPow.Domain.Infrastructure.IRepository<iPow.Infrastructure.Data.DataSys.Sys_DiscountClass>
    {
    }
}
