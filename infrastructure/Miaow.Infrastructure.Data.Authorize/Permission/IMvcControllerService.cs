using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Infrastructure.Crosscutting.Authorize
{
    public interface IMvcControllerService
    {
        bool Add(Miaow.Infrastructure.Data.DataSys.Sys_MvcController entity,Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        bool Add(IList<Miaow.Infrastructure.Data.DataSys.Sys_MvcController> entity,Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        bool Delete(Miaow.Infrastructure.Data.DataSys.Sys_MvcController entity,Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        bool Delete(IList<Miaow.Infrastructure.Data.DataSys.Sys_MvcController> entity,Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        bool Delete(IList<int> idList, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        bool DeleteTrue(Miaow.Infrastructure.Data.DataSys.Sys_MvcController entity,Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        bool DeleteTrue(IList<Miaow.Infrastructure.Data.DataSys.Sys_MvcController> entity,Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        bool DeleteTrue(IList<int> idList, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        bool Modify(Miaow.Infrastructure.Data.DataSys.Sys_MvcController entity,Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        bool Modify(IList<Miaow.Infrastructure.Data.DataSys.Sys_MvcController> entity,Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        Miaow.Infrastructure.Data.DataSys.Sys_MvcController Get(int Id);

        IQueryable<Miaow.Infrastructure.Data.DataSys.Sys_MvcController> GetList();

        Miaow.Infrastructure.Data.DataSys.Sys_MvcController GetControllerSingleById(int id);

        Miaow.Infrastructure.Crosscutting.Authorize.Dto.MvcControllerDto GetControllerSingDto(int id);

        IQueryable<Miaow.Infrastructure.Crosscutting.Authorize.Dto.MvcControllerDto> GetControllerDtoList();

        bool ClassNameAndControllerNameHasController(int classId, string name);
    }
}
