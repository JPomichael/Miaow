using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Crosscutting.Authorize
{
    public interface IRoleService
    {
        void Add(iPow.Infrastructure.Data.DataSys.Sys_Roles role);

        void Delete(iPow.Infrastructure.Data.DataSys.Sys_Roles role);

        void Modify(iPow.Infrastructure.Data.DataSys.Sys_Roles role);

        IQueryable<iPow.Infrastructure.Data.DataSys.Sys_Roles> GetList();

        bool Delete(List<string> roleIdList);

        bool Delete(List<int> roleIdList);

        int GetNewRoleId();

        iPow.Infrastructure.Data.DataSys.Sys_Roles GetRoleById(int id);
    }
}
