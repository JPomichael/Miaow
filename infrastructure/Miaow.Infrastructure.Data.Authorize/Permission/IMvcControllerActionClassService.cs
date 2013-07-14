using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Infrastructure.Crosscutting.Authorize
{
    public interface IMvcControllerActionClassService
    {
        bool Add(Miaow.Infrastructure.Data.DataSys.Sys_MvcControllerActionClass entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        bool Add(IList<Miaow.Infrastructure.Data.DataSys.Sys_MvcControllerActionClass> entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        bool Delete(Miaow.Infrastructure.Data.DataSys.Sys_MvcControllerActionClass entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        bool Delete(IList<Miaow.Infrastructure.Data.DataSys.Sys_MvcControllerActionClass> entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        bool Delete(IList<int> idList, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        bool DeleteTrue(Miaow.Infrastructure.Data.DataSys.Sys_MvcControllerActionClass entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        bool DeleteTrue(IList<Miaow.Infrastructure.Data.DataSys.Sys_MvcControllerActionClass> entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        bool DeleteTrue(IList<int> idList, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        bool Modify(Miaow.Infrastructure.Data.DataSys.Sys_MvcControllerActionClass entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        bool Modify(IList<Miaow.Infrastructure.Data.DataSys.Sys_MvcControllerActionClass> entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        Miaow.Infrastructure.Data.DataSys.Sys_MvcControllerActionClass Get(int Id);

        IQueryable<Miaow.Infrastructure.Data.DataSys.Sys_MvcControllerActionClass> GetList();

        bool NameHasClass(string name);
    }
}
