using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Infrastructure.Crosscutting.Authorize
{
    public interface IRoleService
    {
        bool Add(Miaow.Infrastructure.Data.DataSys.Sys_Roles entity, Miaow.Infrastructure.Data.DataSys.sys_administrator operUser);

        bool Add(IList<Miaow.Infrastructure.Data.DataSys.Sys_Roles> entity, Miaow.Infrastructure.Data.DataSys.sys_administrator operUser);

        bool Delete(Miaow.Infrastructure.Data.DataSys.Sys_Roles entity, Miaow.Infrastructure.Data.DataSys.sys_administrator operUser);

        bool Delete(IList<Miaow.Infrastructure.Data.DataSys.Sys_Roles> entity, Miaow.Infrastructure.Data.DataSys.sys_administrator operUser);

        bool Delete(IList<int> idList, Miaow.Infrastructure.Data.DataSys.sys_administrator operUser);

        bool DeleteTrue(Miaow.Infrastructure.Data.DataSys.Sys_Roles entity, 
            Miaow.Infrastructure.Data.DataSys.sys_administrator operUser);

        bool DeleteTrue(IList<Miaow.Infrastructure.Data.DataSys.Sys_Roles> entity, 
            Miaow.Infrastructure.Data.DataSys.sys_administrator operUser);

        bool DeleteTrue(IList<int> idList, Miaow.Infrastructure.Data.DataSys.sys_administrator operUser);

        bool Modify(Miaow.Infrastructure.Data.DataSys.Sys_Roles entity, 
            Miaow.Infrastructure.Data.DataSys.sys_administrator operUser);

        bool Modify(IList<Miaow.Infrastructure.Data.DataSys.Sys_Roles> entity,
            Miaow.Infrastructure.Data.DataSys.sys_administrator operUser);

        Miaow.Infrastructure.Data.DataSys.Sys_Roles Get(int id);

        IQueryable<Miaow.Infrastructure.Data.DataSys.Sys_Roles> GetList();

        int GetNewRoleId();
    }
}
